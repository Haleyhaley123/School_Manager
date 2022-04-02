using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Manager.Model
{
    public class People
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Birthday { get; set; }
        // 1 nam ; 2 ; nữ
        public int Gender { get; set; }
        // 1 giáo viên ; 2 học sinh ; 3 nhân viên
        public int Job { get; set; }
    }
}
