using Saab.CarRent.Data.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Saab.CarRent.Data.Entity
{
    public class Reservation : BaseEntity
    {
        [Index(IsUnique =true)]
        public int BookingNumber { get; set; }
        public long CarCategoryID { get; set; }
        [ForeignKey("CarCategoryID")]
        public virtual CarCategory CarCategory { get; set; }

        public DateTime CustmerDateOfBirth { get; set; }
        public DateTime RentalDate { get; set; }
        public int CurrentKM { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int NumberOfKm { get; set; }
        [NotMapped]
        public double CalculationPric {
            get {
                TimeSpan t = ReturnDate.Value - RentalDate;
                int numberOfDays = t.Days;
               double price= (Constants.baseDayRental * numberOfDays * CarCategory.DayProcent) +
                   (Constants.kmPrice * NumberOfKm * CarCategory.KmProcent);
                return price;
            }
        }
    }
}
