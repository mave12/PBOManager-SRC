using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using PBOManager.Properties;
using PBOOperations;

namespace PBOManager
{
	public class PBOM_Signature : Form
	{
		private PBOFile _ActivePboFile;

		private byte[] _Checksum;

		private IContainer components;

		private TabControl PBOM_Prp_Tab;

		private TabPage PBOM_Prp_Tab_Checksum;

		private Button PBOM_Prp_BtnApply;

		private Button PBOM_Prp_BtnCancel;

		private ContextMenuStrip PBOM_Cs_Context;

		private ToolStripMenuItem PBOM_Cs_ContextGenerate;

		private ToolStripMenuItem PBOM_Cs_ContextClear;

		private RichTextBox PBOM_Prp_CS;

		public byte[] Checksum => _Checksum;

		public PBOM_Signature(PBOFile Archive)
			: this()
		{
			InitializeComponent();
			PBOM_Localization.LocalizeForm((Form)(object)this);
			string text;
			((Control)this).set_Text(text = PBOM_Localization.LocalizeString(Resources.PBOM_Signature, "PBOM_Signature"));
			((Control)this).set_Text(text);
			_ActivePboFile = Archive;
		}

		private void PBOM_Properties_Load(object sender, EventArgs e)
		{
			Proc_InitForm();
		}

		private void PBOM_Cs_BtnApply_Click(object sender, EventArgs e)
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Invalid comparison between Unknown and I4
			if (Proc_CheckChanges())
			{
				((Form)this).set_DialogResult((DialogResult)2);
				return;
			}
			if (_ActivePboFile.get_PBOContents().get_Checksum() == null)
			{
				((Form)this).set_DialogResult((DialogResult)1);
				return;
			}
			string text = PBOM_Localization.LocalizeString(Resources.PBOM_DigitalSignatureText, "PBOM_DigitalSignatureText");
			string text2 = PBOM_Localization.LocalizeString(Resources.PBOM_DigitalSignatureCaption, "PBOM_DigitalSignatureCaption");
			DialogResult val = MessageBox.Show(text, text2, (MessageBoxButtons)1, (MessageBoxIcon)32);
			if ((int)val == 1)
			{
				((Form)this).set_DialogResult((DialogResult)1);
			}
		}

		private void PBOM_Cs_BtnCancel_Click(object sender, EventArgs e)
		{
			((Form)this).set_DialogResult((DialogResult)2);
		}

		private void PBOM_Prp_Context_Opening(object sender, CancelEventArgs e)
		{
			if (((Control)PBOM_Prp_CS).get_Text().Length > 0)
			{
				((ToolStripItem)PBOM_Cs_ContextGenerate).set_Enabled(false);
				((ToolStripItem)PBOM_Cs_ContextClear).set_Enabled(true);
			}
			else
			{
				((ToolStripItem)PBOM_Cs_ContextGenerate).set_Enabled(true);
				((ToolStripItem)PBOM_Cs_ContextClear).set_Enabled(false);
			}
		}

		private void PBOM_Prp_ContextGenerate_Click(object sender, EventArgs e)
		{
			_Checksum = _ActivePboFile.GenerateShaKey();
			string text = "";
			if (_Checksum != null)
			{
				byte[] checksum = _Checksum;
				foreach (byte b in checksum)
				{
					text = string.Format("{1} {0}", text, b.ToString("X2"));
				}
			}
			((Control)PBOM_Prp_CS).set_Text(text);
		}

		private void PBOM_Prp_ContextClear_Click(object sender, EventArgs e)
		{
			_Checksum = new byte[0];
			((Control)PBOM_Prp_CS).set_Text("");
		}

		private void Proc_InitForm()
		{
			byte[] checksum = _ActivePboFile.get_PBOContents().get_Checksum();
			string text = "";
			if (checksum != null)
			{
				byte[] array = checksum;
				foreach (byte b in array)
				{
					text = string.Format("{1} {0}", text, b.ToString("X2"));
				}
			}
			((Control)PBOM_Prp_CS).set_Text(text);
		}

