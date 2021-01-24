using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Demo
{
    class MysqlConnector
    {
        string server = null;
        string userid = null;
        string password = null;
        string database = null;
        string port = "3306";
        string charset = "UTF-8";

        public MysqlConnector() { }
        public MysqlConnector SetServer(string server)
        {
            this.server = server;
            return this;
        }

        public MysqlConnector SetUserID(string userid)
        {
            this.userid = userid;
            return this;
        }

        public MysqlConnector SetDataBase(string database)
        {
            this.database = database;
            return this;
        }

        public MysqlConnector SetPassword(string password)
        {
            this.password = password;
            return this;
        }
        public MysqlConnector SetPort(string port)
        {
            this.port = port;
            return this;
        }
        public MysqlConnector SetCharset(string charset)
        {
            this.charset = charset;
            return this;
        }

        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        private MySqlConnection GetMysqlConnection()
        {
            string M_str_sqlcon = string.Format("server={0};user id={1};password={2};database={3};port={4}", server, userid, password, database, port);
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }

        // 创建表 插入数据 通过指令可控制
        public void MySql_operating(string Str_sqlstr)
        {
            MySqlConnection mysqlcon = this.GetMysqlConnection(); // 创建连接
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(Str_sqlstr, mysqlcon);
            mysqlcom.ExecuteNonQuery(); // 更新数据库
        }
    }
}
