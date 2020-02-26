using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace DataAccess_CF
{
    public class UserInfo {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Job { get; set; }
    }
    public class NewRequest {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }        
        public string Status { get; set; }
        [ForeignKey("PMId")]        
        public int ProjManID { get; set; }
        public UserInfo PMId { get; set; }
        public NewRequest() {
            Status = "Created";
            //PMId = new UserInfo();
        }
    }
    public class UpdatedRequest {
        public int Id { get; set; }
        public TrainerInfo Trainer { get; set; }
        public NewRequest Request { get; set; }
        public UserInfo Executive { get; set; }
    }
    public class TrainerInfo {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
    }
}
