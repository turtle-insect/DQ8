using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
    class Item
    {
		private readonly uint mID;

		public Item(uint id)
		{
			mID = id;
		}

		public String Name { get; set; }

		public bool Get
		{
			get
			{
				return SaveData.Instance().ReadBit(0x11B0 + mID / 8, mID % 8);
			}

			set
			{
				SaveData.Instance().WriteBit(0x11B0 + mID / 8, mID % 8, value);
			}
		}
	}
}
