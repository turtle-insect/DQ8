﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ8
{
	class DataContext
	{
		public Info Info { get; set; } = Info.Instance();
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Place> Places { get; set; } = new ObservableCollection<Place>();
		public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
		public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
		public ObservableCollection<Monster> Monsters { get; set; } = new ObservableCollection<Monster>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<BattleMonster> BattleLoadMonsters { get; set; } = new ObservableCollection<BattleMonster>();
		public ObservableCollection<BattleMonsterRank> Ranks { get; set; } = new ObservableCollection<BattleMonsterRank>();
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
			foreach (var member in Info.Instance().Orders)
			{
				if (member.Value == 0xFF) continue;
				Charactor ch = new Charactor(0x11EC + member.Value * 64, 0xA10 + member.Value * 34, skills[(int)member.Value]);
				ch.Name = member.Name;
				Party.Add(ch);
			}

			// ルーラ
			foreach (var item in Info.Instance().Places)
			{
				Place zoom = new Place(item.Value);
				zoom.Name = item.Name;
				Places.Add(zoom);
			}

			// パーティ並び
			for (uint i = 0; i < 6; i++)
			{
				Orders.Add(new Order(0x11A0 + i));
			}

			// 錬金釜
			foreach (var recipe in Info.Instance().Recipes)
			{
				Recipes.Add(new Recipe(recipe.Value) { Name = recipe.Name });
			}

			// モンスター図鑑
			foreach (var monster in Info.Instance().Monsters)
			{
				Monsters.Add(new Monster(monster.Value) { Name = monster.Name });
			}

			// アイテム図鑑
			foreach (var item in Info.Instance().Items)
			{
				if (item.Value == 0) continue;
				Items.Add(new Item(item.Value) { Name = item.Name });
			}

			// バトルロードモンスター
			for (uint i = 0; i < 24; i++)
			{
				BattleLoadMonsters.Add(new BattleMonster(0x13F0 + i * 8));
			}

			String[] names = { "G", "F", "E", "D", "C", "B", "A", "S", "SS" };
			for (uint i = 0; i < names.Length; i++)
			{
				Ranks.Add(new BattleMonsterRank(i) { Name = "ランク" + names[i] });
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
				Util.WriteNumber(0x0A08, 4, value, 0, 99999999);
			}
		}

		public uint GoldBank
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x0A0C, 4);
			}
			set
			{
				Util.WriteNumber(0x0A0C, 4, value, 0, 99999000);
			}
		}

		public uint CasinoCoin
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x1564, 4);
			}
			set
			{
				Util.WriteNumber(0x1564, 4, value, 0, 99999999);
			}
		}

		public uint SmallMedal
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x2B64, 4);
			}
			set
			{
				Util.WriteNumber(0x2B64, 4, value, 0, 9999999);
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

		public String TermName1
		{
			get
			{
				return SaveData.Instance().ReadUnicode(0x13A8, 18);
			}

			set
			{
				SaveData.Instance().WriteUnicode(0x13A8, 18, value);
			}
		}

		public String TermName2
		{
			get
			{
				return SaveData.Instance().ReadUnicode(0x13CC, 18);
			}

			set
			{
				SaveData.Instance().WriteUnicode(0x13CC, 18, value);
			}
		}

		public uint Term11
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13C0, 1);
			}
			set
			{
				Util.WriteNumber(0x13C0, 1, value, 0, 23);
			}
		}

		public uint Term12
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13C2, 1);
			}
			set
			{
				Util.WriteNumber(0x13C2, 1, value, 0, 23);
			}
		}

		public uint Term13
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13C4, 1);
			}
			set
			{
				Util.WriteNumber(0x13C4, 1, value, 0, 23);
			}
		}

		public uint Term21
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13E4, 1);
			}
			set
			{
				Util.WriteNumber(0x13E4, 1, value, 0, 23);
			}
		}

		public uint Term22
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13E6, 1);
			}
			set
			{
				Util.WriteNumber(0x13E6, 1, value, 0, 23);
			}
		}

		public uint Term23
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x13E8, 1);
			}
			set
			{
				Util.WriteNumber(0x13E8, 1, value, 0, 23);
			}
		}

		public bool Alchemy
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x2B56, 1) == 1;
			}

			set
			{
				SaveData.Instance().WriteNumber(0x2B56, 1, value ? 1U : 0);
			}
		}

		public bool TermMake
		{
			get
			{
				return SaveData.Instance().ReadBit(0x0100, 2);
			}

			set
			{
				SaveData.Instance().WriteBit(0x0100, 2, value);
			}
		}

		public bool TermCall
		{
			get
			{
				return SaveData.Instance().ReadBit(0x04D6, 0);
			}

			set
			{
				SaveData.Instance().WriteBit(0x04D6, 0, value);
			}
		}
	}
}
