﻿using System.Text.Json;

namespace MovieSystemWebAPI.Model
{
    public class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
