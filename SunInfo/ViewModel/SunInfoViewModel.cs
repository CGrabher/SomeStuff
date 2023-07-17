using SunInfo.Model;
using SunInfo.Services;
using System;
using System.ComponentModel;

namespace SunInfo.ViewModel
{
    internal class SunInfoViewModel : INotifyPropertyChanged
    {

        private ISunInfoService _sunInfoService;
        public SunInfoViewModel(ISunInfoService sunInfoService)
        {
            _sunInfoService = sunInfoService;

            Update();

            _sunInfoModel = new SunInfoModel();

        }

        private async void Update()
        {
            SunInfo = await _sunInfoService.GetSunInfo();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SunInfoModel _sunInfoModel;
        public SunInfoModel SunInfo
        {
            get => _sunInfoModel;
            set
            {
                if (_sunInfoModel == value)
                    return;

                _sunInfoModel = value;
                OnPropertyChanged(nameof(SunInfo));
            }
        }
    }
}