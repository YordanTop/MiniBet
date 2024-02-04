using Microsoft.AspNetCore.Mvc;
using MiniBet.DataBaseConn;
using MiniBet.DataModels;
using MiniBet.Extension;
using MiniBet.ValidationModels;

namespace MiniBet.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("../Profile/Profile");
        }
        private static readonly MiniBetDBContext context = new MiniBetDBContext();

        [HttpPost]
        public IActionResult SearchPlayer(PlayerModel player)
        {
            if(!this.ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            foreach (var user in context.Users)
            {
                if (user.Username == player.Username)
                {
                    var viewModel = new PlayerModel();
                    viewModel.Username = user.Username;

                    return View("Profile", viewModel);
                }
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Add(string add)
        {
            InvitationModel.Player = add;
            return RedirectToAction("AddUser");
        }

        public IActionResult AddUser()
        {

            if(InvitationModel.Player != null)
            {
                if (UserValidation())
                {
                    Invitations inv = new Invitations();
                    inv.UserId = (int)HttpContext.Session.GetInt32("ID");
                    inv.Friends = InvitationModel.Player;

                    context.Invitation.Add(inv);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(string remove)
        {
            InvitationModel.Player = remove;
            return RedirectToAction("RemoveUser");
        }

        public IActionResult RemoveUser()
        {
            if (InvitationModel.Player != null)
            {

                Invitations inv = new Invitations();
                
                inv = context.Invitation.Where(x => x.Friends == InvitationModel.Player).FirstOrDefault();

                context.Invitation.Remove(inv);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public bool UserValidation()
        {
            if (InvitationModel.Player == HttpContext.Session.GetString("Username"))
            {
                this.ModelState.AddModelError("UserError", "You can't search your self!");
                return false;
            }

            if (context.Users.Where(u => u.Username == InvitationModel.Player).Count() <= 0)
            {
                this.ModelState.AddModelError("UserError", "This user these not exist!");
                return false;
            }
            
            if (context.Invitation.Where(u => u.Friends == InvitationModel.Player).Count() > 0)
            {
                this.ModelState.AddModelError("UserError", "You already hava the user as a friend!");
                return false;
            }
            
            return true;
        }

    }
}
