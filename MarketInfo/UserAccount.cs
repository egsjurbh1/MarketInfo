using System;
using System.Data;

namespace MarketInfo
{
    class UserAccount
    {
        /// <summary>
        /// 用户登录，成功返回userid，空账户及密码错返回错误标志
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UserLogin(string username, string password)
        {
            int userid = 0;
            string pwdinDB = null;
            SqlProcess sp = new SqlProcess();
            DataTable dt = new DataTable();

            string sql = "select userid, pwd from market..customer where username = '" + username + "';";
            sp.ExecSingleSQL(CfgStruct.dbconnect_str, sql, dt);
            
            //未查到
            if (dt.Rows.Count == 0)
                return FlagDef.ACCOUNTWRONG;    //账户不存在
            else
            {
                userid = Int32.Parse(dt.Rows[0]["userid"].ToString().Trim());
                pwdinDB = dt.Rows[0]["pwd"].ToString().Trim();
                if (string.Compare(password, pwdinDB) != 0)
                    userid = FlagDef.PWDWRONG;  //密码错误
            }
            return userid;
        }
    }
}
