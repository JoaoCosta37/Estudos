using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Essentials;
using System.Globalization;

namespace ChatApp.Features
{
    public class NewImageMessage
    {
        public class Command : IRequest<OperationResult>
        {
            public string ChatId { get; set; }
            public MemoryStream ImageContent { get; set; }
            public string ImageName { get; set; }   
        }

        public class Handler : IRequestHandler<Command, OperationResult>
        {
            private readonly IAuth auth;
            private readonly IMessageService messageService;
            private readonly IStorageService storageService;

            public Handler(IMessageService messageService, IAuth auth, IStorageService storageService)
            {
                this.auth = auth;
                this.messageService = messageService;
                this.storageService = storageService;
            }

            public async Task<OperationResult> Handle(Command request, CancellationToken cancellationToken)
            {
                    try
                    {
                        var downloadUrl = await storageService.SendFile(request.ImageContent, request.ImageName);

                        Message message = new Message() { Author = auth.AuthUser, Date = DateTime.Now, Text = downloadUrl, MessageType = MessageType.Image };

                        await messageService.CreateMessageAsync(message, request.ChatId);

                        return OperationResult.Success("OK");

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        throw ex;
                    }
            }
        }
    }
}
