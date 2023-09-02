using MediatR;
using PomodoroApp.Enums;
using PomodoroApp.Singles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PomodoroApp.Features
{
    public class UpdateStatistics
    {
        public class Command : IRequest<OperationResult>
        {
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {

            public Handler()
            {
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                int initialPosition = -1;
                int pom = (int)TimeType.POMODORO;
                int sht = (int)TimeType.SHORT;
                int lon = (int)TimeType.LONG;

                

                //if (PomodoroControlInstance.Instance.Progress == sht
                //       && PomodoroControlInstance.Instance.TimeTypeValue == pom)
                //{
                //    PomodoroControlInstance.Instance.Progress = initialPosition;
                //}
                //else if (PomodoroControlInstance.Instance.Progress == lon
                //       && PomodoroControlInstance.Instance.TimeTypeValue == pom)
                //{
                //    PomodoroControlInstance.Instance.Progress = initialPosition;
                //}

                PomodoroControlInstance.SavePomodoroControlAsync();

                return OperationResult.Success("OK");

            }
        }
    }
}
