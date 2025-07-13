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
using TaskDOM.Components;
using TaskDOM.View_Models;

namespace TaskDOM.Pages
{
    /// <summary>
    /// Логика взаимодействия для HardwareModifyPage.xaml
    /// </summary>
    public partial class HardwareModifyPage : Page
    {
        public HardwareModifyPage(Hardware _hardware)
        {
            InitializeComponent();
            //Присовение модели с переданным объектом класса к контексту данных страницы
            DataContext = new HardwareModifyViewModel(_hardware);
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }
    }
}
