using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Service
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
