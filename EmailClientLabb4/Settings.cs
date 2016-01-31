using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailClientLabb4
{   
    [Serializable]
    public class Settings  
    {
        public static Settings theSetting;
        public List<Contacts> myReceivers;

        public Settings()
        {
            myReceivers = new List<Contacts>();
        }

        public void AddToContacts(Contacts theContact)
        {
            
            myReceivers.Add(theContact);
        }

        public void DeleteContact(Contacts deleteContact)
        {

            myReceivers.Remove(deleteContact);                     
            //foreach (var contact in myReceivers)
            //{
            //    if (deleteContact.Name == contact.Name)
            //    {
            //        myReceivers.Remove(contact);
            //        break;
            //    }
            //}
        }

        public List<Contacts> GetMyContacts()
        {
            return myReceivers;
        }

        //public List<Contacts> MyContactsProperty
        //{
        //    get { return myReceivers; }
        //    set { myReceivers = value; }
        //}

        public string Sender { get; set; }
        


        public void showContactList()
        {
            Console.Clear();
            Console.WriteLine("Your contacts: ");
            foreach (var contact in myReceivers)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(contact);
                Console.ResetColor();
            }
        }

        public void saveTheFile()
        {
            XmlSerialization.WriteToXmlFile("C:savedsettings.xml", theSetting);
        }

        public void readTheFile()
        {
            try
            {
                theSetting = XmlSerialization.ReadFromXmlFile<Settings>("C:savedsettings.xml");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Something happened...." + ex.Message);
            }
        }

        //public static void printSettings()
        //{
        //    Console.WriteLine("User setting Sender: " + );
        //}   

    }
}
