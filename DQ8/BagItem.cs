using System;
using System.ComponentModel;

namespace DQ8
{
	class BagItem : INotifyPropertyChanged
	{
		private uint mAddress;
		public event EventHandler ChangeItem;
		public event PropertyChangedEventHandler PropertyChanged;

		public BagItem(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 2);
			}
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 2, value);
				ChangeItem?.Invoke(this, null);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
			}
		}
		public uint Count
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 2, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 2, 2, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
	}
}
