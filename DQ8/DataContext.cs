using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ8
{
	class DataContext
	{
		public Info Info { get; set; } = Info.Instance();
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Zoom> Destination { get; set; } = new ObservableCollection<Zoom>();
		public ObservableCollection<Row> Rows { get; set; } = new ObservableCollection<Row>();
		public Bag Bag { get; set; } = new Bag();

		public DataContext()
		{
			// 人物
			List<List<String>> skills = new List<List<string>>()
			{
				new List<String>{"剣スキル", "ヤリスキル", "ブーメラン", "格闘スキル", "ゆうき" },
				new List<String>{"オノスキル", "打撃スキル", "鎌スキル", "格闘スキル", "にんじょう" },
				new List<String>{"短剣スキル", "ムチスキル", "杖スキル", "格闘スキル", "おいろけ" },
				new List<String>{"剣スキル", "弓スキル", "杖スキル", "格闘スキル", "カリスマ" },
				new List<String>{"扇スキル", "ムチスキル", "短剣スキル", "格闘スキル", "アウトロー" },
				new List<String>{"爪スキル", "打撃スキル", "ブーメラン", "格闘スキル", "ねっけつ" },
			};
			foreach (var member in Info.Instance().Rows)
			{
				if (member.Value == 0xFF) continue;
				Charactor ch = new Charactor(0x11EC + member.Value * 64, 0xA10 + member.Value * 34, skills[(int)member.Value]);
				ch.Name = member.Name;
				Party.Add(ch);
			}

			// ルーラ
			foreach (var item in Info.Instance().Zooms)
			{
				Zoom zoom = new Zoom(item.Value);
				zoom.Name = item.Name;
				Destination.Add(zoom);
			}

			// パーティ並び
			for (uint i = 0; i < 6; i++)
			{
				Row row = new Row(0x11A0 + i);
				Rows.Add(row);
			}
		}

		public uint PlayHour
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x2C48, 4) / 3600;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber(0x2C48, 4) % 3600;
				SaveData.Instance().WriteNumber(0x2C48, 4, value * 3600 + number);
			}
		}

		public uint PlayMinute
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x2C48, 4) % 3600 / 60;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber(0x2C48, 4);
				number = number / 3600 * 3600 + number % 60;
				SaveData.Instance().WriteNumber(0x2C48, 4, value * 60 + number);
			}
		}

		public uint PlaySecond
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x2C48, 4) % 60;
			}
			set
			{
				uint number = SaveData.Instance().ReadNumber(0x2C48, 4);
				number = number / 60 * 60;
				SaveData.Instance().WriteNumber(0x2C48, 4, value + number);
			}
		}

		public String HeroName
		{
			get
			{
				return SaveData.Instance().ReadUnicode(0x09F8, 8);
			}

			set
			{
				SaveData.Instance().WriteUnicode(0x09F8, 8, value);
			}
		}

		public uint BattleCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x37FC, 4);
			}
			set
			{
				Util.WriteNumber(0x37FC, 4, value, 0, 9999999);
			}
		}

		public uint GoldHand
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x0A08, 4);
			}
			set
			{
				Util.WriteNumber(0x0A08, 4, value, 0, 9999999);
			}
		}

		public uint KillCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3800, 4);
			}
			set
			{
				Util.WriteNumber(0x3800, 4, value, 0, 9999999);
			}
		}

		public uint WardOffCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3804, 4);
			}
			set
			{
				Util.WriteNumber(0x3804, 4, value, 0, 9999999);
			}
		}

		public uint EscapeCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3808, 4);
			}
			set
			{
				Util.WriteNumber(0x3808, 4, value, 0, 9999999);
			}
		}

		public uint VictoryCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x380C, 4);
			}
			set
			{
				Util.WriteNumber(0x380C, 4, value, 0, 9999999);
			}
		}

		public uint AnnihilationCount
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3810, 4);
			}
			set
			{
				Util.WriteNumber(0x3810, 4, value, 0, 9999999);
			}
		}

		public uint TotalGold
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3814, 4);
			}
			set
			{
				Util.WriteNumber(0x3814, 4, value, 0, 9999999);
			}
		}

		public uint MaxDamage
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x381C, 4);
			}
			set
			{
				Util.WriteNumber(0x381C, 4, value, 0, 9999999);
			}
		}
	}
}
