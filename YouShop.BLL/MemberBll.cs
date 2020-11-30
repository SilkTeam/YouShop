using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouShop.DAL;

namespace YouShop.BLL
{


    public class MemberBll
    {
        private YoungShopEntites _ef;
        private YoungShopEntites EF
        {
            get
            {
                if (_ef == null)
                    _ef = new YoungShopEntites();
                return _ef;
            }
        }

        public List<Model.User> GetUser(out int count, int pageIndex, int pageSize)
        {
            // out 使用out参数时在方法内改变了值将影响到传入的参数
            count = EF.Users.Count();
            return EF.Users.OrderBy(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public bool  Add(Model.User user){

            EF.Users.Add(user);
            return EF.SaveChanges() > 0;

}
        public Model.User GetMember(int ID)
        {
            var member = EF.Users.FirstOrDefault(x => x.ID == ID);
            return member;


        }

        public  bool Update(Model.User user)
        {
            var member = EF.Users.FirstOrDefault(x => x.ID ==user.ID);
            member = user;
            int member1 = EF.SaveChanges();
            return member1 > 0;


        }

        public bool Delte (int ID)
        {
            var member = EF.Users.FirstOrDefault(x => x.ID == ID);
            EF.Users.Remove(member);
            int num = EF.SaveChanges();
            return num > 0;

        }
    }
}
