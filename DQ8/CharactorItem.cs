using System.ComponentModel;

namespace DQ8
{
	class CharactorItem : INotifyPropertyChanged
	{
		private uint mAddress;
		public event PropertyChangedEventHandler PropertyChanged;

		public CharactorItem(uint address)
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
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
			}
		}
	}
}
