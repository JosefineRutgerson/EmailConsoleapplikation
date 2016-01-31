using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClientLabb4
{
    [Serializable]
   public class BaseMessage
    {
          
        //Det finns en klass DateTime som kan spara en tidsangivelse men
        //det är svårigheter att serializera detta objekt. Lättare om vi stoppar
        //in aktuell tid i en string istället.
        public string Time { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        
    }
}
