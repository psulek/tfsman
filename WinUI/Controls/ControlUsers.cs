using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

using TFSManager.Components;
using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;
using TFSManager.Properties;

using UpdateMode = TFSManager.Components.UpdateMode;

namespace TFSManager.Controls
{
    public partial class ControlUsers: UserControl
    {
        private readonly ListViewSortInfo sortInfo = new ListViewSortInfo(0, SortOrder.Ascending);
        private readonly List<Identity> backup_Selected = new List<Identity>();
        //internal readonly List<string> selectedDomains = new List<string>();
        internal int selectedDomainIndex;
        private bool blockSelectedChange = false;
        private int lastSelectedDomain = -1;
        private List<Identity> cachedUsers;
        internal bool firstTimeLoaded = false;
        int lastFindUserPosY = -1;
        //private FormMain mainForm;
        //Dictionary<string, StoredQueryCollection> sortedProjects;
        private const int USERS_COUNT_LOWER_LIMIT = 100;
        private ManualResetEvent progressChangedCompleted = new ManualResetEvent(false);

        private readonly Dictionary<string, string> workItemFields = new Dictionary<string, string>
        {
            {"Resolved By", "[Microsoft.VSTS.Common.ResolvedBy]"},
            {"Closed By", "[Microsoft.VSTS.Common.ClosedBy]"},
            {"Created By", "[System.CreatedBy]"},
            {"Activated By", "[Microsoft.VSTS.Common.ActivatedBy]"},
            {"Assigned To", "[System.AssignedTo]"},
            {"Changed By", "[System.ChangedBy]"},
            {"Subject Matter Expert 1", "[Microsoft.VSTS.CMMI.SubjectMatterExpert1]"},
            {"Subject Matter Expert 2", "[Microsoft.VSTS.CMMI.SubjectMatterExpert2]"},
            {"Subject Matter Expert 3", "[Microsoft.VSTS.CMMI.SubjectMatterExpert3]"}
        };

        private LoadingPanel loadingPanel;

        public ControlUsers()
        {
            InitializeComponent();
        }

        internal void Initialize()
        {
            //this.mainForm = mainForm;

            PopulateLocateMenus();
        }

        private void PopulateLocateMenus()
        {
            cmbLocateWorkItems.DropDownItems.Clear();
            PopulateLocateItems().ForEach(item => cmbLocateWorkItems.DropDownItems.Add(item));
            mnicmbLocateWorkItems.DropDownItems.Clear();
            PopulateLocateItems().ForEach(item => mnicmbLocateWorkItems.DropDownItems.Add(item));
        }

        private List<ToolStripItem> PopulateLocateItems()
        {
            List<ToolStripItem> result = new List<ToolStripItem>();

            result.Add(new ToolStripMenuItem {Text = "Team Project", Enabled = false});
            result.Add(new ToolStripSeparator());
            
            result.Add(new ToolStripMenuItem { Text = "All Projects", Tag = "@"});
            result.Add(new ToolStripSeparator());

            result.AddRange(PopulateTeamProjects());

            for (int i = 2; i < result.Count; i++)
            {
                ToolStripItem Item = result[i];
                if (Item is ToolStripSeparator)
                {
                    continue;
                }

                ToolStripMenuItem menuItem = Item as ToolStripMenuItem;

                List<ToolStripItem> fieldsMenuItems = PopulateFields();
                fieldsMenuItems.ForEach(fieldsMenuItem => menuItem.DropDownItems.Add(fieldsMenuItem));
            }

            return result;
        }

        private List<ToolStripItem> PopulateTeamProjects()
        {
            List<ToolStripItem> result = new List<ToolStripItem>();

            ProjectCollection projects = Context.ItemStore.Projects;
            var tempProjects = new List<Project>();
            foreach (Project project in projects)
            {
                tempProjects.Add(project);
            }
            tempProjects.Sort((x, y) => string.Compare(x.Name, y.Name));

            foreach (var project in tempProjects)
            {
                result.Add(new ToolStripMenuItem { Text = project.Name, Tag = project.Name });
            }

            return result;
        }

