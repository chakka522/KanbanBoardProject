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
    public class UsersRepository : IRepository<Users>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();

        public bool Add(Users uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.Users.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
              return flag;
        }

        public bool Delete(int Id)
        {
            bool flag = false;
            Users uObj = ctx.Users.FirstOrDefault(p => p.user_id == Id);
            if (uObj != null)
            {
            ctx.Users.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<Users> Get()
        {
            throw new NotImplementedException();
        }

        public Users Show(int Id)
        {
            return ctx.Users.FirstOrDefault(p => p.user_id == Id);
        }

        public bool UpDate(int Id, Users sObj)
        {
            bool flag = false;
                Users uObj = ctx.Users.FirstOrDefault(p => p.user_id == Id);
                if (uObj != null)
                {

                uObj.user_id = sObj.user_id;
                uObj.user_designation = sObj.user_designation;
                uObj.teammember_id=sObj.teammember_id;
                uObj.task_id=sObj.task_id;
                uObj.project_id=sObj.project_id;
                flag = true;
                ctx.SaveChanges();
                }
                return flag;
        }
    }

}

        
        