using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class UserInfoSevice
    {
        public UserInfoSevice()
        {
            Dal=new UserInfoDal();
        }
        private  UserInfoDal Dal { get; set; }

        public Task<IEnumerable<UserInfo>> GetList()
        {
           return Dal.GetList();
        }
    }
}
