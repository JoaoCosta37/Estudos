using Firebase.Database;
using LiteDB;
using Prism.Mvvm;
using Prism.Xaml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimeRecorderApp.DAL;
using TimeRecorderApp.Models;
using TimeRecorderApp.Resources;
using TimeRecorderApp.Services;
using TimeRecorderApp.Singles;
using Xamarin.Forms;

namespace TimeRecorderApp.ViewModels
{
    public class TimerPageViewModel : BindableBase
    {
        private Timer timer;
        private TimeSpan currentTime;
        private bool isRunningCanStop = false;
        private bool isFisrtTime = true;
        private TimesheetViewModel timesheetViewModel;

        public TimerPageViewModel(IRequiredHoursService requiredHoursService)
        {
            BankOfHours.Instance = requiredHoursService;
            goStart();
            StartCommand = new Command(() => start());
            PauseCommand = new Command(() => pause());
            StopCommand = new Command(() => stop());
            GoStartCommand = new Command(() => setCurrentTimer());
        }
        public TimeSpan BankOfHoursVm
        {
            get => BankOfHours.CurrentBank;
        }
        public TimesheetViewModel TimesheetViewModel
        {
            get => this.timesheetViewModel;
            set
            {
                this.timesheetViewModel = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan CurrentTime
        {
            get => this.currentTime;
            set
            {
                this.currentTime = value;
                RaisePropertyChanged();
            }
        }

        public bool IsRunningCanStop
        {
            get => this.isRunningCanStop;
            set
            {
                this.isRunningCanStop = value;
                RaisePropertyChanged();
            }
        }
        public Command StartCommand { get; set; }
        public Command PauseCommand { get; set; }
        public Command StopCommand { get; set; }
        public Command GoStartCommand { get; set; }
        #region Methods
        private void goStart()
        {
            this.timesheetViewModel = getTimesheetViewModel();
            setFirstTime();
            if (this.TimesheetViewModel.IsRunning)
            {
                this.IsRunningCanStop = true;
            }
            setCurrentTimer();
            if (this.TimesheetViewModel.IsRunning)
            {
                timerStart();
            }
            BankOfHours.SetCurrentBank();
        }
        private void timerStart()
        {
            if(timer == null)
            {
                this.timer = new Timer();
                this.timer.Interval = 1000;
                this.timer.Elapsed += Timer_Elapsed;
            }
                timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = CurrentTime.Add(TimeSpan.FromSeconds(1));

        }
        private void start()
        {
            initializeStartTime();

            IsRunningCanStop = true;

            this.TimesheetViewModel.IsRunning = true;

            this.TimesheetViewModel.PauseTime = new DateTime();
            
            updateTimesheetViewModel();
            timerStart();
        }
        private void pause()
        {
            this.TimesheetViewModel.IsRunning = false;
            this.TimesheetViewModel.PauseTime = DateTime.Now;
            this.timer.Stop();
            updateTimesheetViewModel();
        }
        private async void stop()
        {
            var stopTime = DateTime.Now;
            var resources = new ResourceManager(typeof(Messages));
            string stopTitle = resources.GetString("Stop", CultureInfo.CurrentCulture);
            string stopMessage = resources.GetString("StopMessage", CultureInfo.CurrentCulture);
            string confirmMesage = resources.GetString("Yes", CultureInfo.CurrentCulture);
            string cancelMessage  = resources.GetString("No", CultureInfo.CurrentCulture);
            var action = await Application.Current.MainPage.DisplayAlert(stopTitle, stopMessage, confirmMesage, cancelMessage);
            if (action)
            {
                this.timer.Stop();
                this.IsRunningCanStop = false;
                this.TimesheetViewModel.IsRunning = false;
                this.TimesheetViewModel.Ended = true;
                this.TimesheetViewModel.EndTime = stopTime;
                setCurrentTimer(stopTime);
                updateTimesheetViewModel();
                BankOfHours.UpdateBankOfHours(this.CurrentTime);
                RaisePropertyChanged(nameof(this.BankOfHoursVm));
                this.isFisrtTime = true;
                goStart();
            }
        }
        private void setFirstTime()
        {
            if(this.TimesheetViewModel.StartTime.Year != 1 || this.TimesheetViewModel.IsRunning)
            {
                this.isFisrtTime = false;
            }
        }
        private void setCurrentTimer(DateTime timeNow = new DateTime())
        {
            TimeSpan elapsed;
            timeNow = timeNow.Year != 1 ? timeNow : DateTime.Now;
            if (isFisrtTime)
            {
                this.CurrentTime = new TimeSpan();
                return;
            }
            elapsed  = timeNow - this.timesheetViewModel.StartTime;
            if(this.TimesheetViewModel.PauseTime.Year != 1)
            {
                elapsed -= timeNow - this.TimesheetViewModel.PauseTime;
            }
            this.CurrentTime = elapsed - this.timesheetViewModel.TotalPauses;
        }
        private TimesheetViewModel getTimesheetViewModel()
        {
            var format = "yyyyMMdd";
            var database = TimesheetDataBase.Instance.GetAwaiter().GetResult();
            var timesheet = database.GetTimesheetAsync(DateTime.Now.ToString(format)).Result;

            if (timesheet != null)
            {
                return new TimesheetViewModel(timesheet);
            }
                return new TimesheetViewModel(new TimesheetData());

        }
        private async void updateTimesheetViewModel()
        {
            var database = TimesheetDataBase.Instance.GetAwaiter().GetResult();
            await database.SaveTimesheetAsync(this.TimesheetViewModel.Timesheet);
        }
        private void initializeStartTime()
        {
            if (isFisrtTime)
            {
                this.TimesheetViewModel.StartTime = DateTime.Now;
                this.isFisrtTime = false;
            }
            else if (!this.TimesheetViewModel.IsRunning && this.TimesheetViewModel.PauseTime.Year != 1)
            {
                this.TimesheetViewModel.TotalPauses += (DateTime.Now - this.TimesheetViewModel.PauseTime);
            }
        }
        #endregion
    }
}
