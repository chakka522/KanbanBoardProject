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
    public class TasksRepository : IRepository<Tasks>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();

        public bool Add(Tasks uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.Tasks.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
              return flag;
        }

        public bool Delete(int Id)
        {
            bool flag = false;
            Tasks uObj = ctx.Tasks.FirstOrDefault(p => p.task_id == Id);
            if (uObj != null)
            {
            ctx.Tasks.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<Tasks> Get()
        {
            throw new NotImplementedException();
        }

        public Tasks Show(int Id)
        {
            return ctx.Tasks.FirstOrDefault(p => p.task_id == Id);
        }

        public bool UpDate(int Id, Tasks sObj)
        {
            bool flag = false;
                Tasks uObj = ctx.Tasks.FirstOrDefault(p => p.task_id == Id);
                if (uObj != null)
                {

                uObj.task_id = sObj.task_id;
                uObj.task_name = sObj.task_name;
                
                flag = true;
                ctx.SaveChanges();
                }
                return flag;
        }
    }
}



        