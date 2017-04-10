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
using System.IO;
using Util;


namespace SistemaVendas.Page
{
    /// <summary>
    /// Interaction logic for Produto.xaml
    /// </summary>
    public partial class Produtos : System.Windows.Controls.Page
    {
        private Models.Produto produto = new Models.Produto();
        public List<Models.Produto> produtos = new List<Models.Produto>();
        private List<Models.Categoria> categorias = new List<Models.Categoria>();
        private List<Models.Fornecedor> fornecedores = new List<Models.Fornecedor>();
        private BLL.ProdutoBLL bllProduto = new BLL.ProdutoBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.FornecedorBLL bllFornecedor = new BLL.FornecedorBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.CategoriaBLL bllCategoria = new BLL.CategoriaBLL(DAL.SistemaVendasContexto.Instancia);
        private byte[] dadosImagem;
        private TextBox tPesquisa;
        ICollectionView cvProdutos;
        
        public Produtos()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarCategoria();
            CarregarFornecedor();
            FocusInicio();
            tbcProduto.TabIndex = 0;
        }
        
        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if(txtNome.Text != string.Empty && cmbFornecedor.SelectedIndex >= 0 && cmbCategoria.SelectedIndex >= 0)
            {
                try
                {
                    produto.ProdutoNome = txtNome.Text;
                    produto.Fornecedor = cmbFornecedor.SelectedItem as Models.Fornecedor;
                    produto.Categoria = cmbCategoria.SelectedItem as Models.Categoria; 
                    produto.ProdutoUnidade = txtUnidade.Text;
                    produto.ProdutoIpi = decimal.Parse(txtIpi.Text);
                    produto.ProdutoSubsTributaria = decimal.Parse(txtSubsTributaria.Text);
                    produto.ProdutoPrecoCompra = decimal.Parse(txtPrecoCompra.Text);
                    produto.ProdutoPctVenda = decimal.Parse(txtPercVenda.Text);
                    produto.ProdutoPrecoSugerido = decimal.Parse(txtPrecoSugerido.Text);
                    produto.ProdutoMoeda = txtMoeda.Text;
                    if (chkEstoque.IsChecked == true)
                    { produto.ProdutoEstoque = true; }
                    else
                    { produto.ProdutoEstoque = false; }
                    produto.ProdutoQtdEstoque = txtQtdEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdEstoque.Text);
                    produto.ProdutoQtdMinEstoque = txtQtdMinEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdMinEstoque.Text);
                    produto.ProdutoObservacao = txtObservacao.Text;
                    produto.ProdutoImagem = dadosImagem;
                    produto.ProdutoCodOrigem = txtCodOrigem.Text;

                    bllProduto.Incluir(produto);

