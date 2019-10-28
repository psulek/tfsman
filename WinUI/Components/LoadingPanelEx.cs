using System;
using System.Drawing;
using System.Windows.Forms;

using TFSManager.Core;
using TFSManager.Core.WinForms.Controls;
using TFSManager.Properties;

namespace TFSManager.Components
{
    public partial class LoadingPanelEx : UserControl
    {
        #region class LoadingPanelAsyncWork

        private class LoadingPanelAsyncWork : AsyncWorkControl
        {
            public LoadingPanelAsyncWork(LoadingPanelEx visualControl) : base(visualControl) { }

            private new LoadingPanelEx visualControl
            {
                get
                {
                    return (LoadingPanelEx) base.visualControl;
                }
            }

            protected override XPLinkLabel ControlActionButton
            {
                get { return visualControl.linkAction; }
            }

            protected override PictureBox ControlLoadingGif
            {
                get { return visualControl.imgLoading; }
            }

            protected override ProgressBar ControlProgressBar
            {
                get { return this.visualControl.progressBar; }
            }

            protected override Label ControlMessageLabel
            {
                get { return visualControl.lbMessage; }
            }

            protected override Image GetProgressImage(WorkProgressPhase progressPhase)
            {
                switch(progressPhase)
                {
                    case WorkProgressPhase.Running:
                        return Resources.loading_circle_03;
                    case WorkProgressPhase.CompletedWithFailure:
                        return Resources.Error;
                    case WorkProgressPhase.CompletedWithSuccess:
                        return Resources.Information;
                    default:
                        return Resources.Information;
                }
            }

            protected override Image GetActionButtonImage(ButtonType buttonType)
            {
                if (buttonType == ButtonType.Cancel)
                {
                    return Resources.Cancel;
                }

                return Resources.Empty;
            }

            protected override string InternalGetMessageText(WorkProgressPhase progressPhase)
            {
                return null;
            }

            protected override void Initialize() {}
        }

        #endregion class LoadingPanelAsyncWork

        public LoadingPanelEx()
        {
            InitializeComponent();
        }

//        private Control ownerControl;
//        private Action onCancelAction;
//        private Image finalImage;
//        private LoadingPanelSettings loadingPanelSettings;
        private LoadingPanelAsyncWork asyncWork;

        private void Initialize(AsyncWorkControlArgs args)
        {
            this.asyncWork = new LoadingPanelAsyncWork(this);
            this.asyncWork.Initialize(args);
        }

        public static LoadingPanelEx Create(AsyncWorkControlArgs args)
        {
            LoadingPanelEx panel = new LoadingPanelEx();
            panel.Initialize(args);
//            panel.loadingPanelSettings = loadingPanelSettings;
//            panel.Name = Guid.NewGuid().ToString();
//            panel.lbMessage.Text = loadingPanelSettings.Message;
//            panel.UpdateActionButton(true);
//            panel.ownerControl = loadingPanelSettings.OwnerControl;
//            panel.onCancelAction = loadingPanelSettings.OnCancelAction;
//            panel.finalImage = Resources.Information;
            //panel.progressBar.Visible = loadingPanelSettings.ProgressEnabled;
//            panel.progressBar.Maximum = loadingPanelSettings.ProgressMaximum;
//            panel.progressBar.Step = loadingPanelSettings.ProgressStep;
//            panel.progressBar.Value = 0;
//
//            loadingPanelSettings.OwnerControl.Controls.Add(panel);
//            panel.Dock = DockStyle.Top;

            return panel;
        }

//        public void DoActionHide()
//        {
//            Control[] controls = this.panel1.Parent.Controls.Find(this.Name, true);
//            if (controls.Length > 0)
//            {
//                this.panel1.Parent.Controls.Remove(controls[0]);
//            }
//        }

//        public void NotifyStart(string message)
//        {
//            UpdateActionButton(true);
//            lbMessage.Text = message;
//            this.progressBar.Value = 0;
//
//            Control[] controls = this.panel1.Parent.Controls.Find(this.Name, true);
//            if (controls.Length > 0)
//            {
//                this.Visible = true;
//            }
//            else
//            {
//                ownerControl.Controls.Add(this);
//                this.Visible = true;
//            }
//        }

        public void NotifyCompleted()
        {
            NotifyCompleted(null);
        }

        public void NotifyCompleted(Image finalImage)
        {
            NotifyCompleted(null, finalImage);
        }

        public void NotifyCompleted(string message, Image finalImage)
        {
            Action action = () =>
                {
                    if (message != null)
                    {
                        lbMessage.Text = message;
                    }

                    if (finalImage != null)
                    {
                        //this.finalImage = finalImage;
                    }

                    ProgressHide();

                    UpdateActionButton(false);
                };

            InvokeAction(action);
        }

        public void ProgressPerformStep()
        {
            Action action = () =>
                {
                    EnsureProgressVisible();
                    progressBar.PerformStep();
                };

            InvokeAction(action);
        }

        public void ProgressUpdateValue(int value, UpdateMode mode)
        {
            Action action = () =>
                {
                    EnsureProgressVisible();
                    if (mode == UpdateMode.IncrementCurrent)
                    {
                        value += progressBar.Value;
                    }
                    progressBar.Value = value;
                };

            InvokeAction(action);
        }

        private void ProgressHide()
        {
            this.progressBar.Visible = false;
            this.Size = new Size(this.Width, 36);
        }

        private void EnsureProgressVisible()
        {
//            Action action = () =>
//                {
//                    if (!progressBar.Visible && loadingPanelSettings.ProgressEnabled)
//                    {
//                        progressBar.Visible = true;
//                        this.Size = new Size(this.Width, 52);
//                    }
//                };
//
//            InvokeAction(action);
        }

        public void ProgressInitialize(int maximum, int step, int currentValue)
        {
            Action action = () =>
                {
                    this.progressBar.Maximum = maximum;
                    this.progressBar.Step = step;
                    this.progressBar.Value = currentValue;
                };
            
            InvokeAction(action);
        }

        private void InvokeAction(Action action) 
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
                return;
            }

            action();
        }

        private void UpdateActionButton(bool cancelButton)
        {
            linkAction.Text = cancelButton ? "[Cancel]" : "[Hide]";
            linkAction.Tag = cancelButton ? "0" : "1";
            linkAction.Image = cancelButton ? Resources.Cancel : Resources.Empty;
            linkAction.Enabled = true;

            //imgLoading.Image = cancelButton ? Resources.loading_circle_03 : this.finalImage;
        }

        private void linkAction_Click(object sender, EventArgs e)
        {
            string action = (sender as XPLinkLabel).Tag as string;

            if (action == "0") // cancel
            {
                lbMessage.Text = "Cancelling...";
                linkAction.Enabled = false;
                //UpdateActionButton(false);

//                if (onCancelAction != null)
//                {
//                    try
//                    {
//                        onCancelAction();
//                    }
//                    catch (Exception ex)
//                    {
//                        UIContext.Instance.HandleError(ex);
//                    }
//                }
            }
            else // hide
            {
                this.Visible = false;
            }
        }
    }
}
