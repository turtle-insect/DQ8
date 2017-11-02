using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
	class Monster
	{
		private readonly uint mAddress;

		public Monster(uint ID)
		{
			mAddress = ID * 8 + 0x2D9C;
		}

		public String Name { get; set; }

		public uint Count
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 2);
			}

			set
			{
				Util.WriteNumber(mAddress, 2, value, 0, 999);
			}
		}
	}
}
