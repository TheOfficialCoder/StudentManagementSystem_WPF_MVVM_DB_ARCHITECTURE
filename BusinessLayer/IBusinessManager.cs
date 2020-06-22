using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IBusinessManager
    {
        List<Student> AllStudents();
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int id);
        Student FindStudent(int id);
    }
}
