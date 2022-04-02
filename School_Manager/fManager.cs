using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Manager.ManagerData;
using School_Manager.ManagerUser;
using School_Manager.Model;
using Timer = System.Timers.Timer;
using System.Data.SqlClient;

namespace School_Manager
{
    public partial class fManager : Form
    {
        SqlConnection sqlConection;
        SqlCommand sqlCommand;
        string Str = @"Data Source=PRETTY\SQLEXPRESS;Initial Catalog=SchoolManagement;Integrated Security=True";
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

        protected void loaddata (string TV)
        {   
            sqlCommand = sqlConection.CreateCommand();
            sqlCommand.CommandText = TV ;
            DataAdapter.SelectCommand = sqlCommand;
            Table.Clear();
            DataAdapter.Fill(Table);
            dtgvShow.DataSource = Table;
        }
        private void fManager_Load(object sender, EventArgs e)
        {
           
        }



        private static Timer _timer;

        public fManager(User user)
        {
            InitializeComponent();
            // đây là lệnh ko cho viết chữ lên combobox, cái này có ở phần property rồi , ờ ,t quen dùng lệnh hơn là làm cái đó
            // khi khởi tạo trang thì nó sẽ nhảy vào hàm contructor này đầu tiên
            cbShow.DropDownStyle = ComboBoxStyle.DropDownList;
            timeLogin.Text = DateTime.Now.ToString("dd/MM/yyyy HH/mm/ss");
            userName.Text = user.UserName;
            // chạy 
            SetTimerCountDown();
        }
        


        // Đây là cách xử dụng 1 cái timer xây dựng sự kiện với khoảng thời gian mình muôn, giống cái timer m học trong winfroms
        //nhưng dùng cái này thì  sau này chỗ nào m cũng dùng được nó 
        private void SetTimerCountDown()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += OnTimedEventCountDown;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        private void OnTimedEventCountDown(Object source, System.Timers.ElapsedEventArgs e)
        {
            timeNow.Invoke(new MethodInvoker(delegate ()
            {
                timeNow.Text = DateTime.Now.ToString("dd/MM/yyyy HH/mm/ss");
            })); 
        }

      


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           // var listData = Student.GetlistData(); // cái này gọi lần ở đây thôi , gọi chi nhiều
            if (cbShow.Text == "Tất cả")
            {
                sqlConection = new SqlConnection(Str);
                sqlConection.Open();
                loaddata("select * from dbo.Student, dbo.Teacher, dbo.Employee");
              
                //ShowDataGridView(listData);
                //int numRows = dtgvShow.Rows.Count - 1;
                //txbAll.Text = numRows.ToString();
            }
            else if (cbShow.Text == "Học sinh")
            {
                sqlConection = new SqlConnection(Str);
                sqlConection.Open();
                loaddata("select * from Student");

                //List<People> listStudent = new List<People>();
                //listStudent = Student.FilterDataToStudent(listData);
                //ShowDataGridView(listStudent);
                //int numRows1 = dtgvShow.Rows.Count - 1;
                //txbStudent.Text = numRows1.ToString();
            }
            else if (cbShow.Text == "Giáo viên")
            {
                sqlConection = new SqlConnection(Str);
                sqlConection.Open();
                loaddata("select * from Teacher");

                //List<People> listTeacher = new List<People>();
                //listTeacher = Teacher.FilterDataToTearch(listData);
                //ShowDataGridView(listTeacher);
                //int numRows2 = dtgvShow.Rows.Count - 1;
                //txbTeacher.Text = numRows2.ToString();
            }
            else if (cbShow.Text == "Nhân viên")
            {
                sqlConection = new SqlConnection(Str);
                sqlConection.Open();
                loaddata("select * from Employee");

                //List<People> listEmloyee = new List<People>();
                //listEmloyee = Employee.FilterDataToEmployee(listData);
                //ShowDataGridView(listEmloyee);
                //int numRows3 = dtgvShow.Rows.Count - 1;
                //txbEmployee.Text = numRows3.ToString();
            }
           
        }

