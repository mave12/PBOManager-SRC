using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_DropFileEventArgs
	{
		private TreeNode _HoverNode;

		private string[] _FilesToDrop;

		private DragDropEffects _Effect;

		public TreeNode HoverNode => _HoverNode;

		public string[] FilesToDrop => _FilesToDrop;

		public DragDropEffects Effect => _Effect;

		public PBOM_DropFileEventArgs(TreeNode HoverNode, string[] Files, DragDropEffects Effect)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			_HoverNode = HoverNode;
			_FilesToDrop = Files;
			_Effect = Effect;
		}
	}
}
