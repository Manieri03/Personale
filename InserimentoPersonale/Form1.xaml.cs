using System;
using System.Collections.Generic;
using System.IO;
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

namespace InserimentoPersonale
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LeggiFile();
            txtFis.Focus();
        }
        string[] tipo = new string[] { "Aziendale", "SubFornitore", "Fornitore", "Consulente" };
        private HashSet<string> codicifiscali = new HashSet<string>();
        List<Persona> persone = new List<Persona>();

        private void CmbTipo_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in tipo)
            {
                cmbTipo.Items.Add(s);
            }
        }


        private void BtnInserisci_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    if(txtCognome.Text!="" && txtNome.Text!="" && txtFis.Text != "")
                    {
                        if (codicifiscali.Contains(txtFis.Text))
                        {
                            PersonaleAziendale pa = new PersonaleAziendale(txtNome.Text, txtCognome.Text, txtFis.Text, cmbTipo.SelectedItem.ToString());
                            Aziendale formAziendale = new Aziendale(pa);
                            formAziendale.ShowDialog();
                            codicifiscali.Add(pa.CodiceFiscale);
                        }
                        else
                        {
                            MessageBox.Show("Attenzione", "Questo codice fiscale è stato già inserito", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Attenzione", "Non sono stati immessik tutti i dati", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case 1:
                    MessageBox.Show("Informazione", "Work in progress", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 2:
                    MessageBox.Show("Informazione", "Work in progress", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 3:
                    MessageBox.Show("Informazione", "Work in progress", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case -1:
                    MessageBox.Show("Attenzione", "Inserisci una tipologia", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

            }
        }


        private void LeggiFile()
        {
            string line;
            StreamReader sr = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);

            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');
                    codicifiscali.Add(personale[0]);
                }
            } while (line != null);

            sr.Close();
        }


        private void BtnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtFis.Clear(); 
            txtNome.Clear();
            txtCognome.Clear();
            cmbTipo.SelectedIndex = -1;
        }
        private void BtnEsci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
