using System;
using System.Collections.Generic;

namespace DQ8
{
	class Info
	{
		private static Info mThis;
		public List<ItemInfo> Items { get; private set; } = new List<ItemInfo>();

		private Info() { }

		public static Info Instance()
		{
			if (mThis == null)
			{
				mThis = new Info();
				mThis.Init();
			}
			return mThis;
		}

		public ItemInfo Item(uint id)
		{
			int min = 0;
			int max = Items.Count;
			for (; min < max;)
			{
				int mid = (min + max) / 2;
				if (Items[mid].ID == id) return Items[mid];
				else if (Items[mid].ID > id) max = mid;
				else min = mid + 1;
			}
			return null;
		}

		private void Init()
		{
			AppendList("info\\item.txt", Items);
		}

		private void AppendList(String filename, List<ItemInfo> items)
		{
			if (!System.IO.File.Exists(filename)) return;
			String[] lines = System.IO.File.ReadAllLines(filename);
			foreach (String line in lines)
			{
				if (line.Length < 3) continue;
				if (line[0] == '#') continue;
				String[] values = line.Split('\t');
				if (values.Length < 2) continue;
				if (String.IsNullOrEmpty(values[0])) continue;
				if (String.IsNullOrEmpty(values[1])) continue;
				uint id = 0;
				if (values[0].Length > 1 && values[0][1] == 'x') id = Convert.ToUInt32(values[0], 16);
				else id = Convert.ToUInt32(values[0]);
				items.Add(new ItemInfo() { ID = id, Name = values[1] });
			}
		}
	}
}
