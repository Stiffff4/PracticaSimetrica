using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;


namespace Database.OperationResult
{
    public interface IOperationResult : ICloneable
    {
        bool isSuccess { get; }
        object result { get; set; }
        object error { get; set; }
        HttpStatusCode status { get; set; }
        void GetSuccessOperation(Object result);
        void GetErrorOperation(Exception message, HttpStatusCode status = HttpStatusCode.InternalServerError, bool IsWarning = false);

    }


    public class OperationResult : IOperationResult
    {

        private HttpStatusCode _status = HttpStatusCode.OK;
        public HttpStatusCode status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }


        private IEnumerable<HttpStatusCode> Success = new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NonAuthoritativeInformation,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent,
            HttpStatusCode.Continue,
        };

        public bool isSuccess
        {
            get
            {
                return (Success.Contains(status));
            }
        }

        private Object _result;
        public Object result
        {
            get
            {
                if (isSuccess)
                    return _result;
                else
                    return null;
            }
            set { _result = value; }
        }

        private Object _error;
        public Object error
        {
            get
            {
                if (!isSuccess || status == HttpStatusCode.Continue)
                    return _error;
                else
                    return null;
            }
            set { _error = value; }
        }

        public void GetSuccessOperation(object result)
        {
            if (result == null)
            {
                this.status = HttpStatusCode.NoContent;
            }
            else
            {
                this.status = HttpStatusCode.OK;
                this.result = result;
            }
        }

        public void GetErrorOperation(Exception message, HttpStatusCode status = HttpStatusCode.InternalServerError, bool IsWarning = false)
        {
            message = message.GetBaseException();
            var handled_error = message.GetBaseException().Message;

            this.status = OperationError(message, status, IsWarning);
            this.error = handled_error;
        }

        public static HttpStatusCode OperationError(Exception ex, HttpStatusCode status, bool IsWarning = false)
        {
            if (ex.Message.Contains("Timeout"))
            {
                status = System.Net.HttpStatusCode.RequestTimeout;
            }
            else if (ex.Message.Contains("No HTTP resource was found"))
            {
                status = HttpStatusCode.NotFound;
            }

            return status;
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
