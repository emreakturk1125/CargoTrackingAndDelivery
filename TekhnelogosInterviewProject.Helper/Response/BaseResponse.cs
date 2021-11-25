using System;
using System.Collections.Generic;
using System.Text;

namespace TekhnelogosInterviewProject.Helper.Response
{
    public class BaseResponse<T> where T : class
    {
        public T Content { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public BaseResponse(T content)
        {
            this.Success = true;
            this.Content = content;
        }

        public BaseResponse(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
        }
    }
}
