using System.ComponentModel.Design;

namespace MyApp
{
    class HomeController
    {

        private StudentModel _model;

        private HomeView _view;

        public HomeController(StudentModel model, HomeView view)
        {

            this._model = model;
            this._view = view;

        }


        public void setNameStudent(String name)
        {

            this._model.Name = name;

        }

        public string getNameStudent()
        {

            return this._model.Name;

        }


        public void setIdStudent(string id)
        {

            this._model.Id = id;

        }


        public string getIdStudent()
        {

            return this._model.Id;

        }


        public void updateView()
        {
            _view.printStudentDetails(this._model.Id, this._model.Name);
        }





    }
}