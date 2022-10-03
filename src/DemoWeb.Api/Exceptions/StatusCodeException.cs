﻿using System.Net;

namespace DemoWeb.Api.Exceptions
{
    public class StatusCodeException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public StatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            HttpStatusCode = statusCode;
        }
    }
}
