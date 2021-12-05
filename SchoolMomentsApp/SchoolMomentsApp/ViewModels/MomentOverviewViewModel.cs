using SchoolMomentsApp.Extensions;
using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class MomentOverviewViewModel : BaseViewModel
    {
        
        private ObservableCollection<Moment> _moments;
        public ICommand MomentSelectedCommand => new Command<Moment>(OnMomentSelection);

        public IMomentDataService _momentDataService;
        
        public ObservableCollection<Moment> Moments
        {
            get => _moments;
            set
            {
                _moments = value;
                OnPropertyChanged();
            }
        }

        public MomentOverviewViewModel(IMomentDataService momentDataService, INavigationService navigationService) : base(navigationService)
        {
            _momentDataService = momentDataService;
      
            //MomentSelectedCommand = new Command<Moment>(OnMomentSelection);
 
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;
            Moments = (await _momentDataService.GetAllMomentsAsync()).ToObservableCollection();
            IsBusy = false;
            
        }


        private void OnMomentSelection(Moment moment)
        {
            _navigationService.NavigateToAsync<MomentDetailViewModel>(moment);
                   
        }
    }
}
