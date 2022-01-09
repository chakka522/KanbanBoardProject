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
    public class TeamMembersRepository : IRepository<TeamMembers>
    {
        ApplicationDbContext ctx = new ApplicationDbContext();

        public bool Add(TeamMembers uObj)
        {
            bool flag = false;
            if (uObj != null)
            {
            ctx.TeamMembers.Add(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public bool Delete(int Id)
        {
                        bool flag = false;
            TeamMembers uObj = ctx.TeamMembers.FirstOrDefault(p => p.teammember_id == Id);
            if (uObj != null)
            {
            ctx.TeamMembers.Remove(uObj);
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<TeamMembers> Get()
        {
            throw new NotImplementedException();
        }

        public TeamMembers Show(int Id)
        {
            return ctx.TeamMembers.FirstOrDefault(p => p.teammember_id == Id);
        }

        public bool UpDate(int Id, TeamMembers sObj)
        {
                        bool flag = false;
            TeamMembers uObj = ctx.TeamMembers.FirstOrDefault(p => p.teammember_id == Id);
            if (uObj != null)
             {



            uObj.teammember_id = sObj.teammember_id;
            uObj.teammember_designation = sObj.teammember_designation;
            uObj.teammember_name=sObj.teammember_name;
            uObj.project_id=sObj.task_id;
            uObj.task_id=sObj.project_id;
            flag = true;
            ctx.SaveChanges();
            }
            return flag;
        }
    }
}


        
        