        private List<ToolStripItem> PopulateFields()
        {
            List<ToolStripItem> result = new List<ToolStripItem>();

            result.Add(new ToolStripMenuItem { Text = "User Assigned In Field", Enabled = false });
            result.Add(new ToolStripSeparator());
            ToolStripMenuItem anyFieldItem = new ToolStripMenuItem { Text = "Any Field", Tag = "@"};
            anyFieldItem.Click += LocateWorkItemClick;
            result.Add(anyFieldItem);
            result.Add(new ToolStripSeparator());

            foreach (var pair in this.workItemFields)
            {
                ToolStripItem menuItem = new ToolStripMenuItem(pair.Key);
                menuItem.Tag = pair.Value;
                menuItem.Click += LocateWorkItemClick;
                result.Add(menuItem);
            }

            return result;
        }

        private void UpdateControls(bool enabled)
        {
            //lvUsers.Enabled = enabled;
            menuUsers.Enabled = enabled;
            foreach (ToolStripItem stripItem in toolStrip.Items)
            {
                stripItem.Enabled = enabled;
            }
        }

        private void LocateWorkItemClick(object sender, EventArgs args)
        {
            ToolStripItem itm = sender as ToolStripItem;
            string fieldName = itm.Tag as string;
            string teamProject = itm.OwnerItem.Tag as string;

            LocateWorkItemsForUser(teamProject, fieldName);
        }

        private void LocateWorkItemsForUser(string teamProject, string fieldName)
        {
            ListViewItem focusedItem = this.lvUsers.FocusedItem;
            if (focusedItem == null)
            {
                return;
            }

            string userDisplayName = focusedItem.SubItems[1].Text;

            StringBuilder fieldWhere = new StringBuilder();
            StringBuilder fieldColumns = new StringBuilder();
            string teamProjectWhere = string.Empty;

            HighlightFilter hightligths = new HighlightFilter();

            if (fieldName == "@")
            {
                foreach (var workItemFieldName in this.workItemFields.Values)
                {
                    fieldWhere.AppendFormat("{0} = '{1}' OR ", workItemFieldName, userDisplayName);
                    fieldColumns.AppendFormat("{0} ,", workItemFieldName);

                    hightligths.Add(workItemFieldName.Replace("[", "").Replace("]", ""), 
                        new HighlightCondition(userDisplayName, Color.Green));
                }
                fieldWhere = fieldWhere.Remove(fieldWhere.Length - 3, 3);
                fieldColumns = fieldColumns.Remove(fieldColumns.Length - 1, 1);
            }
            else
            {
                fieldColumns.Append(fieldName);
                fieldWhere.AppendFormat("{0} = '{1}'", fieldName, userDisplayName);
                hightligths.Add(fieldName.Replace("[", "").Replace("]", ""), 
                    new HighlightCondition(userDisplayName, Color.Green));
            }

            if (teamProject != "@")
            {
                teamProjectWhere = string.Format("AND [System.TeamProject] = '{0}'", teamProject);
                hightligths.Add("System.TeamProject", new HighlightCondition(teamProject, Color.Green));
            }

            string query = string.Format(
                @"SELECT [System.Id], [System.Title], [System.TeamProject], {0} FROM WorkItems 
WHERE {1} {2}
ORDER BY [System.TeamProject] ASC, [System.Id] DESC",
                fieldColumns, fieldWhere, teamProjectWhere);

            UIContext.Instance.ControlWorkItems.FindRelatedWorkItems(teamProject, query, hightligths);
            //this.mainForm.controlWorkItems.FindRelatedWorkItems(teamProject, query, hightligths);
        }

        private void lvUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.ColumnHeaderCollection columns = this.lvUsers.Columns;
            ColumnHeader column = columns[e.Column];

            object sd = column.Tag;
            SortOrder sortOrder;
            if (sd == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortOrder = (SortOrder) sd;
                if (sortOrder == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }
            }

            if (this.sortInfo.Index > -1)
            {
                columns[this.sortInfo.Index].ImageIndex = -1;
            }

            column.Tag = sortOrder;
            column.ImageIndex = sortOrder == SortOrder.Ascending ? 0 : 1;
            this.sortInfo.Index = e.Column;
            this.sortInfo.Order = sortOrder;

            SortListData();
            PopulateUsers(false, false);
        }

        private void RestoreSelectedItems()
        {
            this.lvUsers.SelectedItems.Clear();
            SelectUsers(this.backup_Selected);
        }

