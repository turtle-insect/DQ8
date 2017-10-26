using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8
{
    class Order
    {
		private readonly uint mAddress;

		public Order(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 1);
			}

			set
			{
				SaveData.Instance().WriteNumber(mAddress, 1, value);
			}
		}
	}
}
