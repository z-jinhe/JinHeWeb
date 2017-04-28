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
        /// <summary>
        ///批量添加用户
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddUserInfos(IEnumerable<UserInfo> list)
        {
            return true;
        }
        /// <summary>
        /// 查询id或者用户名单个用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public Task<IEnumerable<UserInfo>> GetUserInfo( UserInfo userInfo)
        {
            return Dal.GetUserInfo(userInfo);
        }

        public Task<int> Update(UserInfo userInfo)
        {
            return Dal.Update(userInfo);
        }
    }
}
