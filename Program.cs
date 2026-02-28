using ContactsSolution.Buisiness;
using ContactsSolution.buisness;
using System;
using System.Data;


namespace ContactsSolution
{
    internal class Program
    {

        private static void printContactInfo(ContactInfo contact)
        {
            Console.WriteLine($"ID: {contact.id}");
            Console.WriteLine($"First Name: {contact.firstName}");
            Console.WriteLine($"Last Name: {contact.lastName}");
            Console.WriteLine($"Email: {contact.email}");
            Console.WriteLine($"Phone Number: {contact.phoneNumber}");
            Console.WriteLine($"Address: {contact.address}");
            Console.WriteLine($"Date of Birth: {contact.dateOfBirth}");
            Console.WriteLine($"Country ID: {contact.countryId}");
            Console.WriteLine($"Image Path: {contact.imagePath}");
        }

        private static void findContactByID(int contactId)
        {
            ContactInfo contact = ContactsInfoBuisiness.GetContactInfoByID(contactId);
            if (contact != null)
            {
                printContactInfo(contact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }


        private static void createContact()
        {
            ContactInfo newContact = new ContactInfo();

            newContact.firstName = "John";
            newContact.lastName = "Doe";
            newContact.email = "johndoe@gmail.com";
            newContact.phoneNumber = "123-456-7890";
            newContact.address = "123 Main St, Anytown, USA";
            newContact.dateOfBirth = new DateTime(1990, 1, 1);
            newContact.countryId = 1;
            newContact.imagePath = "path/to/image.jpg";

            if (newContact.save()) 
            {
                Console.WriteLine("Contact created successfully.\n");
                printContactInfo(newContact);
            }
            else
            {
                Console.WriteLine("Failed to create contact.");
            }

        }

        private static void updateContact(int contactId)
        {
            ContactInfo contact = ContactsInfoBuisiness.GetContactInfoByID(contactId);
            if (contact != null)
            {
                contact.firstName = "Jane";
                contact.lastName = "Smith";
                contact.email = "noureddinebentaher@gmail.com";

                if (contact.save())
                {
                    Console.WriteLine("Contact updated successfully.\n");
                    printContactInfo(contact);

                }
                else
                {
                    Console.WriteLine("Failed to update contact.");
                }
            }

        }


        static void listContacts()
        {
            DataTable contactsTable = ContactInfo.GetAll();

            if (contactsTable.Rows.Count > 0)
            {
                Console.WriteLine("All Contacts:");
                foreach (DataRow row in contactsTable.Rows)
                {

                    Console.WriteLine($"ID: {row["ContactID"]}");
                    Console.WriteLine($"First Name: {row["FirstName"]}");
                    Console.WriteLine($"Last Name: {row["LastName"]}");
                    Console.WriteLine($"Email: {row["Email"]}");
                    Console.WriteLine($"Phone Number: {row["Phone"]}");
                    Console.WriteLine($"Address: {row["Address"]}");
                    Console.WriteLine($"Date of Birth: {row["DateOfBirth"]}");
                    Console.WriteLine($"Country ID: {row["CountryId"]}");
                    Console.WriteLine($"Image Path: {row["ImagePath"]}");
                    Console.WriteLine(new string('-', 20));

                }
            }
            Console.WriteLine("there is no contacts to display");
        }


    


        static void Main(string[] args)
        {
            //findContactByID(1);
            //reateContact();
            //updateContact(1);
            //listContacts();

            if(ContactInfo.isContactExists(1))
            {
                Console.WriteLine("Contact with ID 1 exists.");
            }
            else
            {
                Console.WriteLine("Contact with ID 1 does not exist.");
            }

            Console.ReadKey();
        }
    }
}
