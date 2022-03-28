using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services_Abstract
{
     public interface ICompanyService
    {
        Task<Company> GetCompanyById(int id);
        Task<Company> CreateCompany(Company company);
        Task DeleteCompany(Company company);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task UpdateCompany(int id, Company company);
    }
}
