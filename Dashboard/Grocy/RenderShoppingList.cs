using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avalonia.Media;
using Avalonia.Layout;
using System.Threading.Tasks;

namespace Dashboard.Grocy
{
    internal class RenderShoppingList : MainWindow
    {
        public static void RenderShoppingListClass(List<ShoppingItem> shoppingItems)
        {
            foreach (var item in shoppingItems)
            {
                Grid grid = new();

                ColumnDefinition checkBoxColumn =
                    new() { Width = new GridLength(1, GridUnitType.Star) };
                ColumnDefinition amountColumn =
                    new() { Width = new GridLength(3, GridUnitType.Star) };
                ColumnDefinition nameColumn =
                    new() { Width = new GridLength(5, GridUnitType.Star) };
                grid.ColumnDefinitions.Add(checkBoxColumn);
                grid.ColumnDefinitions.Add(amountColumn);
                grid.ColumnDefinitions.Add(nameColumn);

                CheckBox checkBox = new() { IsChecked = item.Done };
                grid.Children.Add(checkBox);
                Grid.SetColumn(checkBox, 0);

                TextBlock amountText =
                    new()
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 25,
                        FontWeight = FontWeight.Bold,
                        Text = item.Amount.ToString(),
                        Foreground = new SolidColorBrush(Colors.Black)
                    };
                grid.Children.Add(amountText);
                Grid.SetColumn(amountText, 1);

                TextBlock nameText =
                    new()
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 25,
                        FontWeight = FontWeight.Bold,
                        Text = item.Name.ToString(),
                        Foreground = new SolidColorBrush(Colors.Black)
                    };
                grid.Children.Add(nameText);
                Grid.SetColumn(nameText, 2);

                Main.GroceryViewer.Children.Add(grid);
            }
        }
    }
}
