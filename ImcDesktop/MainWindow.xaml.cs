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

namespace ImcDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pesotextbox.Focus();
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            string s = pesotextbox.Text;
            decimal peso = Convert.ToDecimal(s);
            s = estaturatextbox.Text;
            decimal estatura = Convert.ToDecimal(s);
            decimal imc = peso / (estatura * estatura);
            imctextblock.Text = string.Format("{0:.0000}", imc);
            imctextblock.Foreground = SetColorEstadoNutricional(imc);
            situaciontextblock.Text = EstadoNutricional(imc);
            situaciontextblock.Foreground = SetColorEstadoNutricional(imc);
            limpiarbutton.Focus();
        }

        private void limpiarbutton_Click(object sender, RoutedEventArgs e)
        {
            pesotextbox.Text = "";
            estaturatextbox.Text = "";
            imctextblock.Text = "0.0";
            imctextblock.Foreground = Brushes.Black;
            situaciontextblock.Text = "";
            situaciontextblock.Foreground = Brushes.Black;
            pesotextbox.Focus();
        }

        private void salirbutton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private string EstadoNutricional(decimal imc)
        {
            if (imc < 18.5M) { return "Peso bajo"; }
            else if (imc < 25.0M) { return "Peso normal"; }
            else if (imc < 30.0M) { return "Sobrepeso"; }
            else if (imc < 40.0M) { return "Obesidad"; }
            else { return "Obesidad extrema"; }
        }
        private Brush SetColorEstadoNutricional(decimal imc)
        {
            if (imc < 18.5M) { return Brushes.Yellow; }
            else if (imc < 25.0M) { return Brushes.Green; }
            else if (imc < 30.0M) { return Brushes.Yellow; }
            else if (imc < 40.0M) { return Brushes.Orange; }
            else { return Brushes.Red; }
        }
    } 
}
