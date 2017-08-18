using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WeddingPlanner.Models;
 
namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId {get; set;}
        [Display(Name="Wedder One")]
        public string Wedder1 {get;set;}
        [Display(Name="Wedder Two")]
        public string Wedder2 {get;set;}
        public DateTime Date {get; set;}
        [Display(Name="Wedding Address")]
        public string Address {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get; set;}
        public List<Guest> Guest {get;set;}

        public Wedding(){
            Guest = new List<Guest>();
        }
    }
}

