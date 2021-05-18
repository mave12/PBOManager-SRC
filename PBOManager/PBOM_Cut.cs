using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_Cut : IDisposable
	{
		public delegate void PBOMFileDeleted(object sender, PBOM_DropNodeEventArgs e);

		private bool _Disposed;

		private bool _IsActive;

		private bool _AutoStartOnCutNodesAssign = true;

		private bool _AutoShutDown = true;

		private string _TempStoragePath;

		private Hashtable _CutNodes;

		private FileSystemWatcher _TempStorageWatcher;

		private Form _MainForm;

		public string TempStoragePath
		{
			get
			{
				return _TempStoragePath;
			}
			set
			{
				_TempStoragePath = value;
			}
		}

		public Hashtable CutNodes
		{
			get
			{
				return _CutNodes;
			}
			set
			{
				_CutNodes = value;
				if (_AutoStartOnCutNodesAssign)
				{
					Open();
				}
			}
		}

		public bool AutoStartOnCutNodesAssign
		{
			get
			{
				return _AutoStartOnCutNodesAssign;
			}
			set
			{
				_AutoStartOnCutNodesAssign = value;
			}
		}

		public bool AutoShutDown
		{
			get
			{
				return _AutoShutDown;
			}
			set
			{
				_AutoShutDown = value;
			}
		}

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

		public event PBOMFileDeleted OnFileDeleted;

		public PBOM_Cut()
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			_TempStorageWatcher = new FileSystemWatcher();
			_TempStorageWatcher.set_Filter("*.*");
			_TempStorageWatcher.set_NotifyFilter((NotifyFilters)3);
			_TempStorageWatcher.set_IncludeSubdirectories(true);
			_TempStorageWatcher.add_Deleted(new FileSystemEventHandler(PBOM_Cut_Deleted));
		}

		public PBOM_Cut(Form MainForm)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			_MainForm = MainForm;
			_TempStorageWatcher = new FileSystemWatcher();
			_TempStorageWatcher.set_Filter("*.*");
			_TempStorageWatcher.set_NotifyFilter((NotifyFilters)3);
			_TempStorageWatcher.set_IncludeSubdirectories(true);
			_TempStorageWatcher.add_Deleted(new FileSystemEventHandler(PBOM_Cut_Deleted));
		}

		public void Dispose()
		{
			Dispose(Disposing: true);
		}

		protected virtual void Dispose(bool Disposing)
		{
			if (!_Disposed && Disposing)
			{
				_Disposed = true;
				((Component)_TempStorageWatcher).Dispose();
			}
		}

		private void PBOM_Cut_Deleted(object sender, FileSystemEventArgs e)
		{
			try
			{
				PBOM_DropNodeEventArgs pBOM_DropNodeEventArgs = new PBOM_DropNodeEventArgs(_CutNodes);
				if (this.OnFileDeleted != null && _MainForm != null)
				{
					((Control)_MainForm).Invoke((Delegate)this.OnFileDeleted, new object[2]
					{
						this,
						pBOM_DropNodeEventArgs
					});
				}
				if (_AutoShutDown)
				{
					Close();
				}
			}
			catch
			{
			}
		}

		public void Open()
		{
			if (!_IsActive)
			{
				_IsActive = true;
				_TempStorageWatcher.set_Path(_TempStoragePath);
				_TempStorageWatcher.set_EnableRaisingEvents(true);
			}
		}

		public void Close()
		{
			if (_IsActive)
			{
				_IsActive = false;
				_TempStorageWatcher.set_EnableRaisingEvents(false);
			}
		}
	}
}
