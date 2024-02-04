using Microsoft.AspNetCore.Mvc;
using MiniBet.DataBaseConn;
using MiniBet.DataModels;
using MiniBet.ValidationModels;
using System.Text.RegularExpressions;

namespace MiniBet.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult CreatingAccount()
        {
            return View("../Sign/Register");
        }

        [HttpPost]

        public IActionResult CreatingAccount(RegisterModel rUser)
        {

            if (Validation(rUser) == true)
            {
                Users user = new Users()
                {
                    Username = rUser.Username,
                    Password = rUser.Password,
                    EmailAddress = rUser.Email,
                    Coins = 0
                };

                Stats stats = new Stats()
                {
                    Wins = 0,
                    Loses = 0,
                    User = user
                };
                MiniBetDBContext dBContext = new MiniBetDBContext();
                dBContext.Users.Add(user);
                dBContext.Stat.Add(stats);
                dBContext.SaveChanges();

                return Redirect("../Home");
            }
            return View("../Sign/Register");
        }

        public bool Validation(RegisterModel rUser)
        {
            MiniBetDBContext dBContext = new MiniBetDBContext();
            if (dBContext.Users.Where(u => u.Username == rUser.Username).Count() > 0)
            {
                this.ModelState.AddModelError("InsertingError", "This user already exist!");
                return false;
            }

            if (rUser.Username == null || rUser.Password == null)
            {
                return false;
            }

            if (rUser.Username.Length < 5 || rUser.Password.Length < 5)
            {
                this.ModelState.AddModelError("InsertingError", "The fields has to have at least 5 symbols!");
                    return false;
            }

            if (!rUser.Password.Equals(rUser.ConfirmPassword))
            {
                this.ModelState.AddModelError("InsertingError", "None matching passwords!");
                return false;
            }

            if (rUser.Email == null)
            {
                this.ModelState.AddModelError("InsertingError", "Not valid email!");
                return false;
            }

            if (Regex.IsMatch(rUser.Email, "/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,4}$/"))
            {
                this.ModelState.AddModelError("InsertingError", "Not valid email!");
                return false;
            }
            return true;
        }
    }
}
