using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Manager.ManagerUser;

namespace School_Manager.ManagerUser
{
    class AccountUser:BaseManagerUser
    {
        public string userName, passWord, passWordagain;
        public void NguoiDung()
        {
            userName = "";
            passWord = "";
            passWordagain = "";
        }

        public void NguoiDung(string auserName, string apassWord, string apassWordagain)
        {
            userName = auserName;
            passWord = apassWord;
            passWordagain = apassWordagain;

        }
        public bool Kiemtramatkhau()
        {
            bool kiemtrachu = false;
            bool kiemtraso = false;


            if (passWord.Length >= 8)
            {
                return true; ;
            }


            for (int i = 0; i < passWord.Length; i++)
            {
                if (kiemtrachu = true && kiemtraso == true)
                {
                    break;
                }

                if ((passWord[i] >= 'A' && passWord[i] <= 'Z') || (passWord[i] >= 'a' && passWord[i] <= 'z'))
                {
                    kiemtrachu = true;
                }
                if (passWord[i] >= '0' && passWord[i] <= '9')
                {
                    kiemtraso = true;
                }

            }
            if (kiemtraso == false || kiemtrachu == false)
            {
                return false;
            }

            return true;
        }
    }
}
