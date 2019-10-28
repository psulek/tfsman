using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TFSManager.Core.WinForms.Controls
{
    public abstract class AsyncWorkControl
    {
        #region fields

        protected AsyncWorkControlArgs workArguments;

        protected Thread thread;

        protected readonly Control visualControl;

        private bool isBusy = false;
        private bool cancellationPending = false;
        private readonly object syncObj = new object();
        private readonly object syncReportProgress = new object();
        private System.Windows.Forms.Timer reportProgressTimer;
        private readonly Queue<ProgressChangedEventArgs> reportProgressCache = new Queue<ProgressChangedEventArgs>();

//        private bool processingCancelled = false;

        #endregion fields

        #region abstract properties and methods

        protected abstract XPLinkLabel ControlActionButton { get; }

        protected abstract PictureBox ControlLoadingGif { get; }

        protected abstract ProgressBar ControlProgressBar { get; }

        protected abstract Label ControlMessageLabel { get; }

        protected abstract Image GetProgressImage(WorkProgressPhase progressPhase);

        protected abstract Image GetActionButtonImage(ButtonType buttonType);

        protected abstract string InternalGetMessageText(WorkProgressPhase progressPhase);

        #endregion abstract properties and methods

        #region constructor

        protected AsyncWorkControl(Control visualControl)
        {
            this.visualControl = visualControl;
        }


        #endregion constructor


        #region initialize

        public void Initialize<T>(T args) where T : AsyncWorkControlArgs
        {
            this.workArguments = args;

            this.visualControl.Name = Guid.NewGuid().ToString();
            this.visualControl.Visible = false;
            //this.workArguments.OwnerControl.Controls.Add(this.visualControl);
            this.visualControl.Dock = DockStyle.Top;


            this.reportProgressTimer = new System.Windows.Forms.Timer(this.workArguments.OwnerControl.Container);
            this.reportProgressTimer.Enabled = false;
            this.reportProgressTimer.Interval = 100;
            this.reportProgressTimer.Tick += ReportProgressTimerOnTick;

            this.Initialize();
        }


        protected abstract void Initialize();

        #endregion initialize

        #region other methods

        protected string GetMessageText(WorkProgressPhase progressPhase)
        {
            string result = InternalGetMessageText(progressPhase);

            if (result == null && progressPhase == WorkProgressPhase.Running)
            {
                result = workArguments.WorkMessage;
            }

            return result;
        }

        protected void InvokeSynchronizedAction(Action action)
        {
            if (action == null) return;

            if (visualControl.InvokeRequired)
            {
                visualControl.Invoke(action, new object[0]);
                return;
            }

            action.SafeInvokeAction();
        }

        private void StartThread(object startArgument)
        {
            if (thread == null)
            {
                thread = new Thread(RunningProc)
                    {
                        Name = this.workArguments.WorkMessage
                    };
            }

            if (thread.ThreadState != ThreadState.Unstarted)
            {
                thread.Join();
            }

            //ProcessingCancelled = false;

            thread.Start(startArgument);
        }

        private void RunningProc(object startArgument)
        {
            Exception doWorkException = null;

            DoWorkEventArgs args = new DoWorkEventArgs(startArgument);
            try
            {
                IsBusy = true;

                this.workArguments.OnDoWork.SafeInvokeAction(this, args);
            }
            catch (Exception e)
            {
                doWorkException = e;
            }

            WaitForReportProgressCompletition(30 * 1000);

            RunWorkerCompletedEventArgs args2 = new RunWorkerCompletedEventArgs(args.Result, doWorkException, args.Cancel);
            try
            {
                this.workArguments.OnWorkCompleted.SafeInvokeAction(this, args2);
            }
            finally
            {
                IsBusy = false;
                CancellationPending = false;
            }
        }

        private void WaitForReportProgressCompletition(int timeout)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(timeout);

            bool timeouted = false;
            while(!IsReportProgressCacheEmpty && !timeouted)
            {
                timeouted = DateTime.Now >= endTime;
                Thread.Sleep(100);
            }
        }

        private bool IsReportProgressCacheEmpty
        {
            get
            {
                lock (syncReportProgress)
                {
                    return this.reportProgressCache.Count == 0;
                }
            }
        }

        private void ReportProgressTimerOnTick(object sender, EventArgs eventArgs)
        {
            //reportProgressTimer.Enabled = false;

            ProgressChangedEventArgs args = null;
            lock (syncReportProgress)
            {
                if (this.reportProgressCache.Count > 0)
                {
                    args = this.reportProgressCache.Dequeue();
                }
            }

            try
            {
                if (args != null)
                {
                    this.workArguments.OnProgressChanged.SafeInvokeAction(this, args);
                }
            }
            finally
            {
                //                if (!IsReportProgressCacheEmpty)
                //                {
                //                    reportProgressTimer.Enabled = true;
                //                }
            }
        }

        public void ReportProgress(int percentProgress)
        {
            ReportProgress(percentProgress, null);
        }

        public void ReportProgress(int percentProgress, object userState)
        {
            ProgressChangedEventArgs args = new ProgressChangedEventArgs(percentProgress, userState);

            Action action = () =>
                {
                    lock (syncReportProgress)
                    {
                        reportProgressCache.Enqueue(args);

                        if (!reportProgressTimer.Enabled)
                        {
                            reportProgressTimer.Enabled = true;
                        }
                    }
                };

            InvokeSynchronizedAction(action);
        }

        public void CancelAsync()
        {
            lock (syncObj)
            {
                if (IsBusy && !CancellationPending)
                {
                    CancellationPending = true;
                    //ProcessingCancelled = true;
                }
            }
        }

        public void HardAbort()
        {
            reportProgressTimer.Enabled = false;

            if (thread != null)
            {
                thread.Abort();
            }
        }

        //        public bool ProcessingCancelled
        //        {
        //            get
        //            {
        //                lock(syncObj)
        //                {
        //                    return processingCancelled;
        //                }
        //            }
        //            private set
        //            {
        //                lock (syncObj)
        //                {
        //                    processingCancelled = value;
        //                }
        //            }
        //        }

        public bool CancellationPending
        {
            get
            {
                lock (syncObj)
                {
                    return this.cancellationPending;
                }
            }
            private set
            {
                lock (syncObj)
                {
                    this.cancellationPending = value;
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                lock(syncObj)
                {
                    return this.isBusy;
                }
            }
            private set
            {
                lock (syncObj)
                {
                    this.isBusy = value;
                }
            }
        }

        #endregion other methods

        #region start section

        public void Start()
        {
            Start(null);
        }

        public void Start(object startArgument)
        {
            Start(startArgument, false, 0, 0);
        }

        public void Start(bool progressEnabled, int progressMaximum)
        {
            Start(null, progressEnabled, progressMaximum);
        }

        public void Start(object startArgument, bool progressEnabled, int progressMaximum)
        {
            Start(startArgument, progressEnabled, progressMaximum, 1);
        }

        public void Start(object startArgument, bool progressEnabled, int progressMaximum, int progressStep)
        {
            visualControl.Visible = true;

            ActionButtonUpdate(WorkProgressPhase.Running);
            ProgressUpdateVisibility(progressEnabled);

            if (progressEnabled)
            {
                ProgressInitialize(progressMaximum, progressStep, 0);
            }

            Control[] controls = this.workArguments.OwnerControl.Controls.Find(this.visualControl.Name, true);
            if (controls.Length == 0)
            {
                this.workArguments.OwnerControl.Controls.Add(this.visualControl);
            }

            StartThread(startArgument);
        }

        #endregion start section

        #region action button section

        protected void ActionButtonUpdate(WorkProgressPhase progressPhase)
        {
            ActionButtonUpdate(progressPhase, true);
        }

        protected void ActionButtonUpdate(WorkProgressPhase progressPhase, bool actionButtonEnabled)
        {
            Action action = () =>
                {
                    ControlMessageLabel.Text = GetMessageText(progressPhase);

                    ControlActionButton.Text = progressPhase == WorkProgressPhase.Running ? "[Cancel]" : "[Hide]";
                    ControlActionButton.Tag = progressPhase;
                    ControlActionButton.Image = progressPhase == WorkProgressPhase.Running
                        ? GetActionButtonImage(ButtonType.Cancel)
                        : GetActionButtonImage(ButtonType.Hide);
                    ControlActionButton.Enabled = actionButtonEnabled;

                    ControlLoadingGif.Image = GetProgressImage(progressPhase);
                };

            InvokeSynchronizedAction(action);
        }

        #endregion action button section

        #region update work message text section

        public void UpdateWorkMessage(string message)
        {
            Action action = () =>
                {
                    this.ControlMessageLabel.Text = message;
                };

            InvokeSynchronizedAction(action);
        }

        #endregion update work message text section

        #region progress section

        public void ProgressInitialize(int maximum, int step, int currentValue)
        {
            if (ControlProgressBar == null) return;

            Action action = () =>
                {
                    ControlProgressBar.Maximum = maximum;
                    ControlProgressBar.Step = step;
                    ControlProgressBar.Value = currentValue;
                };

            InvokeSynchronizedAction(action);
        }

        public void ProgressUpdateVisibility(bool visible)
        {
            if (ControlProgressBar == null) return;

            Action action = () =>
                {
                    bool allowedChange = ControlProgressBar.Visible != visible;
                    if (allowedChange)
                    {
                        allowedChange = !visible || this.workArguments.ProgressEnabled;

                        if (allowedChange)
                        {
                            ControlProgressBar.Visible = true;
                            this.workArguments.OnUpdateProgressVisibility.SafeInvokeAction(this);
                        }
                    }
                };

            InvokeSynchronizedAction(action);
        }

        public void ProgressUpdateValue(int value, UpdateProgressMode mode)
        {
            if (ControlProgressBar == null) return;

            Action action = () =>
                {
                    ProgressUpdateVisibility(true);
                    if (mode == UpdateProgressMode.IncrementCurrent)
                    {
                        value += ControlProgressBar.Value;
                    }
                    
                    ControlProgressBar.Value = value;
                };

            InvokeSynchronizedAction(action);
        }

        public void ProgressPerformStep()
        {
            if (ControlProgressBar == null) return;

            Action action = () =>
                {
                    ProgressUpdateVisibility(true);
                    ControlProgressBar.PerformStep();
                };

            InvokeSynchronizedAction(action);
        }

        #endregion progress section

        #region enum UpdateProgressMode

        public enum UpdateProgressMode
        {
            DirectSet,
            IncrementCurrent
        }

        #endregion enum UpdateProgressMode

        #region enum WorkProgressPhase

        public enum WorkProgressPhase
        {
            Running,
            CompletedWithFailure,
            CompletedWithSuccess
        }

        #endregion enum WorkProgressPhase

        #region enum ButtonType

        public enum ButtonType
        {
            Cancel,
            Hide
        }

        #endregion enum ButtonType
    }

    #region class AsyncWorkControlArgs

    public class AsyncWorkControlArgs
    {
        public Control OwnerControl { get; set; }

        public string WorkMessage { get; set; }

        public bool ProgressEnabled { get; set; }

        public AsyncWorkAction OnCancel { get; set; }

        public AsyncWorkAction OnUpdateProgressVisibility { get; set; }

        public AsyncWorkEventHandler<DoWorkEventArgs> OnDoWork { get; set; }

        public AsyncWorkEventHandler<ProgressChangedEventArgs> OnProgressChanged { get; set; }

        public AsyncWorkEventHandler<RunWorkerCompletedEventArgs> OnWorkCompleted { get; set; }
    }

    #endregion class AsyncWorkControlArgs

    #region delegates

    public delegate void AsyncWorkAction(AsyncWorkControl workControl);

    public delegate void AsyncWorkEventHandler<TEventArgs>(AsyncWorkControl workControl, TEventArgs e) where TEventArgs : EventArgs;

    #endregion delegates
}