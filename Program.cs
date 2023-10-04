using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace n {
    class Program {
        static void Main(string[] args){
            //Create a basic phonebook console application that stores contacts using a dictionary and allows users to add, search, and delete contacts.
            Dictionary <string,string> contacts = new Dictionary<string, string>();
            int choice;
            string name = "";
            bool run = true;

            while(run){
                printMenu();
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice){
                    case 1:
                        Console.Write("Enter New Contact Name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter New Contact Nnumber: ");
                        string number = Console.ReadLine();
                        // add contact to dictionary
                        contacts.Add(name, number);
                        Console.WriteLine("Contact added!");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Write("Enter Name to Search: ");
                        name = Console.ReadLine();
                        searchContact(contacts, name);
                        Console.Clear();
                        break;
                    case 3:
                        printContacts(contacts);
                        Console.WriteLine("");
                        Console.Write("Enter Name of Contact to Delete: ");
                        name = Console.ReadLine();
                        // delete contact from dictionary
                        contacts.Remove(name);
                        Console.WriteLine("Contact deleted!");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 4:
                        printContacts(contacts);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.Read();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        run=false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void printContacts(Dictionary<string, string>  dict){
            Console.WriteLine("All Contacts: ");
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
        }

        static void searchContact(Dictionary<string, string>  dict, string name){
            bool found = false;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if(kvp.Key == name){
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                    found = true;
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue...");
                    Console.Read();
                }
            }
            if(!found){
                Console.WriteLine("Contact not Found!");
                System.Threading.Thread.Sleep(500);
            }
        }

        static void printMenu(){
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Search Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Print Contacts");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
        }
    }
}