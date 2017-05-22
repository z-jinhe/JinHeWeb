using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserInfoDal
    {
        //string conStr = @"Data Source=D:\jinxiang\jinxiang.db;Version=3;Legacy Format=True;";
        //private string constr1 = @"Server=localhost;Database=jinhe;Uid=root;Pwd=tianmeng";
        //public async Task<IEnumerable<UserInfo>> GetList()
        //{
        //    //IEnumerable<UserInfo> list = null;
        //    using (IDbConnection con = new MySqlConnection(constr1))
        //    {
        //        con.Open();
        //        string sql = "select * from userinfo";
        //        var  list = await con.QueryAsync<UserInfo>(sql);
        //        return list.ToList();
        //        //list.ToList().ForEach(item =>
        //        //{
        //        //    Console.WriteLine(item.Name);
        //        //});

        //        ////string sql = "insert into home (name) values (@Name);select last_insert_rowid() newid";
        //        //int id = con.Query<int>(sql, new { Name = "蛋蛋" }).FirstOrDefault();

        //        //string sql = "select * from home";
        //        //if (r > 0)
        //        //{
        //        //    Console.WriteLine("插入了{0}", r);
        //        //}
        //        // Console.WriteLine(id);

        //    }

        //}
        public async Task<IEnumerable<UserInfo>> GetListAsync()
        {
            string sql = "select * from JH_userinfo where username=@UserName";
            var list = await DapperHelper.QueryAsync<UserInfo>(sql, new {UserName="tianmeng"});
            return list;
        }
        /// <summary>
        /// 根据用户名或者用户id查找对应的用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserInfo>> GetUserInfoAsync(UserInfo userInfo)
        {
            string sql;
            IEnumerable<UserInfo> userList;
            if (userInfo.Id > 0)
            {
                sql = "select * from JH_userinfo where Id=@Id";
                userList = await DapperHelper.QueryAsync<UserInfo>(sql, new { Id = userInfo.Id });
            }
            else if(!string.IsNullOrWhiteSpace(userInfo.UnionId))
            {
                sql = "select * from JH_userinfo where UnionId=@UnionId";
                userList = await DapperHelper.QueryAsync<UserInfo>(sql, new { UnionId = userInfo.UnionId });
            }
            else
            {
                return null;
            }


            return userList;
        }
        public async Task<int> UpdateAsync(UserInfo userInfo)
        {
            string sql = "UPDATE JH_userinfo SET password = @password WHERE username = @username";
            return await DapperHelper.ExecuteAsync(sql, userInfo);
        }
    }
}
