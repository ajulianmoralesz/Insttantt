using Insttantt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Interfaces
{
    public interface IErrorServiceProvider
    {
        void AddError(string errorCode, string errorMessage);
        void AddErrorList(List<MessageDto> errors);
        void AddWarning(string warningCode, string warningMessage);
        void AddWarningList(List<MessageDto> warnings);
        List<MessageDto> GetErrors();
        List<MessageDto> GetWarnings();
        bool HasError();
        bool HasWarning();
    }
}
