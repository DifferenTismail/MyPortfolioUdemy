using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MyPortfolioUdemy.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = context.Contacts.FirstOrDefault();
            return View(value); 
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            var value = context.Contacts.Update(contact);   
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
