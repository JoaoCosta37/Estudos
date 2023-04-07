using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using TimeRecorderApp.Models;

namespace TimeRecorderApp.ViewModels
{
    public class TimesheetViewModel : BindableBase
    {
        private TimesheetData timesheet;
        public TimesheetViewModel(TimesheetData timesheet)
        {
            this.timesheet = timesheet;
        }
        public TimesheetData Timesheet
        {
            get => this.timesheet;
            set
            {
                this.timesheet = value;
                RaisePropertyChanged();
            }
        }
        public string TimerDate
        {
            get => this.Timesheet.TimerDate;
            set
            {
                Timesheet.TimerDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime StartTime
        {
            get => this.Timesheet.StartTime;
            set
            {
                Timesheet.StartTime = value;
                RaisePropertyChanged();
            }
        } 
        public DateTime PauseTime
        {
            get => this.Timesheet.PauseTime;
            set
            {
                Timesheet.PauseTime = value;
                RaisePropertyChanged();
            }
        } 
        public bool IsRunning
        {
            get => this.Timesheet.IsRunning;
            set
            {
                Timesheet.IsRunning = value;
                RaisePropertyChanged();
            }
        }

        public DateTime EndTime
        {
            get => this.Timesheet.EndTime;
            set
            {
                Timesheet.EndTime = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan TotalPauses
        {
            get => this.Timesheet.TotalPauses;
            set
            {
                Timesheet.TotalPauses = value;
                RaisePropertyChanged();
            }
        }
        public bool Ended
        {
            get => this.Timesheet.Ended;
            set
            {
                Timesheet.Ended = value;
                RaisePropertyChanged();
            }
        }
    }
}
