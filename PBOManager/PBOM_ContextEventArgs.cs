using System.Collections;
using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_ContextEventArgs
	{
		private PBOM_ContextMessage _Message;

		private Hashtable _SelectedNodes;

		private TreeNode _SelectedNode;

		public Hashtable SelectedNodes => _SelectedNodes;

		public TreeNode SelectedNode => _SelectedNode;

		public PBOM_ContextMessage Message => _Message;

		public PBOM_ContextEventArgs(Hashtable Nodes, TreeNode Node, PBOM_ContextMessage Msg)
		{
			_SelectedNodes = Nodes;
			_SelectedNode = Node;
			_Message = Msg;
		}
	}
}
