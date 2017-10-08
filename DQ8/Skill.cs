using System;

namespace DQ8
{
	class Skill
    {
		private readonly uint mAddress;
		public String Name { get; set; }

		public uint Value
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 2);
			}

			set
			{
				Util.WriteNumber(mAddress, 2, value, 0, 100);
			}
		}

		public Skill(uint address)
		{
			mAddress = address;
		}
	}
}
