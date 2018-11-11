using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_management_app
{
    class RequestController
    {

        public static void SelectCategory()
        {
            Console.WriteLine("Please , Select your category");
            Console.WriteLine("[Tour agent] [Customer] [Administrator]");
            string category = Console.ReadLine();

            switch (category)
            {
                case ("Tour agent"):
                    string agentInfo = TourAgent.CheckTourAgent();
                    if (agentInfo != "false")
                    {
                        Console.WriteLine("How many people would you like to register?");
                        int numberOfPeople = Convert.ToInt32(Console.ReadLine());
                        if (numberOfPeople < 11)
                        {
                            for (int i = 0; i < numberOfPeople; i++)
                            {
                                TourAgent.RegisterCustomer(agentInfo);
                                Console.WriteLine("Please select an available room's number from the provided");
                                TourAgent.ShowAvailableRoom();
                                TourAgent.ConfirmRegistration();
                            };
                            SelectCategory();
                        }
                        else
                        {
                            Console.WriteLine("Please, use only numbers from 0-9");
                        }
                    }
                    SelectCategory();
                    break;
                case ("Customer"):
                    Console.WriteLine("List of tour agents: ");
                    Customer.ShowTourAgentList();
                    Console.WriteLine("List of available rooms: ");
                    TourAgent.ShowAvailableRoom();
                    SelectCategory();
                    break;
                case ("Administrator"):
                    bool input = Administrator.CheckAdministrator();
                    switch (input)
                    {
                        case (true):
                            Administrator.ShowInfo();
                            break;
                        case (false):
                            Console.WriteLine("Wrong data provided!");
                            SelectCategory();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Please select from the provided");
                    SelectCategory();
                    break;
            }
        }
    }
}
