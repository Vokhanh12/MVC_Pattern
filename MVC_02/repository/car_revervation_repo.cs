using database;
using Microsoft.VisualBasic;
using model;


namespace repository
{

    interface ICarReservationRepo
    {
        void addCar(CarModel carModel);

        void removeCar(CarModel carModel);

        void updateCar(CarModel carModel);

        void addCustomer(CustomerModel customerModel);

        void removeCustomer(CustomerModel customerModel);

        List<CustomerModel> getCustomers();

        void addReservation(CarReserVationModel carReserVationModel);

        void removeReservation(CarReserVationModel carReserVationModel);

        List<CarReserVationModel> getReservations();

        List<CarModel> getAvailableCars();





    }


    class CarReservationRepo : ICarReservationRepo
    {
        public void addCar(CarModel carModel)
        {
            Database.Cars.Add(carModel);
        }

        public void addCustomer(CustomerModel customerModel)
        {
            Database.Customers.Add(customerModel);
        }

        public void addReservation(CarReserVationModel carReserVationModel)
        {
            Database.CarReverVationModels.Add(carReserVationModel);
        }

        public List<CarModel> getAvailableCars()
        {

            List<CarModel> availableCars = new List<CarModel>();


            foreach (CarModel item in Database.Cars)
            {

                if (item.Available == 0)
                {

                    availableCars.Add(item);
                }

            }

            return availableCars;

         }

   

        public List<CustomerModel> getCustomers()
        {
            return Database.Customers;
        }

        public List<CarReserVationModel> getReservations()
        {
            return Database.CarReverVationModels;
        }

        public void removeCar(CarModel carModel)
        {
        }

        public void removeCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public void removeReservation(CarReserVationModel carReserVationModel)
        {
            throw new NotImplementedException();
        }


        public void updateCar(CarModel carModel)
        {
            throw new NotImplementedException();
        }
    }


}
