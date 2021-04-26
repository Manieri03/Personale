using LibreriaPersonale;
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
using System.Windows.Shapes;

namespace InserimentoPersonale
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FormAziendale : Window
    {
        private string[] qualifiche = new string[] { "Dirigente", "Quadro", "Amministrativo", "Operaio" };
        private PersonaleAziendale pa;
        public FormAziendale(PersonaleAziendale pa)
        {
            this.pa = pa;
            InitializeComponent();

        }

        private void cmbQualifica_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in qualifiche)
            { 
                cmbQualifica.Items.Add(s); 
            }
        }

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbQualifica.SelectedIndex == -1)
                    throw new Exception("Selezionare una qualifica");
                if (txtArea.Text == "")
                    throw new Exception("Area non valida");

                pa.Qualifica = cmbQualifica.SelectedItem.ToString();
                pa.Area = txtArea.Text;

                using (StreamWriter sw = new StreamWriter(Costanti.FILE, true))
                {
                    sw.WriteLine($"{pa.CodiceFiscale};{pa.Nome};{pa.Cognome};{pa.Tipologia};{pa.Qualifica};{pa.Area}");
                    sw.Flush();
                    sw.Close();
                }
                listRiepilogo.Items.Add(pa.ToString());       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnInserimento_Click(object sender, RoutedEventArgs e)
        {
            if (listRiepilogo.Items.Count == 0)
                MessageBox.Show("Attenzione", "Occorre Inserire qualifica e area per poter creare la persona!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                this.Close();
        }

        private void btnMostraFile_Click(object sender, RoutedEventArgs e)
        {
            new MostraFile().ShowDialog();
        }
    }
}
