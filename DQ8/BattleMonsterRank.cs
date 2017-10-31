using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
	class BattleMonsterRank
	{
		private readonly uint mNumber;

		public BattleMonsterRank(uint number)
		{
			mNumber = number;
		}

		public String Name { get; set; }
		public bool Clear
		{
			get
			{
				return SaveData.Instance().ReadBit(0x0481 + (7 + mNumber) / 8, (7 + mNumber) % 8);
			}

			set
			{
				SaveData.Instance().WriteBit(0x0481 + (7 + mNumber) / 8, (7 + mNumber) % 8, value);
			}
		}
	}
}
