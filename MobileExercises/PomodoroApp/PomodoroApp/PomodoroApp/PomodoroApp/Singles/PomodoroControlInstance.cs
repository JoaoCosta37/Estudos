using ImTools;
using MediatR;
using PomodoroApp.Features;
using PomodoroApp.Models;
using PomodoroApp.Repositorys;
using PomodoroApp.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Internals;

namespace PomodoroApp.Singles
{
    public class PomodoroControlInstance
    {
        private static PomodoroControlViewModel instance;
        private static PomodoroControlRepository repository;

        public static PomodoroControlViewModel Instance
        {
            get
            {
                if (instance == null) { setInstance(); }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static TimeDurationViewModel IsSelectedTimeDuration;
        //{
        //    get
        //    {
        //        return Instance.Durations[1];
        //    }
        //    set
        //    {
        //        Instance.Durations[1] = value;
        //    }
        //}
        //{
        //    set
        //    {
        //        //Instance.Durations.Where((x) => x.TimeType == value.TimeType).FirstOrDefault() = value;
        //        var index = Instance.Durations.FindIndex((x) => x.TimeType == value.TimeType);
        //        Instance.Durations[index] = value;
        //    }
        //}
        public static int IsSelectedToUpdate;

        private static void setInstance()
        {
            repository = new PomodoroControlRepository();
            var model = repository.GetPomodoroControlAsync().Result;
            instance = new PomodoroControlViewModel(model);
        }
        public static async void UpdatePomodoroControlAsync(IMediator mediator)
        {
            var command = new UpdatePomodoroControl.Command();
            var result = await mediator.Send(command);
        }
        public static async void SavePomodoroControlAsync()
        {
            var result =  await repository.SavePomodoroControlAsync(instance.PomodoroControl);
            instance = new PomodoroControlViewModel(result);
        }
    }
}
