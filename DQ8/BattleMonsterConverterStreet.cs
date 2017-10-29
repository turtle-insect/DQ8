using System;
using System.Globalization;
using System.Windows.Data;

namespace DQ8
{
	class BattleMonsterConverterStreet : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			foreach (var monster in Info.Instance().BattleLoadMonsters)
			{
				if (monster.ID == id) return monster.Street;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
