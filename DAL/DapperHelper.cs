using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace DAL
{
    
    public static class DapperHelper
    {
        private static readonly string ConStr =System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;//@"Server=bdm275070332.my3w.com;Database=bdm275070332_db;Uid=bdm275070332;Pwd=pspgbcong";
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <typeparam name="T">T类型要是class类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param ) where T:class
        {
            IEnumerable<T> list;
            using (IDbConnection con = new MySqlConnection (ConStr))
            {
                con.Open();
                list =await con.QueryAsync<T>(sql,param);
            }
            return list;
        }

        public static async  Task<int> ExecuteAsync(string sql,object param)
        {
            int r;
            using (IDbConnection con = new MySqlConnection(ConStr))
            {
                con.Open();
                r = await con.ExecuteAsync(sql, param);
            }
            return r;
        }
    }
}
