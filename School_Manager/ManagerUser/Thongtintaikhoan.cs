using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using School_Manager.ManagerUser;

namespace School_Manager.ManagerUser
{
    public class Thongtintaikhoan :BaseManagerUser
    {
        protected string userName;
        protected string passWord;
        public void account(string auserName, string apassWord)
        {
            userName = auserName;
            passWord = apassWord;
        }
        public void save_data(string UserName, string PassWord)
        {
            StreamWriter Data = new StreamWriter(filePath);
            Data.Write("DL" + "(UserName:" + UserName + ";Password:" + PassWord + ")");
            //DL(UserName:0123456789;Password:0123456789)
            Data.Write(Environment.NewLine);
            Data.Flush();
            Data.Close();
            fs.Close();

        }
    }
}
