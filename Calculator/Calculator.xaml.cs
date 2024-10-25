using System;
using Microsoft.Maui.Controls;

namespace Calculator
{

    public partial class Calculator : ContentPage
    {
        private string currentEntry = "";
        private double currentResult = 0;
        private string currentOperator = "";
        private bool isNewEntry = true;

        public Calculator()
        {
            InitializeComponent();
        }
        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string number = button.Text;

            if (isNewEntry && !string.IsNullOrEmpty(currentOperator))
            {
                isNewEntry = false;
            }

            currentEntry += number;
            ResultEntry.Text = currentEntry;
        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string operatorSymbol = button.Text;

            if (double.TryParse(currentEntry.Split(' ')[^1], out double number))
            {
                if (string.IsNullOrEmpty(currentOperator))
                {
                    currentResult = number;
                }
                else
                {
                    PerformCalculation(number);
                }
            }

            currentOperator = operatorSymbol;
            currentEntry = $"{currentResult} {currentOperator} "; // currentEntry değişkenine sayıyı ve operatörü ekler
            ResultEntry.Text = currentEntry;
            isNewEntry = true;
        }

        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentEntry.Split(' ')[^1], out double number))
            {
                PerformCalculation(number);

                ResultEntry.Text = currentResult.ToString();
                currentEntry = currentResult.ToString();
                currentOperator = "";
                isNewEntry = true;
            }
        }

        private void PerformCalculation(double number)
        {
            switch (currentOperator)
            {
                case "+":
                    currentResult += number;
                    break;
                case "-":
                    currentResult -= number;
                    break;
                case "*":
                    currentResult *= number;
                    break;
                case "/":
                    if (number != 0)
                        currentResult /= number;
                    else
                    {
                        DisplayAlert("Hata", "Sıfıra bölme hatası!", "Tamam");
                        return;
                    }
                    break;
            }
        }
        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            currentEntry = "";
            currentOperator = "";
            currentResult = 0;
            isNewEntry = true;
            ResultEntry.Text = "0";
        }
    }
}