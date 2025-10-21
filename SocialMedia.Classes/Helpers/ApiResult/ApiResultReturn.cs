namespace SocialMedia.Shared.Helpers.ApiResult
{
    public static class ApiResultReturn
    {
        public static ApiResult<object> Ok(string message = "") => new() { Success = true, Data = null, Message = message };

        public static ApiResult<T> Ok<T>(T data, string message = "") => new() { Success = true, Data = data, Message = message };

        public static ApiResult<object> Fail(IEnumerable<string> errors, string message = "") => new() { Success = false, Errors = errors, Message = message };

        public static ApiResult<T> Fail<T>(IEnumerable<string> errors, string message = "") => new() { Success = false, Errors = errors, Message = message };
    }
}
