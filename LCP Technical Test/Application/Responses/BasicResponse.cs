using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class BasicResponse
    {
        public bool Success { get; }

        public BasicResponse(
            bool success = true)
        {
            Success = success;
        }
    }
}
