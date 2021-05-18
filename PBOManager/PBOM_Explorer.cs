using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MWCommon;
using MWControls;
using PBOManager.Properties;
using PBOOperations;

namespace PBOManager
{
	public class PBOM_Explorer : Form
	{
		public delegate void PBOMFormStateChangedEventHandler(object sender, PBOM_FormStateChangeEventArgs e);

		private const int WM_NCLBUTTONDBLCLK = 163;

		private const int WM_SYSCOMMAND = 274;

		private const int SC_RESTORE = 61728;

		private const int SC_MAXIMIZE = 61488;

		private IContainer components;

		private Panel PBOM_Ex_TreePanel;

		private ToolStrip PBOM_Ex_TS;

		private ToolStripButton PBOM_Ex_TS_BtnLoad;

		private ToolStripButton PBOM_Ex_TS_BtnUnLoad;

		private ToolStripSeparator PBOM_Ex_TS_Sep1;

		private ToolStripButton PBOM_Ex_TS_BtnOptions;

		internal MWTreeView PBOM_Ex_Tree;

		private ToolStripSeparator PBOM_Ex_TS_Sep2;

		private ContextMenuStrip PBOM_Ex_Context;

		private ToolStripMenuItem PBOM_Ex_Context_Open;

		private ToolStripSeparator PBOM_Ex_Context_S1;

		private ToolStripMenuItem PBOM_Ex_ContextExtract;

		private ToolStripMenuItem PBOM_Ex_ContextExtractCurrent;

		private ToolStripMenuItem PBOM_Ex_ContextExtractFolder;

		private ToolStripSeparator PBOM_Ex_Context_S2;

		private ToolStripMenuItem PBOM_Ex_ContextCut;

		private ToolStripMenuItem PBOM_Ex_ContextCopy;

		private ToolStripMenuItem PBOM_Ex_ContextPaste;

		private ToolStripSeparator PBOM_Ex_Context_S3;

		private ToolStripMenuItem PBOM_Ex_ContextDelete;

		private ToolStripSeparator toolStripMenuItem4;

		private ToolStripMenuItem PBOM_Ex_Context_Rename;

		private ToolStripButton PBOM_Ex_TS_BtnSignature;

		private string _StartupFileName = string.Empty;

		private string _TempPath = "PboM\\";

		private ImageList _SmallImageList;

		private PBOFile _ActivePboFile;

		private PBOM_DragDrop _DragDropWrapper;

		private PBOM_WorkInProgress _WorkInProgress;

		private PBOM_Cut _CutWrapper;

		private PBOM_Context _ContextWrapper;

		private PBOM_Settings _SettingsWrapper;

		public PBOFile ActivePboFile => _ActivePboFile;

		public sealed override string Text
		{
			get
			{
				return ((Form)this).get_Text();
			}
			set
			{
				((Form)this).set_Text(value);
			}
		}

