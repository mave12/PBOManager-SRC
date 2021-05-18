using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PBOManager
{
	internal class PBOM_Settings
	{
		private string _XmlFile = "Settings.xml";

		private bool _IsActive;

		private PBOM_Explorer _MainForm;

		private PBOM_Xml _XmlConfig;

		private XmlSerializer _Serializer;

		public PBOM_Explorer MainForm
		{
			get
			{
				return _MainForm;
			}
			set
			{
				if (_IsActive)
				{
					Detach();
				}
				_MainForm = value;
			}
		}

		public bool IsActive => _IsActive;

		public PBOM_Settings()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			string text = Application.get_StartupPath();
			if (text[text.Length - 1] != '\\')
			{
				text = $"{text}\\";
			}
			_XmlFile = $"{text}{_XmlFile}";
			_Serializer = new XmlSerializer(typeof(PBOM_Xml));
		}

		public PBOM_Settings(PBOM_Explorer MainForm)
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			if (text[text.Length - 1] != '\\')
			{
				text = $"{text}\\";
			}
			text = $"{text}PboM\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			_XmlFile = $"{text}{_XmlFile}";
			_Serializer = new XmlSerializer(typeof(PBOM_Xml));
			_MainForm = MainForm;
		}

		public void Attach()
		{
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			if (_MainForm == null)
			{
				throw new Exception("\"MainForm\" member should be specified before calling \"Attach()\" method");
			}
			if (_IsActive)
			{
				return;
			}
			_IsActive = true;
			_MainForm.OnWindowStateChanged += _MainForm_OnWindowStateChanged;
			((Form)_MainForm).add_ResizeEnd((EventHandler)_MainForm_ResizeEnd);
			((Control)_MainForm).add_Move((EventHandler)_MainForm_Move);
			_XmlConfig = new PBOM_Xml();
			if (File.Exists(_XmlFile))
			{
				try
				{
					FileStream fileStream = new FileStream(_XmlFile, FileMode.Open, FileAccess.Read);
					_XmlConfig = (PBOM_Xml)_Serializer.Deserialize((Stream)fileStream);
					fileStream.Close();
					((Form)_MainForm).set_Size(new Size(_XmlConfig.W, _XmlConfig.H));
					((Form)_MainForm).set_Location(new Point(_XmlConfig.X, _XmlConfig.Y));
					((Form)_MainForm).set_WindowState(_XmlConfig.State);
				}
				catch
				{
					File.Delete(_XmlFile);
				}
			}
			else
			{
				PBOM_Xml xmlConfig = _XmlConfig;
				Size size = ((Form)_MainForm).get_Size();
				xmlConfig.H = ((Size)(ref size)).get_Height();
				PBOM_Xml xmlConfig2 = _XmlConfig;
				Size size2 = ((Form)_MainForm).get_Size();
				xmlConfig2.W = ((Size)(ref size2)).get_Width();
				PBOM_Xml xmlConfig3 = _XmlConfig;
				Point location = ((Form)_MainForm).get_Location();
				xmlConfig3.X = ((Point)(ref location)).get_X();
				PBOM_Xml xmlConfig4 = _XmlConfig;
				Point location2 = ((Form)_MainForm).get_Location();
				xmlConfig4.Y = ((Point)(ref location2)).get_Y();
				_XmlConfig.State = ((Form)_MainForm).get_WindowState();
			}
		}

		public void Detach()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Invalid comparison between Unknown and I4
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			if (_MainForm == null)
			{
				throw new Exception("\"MainForm\" member should be specified before calling \"Detach()\" method");
			}
			if (_IsActive)
			{
				_IsActive = false;
				_MainForm.OnWindowStateChanged -= _MainForm_OnWindowStateChanged;
				((Form)_MainForm).remove_ResizeEnd((EventHandler)_MainForm_ResizeEnd);
				((Control)_MainForm).remove_Move((EventHandler)_MainForm_Move);
				_XmlConfig.State = (((int)((Form)_MainForm).get_WindowState() == 1) ? _XmlConfig.State : ((Form)_MainForm).get_WindowState());
				FileStream fileStream = new FileStream(_XmlFile, FileMode.Create, FileAccess.Write);
				_Serializer.Serialize((Stream)fileStream, (object)_XmlConfig);
				fileStream.Close();
			}
		}

		private void _MainForm_OnWindowStateChanged(object sender, PBOM_FormStateChangeEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_XmlConfig.State = e.WindowState;
		}

		private void _MainForm_Move(object sender, EventArgs e)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			if ((int)((Form)_MainForm).get_WindowState() == 0)
			{
				PBOM_Xml xmlConfig = _XmlConfig;
				Point location = ((Form)_MainForm).get_Location();
				xmlConfig.X = ((Point)(ref location)).get_X();
				PBOM_Xml xmlConfig2 = _XmlConfig;
				Point location2 = ((Form)_MainForm).get_Location();
				xmlConfig2.Y = ((Point)(ref location2)).get_Y();
			}
		}

		private void _MainForm_ResizeEnd(object sender, EventArgs e)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			PBOM_Xml xmlConfig = _XmlConfig;
			Size size = ((Form)_MainForm).get_Size();
			xmlConfig.H = ((Size)(ref size)).get_Height();
			PBOM_Xml xmlConfig2 = _XmlConfig;
			Size size2 = ((Form)_MainForm).get_Size();
			xmlConfig2.W = ((Size)(ref size2)).get_Width();
		}
	}
}
