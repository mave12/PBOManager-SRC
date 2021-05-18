using System.Collections;

namespace PBOManager
{
	public class PBOM_DropNodeEventArgs
	{
		private Hashtable _NodesToDrop;

		public Hashtable NodesToDrop => _NodesToDrop;

		public PBOM_DropNodeEventArgs(Hashtable Nodes)
		{
			_NodesToDrop = Nodes;
		}
	}
}
