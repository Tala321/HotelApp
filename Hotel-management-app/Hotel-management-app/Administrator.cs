using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_app
{
    class Administrator
    {
        //The hotel adminstrators' list
        public static string[] AdminstratorList = new string[2]
           {
              "Esed Muradov",
              "Dadas Bedelov"

           };


        // there is a method to show available room //Show available rooms

        // Show info about the provided funcitons
        public static void ShowInfo()
        {
            Console.WriteLine("[Tour agent list] [Hotel's guests info] [Available rooms] [Customer's tour agent] [Tour agent's statistics]");
            Console.WriteLine("Or write anything to come back to the main menu");
            string input = Console.ReadLine();

            switch (input)
            {
                case ("Tour agent list"):
                    TourAgentList();
                    ShowInfo();
                    break;
                case ("Hotel's guests info"):
                    ShowBookedRoomCustomerInfo();
                    ShowInfo();
                    break;
                case ("Available rooms"):
                    TourAgent.ShowAvailableRoom();
                    ShowInfo();
                    break;
                case ("Customer's tour agent"):
                    Console.Write("Customer's id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    CustomerTourAgent(id);
                    ShowInfo();
                    break;
                case ("Tour agent's statistics"):
                    Console.Write("Tour agnet's name&surname: ");
                    string tourAgentNameSurname = Console.ReadLine();
                    ShowTourAgentStatics(tourAgentNameSurname);
                    ShowInfo();
                    break;
                default:
                    RequestController.SelectCategory();
                    break;
            }
        }

        static dynamic password = "admin11";
        //Check an Administrator
        public static bool CheckAdministrator()
        {
            Console.Write("Your name & surname: ");
            string input = Console.ReadLine();
            Console.Write("Enter your password: ");
            dynamic inputPass = Console.ReadLine();

            for (int i = 0; i < AdminstratorList.Length; i++)
            {
                if (AdminstratorList[i] == input && password == inputPass)
                {
                    Console.WriteLine("You Have successfully logged in");
                    return true;
                }
            }
            return false;
        }

        //Show a customer's info  who already  booked a room in the hotel
        public static void ShowBookedRoomCustomerInfo()
        {
            for (int i = 0; i < Hotel.HotelRooms.Length; i++)
            {
                foreach (var item in Customer.Customers)
                {
                    if (item.roomNum == i)
                    {
                        Console.WriteLine($"Customer's name: {item.name} / Customer's surname: {item.surname} /  Customer's id: {item.id}/ Customer's room number: {item.roomNum}");
                    }
                }
            }
        }

        //Show tour agents list
        public static void TourAgentList()
        {
            for (int i = 0; i < TourAgent.TourAgentList.Length; i++)
            {
                Console.WriteLine("Tour agent name&surname :" + TourAgent.TourAgentList[i]);
            }
        }

        //Show a tour agent, that  brought a particular customer
        public static void CustomerTourAgent(int _id)
        {
            foreach (var item in Customer.Customers)
            {
                if (item.id == _id)
                {
                    Console.WriteLine($"Customer's name: {item.name} / Customer's surname: {item.surname} /  Customer's id: {item.id} / Touragent name/surname: {item.tourAgent}");
                }
            }
        }


        //Show how many clients do  a particular tour agent have
        public static void ShowTourAgentStatics(string _agentName)
        {
            int count = 0;
            foreach (var item in Customer.Customers)
            {
                if (item.tourAgent == _agentName)
                {
                    count++;
                }
            }
            Console.WriteLine("The touragent " + _agentName + " brought " + count + " customer(s) till now.");
        }
    }
}
