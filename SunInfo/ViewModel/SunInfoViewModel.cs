using SunInfo.Model;
using SunInfo.Services;
using SunInfo.WpfStuff;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SunInfo.ViewModel
{
    public class SunInfoViewModel : BaseViewModel
    {
        private readonly ISunInfoService _sunInfoService;
        public SunInfoViewModel(ISunInfoService sunInfoService)
        {
            _sunInfoService = sunInfoService;
            RefreshCommand = new RelayCommand(_ => 
            {
                _sunfInfo = null;
                OnPropertyChanged(nameof(SunInfo));
            });
        }
        public ICommand RefreshCommand { get; }

        private LazyProperty<SunInfoModel>? _sunfInfo;
        public LazyProperty<SunInfoModel> SunInfo => _sunfInfo ??= new LazyProperty<SunInfoModel>(GetSunInfo);
        private async Task<SunInfoModel> GetSunInfo(CancellationToken cancellationToken)
        {
            var result = await _sunInfoService.GetSunInfo();
            return result;
        }
    }
}