		public event PBOMFormStateChangedEventHandler OnWindowStateChanged;

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
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Expected O, but got Unknown
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Expected O, but got Unknown
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Expected O, but got Unknown
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_049d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0520: Unknown result type (might be due to invalid IL or missing references)
			//IL_056a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0626: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0657: Expected O, but got Unknown
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0733: Unknown result type (might be due to invalid IL or missing references)
			//IL_0776: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_081c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0852: Unknown result type (might be due to invalid IL or missing references)
			//IL_0895: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_093b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0971: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a3e: Expected O, but got Unknown
			//IL_0a5c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a66: Expected O, but got Unknown
			components = (IContainer)new Container();
			ComponentResourceManager val = new ComponentResourceManager(typeof(PBOM_Explorer));
			PBOM_Ex_TreePanel = new Panel();
			PBOM_Ex_Tree = new MWTreeView();
			PBOM_Ex_TS = new ToolStrip();
			PBOM_Ex_TS_BtnLoad = new ToolStripButton();
			PBOM_Ex_TS_BtnUnLoad = new ToolStripButton();
			PBOM_Ex_TS_Sep1 = new ToolStripSeparator();
			PBOM_Ex_TS_BtnOptions = new ToolStripButton();
			PBOM_Ex_TS_BtnSignature = new ToolStripButton();
			PBOM_Ex_TS_Sep2 = new ToolStripSeparator();
			PBOM_Ex_Context = new ContextMenuStrip(components);
			PBOM_Ex_Context_Open = new ToolStripMenuItem();
			toolStripMenuItem4 = new ToolStripSeparator();
			PBOM_Ex_Context_Rename = new ToolStripMenuItem();
			PBOM_Ex_Context_S1 = new ToolStripSeparator();
			PBOM_Ex_ContextExtract = new ToolStripMenuItem();
			PBOM_Ex_ContextExtractCurrent = new ToolStripMenuItem();
			PBOM_Ex_ContextExtractFolder = new ToolStripMenuItem();
			PBOM_Ex_Context_S2 = new ToolStripSeparator();
			PBOM_Ex_ContextCut = new ToolStripMenuItem();
			PBOM_Ex_ContextCopy = new ToolStripMenuItem();
			PBOM_Ex_ContextPaste = new ToolStripMenuItem();
			PBOM_Ex_Context_S3 = new ToolStripSeparator();
			PBOM_Ex_ContextDelete = new ToolStripMenuItem();
			((Control)PBOM_Ex_TreePanel).SuspendLayout();
			((Control)PBOM_Ex_TS).SuspendLayout();
			((Control)PBOM_Ex_Context).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)PBOM_Ex_TreePanel).get_Controls().Add((Control)(object)PBOM_Ex_Tree);
			((Control)PBOM_Ex_TreePanel).set_Dock((DockStyle)5);
			((Control)PBOM_Ex_TreePanel).set_Location(new Point(0, 25));
			((Control)PBOM_Ex_TreePanel).set_Name("PBOM_Ex_TreePanel");
			((Control)PBOM_Ex_TreePanel).set_Size(new Size(261, 352));
			((Control)PBOM_Ex_TreePanel).set_TabIndex(0);
			PBOM_Ex_Tree.set_CheckedNodes((Hashtable)((ResourceManager)(object)val).GetObject("PBOM_Ex_Tree.CheckedNodes"));
			((Control)PBOM_Ex_Tree).set_Dock((DockStyle)5);
			((TreeView)PBOM_Ex_Tree).set_LabelEdit(true);
			PBOM_Ex_Tree.set_LabelEditRegEx("[0-9a-fA-F()\\[\\]\\#&&\\@\\%\\^_\\-\\+\\=\\?]+");
			((Control)PBOM_Ex_Tree).set_Location(new Point(0, 0));
			((Control)PBOM_Ex_Tree).set_Name("PBOM_Ex_Tree");
			PBOM_Ex_Tree.set_SelNodes((Hashtable)((ResourceManager)(object)val).GetObject("PBOM_Ex_Tree.SelNodes"));
			((Control)PBOM_Ex_Tree).set_Size(new Size(261, 352));
			((Control)PBOM_Ex_Tree).set_TabIndex(0);
			((TreeView)PBOM_Ex_Tree).add_AfterLabelEdit(new NodeLabelEditEventHandler(PBOM_Ex_Tree_AfterLabelEdit));
			((TreeView)PBOM_Ex_Tree).add_NodeMouseDoubleClick(new TreeNodeMouseClickEventHandler(PBOM_Ex_Tree_NodeMouseDoubleClick));
			((Control)PBOM_Ex_Tree).add_KeyDown(new KeyEventHandler(PBOM_Ex_Tree_KeyDown));
			PBOM_Ex_TS.get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[6]
			{
				(ToolStripItem)PBOM_Ex_TS_BtnLoad,
				(ToolStripItem)PBOM_Ex_TS_BtnUnLoad,
				(ToolStripItem)PBOM_Ex_TS_Sep1,
				(ToolStripItem)PBOM_Ex_TS_BtnOptions,
				(ToolStripItem)PBOM_Ex_TS_BtnSignature,
				(ToolStripItem)PBOM_Ex_TS_Sep2
			});
			((Control)PBOM_Ex_TS).set_Location(new Point(0, 0));
			((Control)PBOM_Ex_TS).set_Name("PBOM_Ex_TS");
			((Control)PBOM_Ex_TS).set_Size(new Size(261, 25));
			((Control)PBOM_Ex_TS).set_TabIndex(1);
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_DisplayStyle((ToolStripItemDisplayStyle)2);
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_Image((Image)(object)Resources.load16);
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_ImageTransparentColor(Color.get_Magenta());
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_Name("PBOM_Ex_TS_BtnLoad");
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_Size(new Size(23, 22));
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).set_Text("Open file");
			((ToolStripItem)PBOM_Ex_TS_BtnLoad).add_Click((EventHandler)PBOM_Ex_TS_BtnLoad_Click);
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_DisplayStyle((ToolStripItemDisplayStyle)2);
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Image((Image)(object)Resources.close16);
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_ImageTransparentColor(Color.get_Magenta());
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Name("PBOM_Ex_TS_BtnUnLoad");
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Size(new Size(23, 22));
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Text("Close file");
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).add_Click((EventHandler)PBOM_Ex_TS_BtnUnLoad_Click);
			((ToolStripItem)PBOM_Ex_TS_Sep1).set_Name("PBOM_Ex_TS_Sep1");
			((ToolStripItem)PBOM_Ex_TS_Sep1).set_Size(new Size(6, 25));
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_DisplayStyle((ToolStripItemDisplayStyle)2);
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Image((Image)(object)Resources.application16);
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_ImageTransparentColor(Color.get_Magenta());
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Name("PBOM_Ex_TS_BtnOptions");
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Size(new Size(23, 22));
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Text("File properties");
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).add_Click((EventHandler)PBOM_Ex_TS_BtnOptions_Click);
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_DisplayStyle((ToolStripItemDisplayStyle)2);
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Image((Image)(object)Resources.package_installed_locked);
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_ImageTransparentColor(Color.get_Magenta());
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Name("PBOM_Ex_TS_BtnSignature");
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Size(new Size(23, 22));
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Text("File checksum");
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).add_Click((EventHandler)PBOM_Ex_TS_BtnSignature_Click);
			((ToolStripItem)PBOM_Ex_TS_Sep2).set_Name("PBOM_Ex_TS_Sep2");
			((ToolStripItem)PBOM_Ex_TS_Sep2).set_Size(new Size(6, 25));
			((ToolStrip)PBOM_Ex_Context).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[13]
			{
				(ToolStripItem)PBOM_Ex_Context_Open,
				(ToolStripItem)toolStripMenuItem4,
				(ToolStripItem)PBOM_Ex_Context_Rename,
				(ToolStripItem)PBOM_Ex_Context_S1,
				(ToolStripItem)PBOM_Ex_ContextExtract,
				(ToolStripItem)PBOM_Ex_ContextExtractCurrent,
				(ToolStripItem)PBOM_Ex_ContextExtractFolder,
				(ToolStripItem)PBOM_Ex_Context_S2,
				(ToolStripItem)PBOM_Ex_ContextCut,
				(ToolStripItem)PBOM_Ex_ContextCopy,
				(ToolStripItem)PBOM_Ex_ContextPaste,
				(ToolStripItem)PBOM_Ex_Context_S3,
				(ToolStripItem)PBOM_Ex_ContextDelete
			});
			((Control)PBOM_Ex_Context).set_Name("PBOM_Ex_Context");
			((Control)PBOM_Ex_Context).set_Size(new Size(190, 226));
			((ToolStripItem)PBOM_Ex_Context_Open).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_Context_Open).set_Font(new Font("Segoe UI", 9f, (FontStyle)1));
			((ToolStripItem)PBOM_Ex_Context_Open).set_Image((Image)(object)Resources.run16);
			((ToolStripItem)PBOM_Ex_Context_Open).set_Name("PBOM_Ex_Context_Open");
			((ToolStripItem)PBOM_Ex_Context_Open).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_Context_Open).set_Text("Open");
			((ToolStripItem)toolStripMenuItem4).set_Name("toolStripMenuItem4");
			((ToolStripItem)toolStripMenuItem4).set_Size(new Size(186, 6));
			((ToolStripItem)PBOM_Ex_Context_Rename).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_Context_Rename).set_Image((Image)(object)Resources.rename16);
			((ToolStripItem)PBOM_Ex_Context_Rename).set_Name("PBOM_Ex_Context_Rename");
			((ToolStripItem)PBOM_Ex_Context_Rename).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_Context_Rename).set_Text("Rename..");
			((ToolStripItem)PBOM_Ex_Context_S1).set_Name("PBOM_Ex_Context_S1");
			((ToolStripItem)PBOM_Ex_Context_S1).set_Size(new Size(186, 6));
			((ToolStripItem)PBOM_Ex_ContextExtract).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextExtract).set_Image((Image)(object)Resources.extractto16);
			((ToolStripItem)PBOM_Ex_ContextExtract).set_Name("PBOM_Ex_ContextExtract");
			((ToolStripItem)PBOM_Ex_ContextExtract).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextExtract).set_Text("Extract..");
			((ToolStripItem)PBOM_Ex_ContextExtractCurrent).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextExtractCurrent).set_Image((Image)(object)Resources.ectractcurrent16);
			((ToolStripItem)PBOM_Ex_ContextExtractCurrent).set_Name("PBOM_Ex_ContextExtractCurrent");
			((ToolStripItem)PBOM_Ex_ContextExtractCurrent).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextExtractCurrent).set_Text("Extract to *.pbo folder");
			((ToolStripItem)PBOM_Ex_ContextExtractFolder).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextExtractFolder).set_Image((Image)(object)Resources.extractfolder16);
			((ToolStripItem)PBOM_Ex_ContextExtractFolder).set_Name("PBOM_Ex_ContextExtractFolder");
			((ToolStripItem)PBOM_Ex_ContextExtractFolder).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextExtractFolder).set_Text("Extract to {0}");
			((ToolStripItem)PBOM_Ex_Context_S2).set_Name("PBOM_Ex_Context_S2");
			((ToolStripItem)PBOM_Ex_Context_S2).set_Size(new Size(186, 6));
			((ToolStripItem)PBOM_Ex_ContextCut).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextCut).set_Image((Image)(object)Resources.cut16);
			((ToolStripItem)PBOM_Ex_ContextCut).set_Name("PBOM_Ex_ContextCut");
			((ToolStripItem)PBOM_Ex_ContextCut).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextCut).set_Text("Cut");
			((ToolStripItem)PBOM_Ex_ContextCopy).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextCopy).set_Image((Image)(object)Resources.copy16);
			((ToolStripItem)PBOM_Ex_ContextCopy).set_Name("PBOM_Ex_ContextCopy");
			((ToolStripItem)PBOM_Ex_ContextCopy).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextCopy).set_Text("Copy");
			((ToolStripItem)PBOM_Ex_ContextPaste).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextPaste).set_Image((Image)(object)Resources.paste16);
			((ToolStripItem)PBOM_Ex_ContextPaste).set_Name("PBOM_Ex_ContextPaste");
			((ToolStripItem)PBOM_Ex_ContextPaste).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextPaste).set_Text("Paste");
			((ToolStripItem)PBOM_Ex_Context_S3).set_Name("PBOM_Ex_Context_S3");
			((ToolStripItem)PBOM_Ex_Context_S3).set_Size(new Size(186, 6));
			((ToolStripItem)PBOM_Ex_ContextDelete).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_ContextDelete).set_Image((Image)(object)Resources.delete16);
			((ToolStripItem)PBOM_Ex_ContextDelete).set_Name("PBOM_Ex_ContextDelete");
			((ToolStripItem)PBOM_Ex_ContextDelete).set_Size(new Size(189, 22));
			((ToolStripItem)PBOM_Ex_ContextDelete).set_Text("Delete");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(261, 377));
			((Control)this).get_Controls().Add((Control)(object)PBOM_Ex_TreePanel);
			((Control)this).get_Controls().Add((Control)(object)PBOM_Ex_TS);
			((Control)this).set_DoubleBuffered(true);
			((Form)this).set_Icon((Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("PBOM_Explorer");
			((Control)this).set_Text("PBO Explorer");
			((Form)this).add_FormClosed(new FormClosedEventHandler(PBOM_Explorer_FormClosed));
			((Form)this).add_Load((EventHandler)PBOM_Explorer_Load);
			((Control)PBOM_Ex_TreePanel).ResumeLayout(false);
			((Control)PBOM_Ex_TS).ResumeLayout(false);
			((Control)PBOM_Ex_TS).PerformLayout();
			((Control)PBOM_Ex_Context).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}

		public PBOM_Explorer(string Argument)
			: this()
		{
			InitializeComponent();
			PBOM_Localization.LocalizeForm((Form)(object)this);
			((Control)this).set_Text(PBOM_Localization.LocalizeString(Resources.PBOM_Explorer, "PBOM_Explorer"));
			if (Argument != string.Empty && File.Exists(Argument))
			{
				_StartupFileName = Argument;
			}
		}

		private void PBOM_Explorer_Load(object sender, EventArgs e)
		{
			int num = new Random().Next();
			_TempPath = $"{Path.GetTempPath()}{_TempPath}{num}\\";
			_DragDropWrapper = new PBOM_DragDrop(PBOM_Ex_Tree);
			_DragDropWrapper.OnTreeViewDragDrop += PBOM_Ex_Tree_OnTreeViewDragDrop;
			_DragDropWrapper.OnTreeViewDragStart += PBOM_Ex_Tree_OnTreeViewDragStart;
			_DragDropWrapper.OnTreeViewDropAccept += PBOM_Ex_Tree_OnTreeViewDropAccept;
			_WorkInProgress = new PBOM_WorkInProgress((Form)(object)this);
			_SettingsWrapper = new PBOM_Settings(this);
			_SettingsWrapper.Attach();
			_CutWrapper = new PBOM_Cut((Form)(object)this);
			_CutWrapper.OnFileDeleted += PBOM_Ex_Tree_OnFileDeleted;
			_ContextWrapper = new PBOM_Context(PBOM_Ex_Tree, PBOM_Ex_Context, "");
			_ContextWrapper.OnContextMenuEvent += PBOM_Ex_Tree_OnContextMenuEvent;
			if (_StartupFileName != string.Empty)
			{
				Proc_LoadActiveFile(_StartupFileName);
			}
		}

		private void PBOM_Explorer_FormClosed(object sender, FormClosedEventArgs e)
		{
			_CutWrapper.Dispose();
			_DragDropWrapper.Close();
			_ContextWrapper.Detach();
			_SettingsWrapper.Detach();
			Proc_ClearTempPath();
		}

		private void PBOM_Ex_TS_BtnLoad_Click(object sender, EventArgs e)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Invalid comparison between Unknown and I4
			OpenFileDialog val = new OpenFileDialog();
			((FileDialog)val).set_Filter("Bohemia interactive PBO|*.pbo|Bohemia interactive IFA|*.ifa");
			OpenFileDialog val2 = val;
			if ((int)((CommonDialog)val2).ShowDialog() == 1)
			{
				Proc_LoadActiveFile(((FileDialog)val2).get_FileName());
			}
			((Component)val2).Dispose();
		}

		private void PBOM_Ex_TS_BtnUnLoad_Click(object sender, EventArgs e)
		{
			Proc_UnLoadActiveFile();
		}

		private void PBOM_Ex_TS_BtnOptions_Click(object sender, EventArgs e)
		{
			Proc_ChangeActiveFileProperies();
		}

		private void PBOM_Ex_TS_BtnSignature_Click(object sender, EventArgs e)
		{
			Proc_ChangeActiveFileChecksum();
		}

		private void PBOM_Ex_Tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Proc_ViewArchiveItem(e.get_Node());
		}

		private void PBOM_Ex_Tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (!Proc_FileIsSigned())
			{
				e.set_CancelEdit(true);
				return;
			}
			_WorkInProgress.Show();
			string directoryName = Path.GetDirectoryName(e.get_Node().get_FullPath());
			e.get_Node().set_Name($"{directoryName}\\{e.get_Label()}");
			e.get_Node().set_Text(e.get_Label());
			Hashtable hashtable = new Hashtable();
			Proc_GetNodeName(e.get_Node(), hashtable);
			_ActivePboFile.ChangePboEntryName(hashtable);
			_WorkInProgress.Hide();
		}

		private void Proc_ViewArchiveItem(TreeNode Node)
		{
			if (Node.get_ToolTipText() != "folder")
			{
				int index = (int)Node.get_Tag();
				_ActivePboFile.ExtractPboEntry(_ActivePboFile.get_PBOContents().get_HeaderEntries()[index], _TempPath, false);
				string text = $"{_TempPath}{_ActivePboFile.get_PBOContents().get_HeaderEntries()[index].get_FileName()}";
				Process.Start(text);
			}
		}

		private void Proc_CreateTempFile(string FileName)
		{
			string directoryName = Path.GetDirectoryName(FileName);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (!File.Exists(FileName))
			{
				FileStream fileStream = File.Create(FileName);
				fileStream.Dispose();
			}
		}

		private void Proc_CreateDummyFiles()
		{
			foreach (PBOHeaderEntry headerEntry in _ActivePboFile.get_PBOContents().get_HeaderEntries())
			{
				Proc_CreateTempFile($"{_TempPath}{headerEntry.get_FileName()}");
			}
		}

		private void Proc_ClearTempPath()
		{
			try
			{
				if (Directory.Exists(_TempPath))
				{
					Directory.Delete(_TempPath, true);
				}
			}
			catch
			{
			}
		}

		private void Proc_LoadActiveFile(string FileName)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				_WorkInProgress.Show();
				_ActivePboFile = new PBOFile();
				_ActivePboFile.OpenRead(FileName, true);
				_ActivePboFile.Close();
				Proc_GetAssociatedImages();
				Proc_ExploreFileStructure();
				Proc_ClearTempPath();
				Proc_CreateDummyFiles();
				((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Enabled(true);
				((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Enabled(true);
				((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Enabled(true);
				_DragDropWrapper.Open();
				_ContextWrapper.Attach();
				_ContextWrapper.ExtractToFolder = $"{Path.GetFileNameWithoutExtension(_ActivePboFile.get_ShortFileName())}\\";
				_CutWrapper.TempStoragePath = _TempPath;
			}
			catch
			{
				_ActivePboFile.Dispose();
				string text = PBOM_Localization.LocalizeString(Resources.PBOM_LoadErrorText, "PBOM_LoadErrorText");
				string text2 = PBOM_Localization.LocalizeString(Resources.PBOM_LoadErrorCaption, "PBOM_LoadErrorCaption");
				MessageBox.Show(text, text2, (MessageBoxButtons)0, (MessageBoxIcon)16);
			}
			finally
			{
				_WorkInProgress.Hide();
				GC.Collect();
			}
		}

		private void Proc_UnLoadActiveFile()
		{
			((ToolStripItem)PBOM_Ex_TS_BtnUnLoad).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_TS_BtnOptions).set_Enabled(false);
			((ToolStripItem)PBOM_Ex_TS_BtnSignature).set_Enabled(false);
			((TreeView)PBOM_Ex_Tree).get_Nodes().Clear();
			Proc_ClearTempPath();
			_ActivePboFile.Dispose();
			_DragDropWrapper.Close();
			_CutWrapper.Close();
			_ContextWrapper.Detach();
		}

		private void Proc_ChangeActiveFileProperies()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Invalid comparison between Unknown and I4
			PBOM_Properties pBOM_Properties = new PBOM_Properties(_ActivePboFile);
			((Form)pBOM_Properties).ShowDialog();
			if ((int)((Form)pBOM_Properties).get_DialogResult() == 1)
			{
				_WorkInProgress.Show();
				_ActivePboFile.ChangePboProperties(pBOM_Properties.HeaderProperties);
				_WorkInProgress.Hide();
			}
			((Component)pBOM_Properties).Dispose();
		}

		private void Proc_ChangeActiveFileChecksum()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Invalid comparison between Unknown and I4
			PBOM_Signature pBOM_Signature = new PBOM_Signature(_ActivePboFile);
			((Form)pBOM_Signature).ShowDialog();
			if ((int)((Form)pBOM_Signature).get_DialogResult() == 1)
			{
				_WorkInProgress.Show();
				_ActivePboFile.ClearShaKey();
				_ActivePboFile.AssignShaKey(pBOM_Signature.Checksum);
				_WorkInProgress.Hide();
			}
			((Component)pBOM_Signature).Dispose();
		}

		private void Proc_ExploreFileStructure()
		{
			((TreeView)PBOM_Ex_Tree).set_TreeViewNodeSorter((IComparer)new PBOM_TreeViewNodeSorter());
			((TreeView)PBOM_Ex_Tree).get_Nodes().Clear();
			((TreeView)PBOM_Ex_Tree).get_Nodes().Add(_ActivePboFile.get_ShortFileName());
			for (int i = 0; i < _ActivePboFile.get_PBOContents().get_HeaderEntries().Count; i++)
			{
				Proc_AddItemToTree(_ActivePboFile.get_PBOContents().get_HeaderEntries()[i], i, ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0));
			}
			((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).set_ImageIndex(0);
			((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).set_SelectedImageIndex(0);
			((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).set_ToolTipText("folder");
			((TreeView)PBOM_Ex_Tree).Sort();
		}

		private bool Proc_FileIsSigned()
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Invalid comparison between Unknown and I4
			if (_ActivePboFile.get_PBOContents().get_Checksum() != null)
			{
				_DragDropWrapper.TemporalyStopNodeAutoExpand();
				string text = PBOM_Localization.LocalizeString(Resources.PBOM_DigitalSignatureText, "PBOM_DigitalSignatureText");
				string text2 = PBOM_Localization.LocalizeString(Resources.PBOM_DigitalSignatureCaption, "PBOM_DigitalSignatureCaption");
				DialogResult val = MessageBox.Show(text, text2, (MessageBoxButtons)1, (MessageBoxIcon)32);
				if ((int)val == 2)
				{
					return false;
				}
			}
			return true;
		}

		private void Proc_AddItemToTree(PBOHeaderEntry Entry, int EntryIndex, TreeNode Root)
		{
			TreeNode val = Root;
			string text = Root.get_FullPath();
			string[] array = Entry.get_FileName().Split(new char[1]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				text = $"{text}\\{text2}";
				TreeNode[] array3 = ((TreeView)PBOM_Ex_Tree).get_Nodes().Find(text, true);
				if (array3.Length > 0)
				{
					val = array3[0];
					continue;
				}
				val.get_Nodes().Add(text, text2);
				val.set_ImageIndex(_SmallImageList.get_Images().IndexOfKey("folder"));
				val.set_SelectedImageIndex(val.get_ImageIndex());
				val.set_Tag((object)(-1));
				val.set_ToolTipText("folder");
				string extension = Path.GetExtension(text2);
				val = ((TreeView)PBOM_Ex_Tree).get_Nodes().Find(text, true)[0];
				int num = _SmallImageList.get_Images().IndexOfKey(extension);
				val.set_ImageIndex((num >= 0) ? num : _SmallImageList.get_Images().IndexOfKey("-1"));
				val.set_SelectedImageIndex(val.get_ImageIndex());
				val.set_Tag((object)EntryIndex);
				val.set_ToolTipText(extension);
			}
		}

		private void Proc_GetDataFromShell(TreeNode ParentNode, string[] FileNames, DragDropEffects Effect)
		{
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Expected O, but got Unknown
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Invalid comparison between Unknown and I4
			if (ParentNode == null)
			{
				ParentNode = ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0);
			}
			else if (ParentNode.get_ToolTipText() != "folder")
			{
				ParentNode = ParentNode.get_Parent();
			}
			if (!Proc_FileIsSigned())
			{
				return;
			}
			_WorkInProgress.Show();
			string fullPath = ParentNode.get_FullPath();
			string arg = ((ParentNode == ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0)) ? "" : string.Format("{0}{1}", fullPath.Remove(0, ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).get_Text()
				.Length + 1), "\\"));
			Hashtable hashtable = new Hashtable();
			Hashtable hashtable2 = new Hashtable();
			foreach (string text in FileNames)
			{
				if (File.Exists(text))
				{
					string fileName = Path.GetFileName(text);
					hashtable2.Add(text, $"{arg}{fileName}");
					string text2 = $"{fullPath}\\{fileName}";
					TreeNode[] array = ((TreeView)PBOM_Ex_Tree).get_Nodes().Find(text2, true);
					if (array.Length > 0)
					{
						MWTreeNodeWrapper val = new MWTreeNodeWrapper(array[0]);
						hashtable.Add(((object)val).GetHashCode(), val);
					}
				}
				else
				{
					if (!Directory.Exists(text))
					{
						continue;
					}
					DirectoryInfo val2 = new DirectoryInfo(text);
					if (val2.get_Parent() == null)
					{
						continue;
					}
					int num = ((FileSystemInfo)val2.get_Parent()).get_FullName().Length;
					if (((FileSystemInfo)val2.get_Parent()).get_FullName()[num - 1] != '\\')
					{
						num++;
					}
					string[] files = Directory.GetFiles(text, "*.*", (SearchOption)1);
					string[] array2 = files;
					foreach (string text3 in array2)
					{
						string arg2 = text3.Remove(0, num);
						hashtable2.Add(text3, $"{arg}{arg2}");
						string text4 = $"{fullPath}\\{arg2}";
						TreeNode[] array3 = ((TreeView)PBOM_Ex_Tree).get_Nodes().Find(text4, true);
						if (array3.Length > 0)
						{
							MWTreeNodeWrapper val3 = new MWTreeNodeWrapper(array3[0]);
							hashtable.Add(((object)val3).GetHashCode(), val3);
						}
					}
				}
			}
			Proc_RemoveItems(hashtable);
			int count = _ActivePboFile.get_PBOContents().get_HeaderEntries().Count;
			_ActivePboFile.AddPboEntry(hashtable2);
			if ((int)Effect == 2)
			{
				foreach (string text5 in FileNames)
				{
					if (File.Exists(text5))
					{
						File.Delete(text5);
					}
					else if (Directory.Exists(text5))
					{
						Directory.Delete(text5, true);
					}
				}
			}
			Proc_GetAssociatedImages();
			for (int l = count; l < _ActivePboFile.get_PBOContents().get_HeaderEntries().Count; l++)
			{
				Proc_AddItemToTree(_ActivePboFile.get_PBOContents().get_HeaderEntries()[l], l, ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0));
			}
			((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).set_ImageIndex(0);
			((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).set_SelectedImageIndex(0);
			((TreeView)PBOM_Ex_Tree).Sort();
			_WorkInProgress.Hide();
		}

		private void Proc_GetDataFromClipboard(TreeNode ParentNode)
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			if (!Clipboard.ContainsFileDropList())
			{
				return;
			}
			int num = 5;
			MemoryStream memoryStream = (MemoryStream)Clipboard.GetData("Preferred DropEffect");
			if (memoryStream != null)
			{
				num = memoryStream.ReadByte();
				if (num != 2 && num != 5)
				{
					return;
				}
			}
			DragDropEffects effect = (DragDropEffects)((num != 2) ? 1 : 2);
			string[] fileNames = (string[])Clipboard.GetData(DataFormats.FileDrop);
			Proc_GetDataFromShell(ParentNode, fileNames, effect);
		}

		private void Proc_SendDataToClipboard(DragDropEffects Effect)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Expected O, but got Unknown
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Invalid comparison between Unknown and I4
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			if (PBOM_Ex_Tree.get_SelNodes() == null)
			{
				return;
			}
			foreach (MWTreeNodeWrapper value in PBOM_Ex_Tree.get_SelNodes().Values)
			{
				MWTreeNodeWrapper val = value;
				if (val.get_Node() == ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0))
				{
					return;
				}
			}
			int num = 0;
			int count = ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).get_Text()
				.Length + 1;
			TreeNode val2 = new TreeNode();
			List<string> list = new List<string>();
			foreach (MWTreeNodeWrapper value2 in PBOM_Ex_Tree.get_SelNodes().Values)
			{
				MWTreeNodeWrapper val3 = value2;
				if (num != 0 && val2 != val3.get_Node().get_Parent())
				{
					return;
				}
				if (num == 0)
				{
					val2 = val3.get_Node().get_Parent();
				}
				list.Add($"{_TempPath}{val3.get_Node().get_FullPath().Remove(0, count)}");
				num++;
			}
			Proc_PreExtractFiles(PBOM_Ex_Tree.get_SelNodes());
			byte[] buffer;
			if ((int)Effect == 1)
			{
				buffer = new byte[4]
				{
					5,
					0,
					0,
					0
				};
				_CutWrapper.Close();
			}
			else
			{
				buffer = new byte[4]
				{
					2,
					0,
					0,
					0
				};
				Hashtable hashtable = new Hashtable();
				foreach (MWTreeNodeWrapper value3 in PBOM_Ex_Tree.get_SelNodes().Values)
				{
					MWTreeNodeWrapper val4 = value3;
					hashtable.Add(((object)val4).GetHashCode(), val4);
				}
				_CutWrapper.CutNodes = hashtable;
			}
			MemoryStream memoryStream = new MemoryStream(buffer);
			DataObject val5 = new DataObject();
			val5.SetData("Preferred DropEffect", (object)memoryStream);
			val5.SetData(DataFormats.FileDrop, (object)list.ToArray());
			Clipboard.SetDataObject((object)val5);
		}

		private void Proc_RemoveItems(Hashtable Items)
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			if (Items == null || Items.Count <= 0 || !Proc_FileIsSigned())
			{
				return;
			}
			_CutWrapper.Close();
			_WorkInProgress.Show();
			List<TreeNode> list = new List<TreeNode>();
			foreach (MWTreeNodeWrapper value in Items.Values)
			{
				MWTreeNodeWrapper val = value;
				Proc_GetNodeIndex(val.get_Node(), list);
			}
			List<int> list2 = new List<int>();
			foreach (TreeNode item in list)
			{
				if (item.get_ToolTipText() != "folder")
				{
					list2.Add((int)item.get_Tag());
				}
				TreeNode val2 = item.get_Parent();
				((TreeView)PBOM_Ex_Tree).get_Nodes().Remove(item);
				if (val2 != null)
				{
					while (val2 != ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0) && val2.get_Nodes().get_Count() == 0)
					{
						TreeNode parent = val2.get_Parent();
						((TreeView)PBOM_Ex_Tree).get_Nodes().Remove(val2);
						val2 = parent;
					}
				}
			}
			_ActivePboFile.RemovePboEntry(list2);
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				Proc_ReindexNode(((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0), list2[num]);
			}
			_WorkInProgress.Hide();
		}

		private void Proc_GetNodeIndex(TreeNode Node, List<TreeNode> ItemIndexes)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			if (Node.get_ToolTipText() == "folder")
			{
				foreach (TreeNode node2 in Node.get_Nodes())
				{
					TreeNode node = node2;
					Proc_GetNodeIndex(node, ItemIndexes);
				}
				if (Node != ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0))
				{
					ItemIndexes.Add(Node);
				}
			}
			else
			{
				ItemIndexes.Add(Node);
			}
		}

		private void Proc_GetNodeName(TreeNode Node, Hashtable Names)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			if (Node.get_ToolTipText() == "folder")
			{
				foreach (TreeNode node2 in Node.get_Nodes())
				{
					TreeNode node = node2;
					Proc_GetNodeName(node, Names);
				}
			}
			else
			{
				int count = ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0).get_Text()
					.Length + 1;
				Names.Add(Node.get_Tag(), Node.get_FullPath().Remove(0, count));
			}
		}

		private void Proc_ReindexNode(TreeNode Node, int StartIndex)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			if (Node.get_ToolTipText() == "folder")
			{
				foreach (TreeNode node2 in Node.get_Nodes())
				{
					TreeNode node = node2;
					Proc_ReindexNode(node, StartIndex);
				}
			}
			else
			{
				int num = (int)Node.get_Tag();
				if (num >= StartIndex)
				{
					Node.set_Tag((object)(num - 1));
				}
			}
		}

		private void Proc_PreExtractFiles(Hashtable SelNodes)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			_WorkInProgress.Show();
			Hashtable hashtable = new Hashtable();
			foreach (MWTreeNodeWrapper value in SelNodes.Values)
			{
				MWTreeNodeWrapper val = value;
				Proc_GetNodeName(val.get_Node(), hashtable);
			}
			_ActivePboFile.ExtractPboEntry(hashtable, _TempPath, false);
			_WorkInProgress.Hide();
		}

		private void Proc_GetAssociatedImages()
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			if (_SmallImageList == null)
			{
				_SmallImageList = new ImageList();
			}
			SHFILEINFO ShInfo = default(SHFILEINFO);
			Proc_AddImageToList(_SmallImageList, ".pbo", ref ShInfo, 273u);
			if (!_SmallImageList.get_Images().ContainsKey("folder"))
			{
				_SmallImageList.get_Images().Add("folder", (Image)(object)Resources.browser_folder);
			}
			if (!_SmallImageList.get_Images().ContainsKey("-1"))
			{
				_SmallImageList.get_Images().Add("-1", (Image)(object)Resources.unknown16);
			}
			foreach (PBOHeaderEntry headerEntry in _ActivePboFile.get_PBOContents().get_HeaderEntries())
			{
				string extension = Path.GetExtension(headerEntry.get_FileName());
				if (extension != "" && !_SmallImageList.get_Images().ContainsKey(extension))
				{
					Proc_AddImageToList(_SmallImageList, extension, ref ShInfo, 273u);
				}
			}
			((TreeView)PBOM_Ex_Tree).set_ImageList(_SmallImageList);
		}

		private void Proc_AddImageToList(ImageList List, string Extension, ref SHFILEINFO ShInfo, uint ImageAttributes)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			if (!List.get_Images().ContainsKey(Extension))
			{
				Win32.SHGetFileInfo(Extension, 0u, ref ShInfo, (uint)Marshal.SizeOf((object)ShInfo), ImageAttributes);
				Icon val = (Icon)Icon.FromHandle(ShInfo.hIcon).Clone();
				Win32.DestroyIcon(ShInfo.hIcon);
				List.get_Images().Add(Extension, val);
			}
		}

		private void PBOM_Ex_Tree_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Invalid comparison between Unknown and I4
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected I4, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Invalid comparison between Unknown and I4
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected I4, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Invalid comparison between Unknown and I4
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Expected O, but got Unknown
			if (!((Control)PBOM_Ex_Tree).get_AllowDrop())
			{
				return;
			}
			Keys keyCode = e.get_KeyCode();
			if ((int)keyCode <= 67)
			{
				switch (keyCode - 45)
				{
				default:
					if ((int)keyCode == 67 && e.get_Control())
					{
						Proc_SendDataToClipboard((DragDropEffects)1);
					}
					break;
				case 1:
				{
					int num = 0;
					Hashtable selNodes = PBOM_Ex_Tree.get_SelNodes();
					foreach (MWTreeNodeWrapper value in selNodes.Values)
					{
						MWTreeNodeWrapper val = value;
						if (val.get_Node() == ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0))
						{
							return;
						}
						num++;
					}
					Proc_RemoveItems(PBOM_Ex_Tree.get_SelNodes());
					break;
				}
				case 0:
					if (e.get_Shift())
					{
						Proc_GetDataFromClipboard(((TreeView)PBOM_Ex_Tree).get_SelectedNode());
					}
					else if (e.get_Control())
					{
						Proc_SendDataToClipboard((DragDropEffects)1);
					}
					break;
				}
				return;
			}
			switch (keyCode - 86)
			{
			default:
				if ((int)keyCode == 113 && ((TreeView)PBOM_Ex_Tree).get_LabelEdit() && PBOM_Ex_Tree.get_SelNode() != null && PBOM_Ex_Tree.get_SelNode() != ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0))
				{
					PBOM_Ex_Tree.get_SelNode().BeginEdit();
				}
				break;
			case 0:
				if (e.get_Control())
				{
					Proc_GetDataFromClipboard(((TreeView)PBOM_Ex_Tree).get_SelectedNode());
				}
				break;
			case 2:
				if (e.get_Control())
				{
					Proc_SendDataToClipboard((DragDropEffects)2);
				}
				break;
			case 1:
				break;
			}
		}

		private void PBOM_Ex_Tree_OnContextMenuEvent(object sender, PBOM_ContextEventArgs e)
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Invalid comparison between Unknown and I4
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			switch (e.Message)
			{
			case PBOM_ContextMessage.Open:
				Proc_ViewArchiveItem(e.SelectedNode);
				break;
			case PBOM_ContextMessage.Rename:
				if (((TreeView)PBOM_Ex_Tree).get_LabelEdit() && e.SelectedNode != null && e.SelectedNode != ((TreeView)PBOM_Ex_Tree).get_Nodes().get_Item(0))
				{
					e.SelectedNode.BeginEdit();
				}
				break;
			case PBOM_ContextMessage.Extract:
			{
				FolderBrowserDialog val3 = new FolderBrowserDialog();
				if ((int)((CommonDialog)val3).ShowDialog() == 1)
				{
					_WorkInProgress.Show();
					Hashtable hashtable3 = new Hashtable();
					foreach (MWTreeNodeWrapper value in e.SelectedNodes.Values)
					{
						MWTreeNodeWrapper val4 = value;
						Proc_GetNodeName(val4.get_Node(), hashtable3);
					}
					_ActivePboFile.ExtractPboEntry(hashtable3, val3.get_SelectedPath(), true);
					_WorkInProgress.Hide();
				}
				((Component)val3).Dispose();
				break;
			}
			case PBOM_ContextMessage.ExtractCurrent:
			{
				_WorkInProgress.Show();
				Hashtable hashtable2 = new Hashtable();
				foreach (MWTreeNodeWrapper value2 in e.SelectedNodes.Values)
				{
					MWTreeNodeWrapper val2 = value2;
					Proc_GetNodeName(val2.get_Node(), hashtable2);
				}
				_ActivePboFile.ExtractPboEntry(hashtable2, _ActivePboFile.get_FileDirectory(), true);
				_WorkInProgress.Hide();
				break;
			}
			case PBOM_ContextMessage.ExtractFolder:
			{
				_WorkInProgress.Show();
				string text = $"{_ActivePboFile.get_FileDirectory()}{Path.GetFileNameWithoutExtension(_ActivePboFile.get_ShortFileName())}";
				Hashtable hashtable = new Hashtable();
				foreach (MWTreeNodeWrapper value3 in e.SelectedNodes.Values)
				{
					MWTreeNodeWrapper val = value3;
					Proc_GetNodeName(val.get_Node(), hashtable);
				}
				_ActivePboFile.ExtractPboEntry(hashtable, text, true);
				_WorkInProgress.Hide();
				break;
			}
			case PBOM_ContextMessage.Cut:
				Proc_SendDataToClipboard((DragDropEffects)2);
				break;
			case PBOM_ContextMessage.Copy:
				Proc_SendDataToClipboard((DragDropEffects)1);
				break;
			case PBOM_ContextMessage.Paste:
				Proc_GetDataFromClipboard(e.SelectedNode);
				break;
			case PBOM_ContextMessage.Delete:
				Proc_RemoveItems(e.SelectedNodes);
				break;
			}
		}

		private void PBOM_Ex_Tree_OnFileDeleted(object sender, PBOM_DropNodeEventArgs e)
		{
			Proc_RemoveItems(e.NodesToDrop);
		}

		private void PBOM_Ex_Tree_OnTreeViewDropAccept(object sender, PBOM_DropNodeEventArgs e)
		{
			Proc_PreExtractFiles(e.NodesToDrop);
		}

		private void PBOM_Ex_Tree_OnTreeViewDragStart(object sender, PBOM_DragFileEventArgs e)
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			string[] array = new string[e.FilesToDrag.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = $"{_TempPath}{e.FilesToDrag[i]}";
			}
			_CutWrapper.Close();
			Proc_CreateDummyFiles();
			DataObject val = new DataObject();
			val.SetData(e.Signature, (object)"ok");
			val.SetData(DataFormats.FileDrop, (object)array);
			((Control)this).DoDragDrop((object)val, (DragDropEffects)3);
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!File.Exists(text) && !Directory.Exists(text))
				{
					Proc_RemoveItems(e.DragNodes);
					break;
				}
			}
		}

		private void PBOM_Ex_Tree_OnTreeViewDragDrop(object sender, PBOM_DropFileEventArgs e)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Proc_GetDataFromShell(e.HoverNode, e.FilesToDrop, e.Effect);
		}

		protected override void WndProc(ref Message m)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			((Form)this).WndProc(ref m);
			if (((Message)(ref m)).get_Msg() == 274 && ((int)((Message)(ref m)).get_WParam() == 61728 || (int)((Message)(ref m)).get_WParam() == 61488) && this.OnWindowStateChanged != null)
			{
				PBOM_FormStateChangeEventArgs e = new PBOM_FormStateChangeEventArgs(((Form)this).get_WindowState());
				this.OnWindowStateChanged(this, e);
			}
			if (((Message)(ref m)).get_Msg() == 163 && this.OnWindowStateChanged != null)
			{
				PBOM_FormStateChangeEventArgs e2 = new PBOM_FormStateChangeEventArgs(((Form)this).get_WindowState());
				this.OnWindowStateChanged(this, e2);
			}
		}
	}
}
