using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ8
{
	class Charactor
    {
		private readonly uint mStatusAddress;
		private readonly uint mItemAddress;

		public ObservableCollection<CharactorItem> Items { get; set; } = new ObservableCollection<CharactorItem>();
		public List<Skill> Skills { get; set; } = new List<Skill>();
		public String Name { get; set; }

		public Charactor(uint statusAddress, uint itemAddress, List<String> skillNames)
		{
			mStatusAddress = statusAddress;
			mItemAddress = itemAddress;
			for (uint i = 0; i < skillNames.Count; i++)
			{
				Skill skill = new Skill(mStatusAddress + 0x2C + i * 2);
				skill.Name = skillNames[(int)i];
				Skills.Add(skill);
			}
			for(uint i = 0; i < 12; i++)
			{
				Items.Add(new CharactorItem(itemAddress + i * 2));
			}
		}

		public uint HP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress, 2, value, 0, 999);
			}
		}

		public uint MP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x08, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x08, 2, value, 0, 999);
			}
		}

		public uint Lv
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x14, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x14, 2, value, 1, 99);
			}
		}

		public uint Exp
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x0C, 4);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x0C, 4, value, 0, 9999999);
			}
		}

		public uint Power
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x16, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x16, 2, value, 0, 999);
			}
		}

		public uint Defense
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x18, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x18, 2, value, 0, 999);
			}
		}

		public uint Speed
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x1A, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x1A, 2, value, 0, 999);
			}
		}

		public uint Cool
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x1C, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x1C, 2, value, 0, 999);
			}
		}

		public uint HPPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x20, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x20, 2, value, 0, 999);
			}
		}

		public uint MPPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x22, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x22, 2, value, 0, 999);
			}
		}

		public uint PowerPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x24, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x24, 2, value, 0, 999);
			}
		}

		public uint DefensePlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x26, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x26, 2, value, 0, 999);
			}
		}

		public uint SpeedPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x28, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x28, 2, value, 0, 999);
			}
		}

		public uint CoolPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x2A, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x2A, 2, value, 0, 999);
			}
		}

		public uint SkillPlus
		{
			get
			{
				return SaveData.Instance().ReadNumber(mStatusAddress + 0x36, 2);
			}

			set
			{
				Util.WriteNumber(mStatusAddress + 0x36, 2, value, 0, 999);
			}
		}

		public int EquipmentWeapon
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber(mItemAddress + 0x18, 2);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber(mStatusAddress + 0x18, 2, num, 0, 0xFFFF);
			}
		}

		public int EquipmentArmor
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber(mItemAddress + 0x1A, 2);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber(mStatusAddress + 0x1A, 2, num, 0, 0xFFFF);
			}
		}

		public int EquipmentShield
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber(mItemAddress + 0x1C, 2);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber(mStatusAddress + 0x1C, 2, num, 0, 0xFFFF);
			}
		}

		public int EquipmentHelmet
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber(mItemAddress + 0x1E, 2);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber(mStatusAddress + 0x1E, 2, num, 0, 0xFFFF);
			}
		}

		public int EquipmentAccessory
		{
			get
			{
				int value = (int)SaveData.Instance().ReadNumber(mItemAddress + 0x20, 2);
				if (value == 0xFFFF) value = -1;
				return value;
			}

			set
			{
				uint num = (uint)value;
				if (value == -1) num = 0xFFFF;
				Util.WriteNumber(mStatusAddress + 0x20, 2, num, 0, 0xFFFF);
			}
		}
	}
}
