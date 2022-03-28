﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UserLogInDTO
    {
        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password, ErrorMessage = "Password should have min 1 lowercase letter, 1 uppercase letter, 1 number, 1 non alphanumeric character and min 6 characters total")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
