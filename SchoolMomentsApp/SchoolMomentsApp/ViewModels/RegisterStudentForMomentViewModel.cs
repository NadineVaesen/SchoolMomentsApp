using SchoolMomentsApp.Models;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class RegisterStudentForMomentViewModel : BaseViewModel
    {
        //private string studentnumber;
        private ICommand ConfirmStudentPresence;
        private IQrScanningService _qrScanningService;

        private ICommand ScanCommand => new Command(GetScanResult);

        private string _scannedNumber;
        public string ScannedNumber
        {
            get { return _scannedNumber; }
            set { _scannedNumber= value;
                OnPropertyChanged();
            }
        }

        public RegisterStudentForMomentViewModel(INavigationService navigationService, IQrScanningService qrScanningService): base(navigationService)
        {
            _qrScanningService = qrScanningService;
        }

        public RegisterStudentForMomentViewModel(INavigationService navigationService) : base(navigationService)
        {
            ConfirmStudentPresence = new Command<Moment>(OnConfirmStudent);
        }

        private void OnConfirmStudent(Moment moment)
        {
            //let the moment know that it's lists of students changed
            MessagingCenter.Send(this, MessageNames.MomentChangedMessage, moment);
       
            _navigationService.NavigateToAsync<MomentOverviewViewModel>();
        }

        //If I received a studentnumber => check if the student is in the list of requested studends
        //YES? show StudentName to confirm it's presence
        //NO? show Message => student is not supposed to be in this lesson

        private async void GetScanResult()
        {
            try
            {
                var result = _qrScanningService.ScanAsync();
                if (result != null)
                {
                    ScannedNumber = result.Result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
