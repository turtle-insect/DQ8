using System;
using System.Collections.ObjectModel;

namespace DQ8
{
	class Bag
	{
		public ObservableCollection<BagItem> Items { get; set; } = new ObservableCollection<BagItem>();

		public Bag()
		{
			Load();
		}

		private void Load()
		{
			Items.Clear();
			SaveData saveData = SaveData.Instance();
			for (uint i = 0; i < Util.ItemCount; i++)
			{
				BagItem item = new BagItem(Util.ItemAddress + i * 4);
				item.ChangeItem += Item_ChangeItem;
				Items.Add(item);
			}
		}

		private void Item_ChangeItem(object sender, EventArgs e)
		{
			BagItem target = sender as BagItem;
			if (target == null) return;
			if (target.ID != 0) return;

			for (uint i = 0; i < Util.ItemCount; i++)
			{
				if (Items[(int)i] == target)
				{
					SaveData saveData = SaveData.Instance();
					for (uint j = i; j < Util.ItemCount - 1; j++)
					{
						saveData.Copy(Util.ItemAddress + (j + 1) * 4, Util.ItemAddress + j * 4, 4);
					}
					Load();
					break;
				}
			}
		}
	}
}
