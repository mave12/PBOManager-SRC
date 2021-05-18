using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MWCommon;
using MWControls;

namespace PBOManager
{
	public class PBOM_DragDrop : IDisposable
	{
		public delegate void PBOMTreeViewDragStart(object sender, PBOM_DragFileEventArgs e);

		public delegate void PBOMTreeViewDragDrop(object sender, PBOM_DropFileEventArgs e);

		public delegate void PBOMTreeViewDropAccept(object sender, PBOM_DropNodeEventArgs e);

		private const int _SHIFT = 4;

		private const int _CTRL = 8;

		private const int _ALT = 32;

		private bool _Disposed;

		private bool _IsOpen;

		private bool _DnDAutoExpandNodes = true;

		private bool _DnDAcceptDragDrop;

		private string _AppSignature;

		private MouseButtons _DnDMouseButton;

		private Timer _DnDExpandNodeTimer;

		private MWTreeView _TreeViewControl;

		private Hashtable _DnDCurrentDragNode;

		private TreeNode _DnDCurrentHoverNode;

		private TreeNode _DnDPreviousHoverNode;

		private Color _NodeForeColorOnHover = SystemColors.get_HighlightText();

		private Color _NodeForeColorAfterHover = SystemColors.get_WindowText();

		private Color _NodeBackColorOnHover = SystemColors.get_MenuHighlight();

		private Color _NodeBackColorAfterHover = SystemColors.get_Window();

		private Color _NodeForeColorOnDrag = SystemColors.get_WindowText();

		private Color _NodeForeColorAfterDrag = SystemColors.get_WindowText();

		private Color _NodeBackColorOnDrag = SystemColors.get_InactiveCaption();

		private Color _NodeBackColorAfterDrag = SystemColors.get_Window();

		public MWTreeView TreeViewControl
		{
			get
			{
				return _TreeViewControl;
			}
			set
			{
				if (_IsOpen)
				{
					Close();
				}
				_TreeViewControl = value;
			}
		}

		public bool IsOpen => _IsOpen;

		public int NodeAutoExpandTime
		{
			get
			{
				return _DnDExpandNodeTimer.get_Interval();
			}
			set
			{
				_DnDExpandNodeTimer.set_Interval(value);
			}
		}

		public bool NodeAutoExpand
		{
			get
			{
				return _DnDAutoExpandNodes;
			}
			set
			{
				_DnDAutoExpandNodes = value;
			}
		}

