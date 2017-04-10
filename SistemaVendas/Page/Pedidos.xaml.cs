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
    /// Interaction logic for Pedidos.xaml
    /// </summary>
    public partial class Pedidos : System.Windows.Controls.Page
    {
        private Models.Pedido pedido = new Models.Pedido();
        private Models.PedidoDetalhe peDetalhe = new Models.PedidoDetalhe();
        private List<Models.Pedido> pedidos = new List<Models.Pedido>();
        private List<Models.PedidoDetalhe> pedDetalhes = new List<Models.PedidoDetalhe>();

        private Models.Vendedor vendedor = new Models.Vendedor();
        private List<Models.Vendedor> vendedores = new List<Models.Vendedor>();
        private Models.Fornecedor fornecedor = new Models.Fornecedor();
        private List<Models.Fornecedor> fornecedores = new List<Models.Fornecedor>();

        private BLL.PedidoBLL bllPedido = new BLL.PedidoBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.VendedorBLL bllVendedor = new BLL.VendedorBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.ClienteBLL bllCliente = new BLL.ClienteBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.ProdutoBLL bllProduto = new BLL.ProdutoBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.FornecedorBLL bllFornecedor = new BLL.FornecedorBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        ICollectionView cvPedidos;


        public Pedidos()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarVendedor();
            CarregarFornecedor();
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gerarNota_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarregarGrid()
        {
            pedidos = bllPedido.getPedidos();
            cvPedidos = CollectionViewSource.GetDefaultView(pedidos);

            if (pedidos.Count >= 1)
            {
                dtgPedido.ItemsSource = cvPedidos;
            }
            else
            {
                dtgPedido.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Pedido p = (o as Models.Pedido);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtNrPedidoPesq")
            {
                if (p.PedidoId.ToString().Contains(tPesquisa.Text))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else if (tPesquisa.Name == "txtClientePesq")
            {
                if (p.Cliente.ClienteNomeFantasia.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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

            if (cvPedidos != null)
            {
                cvPedidos.Filter = TextFilter;
            }
        }

        private void CarregarVendedor()
        {
            vendedores = bllVendedor.getVendedores();

            if (vendedores.Count > 0)
            {
                cmbVendedor.ItemsSource = vendedores;
            }
            else
            {
                cmbVendedor.ItemsSource = null;
            }
        }

        private void CarregarFornecedor()
        {
            fornecedores = bllFornecedor.getFornecedores();

            if (fornecedores.Count > 0)
            {
                cmbFornecedor.ItemsSource = fornecedores;
            }
            else
            {
                cmbFornecedor.ItemsSource = null;
            }
        }

        private void dtgPedido_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                pedido = dtgPedido.CurrentCell.Item as Models.Pedido;

                if (pedido != null)
                {
                    txtCodPedido.Text = pedido.PedidoId.ToString();
                    txtDataEmissao.Text = pedido.PedidoDatEmissao.ToString();
                    txtCodCliente.Text = pedido.Cliente.ClienteId.ToString();
                    txtCliente.Text = pedido.Cliente.ClienteNomeFantasia;
                    dtgItens.ItemsSource = pedido.Pdetalhes;
                    txtDesconto.Text = pedido.PedidoDesconto.ToString();
                    txtValTotalParcial.Text = pedido.PedidoValorSubTotal.ToString();
                    txtFrete.Text = pedido.PedidoFrete.ToString();
                    txtValTotal.Text = pedido.PedidoValor.ToString();
                    txtFormaPagamento.Text = pedido.PedidoCondPagto;
                    txtObservacao.Text = pedido.PedidoObservacao;

                    cmbVendedor.SelectedValue = pedido.Vendedor.VendedorId;
                    cmbFornecedor.SelectedValue = pedido.Fornecedor.FornecedorId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