                    MessageBox.Show("Produto Inserido com Sucesso!", "Produto");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão deste Produto! " + ex.ToString(), "Produto");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios: Nome, Fornecedor e Categoria. Favor preencher!","Produto");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    produto.ProdutoId = Int32.Parse(txtCodigo.Text);
                    produto.ProdutoNome = txtNome.Text;
                    produto.Fornecedor = cmbFornecedor.SelectedItem as Models.Fornecedor;
                    produto.Categoria = cmbCategoria.SelectedItem as Models.Categoria;
                    produto.ProdutoUnidade = txtUnidade.Text;
                    produto.ProdutoIpi = decimal.Parse(txtIpi.Text);
                    produto.ProdutoSubsTributaria = decimal.Parse(txtSubsTributaria.Text);
                    produto.ProdutoPrecoCompra = decimal.Parse(txtPrecoCompra.Text);
                    produto.ProdutoPctVenda = decimal.Parse(txtPercVenda.Text);
                    produto.ProdutoPrecoSugerido = decimal.Parse(txtPrecoSugerido.Text);
                    produto.ProdutoMoeda = txtMoeda.Text;
                    if (chkEstoque.IsChecked == true)
                    { produto.ProdutoEstoque = true; }
                    else
                    { produto.ProdutoEstoque = false; }
                    produto.ProdutoQtdEstoque = txtQtdEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdEstoque.Text);
                    produto.ProdutoQtdMinEstoque = txtQtdMinEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdMinEstoque.Text);
                    produto.ProdutoObservacao = txtObservacao.Text;
                    produto.ProdutoImagem = dadosImagem;
                    produto.ProdutoCodOrigem = txtCodOrigem.Text;

                    bllProduto.Excluir(produto);

                    MessageBox.Show("Produto Excluido com Sucesso!", "Produto");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar excluir este Produto! " + ex.ToString(), "Produto");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Produto");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    produto.ProdutoId = Int32.Parse(txtCodigo.Text);
                    produto.ProdutoNome = txtNome.Text;
                    produto.Fornecedor = cmbFornecedor.SelectedItem as Models.Fornecedor;
                    produto.Categoria = cmbCategoria.SelectedItem as Models.Categoria;
                    produto.ProdutoUnidade = txtUnidade.Text;
                    produto.ProdutoIpi = decimal.Parse(txtIpi.Text);
                    produto.ProdutoSubsTributaria = decimal.Parse(txtSubsTributaria.Text);
                    produto.ProdutoPrecoCompra = decimal.Parse(txtPrecoCompra.Text);
                    produto.ProdutoPctVenda = decimal.Parse(txtPercVenda.Text);
                    produto.ProdutoPrecoSugerido = decimal.Parse(txtPrecoSugerido.Text);
                    produto.ProdutoMoeda = txtMoeda.Text;
                    if (chkEstoque.IsChecked == true)
                    { produto.ProdutoEstoque = true; }
                    else
                    { produto.ProdutoEstoque = false; }
                    produto.ProdutoQtdEstoque = txtQtdEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdEstoque.Text);
                    produto.ProdutoQtdMinEstoque = txtQtdMinEstoque.Text == string.Empty ? 0 : Int32.Parse(txtQtdMinEstoque.Text);
                    produto.ProdutoObservacao = txtObservacao.Text;
                    produto.ProdutoImagem = dadosImagem;
                    produto.ProdutoCodOrigem = txtCodOrigem.Text;

                    bllProduto.Atualizar(produto);

                    MessageBox.Show("Produto Alterado com Sucesso!", "Produto");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar alterar este Produto! " + ex.ToString(), "Produto");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Produto");
                FocusInicio();
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = string.Empty;
            CarregarFornecedor();
            CarregarCategoria();
            txtUnidade.Text = string.Empty;
            txtIpi.Text = string.Empty;
            txtSubsTributaria.Text = string.Empty;
            txtPrecoCompra.Text = string.Empty;
            txtPercVenda.Text = string.Empty;
            txtPrecoSugerido.Text = string.Empty;
            txtMoeda.Text = string.Empty;
            chkEstoque.IsChecked = false;
            txtQtdEstoque.Text = string.Empty;
            txtQtdMinEstoque.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            imgImagem.Source = null;
            txtCodOrigem.Text = string.Empty;
            FocusInicio();
        }

        private void txtIpi_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtIpi.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtIpi.Text)))
                {
                    txtIpi.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtIpi.Text));
                }
                else
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtIpi.Text = Validacao.MascaraDecimal("0");
                    txtIpi.Focus();
                }
            }
        }

        private void txtSubsTributaria_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSubsTributaria.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtSubsTributaria.Text)))
                {
                    txtSubsTributaria.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtSubsTributaria.Text));
                }
                else
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtSubsTributaria.Text = Validacao.MascaraDecimal("0");
                    txtSubsTributaria.Focus();
                }
            }
        }

        private void txtPrecoCompra_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPrecoCompra.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtPrecoCompra.Text)))
                {
                    txtPrecoCompra.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtPrecoCompra.Text));
                }
                else
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtPrecoCompra.Text = Validacao.MascaraDecimal("0");
                    txtPrecoCompra.Focus();
                }
            }
        }

        private void txtPercVenda_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPercVenda.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtPercVenda.Text)))
                {
                    txtPercVenda.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtPercVenda.Text));
                }
                else
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtPercVenda.Text = Validacao.MascaraDecimal("0");
                    txtPercVenda.Focus();
                }
            }
        }

        private void txtPrecoSugerido_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPrecoSugerido.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(Validacao.RetiraMascara(txtPrecoSugerido.Text)))
                {
                    txtPrecoSugerido.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(txtPrecoSugerido.Text));
                }
                else
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtPrecoSugerido.Text = Validacao.MascaraDecimal("0");
                    txtPrecoSugerido.Focus();
                }
            }
        }

        private void txtQtdEstoque_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQtdEstoque.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtQtdEstoque.Text))
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtQtdEstoque.Focus();
                }
            }
        }

        private void txtQtdMinEstoque_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQtdMinEstoque.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtQtdMinEstoque.Text))
                {
                    MessageBox.Show("Valor ínvalido!", "Produto");
                    txtQtdMinEstoque.Focus();
                }
            }
        }

        private void CarregarGrid()
        {
            produtos = bllProduto.getProdutos();

            cvProdutos = CollectionViewSource.GetDefaultView(produtos);

            if (produtos.Count >= 1)
            {
                dtgProdutos.ItemsSource = cvProdutos;
            }
            else
            {
                dtgProdutos.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Produto p = (o as Models.Produto);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtProduto")
            {
                if (p.ProdutoNome.ToUpper().Contains(tPesquisa.Text.ToUpper()))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else if (tPesquisa.Name == "txtCategoriaProduto")
            {
                if (p.Categoria.CategoriaNome.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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

            if (cvProdutos!= null)
            {
                cvProdutos.Filter = TextFilter;
            }
        }

        private void CarregarFornecedor()
        {
            fornecedores = bllFornecedor.getFornecedores();
            if (fornecedores.Count >= 1)
            {
                cmbFornecedor.ItemsSource = fornecedores;
            }
            else
            {
                cmbFornecedor.ItemsSource = null;
            }
        }

        private void CarregarCategoria()
        {
            categorias = bllCategoria.getCategorias();
            if (categorias.Count >= 1)
            {
                cmbCategoria.ItemsSource = categorias;
            }
            else
            {
                cmbCategoria.ItemsSource = null;
            }
        }

        private void FocusInicio()
        {
            txtNome.Focus();
        }

        private void dtgProdutos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                produto = dtgProdutos.CurrentCell.Item as Models.Produto;

                if (produto != null)
                {
                    txtCodigo.Text = produto.ProdutoId.ToString();
                    txtNome.Text = produto.ProdutoNome;
                    txtCodOrigem.Text = produto.ProdutoCodOrigem;
                    cmbFornecedor.SelectedValue = produto.Fornecedor.FornecedorId; //verificar
                    cmbCategoria.SelectedValue = produto.Categoria.CategoriaId; //verificar
                    txtUnidade.Text = produto.ProdutoUnidade;
                    txtIpi.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(produto.ProdutoIpi.ToString()));
                    txtSubsTributaria.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(produto.ProdutoSubsTributaria.ToString()));
                    txtPrecoCompra.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(produto.ProdutoPrecoCompra.ToString()));
                    txtPercVenda.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(produto.ProdutoPctVenda.ToString()));
                    txtPrecoSugerido.Text = Validacao.MascaraDecimal(Validacao.RetiraMascara(produto.ProdutoPrecoSugerido.ToString()));
                    txtMoeda.Text = produto.ProdutoMoeda;
                    chkEstoque.IsChecked = produto.ProdutoEstoque;
                    txtQtdEstoque.Text = produto.ProdutoQtdEstoque.ToString();
                    txtQtdMinEstoque.Text = produto.ProdutoQtdMinEstoque.ToString();
                    txtObservacao.Text = produto.ProdutoObservacao;
                    if (produto.ProdutoImagem != null)
                    {
                        MemoryStream strm = new MemoryStream();
                        strm.Write(produto.ProdutoImagem, 0, produto.ProdutoImagem.Length);
                        strm.Position = 0;
                        System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ms.Seek(0, SeekOrigin.Begin);
                        bi.StreamSource = ms;
                        bi.EndInit();
                        imgImagem.Source = bi;
                        dadosImagem = produto.ProdutoImagem;
                    }
                    tbiCadastro.IsSelected = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCarregarImagem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Title = "Selecione um Arquivo!";
            dlg.InitialDirectory = "";
            dlg.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png)";
            dlg.FilterIndex = 1;
            dlg.ShowDialog();

            try
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                dadosImagem = new byte[fs.Length];
                fs.Read(dadosImagem, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();

                ImageSourceConverter imgs = new ImageSourceConverter();
                imgImagem.SetValue(Image.SourceProperty, imgs.ConvertFromString(dlg.FileName.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Produto");
            }
        }
                
    }
}
