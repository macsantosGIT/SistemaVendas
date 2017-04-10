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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : System.Windows.Controls.Page
    {
        private int tipoPessoa;

        public Cliente()
        {
            InitializeComponent();
        }

        private void rdoTipoPessoa_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            if (button.Name.ToString() == "rdoJuridica")
            {
                tipoPessoa = 1;
            }
            else {
                tipoPessoa = 2;
            }
        }

    }
}
