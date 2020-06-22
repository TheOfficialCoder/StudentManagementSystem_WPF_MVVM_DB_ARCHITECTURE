using CommonLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataManager
    {
        string connectionString = @"Data Source=DESKTOP-CHPF16F;Initial Catalog=StudentManagementSystem;Integrated Security=True";

        public List<Student> AllStudents()
        {
            List<Student> students = new List<Student>();
            string sql = "select * from tbl_Student";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            con.Close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Student stud = new Student
                {
                    Id = Convert.ToInt32(dataTable.Rows[i]["Id"]),
                    Name = dataTable.Rows[i]["Name"].ToString(),
                    MobileNumber = dataTable.Rows[i]["MobileNumber"].ToString(),
                    Email= dataTable.Rows[i]["Email"].ToString()
                };
                students.Add(stud);
            }
            return students;
        }
        public bool InsertStudent(Student student)
        {
            bool isExecuted = false;
            string sql = "insert into tbl_Student(Name,MobileNumber,Email) values(@Name,@MobileNumber,@Email)";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
                command.Parameters.AddWithValue("@Email", student.Email);
                con.Open();
                int row = command.ExecuteNonQuery();
                if (row > 0)
                    isExecuted = true;
            }
            finally
            {
                con.Close();
            }
            return isExecuted;
        }

        public bool UpdateStudent(Student student)
        {
            bool isExecuted = false;
            string sql = "update tbl_Student set Name=@Name,MobileNumber=@MobileNumber,Email=@Email where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Id", student.Id);
                con.Open();
                int row = command.ExecuteNonQuery();
                if (row > 0)
                    isExecuted = true;
            }
            finally
            {
                con.Close();
            }
            return isExecuted;
        }

        public bool RemoveStudent(int id)
        {
            bool isExecuted = false;
            string sql = "delete from tbl_Student where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Id", id);
                con.Open();
                int row = command.ExecuteNonQuery();
                if (row > 0)
                    isExecuted = true;
            }
            finally
            {
                con.Close();
            }
            return isExecuted;
        }

        public Student FindStudent(int id)
        {
            string sql = "select * from tbl_Student where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                con.Open();
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                if (dataTable.Rows.Count>0)
                {
                    Student stud = new Student
                    {
                        Id = Convert.ToInt32(dataTable.Rows[0]["Id"]),
                        Name = dataTable.Rows[0]["Name"].ToString(),
                        MobileNumber = dataTable.Rows[0]["MobileNumber"].ToString(),
                        Email = dataTable.Rows[0]["Email"].ToString()
                    };
                    return stud;
                }
            }
            finally
            {
                con.Close();
            }
            return null;
        }
    }
}
