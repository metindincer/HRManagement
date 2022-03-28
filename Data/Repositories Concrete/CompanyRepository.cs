using Core.Models;
using Core.Repositories_Abstract;
using Data.Context;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Concrete
{
     public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        protected HRDbContext _context;
        public CompanyRepository(HRDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company company)
        {
            var companyToBeUpdated = await _context.Companies.FindAsync(id);

            if(companyToBeUpdated!=null)
            {
                companyToBeUpdated.CompanyName = company.CompanyName;
                companyToBeUpdated.LogoPath = company.LogoPath;
                companyToBeUpdated.MembershipEndDate = company.MembershipEndDate;
                companyToBeUpdated.MembershipValidity = company.MembershipValidity;

                await _context.SaveChangesAsync();
            }
            return company;
        }
    }
}
