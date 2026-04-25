using System.Globalization;
using System.Windows.Data;

namespace DQ8
{
	class OrderConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			foreach (var row in Info.Instance().Orders)
			{
				if (row.Value == id) return row.Name;
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "";
		}
	}
}
