using System;
using System.Data.Common;
using MyApp;


namespace model
{
    class CustomerModel
    {
        private string _id;
        private string _name;
        private string _email;
        private string _phone;


        // Getter and setter for _id
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        // Getter and setter for _name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Getter and setter for _email
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        // Getter and setter for _phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }

        }
    }
}