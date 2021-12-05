using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class AddRequestedStudentToMomentViewModel : BaseViewModel
    {

        private string _studentId;
        private Moment _moment;
        
        public IStudentDataService _studentDataService;
        public IMomentDataService _momentDataService;
        public ICommand GoBackToMoment => new Command<Moment>(navigateBackToMoment);
        public Moment Moment
        {
            get => _moment;
            set
            {
                _moment = value;
                OnPropertyChanged();
            }
        }
        public AddRequestedStudentToMomentViewModel(INavigationService navigationService, IStudentDataService studentDataService, IMomentDataService momentDataService) : base(navigationService)
        {
            _studentDataService = studentDataService;
            _momentDataService = momentDataService;
            
        }
        
      

        public string StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object parameter)
        {
            Moment = (Moment)parameter;
            
        }

        private async void navigateBackToMoment(object obj)
        {
            IsBusy = true;
            Moment.RequestedStudents.Add(_studentDataService.GetStudent(Convert.ToInt32(StudentId)).Result);
            Moment resultMoment = await _momentDataService.AddRequestedStudent(Moment.MomentId, Moment);
            await _navigationService.NavigateToAsync<MomentDetailViewModel>(Moment);
            IsBusy = false;
        }

    }
}
