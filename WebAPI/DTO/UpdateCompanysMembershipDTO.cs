using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UpdateCompanysMembershipDTO
    {
        public DateTime MembershipEndDate { get; set; }

        public DateTime MembershipValidity { get; set; }
    }
}
