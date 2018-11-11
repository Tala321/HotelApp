using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_app
{
    class TourAgent
    {
        public static string[] TourAgentList = new string[3]
        {
            "Vagif Esedov",
            "Amir Besirov",
            "Adil Humbetov"
        };


        static dynamic password = "castle11";
        //Check a tour agent
        public static string CheckTourAgent()
        {
            Console.Write("Your name & surname: ");
            string input = Console.ReadLine();
            Console.Write("Enter your password: ");
            dynamic inputPass = Console.ReadLine();
            for (int i = 0; i < TourAgentList.Length; i++)
            {
                if (TourAgentList[i] == input && password == inputPass)
                {
                    Console.WriteLine("You Have successfully logged in");
                    return input;
                }
            }
            Console.WriteLine("No tour agent with this name or  data entered was wrong .");
            return "false";
        }

        // use this variable in confirm method to assign a room to a customer
        static Customer CustomerRoom;
        //Register a customer by tour agent in the hotel
        public static void RegisterCustomer(string tourAgent)
        {

            switch (tourAgent)
            {
                case ("false"):
                    Console.WriteLine("Wrong info try again");
                    RequestController.SelectCategory();
                    break;

                default:
                    Console.Write("Customer name: ");
                    string name = Console.ReadLine();
                    Console.Write("Customer surname: ");
                    string surname = Console.ReadLine();
                    Console.Write("Customer id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Customer newCustomer = new Customer(name, surname, id, tourAgent);
                    CustomerRoom = newCustomer;
                    break;
            }
        }

        //Show available rooms
        static int sumOfRoomsNum = 0;
        public static void ShowAvailableRoom()
        {
            for (int i = 0; i < Hotel.HotelRooms.Length; i++)
            {

                if (Hotel.HotelRooms[i] == 0)
                {
                    sumOfRoomsNum++;
                    Console.WriteLine("Room number: " + i);
                }
                else if (sumOfRoomsNum == Hotel.HotelRooms.Length)
                {
                    Console.WriteLine("No available room.");
                }
            }
        }

        // confirm a registration 
        public static void ConfirmRegistration()
        {
            int roomNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Confirm your selection? Yes/No");
            string confirmation = Console.ReadLine();

            switch (confirmation)
            {
                case ("Yes"):
                    CustomerRoom.AssignRoom(roomNum);
                    for (int i = 0; i < Hotel.HotelRooms.Length; i++)
                    {
                        if (i == roomNum)
                        {
                            if (i == 0)
                            {
                                Hotel.HotelRooms[i] = roomNum + 1;
                            }
                            else
                            {
                                Hotel.HotelRooms[i] = roomNum;
                            }
                        }
                    }
                    break;

                case ("No"):
                    RequestController.SelectCategory();
                    break;
            }
        }
    }
}
