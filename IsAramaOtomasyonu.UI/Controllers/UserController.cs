using IsAramaOtomasyonu.BLL;
using IsAramaOtomasyonu.FluentAPI.Entity;
using IsAramaOtomasyonu.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.UI.Controllers
{
    public class UserController : Controller
    {
        CompanyService companyService;
        public UserController()
        {
            companyService = new CompanyService();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterVM newUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAddCompleted = companyService.Add(newUser);
                    if (isAddCompleted)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("exception", ex.Message);
                }
            }
            return View(newUser);

        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Request.Cookies.ContainsKey("phone") && HttpContext.Request.Cookies.ContainsKey("password"))
            {
                string phoneNumber = HttpContext.Request.Cookies["phone"];
                string password = HttpContext.Request.Cookies["password"];
                Company company = companyService.CheckLogin(new UserLoginVM() { Password = password, PhoneNumber = phoneNumber });
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Login(UserLoginVM loginUser)
        {
            if (ModelState.IsValid)
            {
                Company company = companyService.CheckLogin(loginUser);
                if (company != null)
                {
                    //giriş yapabilir
                    if (loginUser.IsRemember)
                    {
                        //eğer doğru bilgileri girdiyse ve checkboxa tıkladıysa o zaman kullanıcının phone ve password bilgilerini cookieye kayıt edin.

                        //Cookie Nedir ? State Management 
                        /*Son kullanıcının bilgisayarında sakladığınız küçük kayıtlardır. */
                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMonths(1));
                        HttpContext.Response.Cookies.Append("phone", loginUser.PhoneNumber, cookieOptions);
                        HttpContext.Response.Cookies.Append("password", loginUser.Password, cookieOptions);
                    }
                    return RedirectToAction(nameof(User), "Home");
                }
            }
            return View(loginUser);
        }

    }
}
