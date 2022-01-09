using System.Collections.Generic;
using System.Threading.Tasks;
using KanbanBoard.Models;
using KanbanBoard.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace KanbanBoard.Model
{
    public class LoginRepository : IRepository<Login>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();

        public bool Add(Login uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.Login.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
              return flag;
            
        }

        public bool Delete(int Id)
        {
                        bool flag = false;
            Login uObj = ctx.Login.FirstOrDefault(p => p.signup_id == Id);
            if (uObj != null)
            {
            ctx.Login.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<Login> Get()
        {
            throw new NotImplementedException();
        }

        public Login Show(int Id)
        {
            
        return ctx.Login.FirstOrDefault(p => p.signup_id == Id);
         }

        public bool UpDate(int Id, Login sObj)
        {
            bool flag = false;
                Login uObj = ctx.Login.FirstOrDefault(p => p.signup_id == Id);
                if (uObj != null)
                {

                uObj.email_id = sObj.email_id;
                uObj.password = sObj.password;
                uObj.signup_id=sObj.signup_id;
                flag = true;
                ctx.SaveChanges();
                }
                return flag;
        }
    }
}
        