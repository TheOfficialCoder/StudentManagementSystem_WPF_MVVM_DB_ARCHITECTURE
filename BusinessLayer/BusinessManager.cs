using CommonLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessManager : IBusinessManager
    {
        DataManager _db;
        public BusinessManager()
        {
            _db = new DataManager();
        }

        public List<Student> AllStudents()
        {
            return _db.AllStudents();
        }

        public bool DeleteStudent(int id)
        {
            return _db.RemoveStudent(id);
        }

        public Student FindStudent(int id)
        {
            return _db.FindStudent(id);
        }

        public bool InsertStudent(Student student)
        {
            return _db.InsertStudent(student);
        }

        public bool UpdateStudent(Student student)
        {
            return _db.UpdateStudent(student);
        }
    }
}
