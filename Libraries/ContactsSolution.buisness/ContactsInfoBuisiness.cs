using ContactsSolution.buisness;
using ContactsSolution.Data;
using System;



namespace ContactsSolution.Buisiness
{
    public class ContactsInfoBuisiness
    {


        public static ContactInfo GetContactInfoByID(int contactId)
        {
            return ContactInfo.Find(contactId);

        }


        public static bool CreateContactInfo(ContactInfo contactInfo)
        {
            return contactInfo.Create();
        }


    } }
