using System;

namespace CustomDataHelper
{
    public class WebApiResponse<T>
    {
        public T Content { get; set; }
        public string Success { get; set; }
        public ErrorModel Error { get; set; }
        public Exception Exception { get; set; }
    }

    public class ErrorModel
    {
        public string ErrorMessage { get; set; }
    }
}
