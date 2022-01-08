using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class ResponseWithData<T> : BasicResponse
    {
        public T Data { get; }

        public ResponseWithData(
            T data,
            bool success = true)
            : base(
                success)
        {
            Data = data;
        }
    }
}