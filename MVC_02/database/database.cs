using model;

namespace database
{

    static class Database
    {

        public static List<CarModel> Cars = new List<CarModel>();

        public static List<CarReserVationModel> CarReverVationModels = new List<CarReserVationModel>();

        public static List<CustomerModel> Customers = new List<CustomerModel>();

        static Database()
        {

            CarModel car0 = new CarModel();

            car0.Id = "0";
            car0.Make = "test make 0";
            car0.Model = "test model 0";
            car0.Year = 2024;
            car0.Available = 0;

            Cars.Add(new CarModel());

            CustomerModel customerModel0 = new CustomerModel();

            customerModel0.Id = "0";
            customerModel0.Email = "test email 0";
            customerModel0.Name = "test name 0";
            customerModel0.Phone = "test phone 0";

            Customers.Add(customerModel0);


            CarReserVationModel carReserVationModel0 = new CarReserVationModel();

            carReserVationModel0.Id = "0";
            carReserVationModel0.StartDay = new DateTime(2008, 6, 1, 7, 47, 0);
            carReserVationModel0.EndDay = new DateTime(2009, 6, 1, 7, 47, 0);
            carReserVationModel0.ReserveBy = customerModel0;

            CarReverVationModels.Add(carReserVationModel0);

        }

    }
}