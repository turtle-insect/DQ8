using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
	class Place
	{
		private readonly uint ID;

		public String Name { get; set; }

		public Place(uint id)
		{
			ID = id;
		}

		public bool Arrival
		{
			get
			{
				return SaveData.Instance().ReadBit(0x2B34 + ID / 8, ID % 8);
			}

			set
			{
				SaveData.Instance().WriteBit(0x2B34 + ID / 8, ID % 8, value);
			}
		}
	}
}
