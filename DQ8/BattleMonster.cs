using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
    class BattleMonster
    {
		private readonly uint mAddress;

		public BattleMonster(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 2);
			}

			set
			{
				SaveData.Instance().WriteNumber(mAddress, 2, value);
			}
		}

		public uint HP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 2, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 2, 2, value, 0, 999);
			}
		}

		public uint MP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 4, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 4, 2, value, 0, 999);
			}
		}
	}
}
