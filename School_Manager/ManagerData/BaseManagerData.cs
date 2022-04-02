using School_Manager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Manager.ManagerData
{
    public class BaseManagerData
    {
        public static string file = @"C:\Users\Admin\Desktop\WinForm\School_Manager\School_Manager\Data\data.txt";
        public static List<People> GetlistData()
        {
            List<People> listpeople = new List<People>();
            string[] ArrFile = File.ReadAllLines(file);
            for (int i = 0; i < ArrFile.Length; i++)
                if (ArrFile[i].Contains("DL"))
                {
                    int dem = ArrFile[i].IndexOf(")");
                    string lineNeed = ArrFile[i].Substring(3, (dem - 3));
                    string[] arrlineNeed = lineNeed.Split(';');
                    People people = new People();
                    for (int j = 0; j < arrlineNeed.Length; j++)
                    {
                        int indexID = arrlineNeed[0].IndexOf(":");
                        people.ID = arrlineNeed[0].Substring(indexID + 1);
                        int indexName = arrlineNeed[1].IndexOf(":");
                        people.Name = arrlineNeed[1].Substring(indexName + 1);
                        int indexAge = arrlineNeed[2].IndexOf(":");
                        people.Age = arrlineNeed[2].Substring(indexAge + 1);
                        int indexBirthday = arrlineNeed[3].IndexOf(":");
                        people.Birthday = arrlineNeed[3].Substring(indexBirthday + 1);
                        int indexGender = arrlineNeed[4].IndexOf(":");
                        people.Gender = int.Parse(arrlineNeed[4].Substring(indexGender+1)) ;
                        int indexJob = arrlineNeed[5].IndexOf(":");
                        people.Job = int.Parse(arrlineNeed[5].Substring(indexJob+1));
                    }

                    listpeople.Add(people);
                }
            return listpeople;
        }
        public bool Savedata(string ID, string Name, string Age, string Birthday, int Gender, int Job)
        {
            try
            {
                var listdata = GetlistData();
                // đây là câu lệnh linq kiểm tra xem danh sách có tồn tại thằng ID nào giống thằng kia ko
                bool isID = listdata.Any(x => x.ID == ID);

                if (isID)
                {
                    // update lại dữ liệu
                    foreach (var item in listdata)
                    {
                        if (item.ID == ID)
                        {

                            item.Name = Name;
                            item.Age = Age;
                            item.Birthday = Birthday;
                            item.Gender = Gender;
                            item.Job = Job;
                        }
                    }
                    string data = "";
                    foreach (var item in listdata)
                    {
                        data = data + "DL" + "(ID:" + item.ID + ";Name:" + item.Name + ";Age:" + item.Age + ";Birthday:" + item.Birthday + ";Gender:" + item.Gender + ";Job:" + item.Job + ")" + Environment.NewLine;
                    }
                    // đây là lệnh xóa hết cái cũ đi, ghi lại cái mới
                    File.WriteAllText(file, data);

                }
                else
                {
                    FileStream fs;
                    FileInfo fistu = new FileInfo(file);
                    if (!fistu.Exists)
                    {
                        fs = new FileStream(file, FileMode.CreateNew);
                    }
                    else
                    {
                        fs = new FileStream(file, FileMode.Append);

                    }
                    StreamWriter wstu = new StreamWriter(fs);

                    wstu.Write("DL" + "(ID:" + ID + ";Name:" + Name + ";Age:" + Age + ";Birthday:" + Birthday + ";Gender:" + Gender + ";Job:" + Job + ")");

                    wstu.Write(Environment.NewLine);
                    wstu.Flush();
                    wstu.Close();
                    fs.Close();
                }

                return true;

            }
            catch
            {
                return false;
            }
            
        }
        public bool DeletePeople(List<People> lisDataNew)
        {
            try
            {
                string data = "";
                foreach (var item in lisDataNew)
                {
                    data = data + "DL" + "(ID:" + item.ID + ";Name:" + item.Name + ";Age:" + item.Age + ";Birthday:" + item.Birthday + ";Gender:" + item.Gender + ";Job:" + item.Job + ")" + Environment.NewLine;
                }
                // đây là lệnh xóa hết cái cũ đi, ghi lại cái mới
                File.WriteAllText(file, data);
                return true;
            }
            catch
            {
                // try và catch là cái thực hiện nếu trong quá trình xử lý có lỗi thì  nó sẽ nhảy vào catch chứ ko bị chết chương trình
                return false;
            }
            
        }
    }
}
