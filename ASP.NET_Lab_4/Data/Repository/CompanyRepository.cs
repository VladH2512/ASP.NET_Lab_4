using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.Data.Repository
{
    public class CompanyRepository : IClothesCompany
    {
        private readonly AppDBContent appDBContent;
        public CompanyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Company> AllCompanies => appDBContent.Company;
    }
}
