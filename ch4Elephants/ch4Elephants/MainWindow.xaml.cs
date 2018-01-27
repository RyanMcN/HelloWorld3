using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace ch4Elephants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Elephant Lloyd;
        Elephant Lucinda;
        Elephant Placeholder;
        Elephant Bob;
        public MainWindow()
        {
            InitializeComponent();
            Lucinda = new Elephant() { nameElephant = "Lucinda", earSize = 33 };
            Lloyd = new Elephant() { nameElephant = "Lloyd", earSize = 40 };
            Placeholder = new Elephant();
            Bob = new Elephant() { nameElephant = "Bob", earSize = 77 };//create Bob
            using (Stream saveName = File.Create(@"C:\Users\Ryan\Documents\SSE550\cereal\saveTheElephantBob.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(saveName, Bob);

            }

            Bob = null;//kill bob

            using (Stream loadBob = File.OpenRead(@"C:\Users\Ryan\Documents\SSE550\cereal\saveTheElephantBob.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
               
                Elephant sally = (Elephant)formatter.Deserialize(loadBob);

            }

        }

        private void LloydButton_Click(object sender, RoutedEventArgs e)
        {
            Lloyd.WhoAmI();
        }

        private void LucindaButton_Click(object sender, RoutedEventArgs e)
        {
            Lucinda.WhoAmI();
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            Placeholder = Lucinda;
            Lucinda = Lloyd;
            Lloyd = Placeholder;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //Lloyd = Lucinda;
            //Lloyd.earSize = 4321;
            //Lloyd.WhoAmI();
            //Lloyd.TellMe("HIIIII!!!!", Lucinda);
            Lloyd.SpeakTo(Lucinda, "dude! hows it hangin'");
        }
    }
}
