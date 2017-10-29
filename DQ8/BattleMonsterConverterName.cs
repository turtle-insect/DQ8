using System;
using System.Globalization;
using System.Windows.Data;
using System.Collections.Generic;

namespace DQ8
{
	class BattleMonsterConverterName : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			foreach (var monster in Info.Instance().BattleLoadMonsters)
			{
				if (monster.ID == id) return monster.Name;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
