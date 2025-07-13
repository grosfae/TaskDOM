using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaskDOM.View_Models
{
    //База для асинхронных команд
    public class RelayCommand(Func<Task> execute, Func<bool> canExecute = null) : ICommand
    {
        //Функция для метода с типом Task, который должен содержать основной код выполения команды
        private readonly Func<Task> _execute = execute;
        //Функция для определения возможности выполнения команды (необходимые условия)
        private readonly Func<bool> _canExecute = canExecute;

        public bool CanExecute(object parameter)
        {
            //Выполнение переданной из вне функции и проверка на результат true
            return _canExecute?.Invoke() ?? true;
        }

        public async void Execute(object parameter)
        {
            //Обработка ошибок для асинхронных операций
            try
            {
                await _execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