        private void BackupSelectedItems()
        {
            this.backup_Selected.Clear();

            foreach (ListViewItem viewItem in this.lvUsers.SelectedItems)
            {
                this.backup_Selected.Add(viewItem.Tag as Identity);
            }
        }

        private void SelectUser(Identity user)
        {
            SelectUsers(new List<Identity> {user});
        }

        private void SelectUsers(List<Identity> usersToSelect)
        {
            SelectUsers(identity =>
            {
                int index = usersToSelect.FindIndex(userToSelect =>
                {
                    return userToSelect.AccountName == identity.AccountName && userToSelect.Domain == identity.Domain;
                });

                return index > -1;
            }, false);

            #region old

            //            ListViewItem topItem = null;
            //
            //            foreach (ListViewItem viewItem in this.lvUsers.Items)
            //            {
            //                var itemUser = viewItem.Tag as Identity;
            //
            //                ListViewItem item = viewItem;
            //                usersToSelect.ForEach(user =>
            //                {
            //                    if (user.AccountName == itemUser.AccountName && user.Domain == itemUser.Domain)
            //                    {
            //                        if (topItem == null || item.Position.Y < topItem.Position.Y)
            //                        {
            //                            topItem = item;
            //                        }
            //                        item.Selected = true;
            //                        //item.Focused = true;
            //                    }
            //                });
            //            }
            //
            //            if (topItem != null)
            //            {
            //                topItem.Focused = true;
            //                topItem.EnsureVisible();
            //            }

            #endregion
        }

        private void SelectUsers(string accountName, string sid)
        {
            ListViewItem foundUser = SelectUsers(identity =>
            {
                if (accountName != null)
                {
                    return Util.StrContain(identity.AccountName, accountName, true);
                }

                return Util.StrEqual(identity.Sid, sid, true);
            }, true, this.lastFindUserPosY);

            this.lastFindUserPosY = foundUser != null ? foundUser.Position.Y : -1;
        }

        private ListViewItem SelectUsers(Predicate<Identity> match, bool simpleFind)
        {
            return SelectUsers(match, simpleFind, -1);
        }

        private ListViewItem SelectUsers(Predicate<Identity> match, bool simpleFind, int startFromPosY)
        {
            ListViewItem topItem = null;
            List<ListViewItem> matchItems = new List<ListViewItem>();

            foreach (ListViewItem viewItem in this.lvUsers.Items)
            {
                var itemUser = viewItem.Tag as Identity;
                ListViewItem item = viewItem;

                if (match(itemUser))
                {
//                    if (startFromPosY > -1 && viewItem.Position.Y <= startFromPosY)
//                    {
//                        continue;
//                    }

//                    if (topItem == null || item.Position.Y < topItem.Position.Y)
//                    {
//                        topItem = item;
//                    }
//                    item.Selected = true;
                    
                    matchItems.Add(item);
                }

                #region old

                //                if (match(itemUser))
                //                {
                //                    if (startFromPosY > -1 && viewItem.Position.Y <= startFromPosY)
                //                    {
                //                        continue;
                //                    }
                //
                //                    if (topItem == null || item.Position.Y < topItem.Position.Y)
                //                    {
                //                        topItem = item;
                //                    }
                //                    item.Selected = true;
                //                    if (simpleFind)
                //                    {
                //                        break;
                //                    }
                //                }

                #endregion
            }

            matchItems.Sort((item1, item2) => item1.Position.Y - item2.Position.Y);

            if (matchItems.Count > 0)
            {
                matchItems.ForEach(matchItem =>
                {
                    if (!simpleFind || topItem == null)
                    {
                        if (startFromPosY <= -1 || matchItem.Position.Y > startFromPosY)
                        {
                            if (topItem == null || matchItem.Position.Y < topItem.Position.Y)
                            {
                                topItem = matchItem;
                            }
                            matchItem.Selected = true;
                        }
                    }
                });
            }

            if (topItem != null)
            {
                topItem.Focused = true;
                topItem.EnsureVisible();
            }

            return topItem;
        }

        #region old PopulateUsers

