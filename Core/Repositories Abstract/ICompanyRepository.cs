using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories_Abstract
{
  public  interface ICompanyRepository :IRepository<Company>
    {
        Task<Company> UpdateCompanyAsync(int id, Company company);
    }
}
