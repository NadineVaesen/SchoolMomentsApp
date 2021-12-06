using Prism.Services.Dialogs;
using QRCoder;
using SchoolMomentsApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SchoolMomentsApp.ViewModels
{
    public class StudentMainPageViewModel : BaseViewModel
    {
        private string _studentNumber;

        
        public string StudentNumber
        {
            get => _studentNumber;
            set
            {
                _studentNumber = value;
                OnPropertyChanged();
            }
        }


        public StudentMainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
       
        }

        public override async Task InitializeAsync(object data)
        {
            //StudentNumber = (string)data;
            StudentNumber = "315543535";
        }
    }



}
