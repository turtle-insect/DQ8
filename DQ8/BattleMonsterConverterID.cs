using System;
using System.Globalization;
using System.Windows.Data;
using System.Collections.Generic;

namespace DQ8
{
	class BattleMonsterConverterID : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			List<BattleMonsterInfo> items = Info.Instance().BattleLoadMonsters;
			for (int i = 0; i <items.Count; i++)
			{
				if (id == items[i].ID) return i;
			}
			return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().BattleLoadMonsters[(int)value].ID;
		}
	}
}
