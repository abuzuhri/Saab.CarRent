using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saab.CarRent.Service;

namespace Saab.CarRent.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ReservationService rService = new ReservationService();
        [TestMethod]
        public void DBInit()
        {
            rService.DBInit();
        }
        [TestMethod]
        public void NewReservation()
        {
            rService.NewReservation(1,DateTime.Now.AddDays(-5000),Data.Utils.Constants.CarCategoryName.Van,DateTime.Now,1000);
        }
        [TestMethod]
        public void FinishReservation()
        {
            double price= rService.FinishReservation(1, DateTime.Now.AddDays(3), 1100);
        }
    }
}
