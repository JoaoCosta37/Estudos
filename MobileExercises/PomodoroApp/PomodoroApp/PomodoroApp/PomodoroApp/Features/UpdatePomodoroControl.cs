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

namespace PomodoroApp.Features
{
    public class UpdatePomodoroControl
    {
        public class Command : IRequest<OperationResult>
        {
            public PomodoroControlViewModel PomodoroControlViewModel { get; set; }

        }

        //public class CommandValidator : IPipelineBehavior<Command, OperationResult>
        //{
        //    private readonly IChatRoomService chatRoomService;

        //    public CommandValidator(IChatRoomService chatRoomService, IEnumerable<IRequestPreProcessor<Command>> preProcessors)
        //    {
        //        this.chatRoomService = chatRoomService;
        //    }
        //    public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        //    {
        //        var exist = await chatRoomService.ExistChatRoom(request.ChatRoom.Id);
        //        if (exist)
        //        {
        //            return OperationResult.Failure("*", "Chat já exite");
        //        }
        //        else
        //        {
        //            return await next();
        //        }

        //    }


        //}

        public class Handler : IRequestHandler<Command, OperationResult>
        {
            private readonly PomodoroControlRepository pomodoroControlRepository;

            public Handler(PomodoroControlRepository pomodoroControlRepository)
            {
                this.pomodoroControlRepository = pomodoroControlRepository;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                switch (request.PomodoroControlViewModel.CurrentType)
                {
                    case TimeType.Pomodoro:
                        {
                            if (request.PomodoroControlViewModel.PomodoroFinished) break;
                            request.PomodoroControlViewModel.PomodoroFinished = true;
                            if (request.PomodoroControlViewModel.Count == request.PomodoroControlViewModel.PomodoroTimesBeforeLongPause)
                            {
                                request.PomodoroControlViewModel.CurrentType = TimeType.Long;
                                break;
                            }
                            request.PomodoroControlViewModel.Count += 1;
                            request.PomodoroControlViewModel.CurrentType = TimeType.Short;
                            break;
                        }
                    case TimeType.Short:
                        {
                            request.PomodoroControlViewModel.PomodoroFinished = false;
                            request.PomodoroControlViewModel.CurrentType = TimeType.Pomodoro;
                            break;
                            //if (request.PomodoroControlViewModel.Count == 0)
                            //{
                            //    request.PomodoroControlViewModel.Count = 0;
                            //    break;
                            //}

                        }
                    case TimeType.Long:
                        {
                            request.PomodoroControlViewModel.PomodoroFinished = false;
                            request.PomodoroControlViewModel.CurrentType = TimeType.Pomodoro;
                            break;
                        }
                }
                await pomodoroControlRepository.SavePomodoroControlAsync(request.PomodoroControlViewModel.PomodoroControl);

                return OperationResult.Success("OK");

            }

            //public Task<OperationResult> IRequestHandler<Command, OperationResult>Handle(Command request, CancellationToken cancellationToken)
            //{
            //    await chatRoomService.CreateChatRoomAsync(request.ChatRoom);

            //    throw new NotImplementedException();
            //}
        }
    }
}
