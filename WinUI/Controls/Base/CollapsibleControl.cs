using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TFSManager.Controls
{
    public partial class CollapsibleControl: UserControl
    {
        private int _cControlCounter = 0;
        private List<CollapsibleControlSection> SectionList;

        public CollapsibleControl()
        {
            InitializeComponent();
            this.SectionList = new List<CollapsibleControlSection>();

            Resize += (sender, args) =>
            {
                foreach (Control control in this.flowLayoutPanel1.Controls)
                {
                    control.Width = Width;
                }
            };
        }

        public void AddSection(CollapsibleControlSection newSection)
        {
            this.SectionList.Add(newSection);
            // Add a new row. 
            var header = new ListHeader();
            header.Text = newSection.SectionName;
            header.Width = Width;
            header.ListHeaderStateChanged += header_ListHeaderStateChanged;

            if (newSection.HeaderExtControl != null)
            {
                header.Controls.Add(newSection.HeaderExtControl);
                newSection.HeaderExtControl.BringToFront();
            }

            this.flowLayoutPanel1.Controls.Add(header);
            // Get the position of the control the application will add, so that it can show 
            // and hide it when needed.
            header.Tag = "CollapsibleControl" + this._cControlCounter;
            this._cControlCounter++;

            Control c = newSection.SectionControl;
            c.Width = Width;
            c.Name = header.Tag.ToString();
            this.flowLayoutPanel1.Controls.Add(c);
        }

        // Handle the change in the list. 
        private void header_ListHeaderStateChanged(object sender, ListHeaderStateChangedEventArgs e)
        {
            var header = (ListHeader) sender;
            Control c = this.flowLayoutPanel1.Controls[(string) header.Tag];

            if (e.State == ListHeaderState.Collapsed)
            {
                c.Hide();
            }
            else
            {
                c.Show();
            }
        }

        public void TestHidingControl()
        {
            this.flowLayoutPanel1.Controls[1].Hide();
        }

        public void TestShowingControl()
        {
            this.flowLayoutPanel1.Controls[1].Show();
        }
    }

    public class CollapsibleControlSection: Object
    {
        private Control _control = null;
        private Control _headerExtControl = null;
        private string _sectionName = null;

        public CollapsibleControlSection(string sectionName, Control control)
            : this(sectionName, control, null) {}

        public CollapsibleControlSection(string sectionName, Control control,
            Control headerExtControl)
        {
            this._sectionName = sectionName;
            this._control = control;
            this._headerExtControl = headerExtControl;
        }

        public string SectionName
        {
            get
            {
                return (this._sectionName);
            }
            set
            {
                this._sectionName = value;
            }
        }

        public Control SectionControl
        {
            get
            {
                return (this._control);
            }
            set
            {
                this._control = value;
            }
        }

        public Control HeaderExtControl
        {
            get
            {
                return this._headerExtControl;
            }
            set
            {
                this._headerExtControl = value;
            }
        }
    }
}