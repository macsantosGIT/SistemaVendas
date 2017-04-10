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

namespace SistemaVendas.Page
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : System.Windows.Controls.Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void dtgVendas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void dtgOrcamentos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
