using System.Windows;
using System.Windows.Controls;
using Utilities;

namespace The_Calculator_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber, _result;
        private SelectedOperator _lastOperator;

        public MainWindow()
        {
            InitializeComponent();

            //Generate the Click Handlers
            lblAC.Click       += ACButton_Click;
            lblNegative.Click += NegativeButton_Click;
            lblPercent.Click  += PercentButton_Click;
            lblEqual.Click    += EqualButton_Click;

        }

        /// <summary>
        /// Based on the selected operator, the equal button returns the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (_lastOperator)
                {
                    case SelectedOperator.Addition:
                        _result = SimpleMaths.Add(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        _result = SimpleMaths.Subtract(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        _result = SimpleMaths.Multiply(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        if (newNumber == 0)
                        {
                            MessageBox.Show("Error", "Cannot Divide by Zero", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                            _result = 0;
                        }
                        else
                        {
                            _result = (_lastNumber / newNumber);
                        }
                        break;
                    default:
                        break;
                }
                lblResult.Content = _result.ToString();
            }

        }

        /// <summary>
        /// Converts the Number on the screen to percentage i.e Divide the number by 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber / 100;
                lblResult.Content = _lastNumber.ToString();
            }
        }

        /// <summary>
        /// Change the sign of the number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out double lastNumber))
            {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
                
            }
        }

        /// <summary>
        /// Set everything to default and resets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            _lastNumber = 0;
            _result = 0;
            lblResult.Content = "0";
        }

        /// <summary>
        /// Handles all the Numeric Button handler on the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblNumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Validate the max length of the lblResult
            if (lblResult.Content.ToString().Length >= 6)
                return;

            // All the number buttons on the calculator will be handled here
            Button myButton = (Button)sender;
            string buttonContent = myButton.Content.ToString();
            //The above line is equal
            //var selectedValue = (sender as Button).Content.ToString();

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = buttonContent;
            }
            else
            {
                lblResult.Content = lblResult.Content + buttonContent;
                //lblResult.Content = $"{lblResult.Content}7";
            }
        }

        /// <summary>
        /// Handles all the operator buttons on the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblOperatorButton_OnClick(object sender, RoutedEventArgs e)
        {
            // All the operator buttons on the calculator will be handled here
            Button myButton = (Button)sender;
            string buttonContent = myButton.Content.ToString();

            // Update the display on successful attempt.
            // Done to handle the user adding multiple decimal points
            if (double.TryParse(lblResult.Content.ToString(), out _lastNumber))
            {
                lblResult.Content = "0";
            }
            
            // Based on the button content, do the appropriate operation
            if (buttonContent == "+"){
                _lastOperator = SelectedOperator.Addition;
            }
            if (buttonContent == "-")
            {
                _lastOperator = SelectedOperator.Subtraction;
            }
            if (buttonContent == "*")
            {
                _lastOperator = SelectedOperator.Multiplication;
            }
            if (buttonContent == "/")
            {
                _lastOperator = SelectedOperator.Division;
            }

        }

        /// <summary>
        /// Adds a decimal place. Also checks there should not be more than 1 decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblDot_OnClick(object sender, RoutedEventArgs e)
        {
            //Check if there exist a dot in lblResult
            if (!lblResult.Content.ToString().Contains("."))
            {
                lblResult.Content = lblResult.Content + ".";
            }

        }
    }

}
