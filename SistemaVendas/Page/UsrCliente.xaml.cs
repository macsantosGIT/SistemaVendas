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
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Util;

namespace SistemaVendas.Page
{
    /// <summary>
    /// Interaction logic for UsrCliente.xaml
    /// </summary>
    public partial class UsrCliente : UserControl
    {
        private Models.Cliente cliente = new Models.Cliente();
        private List<Models.Cliente> clientes = new List<Models.Cliente>();
        private BLL.ClienteBLL bllCliente = new BLL.ClienteBLL(DAL.SistemaVendasContexto.Instancia);
        TextBox tPesquisa;
        ICollectionView cvClientes;
        
        public UsrCliente()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void dtgClientes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                cliente = dtgClientes.CurrentCell.Item as Models.Cliente;

                if (cliente != null)
                {
                    Orcamentos.cliRetPesquisa = cliente;
                    var parentWin = Window.GetWindow(this);
                    parentWin.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CarregarGrid()
        {
            clientes = bllCliente.getClientes();

            cvClientes = CollectionViewSource.GetDefaultView(clientes);

            if (clientes.Count >= 1)
            {
                dtgClientes.ItemsSource = cvClientes;
            }
            else
            {
                dtgClientes.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Cliente p = (o as Models.Cliente);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtRazaoSocialPesq")
            {
                if (p.ClienteNome.ToUpper().Contains(tPesquisa.Text.ToUpper()))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else if (tPesquisa.Name == "txtNomeFantasiaPesq")
            {
                if (p.ClienteNomeFantasia.ToUpper().Contains(tPesquisa.Text.ToUpper()))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        private void txtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            tPesquisa = (TextBox)sender;

            if (cvClientes != null)
            {
                cvClientes.Filter = TextFilter;
            }
        }

    }
}
