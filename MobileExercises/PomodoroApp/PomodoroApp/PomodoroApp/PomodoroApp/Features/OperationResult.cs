using PomodoroApp.Resources;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Features
{
    public class OperationResult
    {
        public object Result { get; set; }  
        public bool HasTransaction { get; set; }    
        public Dictionary<string,List<String>> Erros { get; set; }

        private readonly Dictionary<string, List<String>> _messages = new Dictionary<string, List<String>>();

        public OperationResult() => Erros = _messages;
        public OperationResult(object result) : this() => Result = result;

        public OperationResult AddError(string key, string message)
        {
            List<String> messages;
            if (_messages.ContainsKey(key)){
                messages = _messages[key];
            }
            else
            {
                messages = new List<string>();
                _messages.Add(key, messages);
            }

            messages.Add(message);
            return this;
        }
        public OperationResult AddError(string key, string[] messages)
        {
            foreach(var message in messages)
            {
                AddError(key, message);
            }
            return this;
        }
        public static OperationResult Success(object result) => new OperationResult(result);
        public static OperationResult Failure(string key, string message)
        {
            var result = new OperationResult() { };
            result.AddError(key, message);
            return result;
        }
    }
}
