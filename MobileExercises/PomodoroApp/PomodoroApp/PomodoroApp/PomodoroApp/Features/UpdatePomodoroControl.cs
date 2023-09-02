using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using PomodoroApp.Models;
using PomodoroApp.Enums;
using PomodoroApp.ViewModels;
using PomodoroApp.Repositorys;
using PomodoroApp.Singles;
using Xamarin.Forms.Internals;

namespace PomodoroApp.Features
{
    public class UpdatePomodoroControl
    {
        public class Command : IRequest<OperationResult>
        {
            //public bool IsStart { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {

            public Handler()
            {
                string value;

                var test = value == "POMO" ? TimeType.POMODORO : TimeType.SHORT;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                //Esse Handle trabaha com Progress, que indica os que já foram rodados e o TimeTypeValue, que indica o que foi rodado antes
                //de chamar o command.

                int initialPosition = -1;
                int pom = (int)TimeType.POMODORO;
                int sht = (int)TimeType.SHORT;
                int lon = (int)TimeType.LONG;
                //if ((PomodoroControlInstance.Instance.Progress + 1) != PomodoroControlInstance.Instance.TimeTypeValue)
                //{
                //    PomodoroControlInstance.Instance.TimeTypeValue = PomodoroControlInstance.Instance.Progress + 1;
                //    return OperationResult.Success("OK");
                //}

                //if (request.IsStart)
                //{
                //    if (PomodoroControlInstance.Instance.Progress == sht
                //        && PomodoroControlInstance.Instance.CountToLongBreak < PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)

                //        PomodoroControlInstance.Instance.Progress = initialPosition;
                //    else if (PomodoroControlInstance.Instance.Progress == lon

                //        && PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                //    {
                //        PomodoroControlInstance.Instance.Progress = initialPosition;
                //        PomodoroControlInstance.Instance.CountToLongBreak = 0;
                //    }

                //    //else if (PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                //    //{
                //    //    PomodoroControlInstance.Instance.ProgressPosition = sht;
                //    //    PomodoroControlInstance.Instance.TimeTypeValue = lon;
                //    //}
                //}
                //else
                //{
                //switch (PomodoroControlInstance.Instance.TimeTypeValue)
                //{
                //    case pom:
                //        {
                //            if (PomodoroControlInstance.Instance.ProgressPosition == initialPosition)
                //            {
                //                PomodoroControlInstance.Instance.CountToLongBreak += 1;
                //                PomodoroControlInstance.Instance.DailyCount += 1;
                //            }

                //            if (PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                //            {
                //                PomodoroControlInstance.Instance.ProgressPosition = shr;
                //                PomodoroControlInstance.Instance.TimeTypeValue = lon;
                //                break;
                //            }
                //            PomodoroControlInstance.Instance.ProgressPosition = pom;
                //            PomodoroControlInstance.Instance.TimeTypeValue = shr;
                //            break;

                //        }
                //    case shr:
                //        {
                //            if (PomodoroControlInstance.Instance.ProgressPosition == pom)
                //            {
                //                PomodoroControlInstance.Instance.ProgressPosition = shr;
                //            }
                //            else if (PomodoroControlInstance.Instance.ProgressPosition == shr
                //                && PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                //            {
                //                PomodoroControlInstance.Instance.TimeTypeValue = lon;
                //            }
                //            PomodoroControlInstance.Instance.TimeTypeValue = pom;
                //            break;
                //        }
                //    case lon:
                //        {
                //            if (PomodoroControlInstance.Instance.ProgressPosition == shr
                //                && PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                //            {
                //                PomodoroControlInstance.Instance.ProgressPosition = lon;
                //                PomodoroControlInstance.Instance.TimeTypeValue = pom;
                //                break;
                //            }
                //            else if (PomodoroControlInstance.Instance.ProgressPosition == initialPosition)
                //            {
                //                PomodoroControlInstance.Instance.TimeTypeValue = pom;
                //                break;
                //            }
                //            else if (PomodoroControlInstance.Instance.ProgressPosition == pom)
                //            {
                //                PomodoroControlInstance.Instance.TimeTypeValue = shr;
                //                break;
                //            }
                //            else
                //            {
                //                PomodoroControlInstance.Instance.TimeTypeValue = pom;
                //                break;
                //            }

                //        }
                //}

                switch (PomodoroControlInstance.Instance.Progress)
                {
                    case -1:
                        {
                            PomodoroControlInstance.Instance.CountToLongBreak += 1;
                            PomodoroControlInstance.Instance.DailyCount += 1;
                            if (PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                            {
                                PomodoroControlInstance.Instance.Progress = sht;
                                PomodoroControlInstance.Instance.TimeTypeValue = lon;
                                break;
                            }
                            PomodoroControlInstance.Instance.Progress = pom;
                            PomodoroControlInstance.Instance.TimeTypeValue = sht;
                            break;
                            //if (PomodoroControlInstance.Instance.TimeTypeValue == pom)
                            //{
                            //    PomodoroControlInstance.Instance.CountToLongBreak += 1;
                            //    PomodoroControlInstance.Instance.DailyCount += 1;
                            //    if (PomodoroControlInstance.Instance.CountToLongBreak == PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak)
                            //    {
                            //        PomodoroControlInstance.Instance.Progress = sht;
                            //        PomodoroControlInstance.Instance.TimeTypeValue = lon;
                            //        break;
                            //    }
                            //    PomodoroControlInstance.Instance.Progress = pom;
                            //    PomodoroControlInstance.Instance.TimeTypeValue = sht;
                            //    break;
                            //}
                            //PomodoroControlInstance.Instance.TimeTypeValue = pom;
                            //break;
                        }
                    case (int)TimeType.POMODORO:
                        {
                            //Se o progress está pomodoro, tinha que ter rodado short, pois quendo encerra o pomodoro e é hora de rodar o long
                            //ele pula o progress para short direto.


                            PomodoroControlInstance.Instance.Progress = sht;
                            PomodoroControlInstance.Instance.TimeTypeValue = pom;
                            break;

                            //if (PomodoroControlInstance.Instance.TimeTypeValue == sht)
                            //{
                            //    PomodoroControlInstance.Instance.Progress = sht;
                            //    PomodoroControlInstance.Instance.TimeTypeValue = pom;
                            //    break;
                            //}
                            //PomodoroControlInstance.Instance.TimeTypeValue = sht;
                            //break;
                        }
                    case (int)TimeType.SHORT:
                        {
                            //Se está short, tinha que ter rodado long, uma vez que quando está short e ainda não deu o número
                            //de pomodoros, ele seta o progess em -1.
                            PomodoroControlInstance.Instance.Progress = lon;
                            PomodoroControlInstance.Instance.TimeTypeValue = pom;
                            PomodoroControlInstance.Instance.CountToLongBreak = 0;
                            break;

                            //if (PomodoroControlInstance.Instance.TimeTypeValue == lon)
                            //{
                            //    PomodoroControlInstance.Instance.Progress = lon;
                            //    PomodoroControlInstance.Instance.TimeTypeValue = pom;
                            //    break;
                            //}
                            //PomodoroControlInstance.Instance.TimeTypeValue = lon;
                            //break;
                        }
                }
                //}

                PomodoroControlInstance.SavePomodoroControlAsync();

                return OperationResult.Success("OK");

            }
        }
    }
}
