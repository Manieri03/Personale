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

        }

        private void btnInserimento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMostraFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
