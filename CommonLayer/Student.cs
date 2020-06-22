using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyname)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChange("Id"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChange("Name"); }
        }

        private string mobileNumber;
        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; OnPropertyChange("MobileNumber"); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChange("Email"); }
        }


    }
}
