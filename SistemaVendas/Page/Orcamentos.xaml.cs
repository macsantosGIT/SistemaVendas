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
    /// Interaction logic for Orcamentos.xaml
    /// </summary>
    public partial class Orcamentos : System.Windows.Controls.Page
    {
        private Models.Orcamento orcamento = new Models.Orcamento();
        private Models.OrcamentoDetalhe orcDetalhe = new Models.OrcamentoDetalhe();
        private List<Models.Orcamento> orcamentos = new List<Models.Orcamento>();
        private List<Models.OrcamentoDetalhe> orcDetalhes = new List<Models.OrcamentoDetalhe>();

        private Models.Vendedor vendedor = new Models.Vendedor();
        private List<Models.Vendedor> vendedores = new List<Models.Vendedor>();
        private Models.Fornecedor fornecedor = new Models.Fornecedor();
        private List<Models.Fornecedor> fornecedores = new List<Models.Fornecedor>();
        private BLL.OrcamentoBLL bllOrcamento = new BLL.OrcamentoBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.VendedorBLL bllVendedor = new BLL.VendedorBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.FornecedorBLL bllFornecedor = new BLL.FornecedorBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.ClienteBLL bllCliente = new BLL.ClienteBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.ProdutoBLL bllProduto = new BLL.ProdutoBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        ICollectionView cvOrcamentos;

        public static Models.Cliente cliRetPesquisa;
        public static Models.Produto proRetPesquisa;

        public Orcamentos()
        {
            InitializeComponent();
            FocusInicio();
            CarregarGrid();
            CarregarVendedor();
            CarregarFornecedor();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (dtpDataEmissao.Text != string.Empty || txtCodCliente.Text != string.Empty || txtCliente.Text != string.Empty
                || cmbVendedor.SelectedIndex != 0)
            {
                try
                {
                    orcamento.OrcamentoDatEmissao = Convert.ToDateTime(dtpDataEmissao.Text);
                    orcamento.OrcamentoDesconto = Convert.ToDecimal(txtValDescontoTotal.Text);
                    orcamento.OrcamentoFrete = Convert.ToDecimal(txtFrete.Text);
                    orcamento.OrcamentoValorSubTotal = Convert.ToDecimal(txtValTotalParcial.Text);
                    orcamento.OrcamentoValor = Convert.ToDecimal(txtValTotal.Text);
                    orcamento.OrcamentoCondPagto = txtFormaPagamento.Text;
                    orcamento.OrcamentoObservacao = txtObservacao.Text;
                    orcamento.OrcamentoStatus = cmbStatus.SelectedIndex; //verificar
                    orcamento.Cliente = cliRetPesquisa;
                    orcamento.Vendedor = cmbVendedor.SelectedItem as Models.Vendedor;
                    orcamento.Fornecedor = cmbFornecedor.SelectedItem as Models.Fornecedor;
                    
                    //testar e verificar
                    orcamento.Odetalhes = orcDetalhes;

                    bllOrcamento.Incluir(orcamento);

                    txtCodOrcamento.Text = orcamento.OrcamentoId.ToString();

                    MessageBox.Show("Orçamento Inserido com Sucesso!", "Orçamento");
                    CarregarGrid();
                    //cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão deste Orçamento! " + ex.ToString(), "Orçamento");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Campos Obrigatórios: Data, Cliente e Vendedor !", "Orçamento");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodOrcamento.Text = string.Empty;
            dtpDataEmissao.Text = string.Empty;
            txtCodCliente.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtCodProduto.Text = string.Empty;
            txtProduto.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            txtValorUnit.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            dtgItens.ItemsSource = null;
            txtValDescontoTotal.Text = string.Empty;
            txtValTotalParcial.Text = string.Empty;
            txtFrete.Text = string.Empty;
            txtValTotal.Text = string.Empty;
            txtFormaPagamento.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            CarregarVendedor();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            Window wCliente = new Window();
            UsrCliente uCliente = new UsrCliente();
            wCliente.Content = uCliente;

            wCliente.ShowDialog();

            if (cliRetPesquisa != null)
            {
                txtCodCliente.Text = cliRetPesquisa.ClienteId.ToString();
                txtCliente.Text = cliRetPesquisa.ClienteNomeFantasia;
            }
        }

        private void btnProduto_Click(object sender, RoutedEventArgs e)
        {
            Window wProduto = new Window();
            UsrProduto uProduto = new UsrProduto();
            wProduto.Content = uProduto;
            
            wProduto.ShowDialog();

            if (proRetPesquisa != null)
            {
                txtCodProduto.Text = proRetPesquisa.ProdutoId.ToString();
                txtProduto.Text = proRetPesquisa.ProdutoNome;
            }
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            /*Incluir produto no grid itens*/
            if (orcDetalhes.Count > 0)
            {
                int i = orcDetalhes.Count;
                orcDetalhe.OrcamentoDetalheItem = orcDetalhes[i].OrcamentoDetalheItem + 1;
            }
            else
            {
                orcDetalhe.OrcamentoDetalheItem = 1;
            }

            orcDetalhe.Produto = proRetPesquisa;
            orcDetalhe.OrcamentoDetalheQtd = Convert.ToInt32(txtQuantidade.Text);
            orcDetalhe.OrcamentoDetalhePctDesc = Convert.ToDecimal(txtDesconto.Text);
            orcDetalhe.OrcamentoDetalhePrecoUnit = Convert.ToDecimal(txtValorUnit.Text);
            orcDetalhe.OrcamentoDetalhePrecoTotal = Convert.ToDecimal(txtSubTotal.Text);

            orcDetalhes.Add(orcDetalhe);

            dtgItens.ItemsSource = orcDetalhes;

            //Atualizar Campos Desconto e Total Parcial
            decimal descontoTotal = 0;
            decimal subTotal = 0;
            foreach (var item in orcDetalhes) 
            {
                if (item.OrcamentoDetalhePctDesc >= 0)
                {
                    descontoTotal += ((item.OrcamentoDetalheQtd * item.OrcamentoDetalhePrecoUnit) * item.OrcamentoDetalhePctDesc / 100);
                }
                subTotal += item.OrcamentoDetalhePrecoTotal;
            }

            txtValDescontoTotal.Text = descontoTotal.ToString("#.##");
            txtValTotalParcial.Text = subTotal.ToString("#.##");
            txtValTotal.Text = subTotal.ToString("#.##");

            txtCodProduto.Text = string.Empty;
            txtProduto.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            txtValorUnit.Text = string.Empty;
            txtSubTotal.Text = string.Empty;

        }

        private void CarregarGrid()
        {
            orcamentos = bllOrcamento.getOrcamentos();
            cvOrcamentos = CollectionViewSource.GetDefaultView(orcamentos);

            if (orcamentos.Count >= 1)
            {
                dtgOrcamentos.ItemsSource = cvOrcamentos;
            }
            else
            {
                dtgOrcamentos.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Orcamento p = (o as Models.Orcamento);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtNrOrcamentoPesq")
            {
                if (p.OrcamentoId.ToString().Contains(tPesquisa.Text))
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

            if (cvOrcamentos != null)
            {
                cvOrcamentos.Filter = TextFilter;
            }
        }

        private void dtgOrcamentos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                orcamento = dtgOrcamentos.CurrentCell.Item as Models.Orcamento;

                if (orcamento != null)
                {
                    txtCodOrcamento.Text = orcamento.OrcamentoId.ToString();
                    dtpDataEmissao.Text = orcamento.OrcamentoDatEmissao.ToString();
                    cliRetPesquisa = orcamento.Cliente;
                    txtCodCliente.Text = cliRetPesquisa.ClienteId.ToString();
                    txtCliente.Text = cliRetPesquisa.ClienteNomeFantasia;
                    dtgItens.ItemsSource = orcamento.Odetalhes;
                    txtDesconto.Text = orcamento.OrcamentoDesconto.ToString();
                    txtValTotalParcial.Text = orcamento.OrcamentoValorSubTotal.ToString();
                    txtFrete.Text = orcamento.OrcamentoFrete.ToString(); 
                    txtValTotal.Text = orcamento.OrcamentoValor.ToString();
                    txtFormaPagamento.Text = orcamento.OrcamentoCondPagto;
                    txtObservacao.Text = orcamento.OrcamentoObservacao;
                    
                    cmbVendedor.SelectedValue = orcamento.Vendedor.VendedorId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void FocusInicio()
        {
            dtpDataEmissao.Focus();
        }

        private void dtgItens_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (MessageBox.Show("Deseja exluir este Item?", "Orçamento - Item", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                Models.OrcamentoDetalhe orcD = new Models.OrcamentoDetalhe();
                orcD = dtgItens.CurrentCell.Item as Models.OrcamentoDetalhe;

                if (orcD != null)
                {
                    orcDetalhes.Remove(orcD);
                    dtgItens.ItemsSource = null;
                    
                    if (orcDetalhes.Count > 0)
                    {
                        dtgItens.ItemsSource = orcDetalhes;
                    }
                }
            }
        }

        private void txtQuantidade_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQuantidade.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtQuantidade.Text))
                {
                    MessageBox.Show("Quantidade Invalida!", "Orçamento");
                    txtQuantidade.Text = string.Empty;
                    txtQuantidade.Focus();                    
                }
            }
        }

        private void txtDesconto_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDesconto.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtDesconto.Text)))
                {
                    txtDesconto.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtDesconto.Text));
                }
                else
                {
                    MessageBox.Show("Valor de Desconto Invalido!", "Orçamento");
                    txtDesconto.Text = Validacao.MascaraDecimal("0");
                    txtDesconto.Focus();
                }
            }
            else
            {
                txtDesconto.Text = Validacao.MascaraDecimal("0");
            }
        }

        private void txtValorUnit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorUnit.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtValorUnit.Text)))
                {
                    txtValorUnit.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtValorUnit.Text));
                    if (txtQuantidade.Text != string.Empty && txtDesconto.Text != string.Empty)
                    {
                        txtValorUnit.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtValorUnit.Text));
                        if (Convert.ToDecimal(txtDesconto.Text) > 0)
                        {
                            txtSubTotal.Text = ((Convert.ToDecimal(txtValorUnit.Text) * Convert.ToInt32(txtQuantidade.Text)) - ((Convert.ToDecimal(txtValorUnit.Text) * Convert.ToInt32(txtQuantidade.Text)) * Convert.ToDecimal(txtDesconto.Text) / 100)).ToString("#.##");
                        }
                        else
                        {
                            txtSubTotal.Text = ((Convert.ToDecimal(txtValorUnit.Text) * Convert.ToInt32(txtQuantidade.Text))).ToString("#.##");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Valor Unitário Invalido!", "Orçamento");
                    txtValorUnit.Text = Validacao.MascaraDecimal("0");
                    txtValorUnit.Focus();
                }
            }
        }

        private void txtSubTotal_LostFocus(object sender, RoutedEventArgs e)
        {
  
        }

        private void txtFrete_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFrete.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtFrete.Text)))
                {
                    txtFrete.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtFrete.Text));
                    txtValTotal.Text = (Convert.ToDecimal(txtValTotalParcial.Text) + Convert.ToDecimal(txtFrete.Text)).ToString("#.##");
                }
                else
                {
                    MessageBox.Show("Valor de Frete Invalido!", "Orçamento");
                    txtFrete.Text = Validacao.MascaraDecimal("0");
                    txtFrete.Focus();
                }
            }
        }
        
        private void txtCodCliente_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCodCliente.Text != string.Empty)
            {
                Models.Cliente cliente = new Models.Cliente();
                cliente.ClienteId = Convert.ToInt32(txtCodCliente.Text);
                cliRetPesquisa = bllCliente.getCliente(cliente);
                txtCliente.Text = cliRetPesquisa.ClienteNomeFantasia;
            }
        }

        private void txtCodProduto_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCodProduto.Text != string.Empty)
            {
                Models.Produto produto = new Models.Produto();
                produto.ProdutoId = Convert.ToInt32(txtCodProduto.Text);
                proRetPesquisa = bllProduto.getProduto(produto);
                txtProduto.Text = proRetPesquisa.ProdutoNome;
            }
        }
    }
}
