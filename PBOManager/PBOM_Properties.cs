using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using PBOManager.Properties;
using PBOOperations;

namespace PBOManager
{
	public class PBOM_Properties : Form
	{
		private IContainer components;

		private Button PBOM_Prp_BtnApply;

		private Button PBOM_Prp_BtnCancel;

		private ContextMenuStrip PBOM_Prp_Context;

		private ToolStripMenuItem PBOM_Prp_ContextAdd;

		private ToolStripMenuItem PBOM_Prp_ContextRemove;

		private ToolStripSeparator PBOM_Prp_ContextSep1;

		private ToolStripMenuItem PBOM_Prp_ContextUp;

		private ToolStripMenuItem PBOM_Prp_ContextDown;

		private TabPage PBOM_Prp_Tab_Properties;

		private DataGridView PBOM_Prp_DG;

		private DataGridViewTextBoxColumn cProperty;

		private DataGridViewTextBoxColumn cValue;

		private TabControl PBOM_Prp_Tab;

		private PBOFile _ActivePboFile;

		public List<PBOFileProperty> HeaderProperties
		{
			get
			{
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Expected O, but got Unknown
				//IL_0077: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Expected O, but got Unknown
				List<PBOFileProperty> list = new List<PBOFileProperty>();
				foreach (DataGridViewRow item2 in (IEnumerable)PBOM_Prp_DG.get_Rows())
				{
					DataGridViewRow val = item2;
					if (val.get_Cells().get_Item(0).get_Value() != null && val.get_Cells().get_Item(1).get_Value() != null)
					{
						PBOFileProperty item = new PBOFileProperty(val.get_Cells().get_Item(0).get_Value()
							.ToString(), val.get_Cells().get_Item(1).get_Value()
							.ToString());
						list.Add(item);
					}
				}
				return list;
			}
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
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0429: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0591: Unknown result type (might be due to invalid IL or missing references)
			//IL_0605: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_070b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0738: Unknown result type (might be due to invalid IL or missing references)
			//IL_0760: Unknown result type (might be due to invalid IL or missing references)
			components = (IContainer)new Container();
			ComponentResourceManager val = new ComponentResourceManager(typeof(PBOM_Properties));
			DataGridViewCellStyle val2 = new DataGridViewCellStyle();
			PBOM_Prp_Context = new ContextMenuStrip(components);
			PBOM_Prp_ContextAdd = new ToolStripMenuItem();
			PBOM_Prp_ContextRemove = new ToolStripMenuItem();
			PBOM_Prp_ContextSep1 = new ToolStripSeparator();
			PBOM_Prp_ContextUp = new ToolStripMenuItem();
			PBOM_Prp_ContextDown = new ToolStripMenuItem();
			PBOM_Prp_BtnApply = new Button();
			PBOM_Prp_BtnCancel = new Button();
			PBOM_Prp_Tab_Properties = new TabPage();
			PBOM_Prp_DG = new DataGridView();
			cValue = new DataGridViewTextBoxColumn();
			cProperty = new DataGridViewTextBoxColumn();
			PBOM_Prp_Tab = new TabControl();
			((Control)PBOM_Prp_Context).SuspendLayout();
			((Control)PBOM_Prp_Tab_Properties).SuspendLayout();
			((ISupportInitialize)PBOM_Prp_DG).BeginInit();
			((Control)PBOM_Prp_Tab).SuspendLayout();
			((Control)this).SuspendLayout();
			((ToolStrip)PBOM_Prp_Context).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[5]
			{
				(ToolStripItem)PBOM_Prp_ContextAdd,
				(ToolStripItem)PBOM_Prp_ContextRemove,
				(ToolStripItem)PBOM_Prp_ContextSep1,
				(ToolStripItem)PBOM_Prp_ContextUp,
				(ToolStripItem)PBOM_Prp_ContextDown
			});
			((Control)PBOM_Prp_Context).set_Name("PBOM_Prp_Context");
			((Control)PBOM_Prp_Context).set_Size(new Size(138, 98));
			((ToolStripDropDown)PBOM_Prp_Context).add_Opening(new CancelEventHandler(PBOM_Prp_Context_Opening));
			((ToolStripItem)PBOM_Prp_ContextAdd).set_Image((Image)(object)Resources.add16);
			((ToolStripItem)PBOM_Prp_ContextAdd).set_Name("PBOM_Prp_ContextAdd");
			((ToolStripItem)PBOM_Prp_ContextAdd).set_Size(new Size(137, 22));
			((ToolStripItem)PBOM_Prp_ContextAdd).set_Text("Add");
			((ToolStripItem)PBOM_Prp_ContextAdd).add_Click((EventHandler)PBOM_Prp_ContextAdd_Click);
			((ToolStripItem)PBOM_Prp_ContextRemove).set_Enabled(false);
			((ToolStripItem)PBOM_Prp_ContextRemove).set_Image((Image)((ResourceManager)(object)val).GetObject("PBOM_Prp_ContextRemove.Image"));
			((ToolStripItem)PBOM_Prp_ContextRemove).set_Name("PBOM_Prp_ContextRemove");
			((ToolStripItem)PBOM_Prp_ContextRemove).set_Size(new Size(137, 22));
			((ToolStripItem)PBOM_Prp_ContextRemove).set_Text("Remove");
			((ToolStripItem)PBOM_Prp_ContextRemove).add_Click((EventHandler)PBOM_Prp_ContextRemove_Click);
			((ToolStripItem)PBOM_Prp_ContextSep1).set_Name("PBOM_Prp_ContextSep1");
			((ToolStripItem)PBOM_Prp_ContextSep1).set_Size(new Size(134, 6));
			((ToolStripItem)PBOM_Prp_ContextUp).set_Image((Image)(object)Resources.up16);
			((ToolStripItem)PBOM_Prp_ContextUp).set_Name("PBOM_Prp_ContextUp");
			((ToolStripItem)PBOM_Prp_ContextUp).set_Size(new Size(137, 22));
			((ToolStripItem)PBOM_Prp_ContextUp).set_Text("Move up");
			((ToolStripItem)PBOM_Prp_ContextUp).add_Click((EventHandler)PBOM_Prp_ContextUp_Click);
			((ToolStripItem)PBOM_Prp_ContextDown).set_Image((Image)(object)Resources.down16);
			((ToolStripItem)PBOM_Prp_ContextDown).set_Name("PBOM_Prp_ContextDown");
			((ToolStripItem)PBOM_Prp_ContextDown).set_Size(new Size(137, 22));
			((ToolStripItem)PBOM_Prp_ContextDown).set_Text("Move down");
			((ToolStripItem)PBOM_Prp_ContextDown).add_Click((EventHandler)PBOM_Prp_ContextDown_Click);
			((Control)PBOM_Prp_BtnApply).set_Location(new Point(70, 182));
			((Control)PBOM_Prp_BtnApply).set_Name("PBOM_Prp_BtnApply");
			((Control)PBOM_Prp_BtnApply).set_Size(new Size(75, 23));
			((Control)PBOM_Prp_BtnApply).set_TabIndex(1);
			((Control)PBOM_Prp_BtnApply).set_Text("Apply");
			((ButtonBase)PBOM_Prp_BtnApply).set_UseVisualStyleBackColor(true);
			((Control)PBOM_Prp_BtnApply).add_Click((EventHandler)PBOM_Prp_BtnApply_Click);
			PBOM_Prp_BtnCancel.set_DialogResult((DialogResult)2);
			((Control)PBOM_Prp_BtnCancel).set_Location(new Point(163, 182));
			((Control)PBOM_Prp_BtnCancel).set_Name("PBOM_Prp_BtnCancel");
			((Control)PBOM_Prp_BtnCancel).set_Size(new Size(75, 23));
			((Control)PBOM_Prp_BtnCancel).set_TabIndex(2);
			((Control)PBOM_Prp_BtnCancel).set_Text("Cancel");
			((ButtonBase)PBOM_Prp_BtnCancel).set_UseVisualStyleBackColor(true);
			((Control)PBOM_Prp_BtnCancel).add_Click((EventHandler)PBOM_Prp_BtnCancel_Click);
			((Control)PBOM_Prp_Tab_Properties).set_BackColor(SystemColors.get_Control());
			((Control)PBOM_Prp_Tab_Properties).get_Controls().Add((Control)(object)PBOM_Prp_DG);
			PBOM_Prp_Tab_Properties.set_Location(new Point(4, 22));
			((Control)PBOM_Prp_Tab_Properties).set_Name("PBOM_Prp_Tab_Properties");
			((Control)PBOM_Prp_Tab_Properties).set_Padding(new Padding(3));
			((Control)PBOM_Prp_Tab_Properties).set_Size(new Size(295, 150));
			PBOM_Prp_Tab_Properties.set_TabIndex(0);
			((Control)PBOM_Prp_Tab_Properties).set_Text("Properties");
			PBOM_Prp_DG.set_AllowUserToAddRows(false);
			PBOM_Prp_DG.set_AllowUserToDeleteRows(false);
			PBOM_Prp_DG.set_AllowUserToResizeColumns(false);
			PBOM_Prp_DG.set_AllowUserToResizeRows(false);
			PBOM_Prp_DG.set_BackgroundColor(Color.get_White());
			PBOM_Prp_DG.set_ColumnHeadersHeightSizeMode((DataGridViewColumnHeadersHeightSizeMode)1);
			PBOM_Prp_DG.get_Columns().AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[2]
			{
				(DataGridViewColumn)cProperty,
				(DataGridViewColumn)cValue
			});
			((Control)PBOM_Prp_DG).set_ContextMenuStrip(PBOM_Prp_Context);
			((Control)PBOM_Prp_DG).set_Dock((DockStyle)5);
			((Control)PBOM_Prp_DG).set_Location(new Point(3, 3));
			PBOM_Prp_DG.set_MultiSelect(false);
			((Control)PBOM_Prp_DG).set_Name("PBOM_Prp_DG");
			PBOM_Prp_DG.set_RowHeadersVisible(false);
			PBOM_Prp_DG.set_RowHeadersWidthSizeMode((DataGridViewRowHeadersWidthSizeMode)1);
			val2.set_Padding(new Padding(5, 0, 0, 0));
			val2.set_WrapMode((DataGridViewTriState)2);
			PBOM_Prp_DG.set_RowsDefaultCellStyle(val2);
			PBOM_Prp_DG.get_RowTemplate().set_Height(18);
			((DataGridViewBand)PBOM_Prp_DG.get_RowTemplate()).set_Resizable((DataGridViewTriState)2);
			PBOM_Prp_DG.set_ScrollBars((ScrollBars)2);
			PBOM_Prp_DG.set_SelectionMode((DataGridViewSelectionMode)1);
			PBOM_Prp_DG.set_ShowEditingIcon(false);
			((Control)PBOM_Prp_DG).set_Size(new Size(289, 144));
			((Control)PBOM_Prp_DG).set_TabIndex(0);
			((DataGridViewColumn)cValue).set_HeaderText("Value");
			((DataGridViewColumn)cValue).set_Name("cValue");
			((DataGridViewBand)cValue).set_Resizable((DataGridViewTriState)2);
			cValue.set_SortMode((DataGridViewColumnSortMode)0);
			((DataGridViewColumn)cValue).set_Width(132);
			((DataGridViewColumn)cProperty).set_HeaderText("Property");
			((DataGridViewColumn)cProperty).set_Name("cProperty");
			((DataGridViewBand)cProperty).set_Resizable((DataGridViewTriState)2);
			cProperty.set_SortMode((DataGridViewColumnSortMode)0);
			((DataGridViewColumn)cProperty).set_Width(132);
			((Control)PBOM_Prp_Tab).get_Controls().Add((Control)(object)PBOM_Prp_Tab_Properties);
			((Control)PBOM_Prp_Tab).set_Dock((DockStyle)1);
			((Control)PBOM_Prp_Tab).set_Location(new Point(0, 0));
			((Control)PBOM_Prp_Tab).set_Name("PBOM_Prp_Tab");
			PBOM_Prp_Tab.set_SelectedIndex(0);
			((Control)PBOM_Prp_Tab).set_Size(new Size(303, 176));
			((Control)PBOM_Prp_Tab).set_TabIndex(0);
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
			((Control)this).set_Name("PBOM_Properties");
			((Form)this).set_ShowIcon(false);
			((Form)this).set_ShowInTaskbar(false);
			((Form)this).set_StartPosition((FormStartPosition)4);
			((Control)this).set_Text("PBO Properties");
			((Form)this).add_Load((EventHandler)PBOM_Properties_Load);
			((Control)PBOM_Prp_Context).ResumeLayout(false);
			((Control)PBOM_Prp_Tab_Properties).ResumeLayout(false);
			((ISupportInitialize)PBOM_Prp_DG).EndInit();
			((Control)PBOM_Prp_Tab).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
		}

		public PBOM_Properties(PBOFile Archive)
			: this()
		{
			InitializeComponent();
			PBOM_Localization.LocalizeForm((Form)(object)this);
			string text;
			((Control)this).set_Text(text = PBOM_Localization.LocalizeString(Resources.PBOM_Properties, "PBOM_Properties"));
			((Control)this).set_Text(text);
			_ActivePboFile = Archive;
		}

		private void PBOM_Properties_Load(object sender, EventArgs e)
		{
			Proc_InitForm();
		}

		private void PBOM_Prp_BtnApply_Click(object sender, EventArgs e)
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

		private void PBOM_Prp_BtnCancel_Click(object sender, EventArgs e)
		{
			((Form)this).set_DialogResult((DialogResult)2);
		}

		private void PBOM_Prp_Context_Opening(object sender, CancelEventArgs e)
		{
			if (PBOM_Prp_DG.get_CurrentRow() != null)
			{
				((ToolStrip)PBOM_Prp_Context).get_Items().get_Item(1).set_Enabled(true);
				if (((DataGridViewBand)PBOM_Prp_DG.get_CurrentRow()).get_Index() == 0)
				{
					((ToolStrip)PBOM_Prp_Context).get_Items().get_Item(3).set_Enabled(false);
				}
				else
				{
					((ToolStrip)PBOM_Prp_Context).get_Items().get_Item(3).set_Enabled(true);
				}
				if (((DataGridViewBand)PBOM_Prp_DG.get_CurrentRow()).get_Index() == PBOM_Prp_DG.get_Rows().get_Count() - 1)
				{
					((ToolStrip)PBOM_Prp_Context).get_Items().get_Item(4).set_Enabled(false);
				}
				else
				{
					((ToolStrip)PBOM_Prp_Context).get_Items().get_Item(4).set_Enabled(true);
				}
			}
		}

		private void PBOM_Prp_ContextAdd_Click(object sender, EventArgs e)
		{
			PBOM_Prp_DG.get_Rows().Add();
		}

		private void PBOM_Prp_ContextRemove_Click(object sender, EventArgs e)
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Invalid comparison between Unknown and I4
			if (PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(0)
				.get_Value() != null || PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(1)
				.get_Value() != null)
			{
				string text = PBOM_Localization.LocalizeString(Resources.PBOM_DeletePropertyText, "PBOM_DeletePropertyText");
				string text2 = PBOM_Localization.LocalizeString(Resources.PBOM_DeletePropertyCaption, "PBOM_DeletePropertyCaption");
				if ((int)MessageBox.Show(text, text2, (MessageBoxButtons)1) == 1)
				{
					PBOM_Prp_DG.get_Rows().Remove(PBOM_Prp_DG.get_CurrentRow());
				}
			}
			else
			{
				PBOM_Prp_DG.get_Rows().Remove(PBOM_Prp_DG.get_CurrentRow());
			}
		}

		private void PBOM_Prp_ContextUp_Click(object sender, EventArgs e)
		{
			object value = PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(0)
				.get_Value();
			object value2 = PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(1)
				.get_Value();
			DataGridViewRow val = PBOM_Prp_DG.get_Rows().get_Item(((DataGridViewBand)PBOM_Prp_DG.get_CurrentRow()).get_Index() - 1);
			PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(0)
				.set_Value(val.get_Cells().get_Item(0).get_Value());
			PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(1)
				.set_Value(val.get_Cells().get_Item(1).get_Value());
			val.get_Cells().get_Item(0).set_Value(value);
			val.get_Cells().get_Item(1).set_Value(value2);
			DataGridViewCell currentCell = PBOM_Prp_DG.get_CurrentCell();
			PBOM_Prp_DG.set_CurrentCell(PBOM_Prp_DG.get_Item(currentCell.get_ColumnIndex(), currentCell.get_RowIndex() - 1));
		}

		private void PBOM_Prp_ContextDown_Click(object sender, EventArgs e)
		{
			object value = PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(0)
				.get_Value();
			object value2 = PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(1)
				.get_Value();
			DataGridViewRow val = PBOM_Prp_DG.get_Rows().get_Item(((DataGridViewBand)PBOM_Prp_DG.get_CurrentRow()).get_Index() + 1);
			PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(0)
				.set_Value(val.get_Cells().get_Item(0).get_Value());
			PBOM_Prp_DG.get_CurrentRow().get_Cells().get_Item(1)
				.set_Value(val.get_Cells().get_Item(1).get_Value());
			val.get_Cells().get_Item(0).set_Value(value);
			val.get_Cells().get_Item(1).set_Value(value2);
			DataGridViewCell currentCell = PBOM_Prp_DG.get_CurrentCell();
			PBOM_Prp_DG.set_CurrentCell(PBOM_Prp_DG.get_Item(currentCell.get_ColumnIndex(), currentCell.get_RowIndex() + 1));
		}

		private void Proc_InitForm()
		{
			PBOM_Prp_DG.get_RowTemplate().set_Height(18);
			foreach (PBOFileProperty headerProperty in _ActivePboFile.get_PBOContents().get_HeaderProperties())
			{
				if (!headerProperty.get_IsEmpty())
				{
					int count = PBOM_Prp_DG.get_Rows().get_Count();
					PBOM_Prp_DG.get_Rows().Add();
					PBOM_Prp_DG.get_Item(0, count).set_Value((object)headerProperty.get_PropertyName());
					PBOM_Prp_DG.get_Item(1, count).set_Value((object)headerProperty.get_PropertyValue());
				}
			}
		}

		private bool Proc_CheckChanges()
		{
			List<PBOFileProperty> headerProperties = HeaderProperties;
			List<PBOFileProperty> headerProperties2 = _ActivePboFile.get_PBOContents().get_HeaderProperties();
			if (headerProperties.Count != headerProperties2.Count)
			{
				return false;
			}
			for (int i = 0; i < headerProperties2.Count; i++)
			{
				if (headerProperties[i].get_PropertyName() != headerProperties2[i].get_PropertyName() || headerProperties[i].get_PropertyValue() != headerProperties2[i].get_PropertyValue())
				{
					return false;
				}
			}
			return true;
		}
	}
}
