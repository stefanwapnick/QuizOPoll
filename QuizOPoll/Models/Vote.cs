using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizOPoll.Models
{
    public class Vote
    {
        public int Id {get; set;}

        //public int PollId {get; set;}
        public int PollAnswerId {get; set;}

        [ForeignKey("User")]
        public string UserId {get; set;}

        public DateTime DateCreated {get; set;}
        
        public virtual ApplicationUser User {get; set;}
        //public virtual Poll Poll {get; set;}
        public virtual PollAnswer PollAnswer {get; set;}
    }
}