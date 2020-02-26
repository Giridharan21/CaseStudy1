using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirement_Task_Web.Models {
    public class UserInfoModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Job { get; set; }
    }
    public class NewRequestModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }
        [ForeignKey("PMId")]
        public int ProjManID { get; set; }
        public UserInfoModel PMId { get; set; }
        public NewRequestModel() {
            Status = "Created";
            
        }
    }
    public class UpdatedRequestModel {
        public int Id { get; set; }
        public TrainerInfo Trainer { get; set; }
        public NewRequestModel Request { get; set; }
        public UserInfoModel Executive { get; set; }
    }
    public class TrainerInfo {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
    }
}