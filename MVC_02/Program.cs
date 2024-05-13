using System;
using database;

using service;
using view;
using controller;
using repository;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CarReservationService carReservationService = new CarReservationService(new CarReservationRepo());

            CarReservationView view = new CarReservationView();

            CarReservationController controller = new CarReservationController(carReservationService, view);



            // reserveCar
            controller.reserveCar()                             
 

        }

    }
}