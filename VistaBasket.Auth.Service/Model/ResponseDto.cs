﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Auth.Service.Model
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
