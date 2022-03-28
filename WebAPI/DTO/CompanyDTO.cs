using Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class CompanyDTO
    {
       
        public string CompanyName { get; set; }

        public string LogoPath { get; set; }

        public DateTime? MembershipEndDate { get; set; }

        public DateTime? MembershipValidity { get; set; }
       
    }
}