        /*
        internal void PopulateUsers(bool refresh, bool resort)
        {
            this.lvUsers.BeginUpdate();

            try
            {
                BackupSelectedItems();

                if (refresh)
                {
                    this.cachedUsers = null;
                }

                if (this.cachedUsers == null)
                {
                    UpdateControls(false, true);
                    workerReadIdentities.RunWorkerAsync();

                    Identity everyOneGroup = Context.SecurityService.ReadIdentity(SearchFactor.EveryoneApplicationGroup, 
                        null, QueryMembership.Direct);
                    int usersCount = everyOneGroup.Members.Length;
                    UIContext.Instance.ProgressBegin(usersCount, 1);

                    try
                    {
                        this.cachedUsers = new List<Identity>();
                        this.lvUsers.Groups.Clear();

                        List<string> domains = new List<string>();

                        Identity[] allIdentities = Context.SecurityService.ReadIdentities(SearchFactor.Sid,
                            everyOneGroup.Members,
                            QueryMembership.None);

                        string selectedDomain = cmbDomains.SelectedItem as string;

                        foreach (Identity identity in allIdentities)
                        {
                            if (identity != null && identity.Type == IdentityType.WindowsUser)
                            {
                                if (!domains.Contains(identity.Domain))
                                {
                                    domains.Add(identity.Domain);
                                }

                                if (selectedDomainIndex == 0 || Util.StrEqual(identity.Domain, selectedDomain, true))
                                {
                                    this.cachedUsers.Add(identity);
                                    this.lvUsers.Groups.Add(identity.Domain, identity.Domain);
                                }
                            }

                            UIContext.Instance.ProgressDoStep();
                        }

                        blockSelectedChange = true;
                        try
                        {
                            cmbDomains.Items.Clear();
                            cmbDomains.Items.Add(string.Empty);
                            domains.ForEach(domain => cmbDomains.Items.Add(domain));

                            cmbDomains.SelectedIndex = selectedDomainIndex;
                        }
                        finally
                        {
                            blockSelectedChange = false;
                        }
                    }
                    finally
                    {
                        UIContext.Instance.ProgressEnd();
                    }
                }

                if (resort)
                {
                    SortListData();
                }

                this.lvUsers.Visible = true;
                this.lvUsers.Items.Clear();
                UIContext.Instance.ProgressBegin(this.cachedUsers.Count, 1);
                this.cachedUsers.ForEach(user =>
                {
                    ListViewItem viewItem = this.lvUsers.Items.Add(user.AccountName);
                    viewItem.ImageIndex = 0;
                    viewItem.Tag = user;
                    viewItem.SubItems.Add(user.DisplayName);
                    viewItem.SubItems.Add(user.Sid);
                    viewItem.SubItems.Add(user.MailAddress);
                    viewItem.SubItems.Add(user.Description);
                    viewItem.Group = this.lvUsers.Groups[user.Domain];

                    UIContext.Instance.ProgressDoStep();
                });
            }
            finally
            {
                this.lvUsers.EndUpdate();
                UIContext.Instance.ProgressEnd();
                RestoreSelectedItems();

                if (!firstTimeLoaded)
                {
                    firstTimeLoaded = true;
                }
            }
        }
*/

        #endregion old PopulateUsers

