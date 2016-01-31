using System;
using System.Collections.Generic;

namespace EmailClientLabb4
{
    [Serializable]
    internal class BaseMessageHandler
    {
        
        public static Contacts setReceiver(List<Contacts> listContact)
        {
            
            Console.WriteLine("Your contacts:\n");
            Settings.theSetting.showContactList();
            Console.WriteLine("\nWrite the name of the receiver:");
            string chooseContact = Console.ReadLine();
            Contacts newContact = new Contacts();

            foreach (var contact in listContact)
            {
                if (contact.Name == chooseContact)
                {
                    newContact = contact;
                    return newContact;
                    
                }
            }
            newContact.Name = chooseContact;
            return newContact;
        }

                
        public static Mail createMail() //string name, List<Contacts> contactList
        {

            Mail newMail = new Mail(); //skapa nytt baseMessage objekt
            newMail.Time = DateTime.Now.ToString();
            newMail.Sender = Settings.theSetting.Sender;
            return newMail;
            
            
            
            //Console.Clear();
            //Console.WriteLine("________________________________________________________\n");
            //Contacts contact= setReceiver(contactList);
            //Console.WriteLine("New Message");
            //Console.WriteLine("________________________________________________________");
            //.Receiver = contact.Name;
            //Console.WriteLine("Write subject:");
            //newMail.Subject = Console.ReadLine();
            //Console.WriteLine("Write message:");
            //newMail.Message = Console.ReadLine();

        }

        //public static void MailIsSeen(Mail message)
        //{
        //    message.isSeen = true;
        //}


        public static int GetNewKey<T>(SortedList<int, T> collection)
        {
            int key = 0;
            while (collection.ContainsKey(key))
            {
                key++;
            }

            return key;
        }

        
       
    }
}