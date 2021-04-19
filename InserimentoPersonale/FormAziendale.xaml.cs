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
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Aziendale : Window
    {
        public Aziendale(PersonaleAziendale pa)
        {
            InitializeComponent();
            this.pa = pa;

        }

        private string[] qualifiche = new string[] { "Dirigente", "Quadro", "Amministrativo", "Operaio" };

        private PersonaleAziendale pa;
        
    }
}
