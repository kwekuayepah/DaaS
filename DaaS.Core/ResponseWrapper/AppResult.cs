using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DaaS.Core.ResponseWrapper
{
     public class AppResult 
    {
        public string Message { get; set; }
        public AppStatus Status { get; set; }
        [XmlIgnore]
        public object Data { get; set; }

        //public int? Page { get; set; }
        //public int? PageSize { get; set; }
        //public int? TotalRecords { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public bool IsSuccessful { get; set; }

        public static AppResult Result(AppStatus status, string message = null, object data = null)
        {
            var result = new AppResult { Status = status, Message = message ?? status.ToString(), Data = data, IsSuccessful = status == AppStatus.Success ? true : false };
            return result;
        }

        public static AppResult Error(string message = null, object data = null) => Result(AppStatus.Error, message, data);

        public static AppResult Success(string message = null, object data = null) => Result(AppStatus.Success, message, data);

        public static AppResult Fail(string message = null, object data = null) => Result(AppStatus.Fail, message, data);
        public static AppResult FailedDependency(string message = null, object data = null) => Result(AppStatus.FailedDependency, message, data);

        public static AppResult NotFound(string message = null, object data = null) => Result(AppStatus.NotFound, message, data);
        
        public static AppResult Unauthorized(string message = null, object data = null) => Result(AppStatus.Unauthorized, message, data);

        public static AppResult ModelError(string message = "Please provide valid data", object data = null) => Result(AppStatus.ModelError, message, data);


        public IActionResult ToIActionResult()
        {
            switch (Status)
            {
                case AppStatus.Success:
                    return new OkObjectResult(this);

                case AppStatus.Error:
                    this.Message = "An error occurred please try again later";
                    return new BadRequestObjectResult(this);

                case AppStatus.Fail:
                    return new BadRequestObjectResult(this);

                case AppStatus.Unauthorized:
                    return new UnauthorizedObjectResult(this);

                case AppStatus.NotFound:
                    return new NotFoundObjectResult(this);

                case AppStatus.InternationalCard:
                    return new OkObjectResult(this);

                case AppStatus.RequireAction:
                    return new OkObjectResult(this);

                default:
                    return new BadRequestObjectResult(this);
            }
        }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class AppResult<T> : AppResult where T : class
    {
        public new T Data { get; set; }

        public static AppResult<T> Result(AppStatus status, string message = null, T data = null) => 
            new AppResult<T> { Status = status, Message = message ?? status.ToString(), Data = data, IsSuccessful = status == AppStatus.Success ? true : false };

        public static AppResult<T> Error(string message = null, T data = null) => Result(AppStatus.Error, message, data);

        public static AppResult<T> Success(string message = null, T data = null) => Result(AppStatus.Success, message, data);

        public static AppResult<T> Fail(string message = null, T data = null) => Result(AppStatus.Fail, message, data);
        public static AppResult<T> FailedDependency(string message = null, T data = null) => Result(AppStatus.FailedDependency, message, data);

        public static AppResult<T> NotFound(string message = null, T data = null) => Result(AppStatus.NotFound, message, data);

        public static AppResult<T> ModelError(string message = "Please provide valid data", T data = null) => Result(AppStatus.ModelError, message, data);
    }


    public enum AppStatus
    {
        Success = 200,
        Error = 500,
        Fail = 502,
        Unauthorized = 401,
        NotFound= 404 ,
        ModelError = 400,
        OutsideZone = 416,
        InternationalCard = 250,
        RequireAction = 260,
        FailedDependency=424
    }
}