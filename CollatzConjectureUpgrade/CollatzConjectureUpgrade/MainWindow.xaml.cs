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

namespace CollatzConjectureUpgrade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCollatz_Click(object sender, RoutedEventArgs e)
        {
            int input = int.Parse(textBoxNumber.Text);

            int number = input;
            int peak = 0;
            int numOfSteps = 0;
            int peakSteps = 0;
            while (number > 1)
            {
                numOfSteps++;

                if ((number % 2) == 0)
                {
                    number = number / 2;

                    if (number > peak)
                    {
                        peak = number;
                        peakSteps = numOfSteps;
                    }
                }
                else
                {
                    number = (number * 3) + 1;

                    if (number > peak)
                    {
                        peak = number;
                        peakSteps = numOfSteps;
                    }
                }
            }

            textBlockSteps.Text = "It took " + numOfSteps + " steps to reach 1 from " + input + ".";
            textBlockPeak.Text = "The value reaches its peak of " + peak + " at step " + peakSteps + ".";

        }
    }
}
