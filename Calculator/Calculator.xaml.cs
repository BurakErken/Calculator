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

            // Yeni bir giriş yapılacaksa, mevcut girişi temizle
            if (isNewEntry && !string.IsNullOrEmpty(currentOperator))
            {
                isNewEntry = false;
            }

            currentEntry += number;
            ResultEntry.Text = currentEntry;
        }

        // İşlem Butonları için Event
        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string operatorSymbol = button.Text;

            // Geçerli bir sayı varsa, işlemi yap
            if (double.TryParse(currentEntry.Split(' ')[^1], out double number))
            {
                if (string.IsNullOrEmpty(currentOperator))
                {
                    // İlk işlemse, sonucu başlat
                    currentResult = number;
                }
                else
                {
                    // Önceki işlemi sonuçlandır
                    PerformCalculation(number);
                }
            }


            // Operatörü güncelle ve yeni giriş için hazırla
            currentOperator = operatorSymbol;
            currentEntry = $"{currentResult} {currentOperator} ";
            ResultEntry.Text = currentEntry;
            isNewEntry = true;
        }

        // Eşittir Butonu için Event
        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentEntry.Split(' ')[^1], out double number))
            {
                PerformCalculation(number);

                // Sonucu göster ve girişleri sıfırla
                ResultEntry.Text = currentResult.ToString();
                currentEntry = currentResult.ToString();
                currentOperator = "";
                isNewEntry = true;
            }
        }

        // İşlemi gerçekleştir
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

        // Temizleme Butonu için Event
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