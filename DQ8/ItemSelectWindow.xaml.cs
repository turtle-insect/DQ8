using System;
using System.Windows;
using System.Windows.Controls;

namespace DQ8
{
	/// <summary>
	/// ItemSelectWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ItemSelectWindow : Window
	{
		public uint ID { get; set; }

		public ItemSelectWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
			foreach (var item in ListBoxItem.Items)
			{
				ItemInfo info = item as ItemInfo;
				if (info.ID == ID)
				{
					ListBoxItem.SelectedItem = item;
					ListBoxItem.ScrollIntoView(item);
					break;
				}
			}
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			ItemInfo info = ListBoxItem.SelectedItem as ItemInfo;
			if (info == null) return;
			ID = info.ID;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			foreach (var item in Info.Instance().Items)
			{
				if (String.IsNullOrEmpty(filter) || item.Name.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(item);
				}
			}
		}
	}
}
