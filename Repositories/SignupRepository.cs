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
    public class SignupRepository : IRepository<Signup>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        
public bool Add(Signup uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.Signup.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
              return flag;
        }

        public bool Delete(int Id)
        {
            bool flag = false;
            Signup uObj = ctx.Signup.FirstOrDefault(p => p.signup_id == Id);
            if (uObj != null)
            {
            ctx.Signup.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<Signup> Get()
        {
            throw new NotImplementedException();
        }

        public Signup Show(int Id)
        {
            return ctx.Signup.FirstOrDefault(p => p.signup_id == Id);
        }

        public bool UpDate(int Id, Signup sObj)
        {
            bool flag = false;
                Signup uObj = ctx.Signup.FirstOrDefault(p => p.signup_id == Id);
                if (uObj != null)
                {

                uObj.email_id = sObj.email_id;
                uObj.password = sObj.password;
                uObj.first_name=sObj.first_name;
                uObj.last_name=sObj.last_name;
                uObj.phone_number=sObj.phone_number;
                uObj.signup_id=sObj.signup_id;
                flag = true;
                ctx.SaveChanges();
                }
                return flag;
        }
    }
    }


       
            
        
        