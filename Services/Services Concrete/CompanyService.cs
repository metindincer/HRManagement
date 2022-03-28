using Core.Models;
using Core.Repositories_Abstract;
using Core.Services_Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository= companyRepository;
        }
        public async Task<Company> CreateCompany(Company company)
        {
            await _companyRepository.AddAsync(company);
            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            await _companyRepository.RemoveAsync(company);
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task UpdateCompany(int id, Company company)
        {
            await _companyRepository.UpdateCompanyAsync(id, company);
        }
    }
}
