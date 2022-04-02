using School_Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Manager.ManagerData
{
    class Teacher: BaseManagerData
    {
        public static List<People> FilterDataToTearch(List<People> listData1)
        {
            List<People> listTeacher = new List<People>();
            foreach (var item in listData1)
            {
                if (item.Job == 1)
                {
                    listTeacher.Add(item);
                }
                
            }
            return listTeacher;
        }
    }
}
