using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UrFit
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Page
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if
            (double.TryParse(txtWeight.Text, out double weight) &&
                double.TryParse(txtHeight.Text, out double height) &&
                int.TryParse(txtAge.Text, out int age))
            {
                double bmr = CalculateBMR(weight, height, age);
                double dailyCalories = CalculateDailyCalories(bmr);
                txtBMR.Text = bmr.ToString("0.00");
                txtDailyCalories.Text = dailyCalories.ToString("0.00");
            }
            else
            {

                MessageBox.Show("Пожалуйста введите значения веса, роста, и возраста.");
            }
        }

        private double CalculateBMR(double weight, double height, int age)
        {
            if (radioMale.IsChecked == true)
            {
                return 88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age);
            }
            else
            {
                return 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);
            }
        }

        private double CalculateDailyCalories(double bmr)
        {
            double activityFactor = 1.2; // Сидячий образ жизни
            if (radioActive.IsChecked == true)
            {
                activityFactor = 1.55; // Умеренно активный
            }
            else if (radioVeryActive.IsChecked == true)
            {
                activityFactor = 1.725; // Очень активный
            }

            return bmr * activityFactor;
        }


        public class NotesModel
        {
            public string Diet { get; set; }
            public string Workouts { get; set; }
            public string DailySchedule { get; set; }
            public DateTime DateCreated { get; set; }
        }

        public class NotesViewModel : INotifyPropertyChanged
        {
            public NotesModel Notes { get; set; }

            public NotesViewModel()
            {
                Notes = new NotesModel();
                Notes.DateCreated = DateTime.Now;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

