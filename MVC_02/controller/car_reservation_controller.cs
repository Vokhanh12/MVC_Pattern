using System.ComponentModel.Design;
using model;
using MyApp;
using service;
using Util;
using view;

namespace controller
{

    class CarReservationController
    {

        // Service
        private ICarReservationService _service;

        // View
        private CarReservationView _view;



        public CarReservationController(ICarReservationService service, CarReservationView view)
        {
            _service = service;
            _view = view;
        }


        public void reserveCar(string make, string model, int year, string color,
         string firstName, string lastName, string email, string phone,
          DateTime startTime, DateTime endTime)
        {
            updateViewCarDetails(_service.checkAvailability(make, model, year, color, firstName, lastName, email,
             phone, startTime, endTime));
        }



        public void updateViewCarDetails(CarDetails carDetails)
        {

            _view.displayCarDetails(carDetails);


        }


    }


}
