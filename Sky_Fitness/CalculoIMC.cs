using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Sky_Fitness
{
    class CalculoIMC : INotifyPropertyChanged
    {
        private string peso;
        private string estatura;
        private string imc;
        double denominador = 0;
        // Propiedades
        public string Peso
        {
            get
            {
                return peso;
            }
            set
            {
                double p;
                bool resultado = double.TryParse(value, out p);
                if (resultado) peso = value;
                OnPropertyChanged("Peso");
                OnPropertyChanged("IMC");
            }
        }
        public string Estatura
        {
            get
            {
                return estatura;
            }
            set
            {
                double e;
                bool resultado = double.TryParse(value, out e);
                if (resultado) estatura = value;
                OnPropertyChanged("Estatura");
                OnPropertyChanged("IMC");
            }
        }

        public string IMC
        {
            get
            {
                
                //denominador = Math.Pow(double.Parse(Estatura), 2);
                double resultado = (double.Parse(Peso) / (Math.Pow(double.Parse(Estatura), 2)));
                return resultado.ToString();
            }
            set
            {
                double denominador = Math.Pow(double.Parse(Estatura), 2);
                double resultado = (double.Parse(Peso) / denominador);
                IMC = resultado.ToString();
                OnPropertyChanged("IMC");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Métodos
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
