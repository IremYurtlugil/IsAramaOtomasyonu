using IsAramaOtomasyonu.FluentAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.DAL.Repositories
{
    public class CompanyRepository
    {
        IsOtomasyonuDbContext context;
        public CompanyRepository()
        {
            context = new IsOtomasyonuDbContext();
        }
        public int Insert(Company company)
        {
            context.Companies.Add(company);
            return context.SaveChanges();
        }

        public bool AnyPhoneNumber(string phoneNumber)
        {
            //varsa true döner
            return context.Companies.Any(a => a.PhoneNumber == phoneNumber);
        }

        public Company CheckLogin(string phoneNumber, string password)
        {
            return context.Companies.SingleOrDefault(a => a.PhoneNumber == phoneNumber && a.Password == password);
        }
    }
}
