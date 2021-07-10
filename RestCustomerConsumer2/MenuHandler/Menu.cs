using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestCustomerConsumer2.Controllers;
using RestCustomerConsumer2.Model;

namespace RestCustomerConsumer2.MenuHandler
{
    public class Menu
    {
        public static void MainMenu()
        {
            Boolean status = true;

            while (status)
            {
                Console.WriteLine("What do you want to do? Choose from 1-6");
                Console.WriteLine("Give your choice 1-6, 9:");
                Console.WriteLine("1: Get all customers");
                Console.WriteLine("2: Get one customer by id");
                Console.WriteLine("3: Delete a customer by id");
                Console.WriteLine("4: Add a new customer");
                Console.WriteLine("5: Update a customer");
                Console.WriteLine("6: Print out all customers");
                Console.WriteLine("9: Exit program");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine("You have chosen: " + key);

                if (char.IsDigit(key.KeyChar))
                {
                    int choice = Convert.ToInt32(key.KeyChar) - 48;

                    //Console.WriteLine("Choice: " + choice);
                    switch (choice)
                    {
                        case 1:
                            menu1(); break;
                        case 2:
                            menu2(); break;
                        case 3:
                            menu3(); break;
                        case 4:
                            menu4(); break;
                        case 5:
                            menu5(); break;
                        case 6:
                            menu6(); break;
                        case 0:
                            status = false; break;
                        default:
                            Console.WriteLine("Must be a number between 0-6"); break;
                    }
                }
                else
                {
                    Console.WriteLine("You need to input a valid number");
                }
            }
        }
        private static void menu1()
        {
            IList<Customer> allC = CustomerController.CustomersController.GetCustomersAsync().Result;
            for (int i = 0; i < allC.Count; i++)
                Console.WriteLine(allC[i].ToString());
        }

        private static void menu2()
        {
            try
            {
                Console.WriteLine("Enter the ID of the customer you're looking for. See exception if not found.");
                string idGet = Console.ReadLine();
                int id = int.Parse(idGet);
                Customer customer = CustomerController.CustomersController.GetCustomerInfoAsync(id).Result;
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        private static void menu3()
        {
            return;
        }

        private static void menu4()
        {
            return;
        }

        private static void menu5()
        {
            return;
        }

        private static void menu6()
        {
            return;
        }
    }
}
