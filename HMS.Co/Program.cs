using HMS.IBL;
using HMS.Models;
using System;
using System.Linq;

namespace HMS.Co
{
    class Program
    {
        static void Main(string[] args)
        {
            GetByID(0);
            Console.ReadLine();

        }
        
        //Customer
        private static void GetTourBy()
        {
            ITourRep tour = new BL.TourRep();
            TourModel l = tour.GetTourByID(3);
            Console.WriteLine(string.Format("count:{0}", l.ToString()));
        }
        public static void CustomerGetAll()
        {
            ICustomerRep record = new BL.CustomerRep();
            
            var r = record.GetAll();
            Console.WriteLine(string.Format("count:{0}", r.Count()));
            Console.ReadLine();
        }

        private static void GetByID(int id)
        {
            ICustomerRep record = new BL.CustomerRep();
            var l = record.GetByID(id);
            Console.WriteLine(string.Format("count:{0}", l.CustId));
        }
        public static void CustomerSave()
        {
            ICustomerRep record = new BL.CustomerRep();
            CustomeEditModel t = new CustomeEditModel()
            {
                CustId=5,
                fullname = "TouristE",
                EmailId = "E@gmail.com",
                Phone = "987",
                stateID = 1,
                Street = "StreetA"
            };
            var r = record.Save(t);
            Console.WriteLine(string.Format("count:{0}", r.ToString()));
            Console.ReadLine();
        }
    }
}
