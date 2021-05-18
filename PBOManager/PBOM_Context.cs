using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MWCommon;
using MWControls;

namespace PBOManager
{
	internal class PBOM_Context
	{
		public delegate void PBOMContextEvent(object Sender, PBOM_ContextEventArgs e);

		private bool _IsActive;

		private string _ExtractToFolder;

		private string _ExtractToFolderMenu;

		private MWTreeView _TreeViewControl;

		private ContextMenuStrip _MenuStrip;

		private TreeNode _ClickedNode;

		public MWTreeView TreeViewControl
		{
			get
			{
				return _TreeViewControl;
			}
			set
			{
				if (_IsActive)
				{
					Detach();
				}
				_TreeViewControl = value;
			}
		}

		public ContextMenuStrip MenuStrip
		{
			get
			{
				return _MenuStrip;
			}
			set
			{
				if (_IsActive)
				{
					Detach();
				}
				_MenuStrip = value;
			}
		}

		public bool IsActive => _IsActive;

		public string ExtractToFolder
		{
			get
			{
				return _ExtractToFolder;
			}
			set
			{
				_ExtractToFolder = value;
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").set_Text(string.Format(_ExtractToFolderMenu, _ExtractToFolder));
			}
		}

		public event PBOMContextEvent OnContextMenuEvent;

