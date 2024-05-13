using model;

namespace Util
{


    class CarDetails
    {

        private CarModel _car;

        private CustomerModel _customer;

        private CarReserVationModel _carReserVation;

        public CarDetails(CarModel car, CustomerModel customer, CarReserVationModel carReserVation)
        {

            _car = car;
            _customer = customer;
            _carReserVation = carReserVation;

        }

        public CarModel GetCar => _car;

        public CustomerModel GetCustomer => _customer;

        public CarReserVationModel GetCarReserVation => _carReserVation;


    }



}