using AllaBolag.BL.Models;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace AllaBolag.BL.CustomExceptions
{
    [Serializable]
    public class ArgumentNullExceptionResult<T> : Exception where T : class
    {
        public Result<T> Result { get; set; }
        public ArgumentNullExceptionResult(Result<T> result) : base(result.Message)
        {
            Result = result;
            Debug.WriteLine(Result.ToString());
        }
    }
}