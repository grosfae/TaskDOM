using System.Windows;
using TaskDOM.Components;

namespace TaskDOM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Реализация контекста базы данных
        public static ApplicationContext DB = new ApplicationContext();
    }

}
