using Saab.CarRent.Data.Context;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Saab.CarRent.Data.Entity;
using Saab.CarRent.Data.Utils;
using System;

namespace Saab.CarRent.Service
{
    public class ReservationService
    {
        MainContext context = new MainContext();
        public void DBInit()
        {

            // Remove all categories
            context.Reservations.ToList().ForEach(a => context.Reservations.Remove(a));
            context.CarCategories.ToList().ForEach(a=>context.CarCategories.Remove(a));
            context.SaveChanges();

            //Add new Categories
            CarCategory cat1 = new CarCategory();
            cat1.Name = "Small Car";
            cat1.ReferenceName = Constants.CarCategoryName.SmallCar.ToString();
            cat1.DayProcent = 1;
            cat1.KmProcent = 1;
            context.CarCategories.Add(cat1);

            CarCategory cat2 = new CarCategory();
            cat2.Name = "Van";
            cat2.ReferenceName = Constants.CarCategoryName.Van.ToString();
            cat2.DayProcent = 1.2;
            cat2.KmProcent = 1;
            context.CarCategories.Add(cat2);

            CarCategory cat3 = new CarCategory();
            cat3.Name = "Mini bus";
            cat3.ReferenceName = Constants.CarCategoryName.MiniBus.ToString();
            cat3.DayProcent = 1.7;
            cat3.KmProcent = 1.5;
            context.CarCategories.Add(cat3);
            context.SaveChanges();
        }
        private long GetCategory(Constants.CarCategoryName Category)
        {
            var cat=context.CarCategories.Where(a => a.ReferenceName.Equals(Category.ToString())).FirstOrDefault();
            if (cat != null)
                return cat.ID;
            else throw new Exception("Not Exist Category");
        }
        public void NewReservation(int bookingNumber, System.DateTime DOB,Constants.CarCategoryName Category,DateTime RentalDate,int CurrentKm)
        {
            Reservation reservation = new Reservation();
            reservation.BookingNumber = bookingNumber;
            reservation.CustmerDateOfBirth = DOB;
            reservation.CarCategoryID = GetCategory(Category);
            reservation.RentalDate = RentalDate;
            reservation.CurrentKM = CurrentKm;

            context.Reservations.Add(reservation);
            context.SaveChanges();
        }
        public double FinishReservation(int bookingNumber, System.DateTime returnDate, int CurrentKm)
        {
            var reservation= context.Reservations.Where(a => a.BookingNumber == bookingNumber).First();
            reservation.ReturnDate = returnDate;
            reservation.NumberOfKm = CurrentKm - reservation.CurrentKM ;
            if (reservation.NumberOfKm < 0)
                throw new Exception("Error on Km calculation");
            context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            
            context.SaveChanges();
            return reservation.CalculationPric;
        }
    }
    
}
