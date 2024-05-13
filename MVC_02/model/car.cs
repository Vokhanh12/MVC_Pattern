using System;
using System.Data.Common;
using MyApp;


namespace model
{
    class CarModel
    {
        private string _id;
        private string _make;
        private string _model;
        private int _year;
        private double _dailyRate;

        private int _available;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string Model
        {

            get { return _model; }
            set { _model = value; }

        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }


        public int Available
        {
            get { return _available; }
            set { _available = value; }
        }

    }
}