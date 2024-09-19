

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.ViewModel.Infrastructure;






    public class ResultsVM<T>
    {

        public List<string> ErrorMessages { get; set; }
        public bool Error { get; set; }

        public ResultsVM()
        {
            ErrorMessages = new List<string>();
            Value = default;

        }
        public bool Success { get { return !Error; } }
        public string SuccessMessage { get; set; }
        public string WarningMessage { get; set; }
        public InterfaceErrorType? ErrorType
        {
            get; set;
        }
        public Exception Exception { get; set; }
        public T Value { get; set; }
        public string LastErrorMessage { get; set; }
        public ResultsVM<T> AddCriticalErrorMessage(string error, InterfaceErrorType? errorType = InterfaceErrorType.ValidationError)
        {
            if (errorType != null)
            {
                ErrorType = errorType;
            }

            Error = true;
            if (string.IsNullOrEmpty(error))
            {
                error = "Undefined error";
            }
            LastErrorMessage = error;
            ErrorMessages.Add(error);
            return this;
        }
        public ResultsVM<T> AddSuccessMessage(string message)
        {
            SuccessMessage = message;
            return this;
        }

        public ResultsVM<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            LastErrorMessage = message;
            return this;
        }
        public ResultsVM<T> AddWarningMessage(string message)
        {
            WarningMessage = message;
            return this;
        }

        public List<string> GetErrorMessages()
        {
            return ErrorMessages;
        }

        public void SetException(Exception ex, string errorMessage = "Unhandled exception occured!")
        {
            Exception = ex;
            Error = true;
            ErrorType = InterfaceErrorType.Exception;
            AddCriticalErrorMessage(errorMessage);
        }

    }

    public enum InterfaceErrorType
    {
        ValidationError,
        Exception
    }