        internal void PopulateUsers(bool refresh, bool resort)
        {
            this.lvUsers.BeginUpdate();

            try
            {
                BackupSelectedItems();

                if (refresh)
                {
                    this.cachedUsers = null;
                }

                this.lvUsers.Visible = true;
                this.lvUsers.Items.Clear();

                if (this.cachedUsers == null)
                {
                    if (!workerReadIdentities.IsBusy && !workerReadIdentities.CancellationPending)
                    {
                        UpdateControls(false);

                        if (loadingPanel == null)
                        {
                            loadingPanel = LoadingPanel.Create(new LoadingPanelSettings
                                {
                                    Message = "Loading users...",
                                    OwnerControl = this.panelWorkingArea,
                                    OnCancelAction = CancelLoadingUsers,
                                    ProgressEnabled = true
                                });
                        }
                        else
                        {
                            loadingPanel.NotifyStart("Loading users...");
                        }
                        workerReadIdentities.RunWorkerAsync();
                        return;
                    }

                    #region old

                    //                    Identity everyOneGroup = Context.SecurityService.ReadIdentity(SearchFactor.EveryoneApplicationGroup,
                    //                        null, QueryMembership.Direct);
                    //                    int usersCount = everyOneGroup.Members.Length;
                    //                    UIContext.Instance.ProgressBegin(usersCount, 1);
                    //
                    //                    try
                    //                    {
                    //                        this.cachedUsers = new List<Identity>();
                    //                        this.lvUsers.Groups.Clear();
                    //
                    //                        List<string> domains = new List<string>();
                    //
                    //                        Identity[] allIdentities = Context.SecurityService.ReadIdentities(SearchFactor.Sid,
                    //                            everyOneGroup.Members,
                    //                            QueryMembership.None);
                    //
                    //                        string selectedDomain = cmbDomains.SelectedItem as string;
                    //
                    //                        foreach (Identity identity in allIdentities)
                    //                        {
                    //                            if (identity != null && identity.Type == IdentityType.WindowsUser)
                    //                            {
                    //                                if (!domains.Contains(identity.Domain))
                    //                                {
                    //                                    domains.Add(identity.Domain);
                    //                                }
                    //
                    //                                if (selectedDomainIndex == 0 || Util.StrEqual(identity.Domain, selectedDomain, true))
                    //                                {
                    //                                    this.cachedUsers.Add(identity);
                    //                                    this.lvUsers.Groups.Add(identity.Domain, identity.Domain);
                    //                                }
                    //                            }
                    //
                    //                            UIContext.Instance.ProgressDoStep();
                    //                        }
                    //
                    //                        blockSelectedChange = true;
                    //                        try
                    //                        {
                    //                            cmbDomains.Items.Clear();
                    //                            cmbDomains.Items.Add(string.Empty);
                    //                            domains.ForEach(domain => cmbDomains.Items.Add(domain));
                    //
                    //                            cmbDomains.SelectedIndex = selectedDomainIndex;
                    //                        }
                    //                        finally
                    //                        {
                    //                            blockSelectedChange = false;
                    //                        }
                    //                    }
                    //                    finally
                    //                    {
                    //                        UIContext.Instance.ProgressEnd();
                    //                    }

                    #endregion old
                }

                if (resort)
                {
                    SortListData();
                }

                UIContext.Instance.ProgressBegin(this.cachedUsers.Count, 1);
                this.cachedUsers.ForEach(user =>
                {
                    ListViewItem viewItem = this.lvUsers.Items.Add(user.AccountName);
                    viewItem.ImageIndex = 0;
                    viewItem.Tag = user;
                    viewItem.SubItems.Add(user.DisplayName);
                    viewItem.SubItems.Add(user.Sid);
                    viewItem.SubItems.Add(user.MailAddress);
                    viewItem.SubItems.Add(user.Description);
                    viewItem.Group = this.lvUsers.Groups[user.Domain];

                    UIContext.Instance.ProgressDoStep();
                });
            }
            finally
            {
                this.lvUsers.EndUpdate();
                UIContext.Instance.ProgressEnd();
                RestoreSelectedItems();

                if (!firstTimeLoaded)
                {
                    firstTimeLoaded = true;
                }
            }
        }

