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
    public class ProjectRepository : IRepository<Project>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();

        public bool Add(Project uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.Project.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
              return flag;
        }

        public bool Delete(int Id)
        {
             bool flag = false;
            Project uObj = ctx.Project.FirstOrDefault(p => p.project_id == Id);
            if (uObj != null)
            {
            ctx.Project.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<Project> Get()
        {
            throw new NotImplementedException();
        }

        public Project Show(int Id)
        {
              return ctx.Project.FirstOrDefault(p => p.project_id == Id);
        }

        public bool UpDate(int Id, Project sObj)
        {
            bool flag = false;
                Project uObj = ctx.Project.FirstOrDefault(p => p.project_id == Id);
                if (uObj != null)
                {

                uObj.project_id = sObj.project_id;
                uObj.project_name = sObj.project_name;
                uObj.task_id=sObj.task_id;
                flag = true;
                ctx.SaveChanges();
                }
                return flag;
        }
    }
}


        
        