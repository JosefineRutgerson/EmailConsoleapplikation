using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailClientLabb4
{
    [Serializable]
    public class Messages
    {
        private SortedList<int, Mail> _savedList;

        public SortedList<int, Mail> SavedList
        {
            get
            {
                return _savedList;
            }

            set
            {
                _savedList = value;
            }
        }

        public Messages()
        {
            SavedList = new SortedList<int, Mail>();
        }

        
        public void saveTheFile()
        {
            BinarySerialization.WriteToBinaryFile("savedlist.bin", SavedList);
        }

        public void readTheFile()
        {
            try
            {
                SavedList = BinarySerialization.ReadFromBinaryFile<SortedList<int, Mail>>("savedlist.bin");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Something happened...." + ex.Message); 
            }
        }
        public void RemoveMessage(Mail mail)
        {
            SavedList.RemoveAt(SavedList.Values.IndexOf(mail));
            saveTheFile();
            
        }

        internal void CreateMessage(Mail newMail)
        {
            SavedList.Add(BaseMessageHandler.GetNewKey(SavedList), newMail);
            saveTheFile();
        }

        //public SortedList<int, Mail> getMessageList()
        //{
        //    return savedList;
        //}
    }
}