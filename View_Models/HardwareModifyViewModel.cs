using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskDOM.Components;

namespace TaskDOM.View_Models
{
    public class HardwareModifyViewModel : ViewModelBase
    {
        private ObservableCollection<HardwareType> _hardwareTypes;
        private ObservableCollection<HardwareStatus> _hardwareStatuses;

        public Hardware Hardware;

        public string ModifyTitle
        { 
            get
            {
                if (Hardware.Id == 0)
                {
                    return "Добавление оборудования";
                }
                else
                {
                    return "Изменение оборудования";
                }
            }
        }
        public string Name
        {
            get
            {
                return Hardware.Name;
            }
            set
            {
                Hardware.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ObservableCollection<HardwareType> HardwareType
        {
            get
            {
                return _hardwareTypes;
            }
            set
            {
                _hardwareTypes = value;
                OnPropertyChanged(nameof(HardwareType));
            }
        }
        public ObservableCollection<HardwareStatus> HardwareStatus
        {
            get
            {
                return _hardwareStatuses;
            }
            set
            {
                _hardwareStatuses = value;
                OnPropertyChanged(nameof(HardwareStatus));
            }
        }
        public HardwareType SelectedHardwareType
        {
            get
            {
                return Hardware.HardwareType;
            }
            set
            {
                Hardware.HardwareType = value;
                OnPropertyChanged(nameof(SelectedHardwareType));
            }
        }
        public HardwareStatus SelectedHardwareStatus
        {
            get
            {
                return Hardware.HardwareStatus;
            }
            set
            {
                Hardware.HardwareStatus = value;
                OnPropertyChanged(nameof(SelectedHardwareStatus));
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(SaveHardwareDataAsync, CanSave);
            }
        }

        //public bool HasErrors => throw new NotImplementedException();

        public HardwareModifyViewModel(Hardware _hardware)
        {
            LoadDataAsync();
            Hardware = _hardware;
        }
        private async void LoadDataAsync()
        {
            try
            {
                var _hardwaresTypes = await App.DB.HardwareType.ToListAsync();
                var _hardwaresStatuses = await App.DB.HardwareStatus.ToListAsync();
                HardwareType = new ObservableCollection<HardwareType>(_hardwaresTypes);
                HardwareStatus = new ObservableCollection<HardwareStatus>(_hardwaresStatuses);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Name) && HardwareType != null && HardwareStatus != null;
        }
        private async Task SaveHardwareDataAsync()
        {
            if (Hardware == null)
            {
                return;
            }
            try
            {
                if (Hardware.Id == 0)
                {
                    App.DB.Hardware.Add(Hardware);
                    await App.DB.SaveChangesAsync();
                }
                else
                {
                    MessageBoxResult _confirmationResult = MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (_confirmationResult == MessageBoxResult.Yes)
                    {
                        await App.DB.SaveChangesAsync();
                    }
                }
                MessageBox.Show("Данные сохранены!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged(nameof(ModifyTitle));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
