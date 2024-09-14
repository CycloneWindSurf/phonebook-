using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;



namespace PhonebookApp
    {
        public class InvalidPhoneNumberException : Exception
        {
            public InvalidPhoneNumberException(string message) : base(message)
            {
            }
        }

        class Program
        {
            static List<Contact> contacts = new List<Contact>();

            static void Main(string[] args)
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nPhonebook Menu:");
                    Console.WriteLine("1. Add Contact");
                    Console.WriteLine("2. Lookup Contact");
                    Console.WriteLine("3. Delete Contact");
                    Console.WriteLine("4. Print All Contacts");
                    Console.WriteLine("5. Save Contacts");
                    Console.WriteLine("6. Load Contacts");
                    Console.WriteLine("7. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddContact();
                            break;
                        case "2":
                            LookupContact();
                            break;
                        case "3":
                            DeleteContact();
                            break;
                        case "4":
                            PrintAllContacts();
                            break;
                        case "5":
                            SaveContacts();
                            break;
                        case "6":
                            LoadContacts();
                            break;
                        case "7":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }

            static void AddContact()
            {
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine().Trim();

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine().Trim();

                Console.Write("Enter country code (1-3 digits): ");
                string countryCode = Console.ReadLine().Trim();

                Console.Write("Enter phone number (max 15 digits): ");
                string phoneNumber = Console.ReadLine().Trim();

                // Validate phone number
                if (!int.TryParse(countryCode, out _) || countryCode.Length > 3 || !long.TryParse(phoneNumber, out _) || phoneNumber.Length > 15)
                {
                    throw new InvalidPhoneNumberException("Phone number is invalid. Country code should be 1-3 digits and phone number should be 15 digits max.");
                }

                // Concatenate country code with phone number and add + symbol
                string fullPhoneNumber = $"+{countryCode}{phoneNumber}";

                // Add contact to the list
                Contact contact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = fullPhoneNumber
                };
                contacts.Add(contact);

                Console.WriteLine("Contact added successfully.");
            }
            static void LookupContact()
            {
                Console.WriteLine("enter first name:");
                string firstname = Console.ReadLine().Trim().ToUpper();

                Console.Write("Enter last name: ");
                string lastname = Console.ReadLine().Trim().ToUpper();
            }


        }
    }
