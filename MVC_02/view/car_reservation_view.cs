using model;
using MyApp;
using Util;

namespace view
{
    class CarReservationView
    {

        public void displayCarDetails(CarDetails carDetails)
        {

            Console.WriteLine(carDetails.GetCar);
            Console.WriteLine(carDetails.GetCustomer);
            Console.WriteLine(carDetails.GetCarReserVation);


        }

    }
}
