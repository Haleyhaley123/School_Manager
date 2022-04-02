using School_Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Manager.ManagerData
{
    class Employee : BaseManagerData
    {
        public static List<People> FilterDataToEmployee(List<People> listData2)
        {
            List<People> listEmloyee = new List<People>();
            foreach (var item in listData2)
            {
                if (item.Job == 3)
                {
                    listEmloyee.Add(item);
                }
            }
            return listEmloyee;
        }
    }
}
