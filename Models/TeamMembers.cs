using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace KanbanBoard.Models
{
     public class TeamMembers
      {

        [Key]
         public int teammember_id { get; set; }
        public string teammember_name{get;set;}
        public string teammember_designation{get;set;}
        public int project_id{get;set;}
        public int task_id{get;set;}
        [ForeignKey("project_id")]

    public Project Project{get;set;}
    [ForeignKey("task_id")]

    public Tasks Tasks{get;set;}
         }

}