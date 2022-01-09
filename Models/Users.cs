using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
namespace KanbanBoard.Models
{
     public class Users
      {
           [Key]
         public int user_id { get; set; }
        public string user_designation{get;set;}
        public int teammember_id{get;set;}
        public int project_id{get;set;}
        public int task_id{get;set;}
        
        [ForeignKey("teammember_id")]

    public TeamMembers TeamMembers{get;set;}
    [ForeignKey("project_id")]

    public Project Project{get;set;}
    [ForeignKey("task_id")]

    public Tasks Tasks{get;set;}
         }
}