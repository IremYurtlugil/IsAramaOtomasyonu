using IsAramaOtomasyonu.FluentAPI.DAL.Repositories;
using IsAramaOtomasyonu.FluentAPI.Entity;
using IsAramaOtomasyonu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.BLL
{
    public class CompanyService
    {
        CompanyRepository companyRepository;
        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }




        //İşveren aynı telefon numarasıyla tekrar kayıt olamamalıdır.
        //İşveren ilk üyelik oluşturduğunda 3 ilan verme hakkı vardır. (Company classında bu iş kuralı sağlandı)
        public bool Add(UserRegisterVM newUser)
        {
            if (companyRepository.AnyPhoneNumber(newUser.PhoneNumber))
            {
                //zaten bu numrada kayıt var geri dön 
                throw new Exception("Bu numarada bir  kayıt bulunmaktadır");
            }

            Company company = new Company()
            {
                CompanyName = newUser.CompanyName,
                Address = newUser.Address,
                Password = newUser.Password,
                PhoneNumber = newUser.PhoneNumber,
                //JobRight=3                
            };
            return companyRepository.Insert(company) > 0;
            //Business Logic Layer 

        }

        public Company CheckLogin(UserLoginVM loginUser)
        {
            return companyRepository.CheckLogin(loginUser.PhoneNumber, loginUser.Password);
        }
    }
}
