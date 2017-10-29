using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
	class BattleMonsterInfo : ILineAnalysis
	{
		public uint ID { get; private set; }
		public String Name { get; private set; }
		public String Street { get; private set; }
		public String Kind { get; private set; }
		public bool Line(string[] oneLine)
		{
			if (oneLine.Length != 4) return false;
			ID = Convert.ToUInt32(oneLine[0]);
			Name = oneLine[1];
			Street = oneLine[2];
			Kind = oneLine[3];
			return true;
		}
	}
}
