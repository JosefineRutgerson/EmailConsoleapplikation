using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailClientLabb4
{
    public class ConfigMessageList
    {
        public static void showMessage(Mail message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("___________________________________________");
            Console.WriteLine("Your Message:");
            Console.WriteLine("\n-------------------------------------------");
            Console.Write("\nFrom: " + message.Sender + "     ");
            Console.WriteLine("To: " + message.Receiver + "\n");
            Console.WriteLine("Title: " + message.Subject + "\n");
            Console.WriteLine(message.Message + "\n");
            Console.WriteLine("Came in at: " + message.Time + "\n");
            Console.WriteLine("__________/)_/)__________/)________________");
            message.isSeen = true;
            Console.ResetColor();


        }

        public static void listMessages(SortedList<int, Mail> listMessages)
        {

            Console.WriteLine("\nYour Messages:");
            Console.WriteLine("____________________________________________");
            foreach (var item in listMessages.Where( message => message.Value.Sender == Settings.theSetting.Sender))
                {
                    int key = item.Key;
                    Mail bm = item.Value;
                    if (bm.isSeen == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\nThis message is new");
                        //Console.ResetColor();
                    }

                Console.WriteLine("\nMail number: " + key);
                Console.Write("\nFrom: " + bm.Sender + "    ");
                Console.Write("Title: " + bm.Subject + "\n");
                Console.Write("Inkom: " + bm.Time + "\n\n");
                Console.WriteLine("____________________________________________");
                Console.ResetColor();
            }
             
            }

        public static void deleteMessage( Mail selectedMail) //Ha ett mail som imparameter
        {
            Messages messageObject = new Messages();
            
            try
            {
               messageObject.RemoveMessage(selectedMail);

            }
            catch (FormatException)
            {
                
            }

        }

        public static Mail chooseMessage(SortedList<int, Mail> choice)
        {
            Console.WriteLine("Write the number of the mail to read it ");
            string choiceKey = Console.ReadLine();
            int userChoice = Int32.Parse(choiceKey);
                        
            Mail mailChoice = new Mail();
            mailChoice = choice[userChoice];
            
            return mailChoice;
                        
        }
        

        //var selectedSingle = choice.Single(item => item.Key == userChoice);
        //Mail b = selectedSingle.Value;


    }
}