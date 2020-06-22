using BusinessLayer;
using CommonLayer;
using StudentManagementSystem.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.ViewModel
{
    class Student_ViewModel:INotifyPropertyChanged
    {
        #region event
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Properties
        //Message
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private Student studentDetails;
        public Student StudentDetails
        {
            get { return studentDetails; }
            set { studentDetails = value; OnPropertyChanged("StudentDetails"); }
        }
        #endregion

        #region Constructor
        BusinessManager _businessManager;
        public Student_ViewModel()
        {
            _businessManager = new BusinessManager();
            StudentDetails = new Student();
            LoadData();
            savestudentCommand = new RelayCommand(RegisterStudent);
            updatestudentCommand = new RelayCommand(UpdateStudent);
            findstudentCommand = new RelayCommand(FindStudent);
            removestudentCommand = new RelayCommand(RemoveStudent);
        }
        #endregion

        #region All Students
        private ObservableCollection<Student> studentList;
        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; OnPropertyChanged("StudentList"); }
        }

        private void LoadData()
        {
            StudentList = new ObservableCollection<Student>(_businessManager.AllStudents());
            Message = "Total:" + StudentList.Count + " Students";
        }
        #endregion

        #region Add Student

        private RelayCommand savestudentCommand;

        public RelayCommand SavestudentCommand
        {
            get { return savestudentCommand; }
        }

        public void RegisterStudent()
        {
            var data = _businessManager.InsertStudent(studentDetails);
            if (data)
            {
                LoadData();
                Message = "Student Registered...!!!";
            }
            else
                Message = "Sorry Something Went Wrong...!!!";
        }
        #endregion

        #region Update Student

        private RelayCommand updatestudentCommand;

        public RelayCommand UpdatestudentCommand
        {
            get { return updatestudentCommand; }
        }

        public void UpdateStudent()
        {
            var data = _businessManager.UpdateStudent(studentDetails);
            if (data)
            {
                LoadData();
                Message = "Student Details Updated...!!!";
            }
            else
                Message = "Sorry Something Went Wrong...!!!";
        }
        #endregion

        #region Find Student

        private RelayCommand findstudentCommand;

        public RelayCommand FindstudentCommand
        {
            get { return findstudentCommand; }
        }

        public void FindStudent()
        {
            var data = _businessManager.FindStudent(studentDetails.Id);
            if (data!=null)
            {
                studentDetails.Name = data.Name;
                studentDetails.MobileNumber = data.MobileNumber;
                studentDetails.Email = data.Email;
            }
            else
                Message = "Incorrect Student Id...!!!";
        }
        #endregion

        #region Remove Student

        private RelayCommand removestudentCommand;

        public RelayCommand RemovestudentCommand
        {
            get { return removestudentCommand; }
        }

        public void RemoveStudent()
        {
            var data = _businessManager.DeleteStudent(studentDetails.Id);
            if (data==false)
            {
                studentDetails.Name = "";
                studentDetails.MobileNumber = "";
                studentDetails.Email = "";
                Message = "Wrong Student Id...!!!";
            }
            else
            {
                LoadData();
                Message = "Student Removed...!!!";

            }
                
        }
        #endregion

    }
}
