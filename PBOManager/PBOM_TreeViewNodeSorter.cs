using System.Collections;
using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_TreeViewNodeSorter : IComparer
	{
		public int Compare(object x, object y)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			TreeNode val = (TreeNode)x;
			TreeNode val2 = (TreeNode)y;
			if (val.get_ImageIndex() != 1 && val2.get_ImageIndex() == 1)
			{
				return 1;
			}
			if (val.get_ImageIndex() == 1 && val2.get_ImageIndex() != 1)
			{
				return -1;
			}
			return string.Compare(val.get_Name(), val2.get_Name());
		}
	}
}
