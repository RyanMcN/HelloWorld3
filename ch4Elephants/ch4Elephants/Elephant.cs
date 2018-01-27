using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ch4Elephants
{
    [Serializable]
    class Elephant
    {
        public string nameElephant;
        public int earSize;

        public void WhoAmI()
        {
            MessageBox.Show("My Ears are " + earSize + "inches tall!", nameElephant + "SAYS...");

        }

        public void TellMe(string message, Elephant whoSaidIt)
        {
            MessageBox.Show(whoSaidIt.nameElephant +"says: " + message);
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.TellMe(message, this);
        }
    }
}
