using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLiNhaHang.Areas.Admin.Data;

namespace WebQuanLiNhaHang.Models
{
    public class UserDao
    {
        Model2 db = new Model2();

        public long Insert(tAdmin user)
        {
            db.tAdmins.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.tAdmins.Count(x => x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public tAdmin GetByName(string username)
        {
            return db.tAdmins.SingleOrDefault(x => x.Username == username);
        }
    }
}