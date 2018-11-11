using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hotel_management_app

{
    class Customer
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int id { get; set; }
        public string tourAgent { get; set; }
        public int roomNum { get; set; }
        public static List<Customer> Customers = new List<Customer>();


        public Customer(string _name, string _surname, int _id, string _tourAgent)
        {
            this.name = _name;
            this.surname = _surname;
            this.id = _id;


            for (int i = 0; i < TourAgent.TourAgentList.Length; i++)
            {
                if (_tourAgent == TourAgent.TourAgentList[i])
                {
                    this.tourAgent = _tourAgent;
                }
            }
            this.tourAgent = _tourAgent;

            Customers.Add(this);
        }



        public void AssignRoom(int _roomNum)
        {
            this.roomNum = _roomNum;
        }

        //To see all touragent that work in the hotel
        public static void ShowTourAgentList()
        {
            for (int i = 0; i < TourAgent.TourAgentList.Length; i++)
            {
                Console.WriteLine(TourAgent.TourAgentList[i]);
            };
        }
    }
}
