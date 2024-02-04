using Microsoft.AspNetCore.Mvc;
using MiniBet.DataBaseConn;
using MiniBet.DataModels;

namespace MiniBet.Extension
{
    public static class InfoHelper
    {

        private static readonly MiniBetDBContext context = new MiniBetDBContext();


        public static List<string> GetFriend(int? userID)
        {
            List<string> list = new List<string>();

            foreach(var user in context.Invitation)
            {
                if(user.UserId == userID)
                {
                    list.Add(user.Friends);
                }
            }

            if (list == null)
            return null;

            return list;
        }

        public static List<Purchases> GetPurchases(int? userID)
        {
            List<Purchases> list = new List<Purchases>();

            foreach (var user in context.Purchase)
            {
                if (user.UserID == userID)
                {
                    list.Add(user);
                }
            }

            if (list == null)
                return null;

            return list;
        }
    }
}
