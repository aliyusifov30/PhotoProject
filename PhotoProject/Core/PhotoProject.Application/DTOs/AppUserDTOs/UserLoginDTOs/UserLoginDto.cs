﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.DTOs.AppUserDTOs.UserLoginDTOs
{
    public class UserLoginDto
    {
        public string UserNameOrEmail { get; set;}
        public string Password { get; set; }
    }
}
