using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Saab.CarRent.Data.Entity
{
    public class CarCategory : BaseEntity
    {
        public CarCategory()
        {
            Reservations = new Collection<Reservation>();
        }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public string Name { get; set; }
        public string ReferenceName { get; set; }
        public double DayProcent { get; set; }
        public double KmProcent { get; set; }
    }
}