        private void SortListData()
        {
            if (this.cachedUsers == null)
            {
                return;
            }

            this.cachedUsers.Sort((x, y) =>
            {
                int compared;

                if (this.sortInfo.Index == 0) // Account name
                {
                    compared = string.CompareOrdinal(x.AccountName, y.AccountName);
                }
                else //if (this.sortInfo.Index == 1) // Display Name
                {
                    compared = string.CompareOrdinal(x.DisplayName, y.DisplayName);
                }

                if (this.sortInfo.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                return compared;
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateUsers(true, true);
        }

        private void CancelLoadingUsers()
        {
            if (this.workerReadIdentities.IsBusy && !this.workerReadIdentities.CancellationPending)
            {
                UIContext.Instance.LogMessage(new IconListEntry(Resources.Information, "Cancel was hit by user to stop loading of users, waiting for cancel operation..."));
                this.workerReadIdentities.CancelAsync();
            }
        }

        private void cmbDomains_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SynchroDomainText(sender, e);
            }
        }

        private void SynchroDomainText(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbDomains.Text))
            {
                int idx = this.cmbDomains.FindStringExact(this.cmbDomains.Text);
                if (idx > -1)
                {
                    this.cmbDomains.Text = this.cmbDomains.Items[idx] as string;
                }
                else
                {
                    this.cmbDomains.SelectedIndex = this.lastSelectedDomain;
                }
            }
        }

        private void cmbDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedDomainIndex = this.cmbDomains.SelectedIndex;

            if (this.blockSelectedChange)
            {
                return;
            }

            PopulateUsers(true, true);
        }

        private void FindUserBy(object sender, EventArgs e)
        {
            ToolStripItem btn = sender as ToolStripItem;
            string action = btn.Tag as string;

            string ident = action == "0" ? "name" : "SID";
            string ident2 = action == "0" ? ":" : " (full sid):";
            string findValue = string.Empty;
            if (FormEditBox.DialogShow("Find user by " + ident, "User " + ident + ident2, "Find", Resources.file_find,
                true, false, (o,args) =>
                {
                    string accountName = action == "0" ? args.Value : null;
                    string userSID = action == "1" ? args.Value : null;
                    lvUsers.SelectedItems.Clear();
                    SelectUsers(accountName, userSID);
                },
                ref findValue) != DialogResult.OK)
            {
                return;
            }
        }

        private void lvUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                this.lastFindUserPosY = e.Item.Position.Y;
            }
        }

        private void workerReadIdentities_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            UIContext.Instance.LogMessage(new IconListEntry(UIContext.Instance.GetLogImage(LogImage.Info),"Loading users..."));

            this.Invoke(new Action(() =>
                {

                    this.lvUsers.Groups.Clear();
                    blockSelectedChange = true;
                    try
                    {
                        cmbDomains.Items.Clear();
                    }
                    finally
                    {
                        blockSelectedChange = false;
                    }
                }));
            
            this.cachedUsers = new List<Identity>();

            Identity everyOneGroup = Context.SecurityService.ReadIdentity(SearchFactor.EveryoneApplicationGroup,
                        null, QueryMembership.Expanded);
            int usersCount = everyOneGroup.Members.Length;

            UIContext.Instance.LogMessage(new IconListEntry(UIContext.Instance.GetLogImage(LogImage.Info), 
                string.Format("Loaded identity group '{0}' with assigned '{1}' members", everyOneGroup.AccountName, usersCount)));

            UIContext.Instance.LogMessage(new IconListEntry(UIContext.Instance.GetLogImage(LogImage.Info),
                string.Format("Starting to load '{0}' identities...", usersCount)));

            int chunkLastStep = 0;
            int chunkCount = 1;
            int maxCount = usersCount;
            if (usersCount > USERS_COUNT_LOWER_LIMIT)
            {
                maxCount = USERS_COUNT_LOWER_LIMIT;
                chunkCount = usersCount / USERS_COUNT_LOWER_LIMIT;
                chunkLastStep = usersCount - (chunkCount * USERS_COUNT_LOWER_LIMIT);
                if (chunkLastStep < 0)
                {
                    chunkLastStep = 0;
                }
            }

            loadingPanel.ProgressInitialize(usersCount, 0, 0);


            //UIContext.Instance.ProgressBegin(usersCount, maxCount);

            int currentProgress = 0;

            Func<Tuple<int, int, EventWaitHandle>, bool> loadIdentitiesFunc = tuple =>
                {
                    int startIdx = tuple.Item1;
                    int maxcnt = tuple.Item2;
                    EventWaitHandle ev = tuple.Item3;
                    string[] filter = new string[maxcnt];
                    Array.Copy(everyOneGroup.Members, startIdx, filter, 0, maxcnt);
                    Identity[] loadedIdentities = Context.SecurityService.ReadIdentities(SearchFactor.Sid, filter, QueryMembership.None);
                    currentProgress += filter.Length;

                    if (ev != null)
                    {
                        ev.Reset();
                    }

                    workerReadIdentities.ReportProgress(currentProgress, Tuple.Create(startIdx, loadedIdentities, ev));

                    return EnsureCancel(e);
                };

            bool loadingCancelled = false;

            for (int i = 0; i < chunkCount; i++)
            {
                EventWaitHandle ev = null;

                if (chunkLastStep <= 0)
                {
                    ev = progressChangedCompleted;
                }

                loadingCancelled = loadIdentitiesFunc(Tuple.Create(i * maxCount, maxCount, ev));
                if (loadingCancelled)
                {
                    break;
                }
            }

            if (chunkLastStep > 0 && !loadingCancelled)
            {
                loadIdentitiesFunc(Tuple.Create(chunkCount * USERS_COUNT_LOWER_LIMIT, chunkLastStep, (EventWaitHandle)progressChangedCompleted));
            }

            progressChangedCompleted.WaitOne();
        }

        private bool EnsureCancel(System.ComponentModel.DoWorkEventArgs e)
        {
            if (workerReadIdentities.CancellationPending)
            {
                e.Cancel = true;
                UIContext.Instance.LogMessage(new IconListEntry( 
                    UIContext.Instance.GetLogImage(LogImage.Warning),
                    "Cancelled loading of users, requested by user"));
            }

            return e.Cancel;
        }

        private void workerReadIdentities_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            UIContext.Instance.ProgressDoStep();
            var state = (Tuple<int, Identity[], EventWaitHandle>)e.UserState;
            int startIdx = state.Item1;
            Identity[] loadedIdentities = state.Item2;
            EventWaitHandle ev = state.Item3;

            List<string> domains = new List<string>();

            string selectedDomain = cmbDomains.SelectedItem as string;

            int oldCount = this.cachedUsers.Count;

            foreach (Identity identity in loadedIdentities)
            {
                if (identity != null && identity.Type == IdentityType.WindowsUser)
                {
                    if (!domains.Contains(identity.Domain))
                    {
                        domains.Add(identity.Domain);
                    }

                    if (selectedDomainIndex == 0 || Util.StrEqual(identity.Domain, selectedDomain, true))
                    {
                        this.cachedUsers.Add(identity);
                        this.Invoke(new Action(() => this.lvUsers.Groups.Add(identity.Domain, identity.Domain)));
                    }
                }

                //UIContext.Instance.ProgressDoStep();
            }

            loadingPanel.ProgressUpdateValue(loadedIdentities.Length, UpdateMode.IncrementCurrent);

            this.Invoke(new Action(() =>
                {
                    PopulateUsers(false, true);

                    blockSelectedChange = true;
                    try
                    {
                        cmbDomains.Items.AddRange(domains.ToArray());
                        cmbDomains.SelectedIndex = selectedDomainIndex;
                    }
                    catch(Exception ex)
                    {
                        string message = ex.Message;
                    }
                    finally
                    {
                        blockSelectedChange = false;
                    }

                    int addedUsers = this.cachedUsers.Count - oldCount;
                    int filteredCount = loadedIdentities.Length - addedUsers;
                    if (addedUsers > 0)
                    {
                        UIContext.Instance.LogMessage(new IconListEntry(Resources.Information,
                            string.Format("Loaded next {0} users, filtered out {1} users (not windows users) / Current total count of loaded users: {2}", 
                            addedUsers, filteredCount, cachedUsers.Count)));
                    }
                    else if (filteredCount > 0)
                    {
                        UIContext.Instance.LogMessage(new IconListEntry(Resources.Information,
                            string.Format("Loading of users filtered out {0} users (not windows users) / Current total count of loaded users: {1}",
                            filteredCount, cachedUsers.Count)));
                    }
                }));

            BackgroundWorker worker = (sender as BackgroundWorker);
            if (ev == null && (worker.CancellationPending || !worker.IsBusy))
            {
                ev = progressChangedCompleted;
            }

            if (ev != null)
            {
                ev.Set();
            }
        }

        private void workerReadIdentities_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //UIContext.Instance.ProgressEnd();
            //progressChangedCompleted.WaitOne();
            UpdateControls(true);

            if (loadingPanel != null)
            {
                loadingPanel.NotifyCompleted(e.Cancelled ? "Loading of users was cancelled" : "Loading of users was successfull",
                    e.Cancelled ? Resources.Warning : Resources.Information);
            }

            if (cachedUsers.Count > 0)
            {
                UIContext.Instance.LogMessage(new IconListEntry(Resources.Information, string.Format("Loading of users completed, there was loaded {0} users.", cachedUsers.Count)));
            }
        }
    }
}