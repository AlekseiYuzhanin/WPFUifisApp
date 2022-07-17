using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agent.Models;
using Microsoft.EntityFrameworkCore;

namespace Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> productList;
        AgentContext agentContext = new AgentContext();

        private static int _skip = 0;
        private static int _shift = 20;
        private static int _take = _shift;

        public MainWindow()
        {
            InitializeComponent();
            agentContext.Database.EnsureCreated();
            var FilterCBoxItems = new List<ProductType>();
            FilterCBoxItems.Add(new ProductType() { Id=0, Title="Все типы" });

            var types = agentContext.ProductTypes.ToList();
            foreach (var type in types)
                FilterCBoxItems.Add(type);
            FilterCbox.ItemsSource = FilterCBoxItems;
            FilterCbox.SelectedIndex = 0;
           productList = agentContext.Products.Include(x => x.ProductType).Include(x => x.ProductMaterials).ThenInclude(x => x.Material).Take(20).ToList();
           ProductsList.ItemsSource = productList;
        }

        private void SearchTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Handle();
        }
        private void Handle()
        {
            //RefreshList(); // обновление листа до изначального состояния
            // обработка поиска
            productList = agentContext.Products.Include(x => x.ProductType).Include(x => x.ProductMaterials).ThenInclude(x => x.Material).Where(x =>
            x.ProductType.Title.Contains(SearchTBox.Text) ||
            x.Title.Contains(SearchTBox.Text) ||
            x.Description.Contains(SearchTBox.Text)).ToList();
            //обработчик для комбобокса сортировки
            switch (OrderByCBox.SelectedIndex)
            {
                case 0: 
                    break;
                case 1:
                    productList = productList.OrderByDescending(x => x.Title).ToList();
                    break;
                case 2:
                    productList = productList.OrderBy(x => x.Title).ToList();
                    break;
                case 3:
                    productList = productList.OrderByDescending(x => x.ProductionWorkshopNumber).ToList();
                    break;
                case 4:
                    productList = productList.OrderBy(x => x.ProductionWorkshopNumber).ToList();
                    break;
                case 5:
                    productList = productList.OrderByDescending(x => x.MinCostForAgent).ToList();
                    break;
                case 6:
                    productList = productList.OrderBy(x => x.MinCostForAgent).ToList();
                    break;
            }
            if (FilterCbox != null)
            {
                var selectedItem = FilterCbox.SelectedItem as ProductType;
                if (selectedItem.Id != 0)
                    productList = productList.Where(x => x.ProductType.Title == selectedItem.Title).ToList();
            }

            if (ProductsList != null)
                ProductsList.ItemsSource = productList;
        }
        private void RefreshList()
        {
            productList = agentContext.Products.Include(x => x.ProductType).Include(x => x.ProductMaterials).ThenInclude(x => x.Material).ToList();
        }

        private void OrderByCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Handle();
        }

        private void FilterCbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Handle();   
        }


        private void LeftDown_Click(object sender, RoutedEventArgs e)
        {
            Handle();
            if (_skip > 0)
            {
                _skip -= _shift;
                _take -= _shift;
            }
            productList = productList.Skip(_skip).Take(_take).ToList();
            ProductsList.ItemsSource = productList;

        }

        private void RightDown_Click(object sender, RoutedEventArgs e)
        {
            Handle();
            if (_skip < productList.Count - _shift)
            {
                _skip += _shift;
                _take += _shift;
            }
            productList = productList.Take(_take).Skip(_skip).ToList();
            ProductsList.ItemsSource = productList;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = ProductsList.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {selectedItems.Count()} элементов?","Внимание",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    agentContext.RemoveRange(selectedItems);
                    agentContext.SaveChanges();
                    MessageBox.Show("Данные удалены");

                    ProductsList.ItemsSource = agentContext.Products.ToList();
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
