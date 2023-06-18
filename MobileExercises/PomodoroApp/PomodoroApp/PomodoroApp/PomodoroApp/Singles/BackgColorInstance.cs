using PomodoroApp.DAL;
using PomodoroApp.Models;
using PomodoroApp.Repositorys;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PomodoroApp.Singles
{
    public class BackgColorInstance : BindableBase
    {
        private static BackgColor instance;
        private static BackgColorRepository backgColorRepository;
        public static string Instance
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
                updateBackgColor();
            }
        }
        private static void setBackgColor()
        {
            backgColorRepository = new BackgColorRepository();
            var backgColor = backgColorRepository.GetBackgColor().Result;
            instance = backgColor;
        }
        private static void updateBackgColor()
        {
            backgColorRepository.SaveBackgColorAsync(instance);
        }
    }
}
