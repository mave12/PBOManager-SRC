using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_WorkInProgress
	{
		private delegate void dFormClose();

		private delegate void dFormProgress(int Progress, int Maximum);

		private bool _IsShown;

		private Thread _Progress;

		private Form _MainForm;

		private PBOM_Progress _ProgressForm;

		public Form MainForm
		{
			get
			{
				return _MainForm;
			}
			set
			{
				_MainForm = value;
			}
		}

		public bool IsShown => _IsShown;

		public PBOM_WorkInProgress()
		{
			_Progress = new Thread(new ThreadStart(Proc_ProgressWindowThread));
			_Progress.Priority = ThreadPriority.Lowest;
			_Progress.IsBackground = true;
		}

		public PBOM_WorkInProgress(Form MainForm)
		{
			_MainForm = MainForm;
		}

		public void Show()
		{
			if (!_IsShown)
			{
				_IsShown = true;
				try
				{
					_Progress = new Thread(new ThreadStart(Proc_ProgressWindowThread));
					_Progress.Priority = ThreadPriority.Lowest;
					_Progress.IsBackground = true;
					_Progress.Start();
				}
				catch
				{
				}
				if (_MainForm != null)
				{
					((Control)_MainForm).set_Enabled(false);
				}
			}
		}

		public void Hide()
		{
			if (_IsShown)
			{
				_IsShown = false;
				((Control)_ProgressForm).Invoke((Delegate)new dFormClose(((Component)_ProgressForm).Dispose));
				if (_MainForm != null)
				{
					((Control)_MainForm).set_Enabled(true);
					((Control)_MainForm).Focus();
					((Control)_MainForm).BringToFront();
				}
			}
		}

		public void SetProgress(int Progress, int Maximum)
		{
			if (_IsShown)
			{
				((Control)_ProgressForm).Invoke((Delegate)new dFormProgress(_ProgressForm.SetProgress), new object[2]
				{
					Progress,
					Maximum
				});
			}
		}

		private void Proc_ProgressWindowThread()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			_ProgressForm = new PBOM_Progress(_MainForm);
			((Form)_ProgressForm).ShowDialog();
		}
	}
}
