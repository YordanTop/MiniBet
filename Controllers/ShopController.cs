using Microsoft.AspNetCore.Mvc;
using MiniBet.DataBaseConn;
using MiniBet.DataModels;
using MiniBet.Extension;

namespace MiniBet.Controllers
{
    public class ShopController : Controller
    {

        public IActionResult Index()
        {
            return View("../Shop/Shop");
        }
        [HttpGet]
        public IActionResult Purchase(string purchase)
        {
            Authentication.TypeOfPurchase = purchase;
            return View("../Shop/Authentication");
        }
        [HttpPost]
        public IActionResult Purchase(Authentication authentication)
        {
            if (authentication.Card_Code == null || authentication.Security_Code == null)
            {
                return View("../Shop/Authentication");
            }

            MiniBetDBContext dBContext = new MiniBetDBContext();

            Users user = dBContext.Users
                        .Where(u => u.Username == HttpContext.Session.GetString("Username")).FirstOrDefault();


            Purchases purchases = new Purchases();
            purchases.Date_Log = DateTime.Now;
            purchases.UserID = user.UserId;

            Transaction transaction = new Transaction()
            {
                UserId = user.UserId,
                User = user,

                PurchaseId = dBContext.Transactions.Where(t => t.UserId == user.UserId).Count(),
                Purchases = purchases,

                Card_Code = authentication.Card_Code,
                Security_Code = authentication.Security_Code

            };
                purchases.Transaction = transaction;
            if (Authentication.TypeOfPurchase.Equals("small"))
            {
                user.Coins += 100;
                purchases.Coins = 100;
                purchases.Price = 4.99f;

            }
            else
            if (Authentication.TypeOfPurchase.Equals("medium"))
            {
                user.Coins += 300;
                purchases.Coins = 300;
                purchases.Price = 10.99f;
            }
            else
            {
                user.Coins += 500;
                purchases.Coins = 500;
                purchases.Price = 14.99f;
            }
            dBContext.Purchase.Add(purchases);
            dBContext.Transactions.Add(transaction);
            
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