        // code người ta thế này thôi ,  phải truyền param vào mà tái xử dụng code chứ
        private void ShowDataGridView(List<People> listData)
        {
            if (listData != null && listData.Count > 0)
            {
                int count = 0;
                // trước khi add data vào thì phải clear hết cái cũ đi
                dtgvShow.Rows.Clear();
                foreach (var student in listData)
                {
                    var row = new DataGridViewRow();
                    dtgvShow.Rows.Add(row);
                    dtgvShow.Rows[count].Cells[0].Value = student.ID;
                    dtgvShow.Rows[count].Cells[1].Value = student.Name;
                    dtgvShow.Rows[count].Cells[2].Value = student.Age;
                    dtgvShow.Rows[count].Cells[3].Value = student.Birthday;
                    if (student.Gender == 1)
                    {
                        dtgvShow.Rows[count].Cells[4].Value = "Nam";
                    }
                    else if (student.Gender == 2)
                    {
                        dtgvShow.Rows[count].Cells[4].Value = "Nữ";
                    }
                    if (student.Job == 1)
                    {
                        dtgvShow.Rows[count].Cells[5].Value = "Giáo viên";
                    }
                    else if (student.Job == 2)
                    {
                        dtgvShow.Rows[count].Cells[5].Value = "Học sinh";
                    }
                    else
                    {
                        dtgvShow.Rows[count].Cells[5].Value = "Nhân viên";
                    }
                    dtgvShow.Rows[count].Cells[6].Value = "Xóa";
                    dtgvShow.Rows[count].Cells[6].Style.ForeColor = Color.Red;
                    dtgvShow.Rows[count].Cells[7].Value = "Sửa";
                    dtgvShow.Rows[count].Cells[7].Style.ForeColor = Color.Yellow;
                    count++;
                }

            }
        }
        private void ShowDataGridViewEdit(People people)
        {
            if (people != null)
            {
                int count = 0;
                // trước khi add data vào thì phải clear hết cái cũ đi
                dtgvEdit.Rows.Clear(); // nếu add thêm vào nhiều thì ko clear đi là được
                var row = new DataGridViewRow();
                dtgvEdit.Rows.Add(row);
                dtgvEdit.Rows[count].Cells[0].Value = people.ID;
                dtgvEdit.Rows[count].Cells[1].Value = people.Name;
                dtgvEdit.Rows[count].Cells[2].Value = people.Age;
                dtgvEdit.Rows[count].Cells[3].Value = people.Birthday;
                if (people.Gender == 1)
                {
                    dtgvEdit.Rows[count].Cells[4].Value = "Nam";
                }
                else if (people.Gender == 2)
                {
                    dtgvEdit.Rows[count].Cells[4].Value = "Nữ";
                }
                if (people.Job == 1)
                {
                    dtgvEdit.Rows[count].Cells[5].Value = "Giáo viên";
                }
                else if (people.Job == 2)
                {
                    dtgvEdit.Rows[count].Cells[5].Value = "Học sinh";
                }
                else
                {
                    dtgvEdit.Rows[count].Cells[5].Value = "Nhân viên";
                }
                dtgvShow.Rows[count].Cells[6].Value = "Xóa";
                dtgvShow.Rows[count].Cells[6].Style.ForeColor = Color.Red;
                dtgvShow.Rows[count].Cells[7].Value = "Sửa";
                dtgvShow.Rows[count].Cells[7].Style.ForeColor = Color.Yellow;

            }
        }
        private void cbShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID = txbID.Text.Trim();
            if (txbID.Text == "" || txbID.Text.Length < 3)
            {
                MessageBox.Show("ID không hợp lệ");
                txbID.Focus();
                return;
            }
            string Name = txbName.Text.Trim();
            if (txbName.Text == "" || txbName.Text.Length < 3)
            {
                MessageBox.Show("Họ tên không hợp lệ");
                txbName.Focus();
                return;
            }
            string Age = txbAge.Text.Trim();
            if (txbAge.Text == "" || txbAge.Text.Length < 0 && txbAge.Text.Length > 100)
            {
                MessageBox.Show("Tuổi không hợp lệ");
                txbAge.Focus();
                return;
            }
            // đây là định dạng cho kiểu datetime
            string Birthday = dtpBirthday.Value.ToString("dd/MM/yyyy");
            string Gender = txbGender.Text.Trim();
            if (txbGender.Text != "Nam" && txbGender.Text != "Nữ")
            {
                MessageBox.Show("Giới tính không hợp lệ");
                txbGender.Focus();
                return;
            }
            string Job = txbJob.Text.Trim();
            if (txbJob.Text != "Học sinh" && txbJob.Text != "Giáo viên" && txbJob.Text != "Nhân viên")
            {
                MessageBox.Show("Nghề nghiệp không hợp lệ");
                txbJob.Focus();
                return;
            }

            People people = new People();
            people.ID = ID;
            people.Name = Name;
            people.Age = Age;
            people.Birthday = Birthday;
            if (txbJob.Text == "Giáo viên")
            {
                people.Job = 1;
            }
            if (txbJob.Text == "Học sinh")
            {
                people.Job = 2;
            }
            if (txbJob.Text == "Nhân viên")
            {
                people.Job = 3;
            }
            if (txbGender.Text == "Nam")
            {
                people.Gender = 1;
            }
            else if (txbGender.Text == "Nữ")
            {
                people.Gender = 2;
            }

