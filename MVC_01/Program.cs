using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var model = retriveStudentFormDatabase();


            var view = new HomeView();


            var controller = new HomeController(model, view);


            // Khi người dùng vào application hiển thị thông tin người dùng
            controller.updateView();


            // Người dùng chỉnh lại tên người dùng

            controller.setNameStudent("Huy");

            // Cập nhật giao diện view lại

            controller.updateView();


        }


        public static StudentModel retriveStudentFormDatabase()
        {

            StudentModel studentModel = new StudentModel();

            studentModel.Id = "1";

            studentModel.Name = "Khanh";

            return studentModel;

        }


    }
}