		public Color NodeForeColorOnHover
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeForeColorOnHover;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeForeColorOnHover = value;
			}
		}

		public Color NodeForeColorAfterHover
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeForeColorAfterHover;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeForeColorAfterHover = value;
			}
		}

		public Color NodeBackColorOnHover
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeBackColorOnHover;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeBackColorOnHover = value;
			}
		}

		public Color NodeBackColorAfterHover
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeBackColorAfterHover;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeBackColorAfterHover = value;
			}
		}

		public Color NodeForeColorOnDrag
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeForeColorOnDrag;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeForeColorOnDrag = value;
			}
		}

		public Color NodeForeColorAfterDrag
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeForeColorAfterDrag;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeForeColorAfterDrag = value;
			}
		}

		public Color NodeBackColorOnDrag
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeBackColorOnDrag;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeBackColorOnDrag = value;
			}
		}

		public Color NodeBackColorAfterDrag
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _NodeBackColorAfterDrag;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				_NodeBackColorAfterDrag = value;
			}
		}

		public event PBOMTreeViewDragStart OnTreeViewDragStart;

		public event PBOMTreeViewDragDrop OnTreeViewDragDrop;

		public event PBOMTreeViewDropAccept OnTreeViewDropAccept;

		public PBOM_DragDrop()
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			_AppSignature = $"{_AppSignature}{new Random().Next()}";
			_DnDExpandNodeTimer = new Timer();
			_DnDExpandNodeTimer.set_Interval(1500);
		}

		public PBOM_DragDrop(MWTreeView TreeViewControl)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			_TreeViewControl = TreeViewControl;
			_AppSignature = $"{_AppSignature}{new Random().Next()}";
			_DnDExpandNodeTimer = new Timer();
			_DnDExpandNodeTimer.set_Interval(1500);
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
				Close();
				((Component)_DnDExpandNodeTimer).Dispose();
			}
		}

		public void Open()
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			if (_TreeViewControl == null)
			{
				throw new Exception("\"TreeViewControl\" member should be specified before calling \"Open()\" method");
			}
			if (!_IsOpen)
			{
				_IsOpen = true;
				((Control)_TreeViewControl).set_AllowDrop(true);
				((Control)_TreeViewControl).add_DragEnter(new DragEventHandler(_TreeViewControl_DragEnter));
				((Control)_TreeViewControl).add_DragLeave((EventHandler)_TreeViewControl_DragLeave);
				((Control)_TreeViewControl).add_DragOver(new DragEventHandler(_TreeViewControl_DragOver));
				((Control)_TreeViewControl).add_DragDrop(new DragEventHandler(_TreeViewControl_DragDrop));
				((TreeView)_TreeViewControl).add_ItemDrag(new ItemDragEventHandler(_TreeViewControl_ItemDrag));
				Form val = ((Control)_TreeViewControl).FindForm();
				((Control)val).add_QueryContinueDrag(new QueryContinueDragEventHandler(_TreeViewControl_QueryContinueDrag));
				_DnDExpandNodeTimer.add_Tick((EventHandler)_DnDExpandNodeTimer_OnTimer);
			}
		}

		public void Close()
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			if (_TreeViewControl == null)
			{
				throw new Exception("\"TreeViewControl\" member should be specified before calling \"Close()\" method");
			}
			if (_IsOpen)
			{
				_IsOpen = false;
				((Control)_TreeViewControl).set_AllowDrop(false);
				((Control)_TreeViewControl).remove_DragEnter(new DragEventHandler(_TreeViewControl_DragEnter));
				((Control)_TreeViewControl).remove_DragLeave((EventHandler)_TreeViewControl_DragLeave);
				((Control)_TreeViewControl).remove_DragOver(new DragEventHandler(_TreeViewControl_DragOver));
				((Control)_TreeViewControl).remove_DragDrop(new DragEventHandler(_TreeViewControl_DragDrop));
				((TreeView)_TreeViewControl).remove_ItemDrag(new ItemDragEventHandler(_TreeViewControl_ItemDrag));
				Form val = ((Control)_TreeViewControl).FindForm();
				((Control)val).remove_QueryContinueDrag(new QueryContinueDragEventHandler(_TreeViewControl_QueryContinueDrag));
				_DnDExpandNodeTimer.set_Enabled(false);
				_DnDExpandNodeTimer.remove_Tick((EventHandler)_DnDExpandNodeTimer_OnTimer);
			}
		}

		public void SyncrinizeColors()
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			if (_TreeViewControl != null)
			{
				_NodeForeColorAfterHover = ((Control)_TreeViewControl).get_ForeColor();
				_NodeBackColorAfterHover = ((Control)_TreeViewControl).get_BackColor();
				_NodeForeColorAfterDrag = ((Control)_TreeViewControl).get_ForeColor();
				_NodeBackColorAfterDrag = ((Control)_TreeViewControl).get_BackColor();
			}
		}

		public void SyncrinizeColors(MWTreeView TreeViewControl)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			if (TreeViewControl != null)
			{
				_NodeForeColorAfterHover = ((Control)TreeViewControl).get_ForeColor();
				_NodeBackColorAfterHover = ((Control)TreeViewControl).get_BackColor();
				_NodeForeColorAfterDrag = ((Control)TreeViewControl).get_ForeColor();
				_NodeBackColorAfterDrag = ((Control)TreeViewControl).get_BackColor();
			}
		}

		public void TemporalyStopNodeAutoExpand()
		{
			_DnDExpandNodeTimer.set_Enabled(false);
		}

		private void TreeViewDragStart(Hashtable DragNodes, string[] FilesToDrag, string Signature)
		{
			if (FilesToDrag != null && FilesToDrag.Length > 0)
			{
				PBOM_DragFileEventArgs e = new PBOM_DragFileEventArgs(DragNodes, FilesToDrag, Signature);
				if (this.OnTreeViewDragStart != null)
				{
					this.OnTreeViewDragStart(this, e);
				}
			}
		}

		private void TreeViewDragDrop(TreeNode HoverNode, string[] FilesToDrop, DragDropEffects Effects)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			if (FilesToDrop != null && FilesToDrop.Length > 0)
			{
				PBOM_DropFileEventArgs e = new PBOM_DropFileEventArgs(HoverNode, FilesToDrop, Effects);
				if (this.OnTreeViewDragDrop != null)
				{
					this.OnTreeViewDragDrop(this, e);
				}
			}
		}

		private void TreeViewDropAccept(Hashtable DroppedNodes)
		{
			if (DroppedNodes != null && DroppedNodes.Count > 0)
			{
				PBOM_DropNodeEventArgs e = new PBOM_DropNodeEventArgs(DroppedNodes);
				if (this.OnTreeViewDropAccept != null)
				{
					this.OnTreeViewDropAccept(this, e);
				}
			}
		}

		private void _DnDExpandNodeTimer_OnTimer(object sender, EventArgs e)
		{
			if (_DnDAutoExpandNodes && _DnDCurrentHoverNode != null)
			{
				_DnDCurrentHoverNode.Expand();
			}
		}

		private void _TreeViewControl_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Invalid comparison between Unknown and I4
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Invalid comparison between Unknown and I4
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			if (e.get_EscapePressed())
			{
				e.set_Action((DragAction)2);
			}
			else if (((e.get_KeyState() & 1) == 1 && (int)_DnDMouseButton == 1048576) || ((e.get_KeyState() & 2) == 2 && (int)_DnDMouseButton == 2097152))
			{
				e.set_Action((DragAction)0);
			}
			else if ((e.get_KeyState() & 3) == 0)
			{
				if (_DnDCurrentDragNode != null)
				{
					TreeViewDropAccept(_DnDCurrentDragNode);
				}
				else
				{
					MessageBox.Show("error");
				}
				e.set_Action((DragAction)1);
			}
			else
			{
				e.set_Action((DragAction)2);
			}
		}

		private void _TreeViewControl_DragDrop(object sender, DragEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Invalid comparison between Unknown and I4
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (((int)e.get_Effect() == 2 || (int)e.get_Effect() == 1) && e.get_Data().GetDataPresent(DataFormats.FileDrop))
			{
				string[] filesToDrop = (string[])e.get_Data().GetData(DataFormats.FileDrop);
				TreeViewDragDrop(_DnDCurrentHoverNode, filesToDrop, e.get_Effect());
			}
			_TreeViewControl_DragLeave(null, null);
		}

		private void _TreeViewControl_ItemDrag(object sender, ItemDragEventArgs e)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected O, but got Unknown
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			_DnDCurrentDragNode = _TreeViewControl.get_SelNodes();
			bool flag = false;
			foreach (MWTreeNodeWrapper value in _DnDCurrentDragNode.Values)
			{
				MWTreeNodeWrapper val = value;
				if (val.get_Node() == ((TreeView)_TreeViewControl).get_Nodes().get_Item(0))
				{
					return;
				}
				if (val.get_Node() == e.get_Item())
				{
					flag = true;
				}
			}
			if (!flag)
			{
				if (e.get_Item() == ((TreeView)_TreeViewControl).get_Nodes().get_Item(0))
				{
					return;
				}
				MWTreeNodeWrapper val2 = new MWTreeNodeWrapper((TreeNode)e.get_Item());
				_DnDCurrentDragNode = new Hashtable();
				_DnDCurrentDragNode.Add(((object)val2).GetHashCode(), val2);
				_TreeViewControl.set_SelNodes(_DnDCurrentDragNode);
			}
			int num = 0;
			int count = ((TreeView)_TreeViewControl).get_Nodes().get_Item(0).get_Text()
				.Length + 1;
			TreeNode val3 = new TreeNode();
			List<string> list = new List<string>();
			foreach (MWTreeNodeWrapper value2 in _DnDCurrentDragNode.Values)
			{
				MWTreeNodeWrapper val4 = value2;
				if (num != 0 && val3 != val4.get_Node().get_Parent())
				{
					return;
				}
				if (num == 0)
				{
					val3 = val4.get_Node().get_Parent();
				}
				list.Add(val4.get_Node().get_FullPath().Remove(0, count));
				num++;
			}
			foreach (MWTreeNodeWrapper value3 in _DnDCurrentDragNode.Values)
			{
				MWTreeNodeWrapper val5 = value3;
				val5.get_Node().set_BackColor(_NodeBackColorOnDrag);
				val5.get_Node().set_ForeColor(_NodeForeColorOnDrag);
			}
			_DnDMouseButton = e.get_Button();
			TreeViewDragStart(_DnDCurrentDragNode, list.ToArray(), _AppSignature);
			foreach (MWTreeNodeWrapper value4 in _DnDCurrentDragNode.Values)
			{
				MWTreeNodeWrapper val6 = value4;
				val6.get_Node().set_BackColor(_NodeBackColorAfterDrag);
				val6.get_Node().set_ForeColor(_NodeForeColorAfterDrag);
			}
		}

		private void _TreeViewControl_DragOver(object sender, DragEventArgs e)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Invalid comparison between Unknown and I4
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Invalid comparison between Unknown and I4
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Invalid comparison between Unknown and I4
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			if (!_DnDAcceptDragDrop)
			{
				return;
			}
			DragDropEffects val = (DragDropEffects)0;
			_DnDCurrentHoverNode = ((TreeView)_TreeViewControl).GetNodeAt(((Control)_TreeViewControl).PointToClient(new Point(e.get_X(), e.get_Y())));
			if (_DnDCurrentHoverNode == null)
			{
				_DnDCurrentHoverNode = ((TreeView)_TreeViewControl).get_Nodes().get_Item(0);
			}
			else if (_DnDCurrentHoverNode.get_ToolTipText() != "folder")
			{
				_DnDCurrentHoverNode = _DnDCurrentHoverNode.get_Parent();
			}
			val = (((e.get_KeyState() & 4) == 4 && (e.get_AllowedEffect() & 2) == 2) ? ((DragDropEffects)2) : (((e.get_KeyState() & 8) == 8 && (e.get_AllowedEffect() & 1) == 1) ? ((DragDropEffects)1) : (((e.get_AllowedEffect() & 2) != 2) ? ((DragDropEffects)0) : ((DragDropEffects)2))));
			if (_DnDCurrentHoverNode != _DnDPreviousHoverNode)
			{
				e.set_Effect(val);
				if (_DnDExpandNodeTimer.get_Enabled())
				{
					_DnDExpandNodeTimer.set_Enabled(false);
				}
				foreach (MWTreeNodeWrapper value in _DnDCurrentDragNode.Values)
				{
					MWTreeNodeWrapper val2 = value;
					if (_DnDCurrentHoverNode == val2.get_Node() || _DnDCurrentHoverNode == val2.get_Node().get_Parent())
					{
						e.set_Effect((DragDropEffects)0);
					}
					TreeNode val3 = _DnDCurrentHoverNode;
					while (val3.get_Parent() != null && val3.get_Parent() != ((TreeView)_TreeViewControl).get_Nodes().get_Item(0))
					{
						if (val3.get_Parent() == val2.get_Node())
						{
							e.set_Effect((DragDropEffects)0);
						}
						val3 = val3.get_Parent();
					}
				}
				if (_DnDPreviousHoverNode != null && _DnDPreviousHoverNode.get_BackColor() != _NodeBackColorOnDrag)
				{
					_DnDPreviousHoverNode.set_BackColor(_NodeBackColorAfterHover);
					_DnDPreviousHoverNode.set_ForeColor(_NodeForeColorAfterHover);
				}
				if (_DnDCurrentHoverNode.get_BackColor() != _NodeBackColorOnDrag)
				{
					_DnDCurrentHoverNode.set_BackColor(_NodeBackColorOnHover);
					_DnDCurrentHoverNode.set_ForeColor(_NodeForeColorOnHover);
				}
				_DnDPreviousHoverNode = _DnDCurrentHoverNode;
			}
			else
			{
				if (!_DnDCurrentHoverNode.get_IsExpanded())
				{
					_DnDExpandNodeTimer.set_Enabled(true);
				}
				if ((int)e.get_Effect() != 0)
				{
					e.set_Effect(val);
				}
			}
		}

		private void _TreeViewControl_DragLeave(object sender, EventArgs e)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			if (_DnDCurrentHoverNode != null)
			{
				_DnDCurrentHoverNode.set_BackColor(_NodeBackColorAfterHover);
				_DnDCurrentHoverNode.set_ForeColor(_NodeForeColorAfterHover);
				_DnDCurrentHoverNode = null;
			}
			if (_DnDPreviousHoverNode != null)
			{
				_DnDPreviousHoverNode.set_BackColor(_NodeBackColorAfterHover);
				_DnDPreviousHoverNode.set_ForeColor(_NodeForeColorAfterHover);
				_DnDPreviousHoverNode = null;
			}
			_DnDExpandNodeTimer.set_Enabled(false);
		}

		private void _TreeViewControl_DragEnter(object sender, DragEventArgs e)
		{
			((TreeView)_TreeViewControl).set_SelectedNode((TreeNode)null);
			if (e.get_Data().GetDataPresent(DataFormats.FileDrop))
			{
				_DnDAcceptDragDrop = true;
				if (!e.get_Data().GetDataPresent(_AppSignature))
				{
					_TreeViewControl.set_SelNodes((Hashtable)null);
					_DnDCurrentDragNode.Clear();
				}
			}
			else
			{
				_DnDAcceptDragDrop = false;
			}
		}
	}
}
