using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using TaskDOM.Components;
using TaskDOM.View_Models;

namespace TaskDOM.Pages
{
    /// <summary>
    /// Логика взаимодействия для HardwaresPage.xaml
    /// </summary>
    public partial class HardwaresPage : Page
    {
        //ViewModel для данной страницы
        public HardwaresPage()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Передача нового объекта "Оборудование" на страницу редактирования/добавления
            NavigationService.Navigate(new HardwareModifyPage(new Hardware()));
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            //Передача выбранного объекта "Оборудование" из списка на страницу редактирования/добавления
            var _selectedHardware = LvHardware.SelectedItem as Hardware;
            if (_selectedHardware != null)
            {
                NavigationService.Navigate(new HardwareModifyPage(_selectedHardware));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Присвоение модели к контексту страницы
            DataContext = new HardwareListViewModel();
        }
    }
}