            if (people.Gender == 1)
            {
                Gender = "Nam";
            }
            else
            {
                Gender = "Nữ";
            }
            if (people.Job == 1)
            {
                Job = "Giáo viên";
            }
            else if (people.Job == 2)
            {
                Job = "Học sinh";
            }
            else
            {
                Job = "Nhân viên";
            }
            ShowDataGridViewEdit(people);
            // ko lên code kiểu Add thé này, vì như thế m ko kiểm soát được nó, với m add vào people.Gender và people.Job thì nó đã if else đâu
            //dtgvEdit.Rows.Add(people.ID, people.Name, people.Age, people.Birthday, people.Gender, people.Job);
            BaseManagerData basedata = new BaseManagerData();
           
            bool result = basedata.Savedata(people.ID, people.Name, people.Age, people.Birthday, people.Gender, people.Job);

            if (result)
            {
                MessageBox.Show("Thành công");
                txbID.Clear();
                txbName.Clear();
                txbAge.Clear();
                txbGender.Clear();
                txbJob.Clear();
            }
            else
            {
                MessageBox.Show("Sai bà nó rồi");
            }

        }

        private void dtgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                if (dtgvShow[0, e.RowIndex].Value == null)
                {
                    return;
                }
                var idChoosed = dtgvShow[0, e.RowIndex].Value.ToString();
                var listData = Student.GetlistData();
                // đoạn này t sẽ code = linq để lọc nó ra
                var dataFilter = listData.Where(x => x.ID == idChoosed)?.FirstOrDefault();
                if (dataFilter != null)
                {
                    tabControl1.SelectedIndex = 1;
                    txbID.Text = dataFilter.ID.Trim();
                    txbName.Text = dataFilter.Name.Trim();
                    txbAge.Text = dataFilter.Age.Trim();
                    dtpBirthday.Text = dataFilter.Birthday;
                    if (dataFilter.Gender == 1)
                    {
                        txbGender.Text = "Nam";
                    }
                    else if (dataFilter.Gender == 2)
                    {
                        txbGender.Text = "Nữ";
                    }
                    if (dataFilter.Job == 1)
                    {
                        txbJob.Text = "Giáo viên";
                    }
                    else if (dataFilter.Job == 2)
                    {
                        txbJob.Text = "Học sinh";
                    }
                    else
                    {
                        txbJob.Text = "Nhân viên";
                    }
                }
            }
            //Xóa

            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                // tý code thêm confirm ở đây hỏi chắc bạn muốn xóa ko , không hoặc có
                if (dtgvShow[0, e.RowIndex].Value == null)
                {
                    return;
                }
                var idChoosed = dtgvShow[0, e.RowIndex].Value.ToString();
                var listData = Student.GetlistData();
                // đoạn này t sẽ code = linq để lọc nó ra
                var dataFilter = listData.Where(x => x.ID == idChoosed)?.FirstOrDefault();
                DialogResult Result = MessageBox.Show("Bạn muốn xóa " + dataFilter.Name, "Xóa dữ liệu", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    if (dataFilter != null)
                    {
                        BaseManagerData basedata = new BaseManagerData();
                        listData.Remove(dataFilter);
                        bool result = basedata.DeletePeople(listData);
                        if (result)
                        {
                            MessageBox.Show("Thành công");
                            ShowDataGridView(listData);
                        }
                        else
                        {
                            MessageBox.Show("Sai bà nó rồi");
                        }

                    }
                }    
                else 
                {
                    return; //
                }    
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgvEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(cbShow == null || cbShow.Text=="")
            {
                return;
            }    
            TextBox textBox = sender as TextBox;
            string theText = string.Empty;
            if (textBox != null)
            {
                theText = textBox.Text;
            }
            else
            {
                return;
            }    
            var listData = BaseManagerData.GetlistData();
            var listDataFilter = listData.Where(x => x.Name.ToUpper().Contains(theText.ToUpper()))?.ToList();
            if (cbShow.Text == "Tất cả")
            {
                ShowDataGridView(listDataFilter);
                int numRows = dtgvShow.Rows.Count - 1;
                txbAll.Text = numRows.ToString();
            }
            else if (cbShow.Text == "Học sinh")
            {
                List<People> listStudent = new List<People>();
                listStudent = Student.FilterDataToStudent(listDataFilter);
                ShowDataGridView(listStudent);
                int numRows1 = dtgvShow.Rows.Count - 1;
                txbStudent.Text = numRows1.ToString();
            }
            else if (cbShow.Text == "Giáo viên")
            {
                List<People> listTeacher = new List<People>();
                listTeacher = Teacher.FilterDataToTearch(listDataFilter);
                ShowDataGridView(listTeacher);
                int numRows2 = dtgvShow.Rows.Count - 1;
                txbTeacher.Text = numRows2.ToString();
            }
            else if (cbShow.Text == "Nhân viên")
            {
                List<People> listEmloyee = new List<People>();
                listEmloyee = Employee.FilterDataToEmployee(listDataFilter);
                ShowDataGridView(listEmloyee);
                int numRows3 = dtgvShow.Rows.Count - 1;
                txbEmployee.Text = numRows3.ToString();
            }
        }
    }
}