		private bool Proc_CheckChanges()
		{
			byte[] checksum = _ActivePboFile.get_PBOContents().get_Checksum();
			if (_Checksum == null)
			{
				return true;
			}
			if (checksum != null)
			{
				if (_Checksum.Length != checksum.Length)
				{
					return false;
				}
				for (short num = 0; num < _Checksum.Length; num = (short)(num + 1))
				{
					if (_Checksum[num] != checksum[num])
					{
						return false;
					}
				}
			}
			else if (_Checksum != null)
			{
				return false;
			}
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				((IDisposable)components).Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Expected O, but got Unknown
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			components = (IContainer)new Container();
			ComponentResourceManager val = new ComponentResourceManager(typeof(PBOM_Signature));
			PBOM_Prp_Tab = new TabControl();
			PBOM_Prp_Tab_Checksum = new TabPage();
			PBOM_Prp_CS = new RichTextBox();
			PBOM_Cs_Context = new ContextMenuStrip(components);
			PBOM_Cs_ContextGenerate = new ToolStripMenuItem();
			PBOM_Cs_ContextClear = new ToolStripMenuItem();
			PBOM_Prp_BtnApply = new Button();
			PBOM_Prp_BtnCancel = new Button();
			((Control)PBOM_Prp_Tab).SuspendLayout();
			((Control)PBOM_Prp_Tab_Checksum).SuspendLayout();
			((Control)PBOM_Cs_Context).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)PBOM_Prp_Tab).get_Controls().Add((Control)(object)PBOM_Prp_Tab_Checksum);
			((Control)PBOM_Prp_Tab).set_Dock((DockStyle)1);
			((Control)PBOM_Prp_Tab).set_Location(new Point(0, 0));
			((Control)PBOM_Prp_Tab).set_Name("PBOM_Prp_Tab");
			PBOM_Prp_Tab.set_SelectedIndex(0);
			((Control)PBOM_Prp_Tab).set_Size(new Size(303, 176));
			((Control)PBOM_Prp_Tab).set_TabIndex(0);
			((Control)PBOM_Prp_Tab_Checksum).set_BackColor(SystemColors.get_Control());
			((Control)PBOM_Prp_Tab_Checksum).get_Controls().Add((Control)(object)PBOM_Prp_CS);
			PBOM_Prp_Tab_Checksum.set_Location(new Point(4, 22));
			((Control)PBOM_Prp_Tab_Checksum).set_Name("PBOM_Prp_Tab_Checksum");
			((Control)PBOM_Prp_Tab_Checksum).set_Padding(new Padding(3));
			((Control)PBOM_Prp_Tab_Checksum).set_Size(new Size(295, 150));
			PBOM_Prp_Tab_Checksum.set_TabIndex(1);
			((Control)PBOM_Prp_Tab_Checksum).set_Text("Checksum");
			((Control)PBOM_Prp_CS).set_BackColor(SystemColors.get_Control());
			((Control)PBOM_Prp_CS).set_ContextMenuStrip(PBOM_Cs_Context);
			((Control)PBOM_Prp_CS).set_Dock((DockStyle)5);
			((Control)PBOM_Prp_CS).set_Location(new Point(3, 3));
			((Control)PBOM_Prp_CS).set_Name("PBOM_Prp_CS");
			((TextBoxBase)PBOM_Prp_CS).set_ReadOnly(true);
			PBOM_Prp_CS.set_ScrollBars((RichTextBoxScrollBars)2);
			((Control)PBOM_Prp_CS).set_Size(new Size(289, 144));
			((Control)PBOM_Prp_CS).set_TabIndex(0);
			((Control)PBOM_Prp_CS).set_Text("");
			((ToolStrip)PBOM_Cs_Context).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[2]
			{
				(ToolStripItem)PBOM_Cs_ContextGenerate,
				(ToolStripItem)PBOM_Cs_ContextClear
			});
			((Control)PBOM_Cs_Context).set_Name("PBOM_Prp_Context");
			((Control)PBOM_Cs_Context).set_Size(new Size(153, 70));
			((ToolStripDropDown)PBOM_Cs_Context).add_Opening(new CancelEventHandler(PBOM_Prp_Context_Opening));
			((ToolStripItem)PBOM_Cs_ContextGenerate).set_Image((Image)(object)Resources.add16);
			((ToolStripItem)PBOM_Cs_ContextGenerate).set_Name("PBOM_Cs_ContextGenerate");
			((ToolStripItem)PBOM_Cs_ContextGenerate).set_Size(new Size(152, 22));
			((ToolStripItem)PBOM_Cs_ContextGenerate).set_Text("Generate");
			((ToolStripItem)PBOM_Cs_ContextGenerate).add_Click((EventHandler)PBOM_Prp_ContextGenerate_Click);
			((ToolStripItem)PBOM_Cs_ContextClear).set_Image((Image)((ResourceManager)(object)val).GetObject("PBOM_Cs_ContextClear.Image"));
			((ToolStripItem)PBOM_Cs_ContextClear).set_Name("PBOM_Cs_ContextClear");
			((ToolStripItem)PBOM_Cs_ContextClear).set_Size(new Size(152, 22));
			((ToolStripItem)PBOM_Cs_ContextClear).set_Text("Clear");
			((ToolStripItem)PBOM_Cs_ContextClear).add_Click((EventHandler)PBOM_Prp_ContextClear_Click);
			((Control)PBOM_Prp_BtnApply).set_Location(new Point(70, 182));
			((Control)PBOM_Prp_BtnApply).set_Name("PBOM_Prp_BtnApply");
			((Control)PBOM_Prp_BtnApply).set_Size(new Size(75, 23));
			((Control)PBOM_Prp_BtnApply).set_TabIndex(1);
			((Control)PBOM_Prp_BtnApply).set_Text("Apply");
			((ButtonBase)PBOM_Prp_BtnApply).set_UseVisualStyleBackColor(true);
			((Control)PBOM_Prp_BtnApply).add_Click((EventHandler)PBOM_Cs_BtnApply_Click);
			PBOM_Prp_BtnCancel.set_DialogResult((DialogResult)2);
			((Control)PBOM_Prp_BtnCancel).set_Location(new Point(163, 182));
			((Control)PBOM_Prp_BtnCancel).set_Name("PBOM_Prp_BtnCancel");
			((Control)PBOM_Prp_BtnCancel).set_Size(new Size(75, 23));
			((Control)PBOM_Prp_BtnCancel).set_TabIndex(2);
			((Control)PBOM_Prp_BtnCancel).set_Text("Cancel");
			((ButtonBase)PBOM_Prp_BtnCancel).set_UseVisualStyleBackColor(true);
			((Control)PBOM_Prp_BtnCancel).add_Click((EventHandler)PBOM_Cs_BtnCancel_Click);
			((Form)this).set_AcceptButton((IButtonControl)(object)PBOM_Prp_BtnApply);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_CancelButton((IButtonControl)(object)PBOM_Prp_BtnCancel);
			((Form)this).set_ClientSize(new Size(303, 217));
			((Control)this).get_Controls().Add((Control)(object)PBOM_Prp_BtnCancel);
			((Control)this).get_Controls().Add((Control)(object)PBOM_Prp_BtnApply);
			((Control)this).get_Controls().Add((Control)(object)PBOM_Prp_Tab);
			((Form)this).set_FormBorderStyle((FormBorderStyle)3);
			((Form)this).set_MaximizeBox(false);
			((Form)this).set_MinimizeBox(false);
			((Control)this).set_Name("PBOM_Signature");
			((Form)this).set_ShowIcon(false);
			((Form)this).set_ShowInTaskbar(false);
			((Form)this).set_StartPosition((FormStartPosition)4);
			((Control)this).set_Text("PBO Checksum");
			((Form)this).add_Load((EventHandler)PBOM_Properties_Load);
			((Control)PBOM_Prp_Tab).ResumeLayout(false);
			((Control)PBOM_Prp_Tab_Checksum).ResumeLayout(false);
			((Control)PBOM_Cs_Context).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
		}
	}
}
