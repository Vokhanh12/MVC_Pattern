using MyApp;

using model;
using repository;
using view;
using System.ComponentModel.Design;
using Util;

namespace service
{

    interface ICarReservationService
    {
        CarDetails checkAvailability(string make, string model, int year, string color, string firstName, string lastName, string email, string phone, DateTime startTime, DateTime endTime);
        CarReserVationModel reseve(CarModel car, DateTime startDate, DateTime endDate, CustomerModel customer);

    }


    class CarReservationService : ICarReservationService
    {

        private ICarReservationRepo _repo;


        public CarReservationService(ICarReservationRepo repo)
        {
            _repo = repo;
        }

        public CarDetails checkAvailability(string make, string model, int year, string color, string firstName, string lastName, string email, string phone, DateTime startTime, DateTime endTime)
        {
            CustomerModel customer = new CustomerModel();
            customer.Id = "2" ; // Auto set in database Id Example id = "2"
            customer.Name = firstName +" "+ lastName;
            customer.Phone = phone;
            customer.Email = email;

            List<CarModel> carModels = retrieveAvailableCars();

            CarModel? carModelToSet = selectCar(make, model, year, carModels);

            updateCar(carModelToSet);

            CarReserVationModel carReserVation = reseve(carModelToSet, startTime, endTime, customer);

            CarDetails carDetails = new CarDetails(carModelToSet, customer, carReserVation);

            return carDetails;
 
        }


        public CarReserVationModel reseve(CarModel car, DateTime startDate, DateTime endDate, CustomerModel customer)
        {
            throw new NotImplementedException();
        }



        private List<CarModel> retrieveAvailableCars()
        {

            return _repo.getAvailableCars();

        }

        // ?????????????????????????????????????????????
        private CarModel? selectCar(string make, string model, int year, List<CarModel> carModels)
        {
            // handle logic time for car to return
            // Example

            foreach (CarModel item in carModels)
            {

                if (item.Make == make && item.Model == model && item.Year == year)
                {
                    return item;

                }

            }

            return null;

        }

        private void updateCar(CarModel carModel)
        {

            _repo.updateCar(carModel);


            Console.WriteLine("Update success");

        }



    }
}
