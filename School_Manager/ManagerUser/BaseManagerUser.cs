using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using School_Manager.Model;

namespace School_Manager.ManagerUser
{
    public class BaseManagerUser
    {


        protected static string filePath = @"C:\Users\Admin\Desktop\2\School_Manager\School_Manager\Data\dataUser.txt";
        protected FileStream fs;
        public BaseManagerUser()
        {        
            if (fs == null)
            {
                ReConnect();
            }
        }
        private void ReConnect()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (!fileInfo.Exists)
                {
                    fs = new FileStream(filePath, FileMode.CreateNew);
                }
                else
                {
                    fs = new FileStream(filePath, FileMode.Append);
                    fs.Close();
                }
            }
            catch (Exception)
            {
                
            }
        }
        public static List<User> GetlistDataUser()
        {
            List<User> listpeople = new List<User>();
            string[] ArrFile = File.ReadAllLines(filePath);
            for (int i = 0; i < ArrFile.Length; i++)
                if (ArrFile[i].Contains("DL"))
                {
                    int dem = ArrFile[i].IndexOf(")");
                    string lineNeed = ArrFile[i].Substring(3, (dem - 3));
                    string[] arrlineNeed = lineNeed.Split(';');
                    User user = new User();
                    for (int j = 0; j < arrlineNeed.Length; j++)
                    {
                        int indexUser = arrlineNeed[0].IndexOf(":");
                        user.UserName = arrlineNeed[0].Substring(indexUser + 1);
                        int indexPw = arrlineNeed[1].IndexOf(":");
                        user.Password = arrlineNeed[1].Substring(indexPw + 1);
                    }

                    listpeople.Add(user);
                }
            return listpeople;
        }
    }
}
