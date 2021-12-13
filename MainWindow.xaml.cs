using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;

        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Cleans the label and sets value of the label to "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        /// <summary>
        /// divides the number by 100 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNumber))
            {
                tempNumber /= 100;
                if (tempNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
            }
        }
        /// <summary>
        /// calculates the result of the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        /// <summary>
        /// adds or removes minus sign from the number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinplusButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }
        /// <summary>
        /// saves the last entered value and set the label to zero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multipleButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Subtraction;

        }
        /// <summary>
        /// makes the number a floating point number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains('.'))
                return;
            resultLabel.Content = $"{resultLabel.Content}.";
        }

        /// <summary>
        /// adds the clicked number to the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = int.Parse((sender as Button)?.Content.ToString());
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }


        }
    }
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}
