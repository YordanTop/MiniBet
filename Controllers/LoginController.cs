using Microsoft.AspNetCore.Mvc;
using MiniBet.DataBaseConn;
using MiniBet.DataModels;
using MiniBet.ValidationModels;
using Microsoft.AspNetCore.Session;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Net.Http;
using System;

namespace MiniBet.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult LoginValidation()
        {

            return View("../Sign/Sign");
        }

        [HttpPost]

        public IActionResult LoginValidation(LoginModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return View("../Sign/Sign",user);
            }
            MiniBetDBContext dBContext = new MiniBetDBContext();

            //Checking for matching user
            Users ValidatedUser = null;
            foreach(Users x in dBContext.Users)
            {
                if(x.Username == user.Username && x.Password == user.Password)
                {
                    ValidatedUser = x;
                    break;
                }
            }

            if (ValidatedUser == null)
            {
                this.ModelState.AddModelError("InvalidUsername", "Wrong username or password!");
                return View("../Sign/Sign", user);
            }
            Stats? stats = new Stats();

            stats = dBContext.Stat.Where(s => s.UserId == ValidatedUser.UserId).FirstOrDefault();

            //Creating Session properties
            HttpContext.Session.SetInt32("ID", ValidatedUser.UserId);
            HttpContext.Session.SetString("Username", ValidatedUser.Username);
            HttpContext.Session.SetString("Password", ValidatedUser.Password);
            if (stats != null)
            {
                HttpContext.Session.SetInt32("Wins", (int)stats.Wins);
                HttpContext.Session.SetInt32("Loses", (int)stats.Loses);
            }
            else
            {
                stats.Wins = 0;
                stats.Loses = 0;

                dBContext.Stat.Add(stats);
                dBContext.SaveChanges();

                HttpContext.Session.SetInt32("Wins", (int)stats.Wins);
                HttpContext.Session.SetInt32("Loses", (int)stats.Loses);
            }



            return Redirect("../Slots");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Password");
            return Redirect("../Home");
        }
    }
}
