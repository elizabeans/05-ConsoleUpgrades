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

namespace ChangeCalculatorUpgrade
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

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double cost = Math.Round(double.Parse(textBoxCost.Text), 2);
                double payment = Math.Round(double.Parse(textBoxPayment.Text), 2);
                double change = payment - cost;

                // Show change in cash register window
                textBlockChange.Text = "$" + string.Format("{0:0.00}", change);

                // Calculate exact change
                double[] exact = calculateExactChange(change);

                // Show exact change to give
                textBlockExactChange.Text = "You need to give \n" +
                                            exact[0] + " $100 bill(s) \n" +
                                            exact[1] + " $50 bill(s) \n" +
                                            exact[2] + " $20 bill(s) \n" +
                                            exact[3] + " $10 bill(s) \n" +
                                            exact[4] + " $5 bill(s) \n" +
                                            exact[5] + " $1 bill(s) \n" +
                                            exact[6] + " quarter(s) \n" +
                                            exact[7] + " dime(s) \n" +
                                            exact[8] + " nickel(s) and \n" +
                                            exact[9] + " pennies.";
            }
            catch (FormatException exception)
            {
                // Window pops up to display error 

                ErrorMessageWindow window = new ErrorMessageWindow();
                if (textBoxCost.Text == "Enter cost here" || textBoxPayment.Text == "Enter payment here")
                {
                    window.textBlockError.Text = "You forgot to enter the cost and/or payment.";
                }
                else
                {
                    window.textBlockError.Text = "Please enter a valid number. \n" +
                                                 "Do not include any currency symbols (i.e. $)";
                }

                window.Show();
            }
        }

        public double[] calculateExactChange (double change)
        {
           double[] exactChange = new double[10];

           exactChange[0] = Math.Floor(change / 100);
           exactChange[1] = Math.Floor(change % 100 / 50);
           exactChange[2] = Math.Floor(change % 100 % 50 / 20);
           exactChange[3] = Math.Floor(change % 100 % 50 % 20 / 10);
           exactChange[4] = Math.Floor(change % 100 % 50 % 20 % 10 / 5);
           exactChange[5] = Math.Floor(change % 100 % 50 % 20 % 10 % 5 / 1);
           exactChange[6] = Math.Floor(change % 100 % 50 % 20 % 10 % 5 % 1 / 0.25);
           exactChange[7] = Math.Floor(change % 100 % 50 % 20 % 10 % 5 % 1 % 0.25 / 0.10);
           exactChange[8] = Math.Floor(change % 100 % 50 % 20 % 10 % 5 % 1 % 0.25 % 0.10 / 0.05);
           exactChange[9] = Math.Floor(change % 100 % 50 % 20 % 10 % 5 % 1 % 0.25 % 0.10 % 0.05 / 0.01);

           return exactChange;
           
        }
    }
}
