using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskDOM.Components;

namespace TaskDOM.View_Models
{
    public class HardwareListViewModel : ViewModelBase
    {
        private ObservableCollection<Hardware> _hardwares;
        private Hardware _selectedHardware;
        //Список оборудования
        public ObservableCollection<Hardware> Hardwares
        {
            get
            {
                return _hardwares;
            }
            set
            {
                _hardwares = value;
                OnPropertyChanged(nameof(Hardwares));
            }
        }
        //Выбранный элемент из списка оборудования
        public Hardware SelectedHardware
        {
            get
            {
                return _selectedHardware;
            }
            set
            {
                _selectedHardware = value;
                OnPropertyChanged(nameof(SelectedHardware));
            }
        }
        //Команда удаления
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteHardwareAsync, () => _selectedHardware != null);
            }
        }
        //Данная команда для подтверждения выбора объекта в списке (чтобы кнопка изменяла своё состояние активности)
        public ICommand SendToModifyCommand
        {
            get
            {
                return new RelayCommand(SendToModifyAsync, () => _selectedHardware != null);
            }
        }

        public HardwareListViewModel()
        {
            LoadDataAsync();
        }
        //Асинхронное добавление данных в список
        private async void LoadDataAsync()
        {   
            try
            {
                //Выборка данных из базы данных
                var _hardwares = await App.DB.Hardware.Include(x => x.HardwareType).Include(x => x.HardwareStatus).ToListAsync();
                Hardwares = new ObservableCollection<Hardware>(_hardwares);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Асинхронное удаление выбранного объекта из списка
        private async Task DeleteHardwareAsync()
        {
            if (SelectedHardware == null)
            {
                return;
            }
            try
            {
                //Подтверждение действия
                MessageBoxResult _confirmationResult = MessageBox.Show("Вы уверены, что хотите удалить данную запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (_confirmationResult == MessageBoxResult.Yes)
                {
                    App.DB.Hardware.Remove(SelectedHardware);
                    await App.DB.SaveChangesAsync();

                    Hardwares.Remove(SelectedHardware);
                }
                SelectedHardware = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Данная команда нужна только для проверки активности кнопки
        private async Task SendToModifyAsync()
        {
            if (SelectedHardware == null)
            {
                return;
            }
        }
    }
}
