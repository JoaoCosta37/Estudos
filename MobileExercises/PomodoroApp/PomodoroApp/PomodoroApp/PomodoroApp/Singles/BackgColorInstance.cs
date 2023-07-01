using PomodoroApp.DAL;
using PomodoroApp.Models;
using PomodoroApp.Repositorys;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Singles
{
    public class BackgColorInstance : BindableBase
    {
        private static BackgColor instance;
        private static BackgColorRepository backgColorRepository;
        public static Color Instance
        {
            get
            {
                if(instance == null)
                {
                    setBackgColor();

                }
                return instance.Color;
            }
            set
            {
                instance.Color = value;
            }
        }
        private static void setBackgColor()
        {
            backgColorRepository = new BackgColorRepository();
            var backgColor = backgColorRepository.GetBackgColor().Result;
            instance = backgColor;
        }
        public static void UpdateBackgColor()
        {
            backgColorRepository.SaveBackgColorAsync(instance);
        }
    }
}
