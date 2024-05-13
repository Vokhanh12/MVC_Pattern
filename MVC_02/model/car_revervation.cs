using System;
using System.Data.Common;
using System.Dynamic;

using MyApp;

namespace model
{

    class CarReserVationModel
    {

        private string _id;
        private CarModel _car;
        private DateTime _startDay;
        private DateTime _endDay;
        private CustomerModel _reserveBy;



        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public CarModel Car
        {
            get { return _car; }
            set { _car = value; }
        }

        public DateTime StartDay
        {
            get { return _startDay; }
            set { _startDay = value; }
        }


        public DateTime EndDay
        {
            get { return _endDay; }
            set { _endDay = value; }
        }

        public CustomerModel ReserveBy
        {
            get { return _reserveBy; }
            set { _reserveBy = value; }
        }




    }



}

