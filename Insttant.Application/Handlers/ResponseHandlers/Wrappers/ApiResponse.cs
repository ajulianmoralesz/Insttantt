using Insttantt.Application.Extensions;
using Insttantt.Domain.Enums;
using Insttantt.Domain.Models;
using System.Runtime.Serialization;

namespace Insttantt.Application.Handlers.ResponseHandlers.Wrappers
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError? ResponseException { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object? Content { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<MessageDto>? ErrorList { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<MessageDto>? WarningList { get; set; }

        public bool Success { get; set; } = true;

        public ApiResponse() { }

        public ApiResponse(
            object? content = null,
            List<MessageDto>? warnings = null,
            int statusCode = 200,
            ResponseMessageEnum message = ResponseMessageEnum.Success,
            List<MessageDto>? errors = null,
            ApiError? apiError = null,
            string apiVersion = "1.0.0"
        )
        {
            StatusCode = statusCode;
            Message = message.GetDescriptionByVal();
            Content = content;
            ResponseException = apiError;
            Version = apiVersion;
            ErrorList = errors;
            WarningList = warnings;
        }
    }
}