		public PBOM_Context()
		{
			_ExtractToFolderMenu = ((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").get_Text();
		}

		public PBOM_Context(MWTreeView TreeViewControl, ContextMenuStrip ContextMenu, string ExtractToFolder)
		{
			_TreeViewControl = TreeViewControl;
			_MenuStrip = ContextMenu;
			_ExtractToFolder = ExtractToFolder;
			_ExtractToFolderMenu = ((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").get_Text();
			((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").set_Text(string.Format(_ExtractToFolderMenu, _ExtractToFolder));
		}

		public void Attach()
		{
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			if (_TreeViewControl == null)
			{
				throw new Exception("\"TreeViewControl\" member should be specified before calling \"Attach()\" method");
			}
			if (_MenuStrip == null)
			{
				throw new Exception("\"MenuStrip\" member should be specified before calling \"Attach()\" method");
			}
			if (!_IsActive)
			{
				_IsActive = true;
				((Control)_TreeViewControl).set_ContextMenuStrip(_MenuStrip);
				((Control)_TreeViewControl).add_MouseDown(new MouseEventHandler(_TreeViewControl_MouseDown));
				((ToolStripDropDown)_MenuStrip).add_Opening(new CancelEventHandler(_MenuStrip_Opening));
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").add_Click((EventHandler)_MenuStrip_Open_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").add_Click((EventHandler)_MenuStrip_Rename_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtract").add_Click((EventHandler)_MenuStrip_Extract_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractCurrent").add_Click((EventHandler)_MenuStrip_ExtractCurrent_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").add_Click((EventHandler)_MenuStrip_ExtractFolder_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCut").add_Click((EventHandler)_MenuStrip_Cut_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCopy").add_Click((EventHandler)_MenuStrip_Copy_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextPaste").add_Click((EventHandler)_MenuStrip_Paste_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextDelete").add_Click((EventHandler)_MenuStrip_Delete_Click);
			}
		}

		public void Detach()
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			if (_TreeViewControl == null)
			{
				throw new Exception("\"TreeViewControl\" member should be specified before calling \"Attach()\" method");
			}
			if (_IsActive)
			{
				_IsActive = false;
				((Control)_TreeViewControl).set_ContextMenuStrip((ContextMenuStrip)null);
				((Control)_TreeViewControl).remove_MouseDown(new MouseEventHandler(_TreeViewControl_MouseDown));
				((ToolStripDropDown)_MenuStrip).remove_Opening(new CancelEventHandler(_MenuStrip_Opening));
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").remove_Click((EventHandler)_MenuStrip_Open_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").remove_Click((EventHandler)_MenuStrip_Rename_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtract").remove_Click((EventHandler)_MenuStrip_Extract_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractCurrent").remove_Click((EventHandler)_MenuStrip_ExtractCurrent_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").remove_Click((EventHandler)_MenuStrip_ExtractFolder_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCut").remove_Click((EventHandler)_MenuStrip_Cut_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCopy").remove_Click((EventHandler)_MenuStrip_Copy_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextPaste").remove_Click((EventHandler)_MenuStrip_Paste_Click);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextDelete").remove_Click((EventHandler)_MenuStrip_Delete_Click);
			}
		}

		private void ContextMenuEvent(PBOM_ContextMessage Msg)
		{
			if (this.OnContextMenuEvent != null)
			{
				PBOM_ContextEventArgs e = new PBOM_ContextEventArgs(_TreeViewControl.get_SelNodes(), _ClickedNode, Msg);
				this.OnContextMenuEvent(this, e);
			}
		}

		private void _MenuStrip_Opening(object sender, CancelEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			int num = 0;
			TreeNode val = new TreeNode();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			Hashtable selNodes = _TreeViewControl.get_SelNodes();
			foreach (MWTreeNodeWrapper value in selNodes.Values)
			{
				MWTreeNodeWrapper val2 = value;
				if (val2.get_Node() == ((TreeView)_TreeViewControl).get_Nodes().get_Item(0))
				{
					flag = true;
				}
				if (val2.get_Node().get_ToolTipText() == "folder")
				{
					flag2 = true;
				}
				if (num != 0 && val != val2.get_Node().get_Parent())
				{
					flag3 = true;
				}
				if (num == 0)
				{
					val = val2.get_Node().get_Parent();
				}
				num++;
			}
			if (flag3)
			{
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtract").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractCurrent").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCut").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCopy").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextPaste").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextDelete").set_Enabled(false);
				return;
			}
			if (selNodes.Count != 1)
			{
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").set_Enabled(false);
			}
			else
			{
				if (!flag && !flag2)
				{
					((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").set_Enabled(true);
				}
				else
				{
					((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Open").set_Enabled(false);
				}
				if (!flag)
				{
					((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").set_Enabled(true);
				}
				else
				{
					((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_Context_Rename").set_Enabled(false);
				}
			}
			if (!flag)
			{
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtract").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractCurrent").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCut").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCopy").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextPaste").set_Enabled(true);
			}
			else
			{
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtract").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractCurrent").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextExtractFolder").set_Enabled(true);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCut").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextCopy").set_Enabled(false);
				((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextPaste").set_Enabled(true);
			}
			((ToolStrip)_MenuStrip).get_Items().get_Item("PBOM_Ex_ContextDelete").set_Enabled(true);
		}

		private void _TreeViewControl_MouseDown(object sender, MouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Invalid comparison between Unknown and I4
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			if ((int)e.get_Button() != 2097152)
			{
				return;
			}
			_ClickedNode = ((TreeView)_TreeViewControl).GetNodeAt(e.get_X(), e.get_Y());
			if (_ClickedNode == null)
			{
				return;
			}
			foreach (MWTreeNodeWrapper value in _TreeViewControl.get_SelNodes().Values)
			{
				MWTreeNodeWrapper val = value;
				if (val.get_Node() == _ClickedNode)
				{
					return;
				}
			}
			Hashtable hashtable = new Hashtable();
			MWTreeNodeWrapper val2 = new MWTreeNodeWrapper(_ClickedNode);
			hashtable.Add(((object)val2).GetHashCode(), val2);
			_TreeViewControl.set_SelNodes(hashtable);
			_TreeViewControl.set_SelNode(_ClickedNode);
		}

		private void _MenuStrip_Open_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Open);
		}

		private void _MenuStrip_Rename_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Rename);
		}

		private void _MenuStrip_Extract_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Extract);
		}

		private void _MenuStrip_ExtractCurrent_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.ExtractCurrent);
		}

		private void _MenuStrip_ExtractFolder_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.ExtractFolder);
		}

		private void _MenuStrip_Cut_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Cut);
		}

		private void _MenuStrip_Copy_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Copy);
		}

		private void _MenuStrip_Paste_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Paste);
		}

		private void _MenuStrip_Delete_Click(object sender, EventArgs e)
		{
			ContextMenuEvent(PBOM_ContextMessage.Delete);
		}
	}
}
