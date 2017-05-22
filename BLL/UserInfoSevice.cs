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

        public async  Task<IEnumerable<UserInfo>> GetListAsync()
        {
           return await Dal.GetListAsync();
        }
        /// <summary>
        ///批量添加用户
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task< bool> AddUserInfosAsync(IEnumerable<UserInfo> list)
        {
            return  true;
        }
        /// <summary>
        /// 查询id或者用户名单个用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserInfo>> GetUserInfoAsync( UserInfo userInfo)
        {
            return  await Dal.GetUserInfoAsync(userInfo);
        }

        public async Task<int> UpdateAsync(UserInfo userInfo)
        {
            return await Dal.UpdateAsync(userInfo);
        }
    }
}
