using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_CF {
    public class Data {
        public static UserInfo Authenticate(UserInfo user) {
            model1 context = new model1();
            var check = context.Users.Where(i => i.Name == user.Name && i.Pass == user.Pass).Select(i => i).FirstOrDefault();
            return check;
        }
        public static void CreateRequest(NewRequest req) {
            model1 context = new model1();
            context.Request.Add(req);
            context.SaveChanges();
        }
        public static List<NewRequest> ViewCreatedRequest() {
            model1 context = new model1();
            return context.Request.ToList();
        }
        public static void update(int r, int e, int t) {

            model1 context = new model1();
            UpdatedRequest up = new UpdatedRequest();
            up.Request = context.Request.Where(i => i.Id == r).Select(i => i).FirstOrDefault();
            up.Request.Status = "Assigned";
            up.Executive = context.Users.Where(i => i.Id == e).Select(i => i).FirstOrDefault();
            up.Trainer = context.Trainers.Where(i => i.Id == t).Select(i => i).FirstOrDefault();
            context.UpdatedReq.Add(up);
            context.SaveChanges();
        }
        public static void update(int r, string s) {
            model1 context = new model1();
            var temp =context.Request.Where(i => i.Id == r).FirstOrDefault();
            temp.Status = s;
            context.SaveChanges();
        }
    }
}
