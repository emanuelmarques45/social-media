namespace SocialMedia.Lib.Helpers.ApiResult
{
    public static class ApiResultReturn
    {
        public static ApiResult<T> Ok<T>(T data, string message = "") => new() { Success = true, Data = data, Message = message };

        public static ApiResult<T> Fail<T>(IEnumerable<string> errors) => new() { Success = false, Errors = errors, Message = string.Empty };
    }
}
