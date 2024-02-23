﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaBasket.Catalog.Service.CustomException
{
    public class UserSpecificException : Exception
    {
        public UserSpecificException()
        {

        }

        public UserSpecificException(string msg) : base(msg)
        {

        }
    }
}
