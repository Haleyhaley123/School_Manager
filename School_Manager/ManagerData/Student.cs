using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using School_Manager.ManagerUser;
using School_Manager.ManagerData;
using School_Manager.Model;

namespace School_Manager.ManagerUser
{
    public class Student : BaseManagerData
    {
        public static List<People> FilterDataToStudent(List<People> listData0)
        {
            List<People> listStudent = new List<People>();
            foreach (var item in listData0)
            {
                if (item.Job == 2)
                {
                    listStudent.Add(item);
                }
                
            }
            return listStudent;
        }
    }
        
        
    
}
