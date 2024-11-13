using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.Models;

public class LoginController : Controller
{
    MyPortfolioContext context = new MyPortfolioContext();

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var admin = await context.Admins
                .FirstOrDefaultAsync(a => a.Email == model.Email && a.Password == model.Password);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminID", admin.AdminID.ToString());
                return RedirectToAction("Index", "Statistic");
            }
            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminID");
        return RedirectToAction("Login");
    }
}
