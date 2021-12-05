using SchoolMomentsApp.Models;
using SchoolMomentsApp.Models.Repository;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class MomentDetailViewModel : BaseViewModel
    {
        private Moment _moment;

        private IMomentDataService _momentDataService;



        public Moment Moment
        {
            get => _moment;
            set
            {
                _moment = value;
                OnPropertyChanged();
            }
        }

        public MomentDetailViewModel(INavigationService navigationService, IMomentDataService momentDataService) : base(navigationService)
        {
            //instantiate to make sure it's created upon the creation of the viewmodel
            _momentDataService = momentDataService;
            Moment = new Moment();

            //listening if moment changes
            MessagingCenter.Subscribe<MomentDetailViewModel, Moment>
                (this, MessageNames.MomentChangedMessage, OnMomentChanged);

        }



        public ICommand LoadAttendedStudents => new Command(OnLoadAttendedStudents);
        public ICommand LoadRequestedStudents => new Command(OnLoadRequestedStudents);
        public ICommand LoadAbsentStudents => new Command(OnLoadAbsentStudents);
        public ICommand RegisterStudent => new Command(OnRegisterStudent);

        public ICommand AddStudent => new Command(AddRequestedStudent);

        private async void OnMomentChanged(MomentDetailViewModel sender, Moment moment)
        {
            Moment = await _momentDataService.GetMomentAsync(moment.MomentId);
        }

        private  void OnLoadAttendedStudents(object obj)
        {
             _navigationService.NavigateToAsync<StudentsOverviewViewModel>(Moment.AttendedStudents);
        }

        private void AddRequestedStudent(object obj)
        {
            _navigationService.NavigateToAsync<AddRequestedStudentToMomentViewModel>(this.Moment);
        }

        private  void OnLoadRequestedStudents(object obj)
        {
            _navigationService.NavigateToAsync<StudentsOverviewViewModel>(Moment.RequestedStudents);
        }

        private async void OnLoadAbsentStudents(object obj)
        {
            List<Student> AbsentStudents = new List<Student>();
            List<Student> RequestStudents = Moment.RequestedStudents;
            List<Student> AttendedStudents = Moment.AttendedStudents;

            foreach (var student in RequestStudents)
            {
                
                if (!AttendedStudents.Contains(student))
                {
                    AbsentStudents.Add(student);
                }
             
         
            }
            await _navigationService.NavigateToAsync<StudentsOverviewViewModel>(AbsentStudents);
        }


        private void OnRegisterStudent(object obj)
        {
             _navigationService.NavigateToAsync<RegisterStudentForMomentViewModel>(Moment);
        }


        public override async Task InitializeAsync(object parameter)
        {

            Moment = (Moment)parameter;
            

        }
    }

}
