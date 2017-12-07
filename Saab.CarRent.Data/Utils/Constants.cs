using System;
using System.Collections.Generic;
using System.Text;

namespace Saab.CarRent.Data.Utils
{
    public class Constants
    {
        public enum CarCategoryName
        {
            SmallCar,
            Van,
            MiniBus
        }
        public const float baseDayRental = 1000;
        public const float kmPrice = 1000;
    }
}
