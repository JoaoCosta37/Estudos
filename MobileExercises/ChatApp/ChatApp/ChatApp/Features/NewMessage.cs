using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Xamarin.Essentials;
using Firebase.Storage;

namespace ChatApp.Features
{
    public class NewMessage
    {
        public class Command : IRequest<OperationResult>
        {
            public String Message { get; set; }
            public string ChatId { get; set; }
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {
            private readonly IAuth auth;
            private readonly IMessageService messageService;

            public Handler(IMessageService messageService, IAuth auth)
            {
                this.auth = auth;
                this.messageService = messageService;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                Message message = new Message() { Author = auth.AuthUser, Date = DateTime.Now, Text = request.Message.ToString(), MessageType = MessageType.Text };

                await messageService.CreateMessageAsync(message, request.ChatId);

                return OperationResult.Success("OK");
            }
        }
    }
}
