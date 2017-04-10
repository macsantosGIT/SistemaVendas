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
    /// Interaction logic for UsrProduto.xaml
    /// </summary>
    public partial class UsrProduto : UserControl
    {
        private Models.Produto produto = new Models.Produto();
        public List<Models.Produto> produtos = new List<Models.Produto>();
        private BLL.ProdutoBLL bllProduto = new BLL.ProdutoBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        ICollectionView cvProdutos;
        
        public UsrProduto()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void dtgProdutos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                produto = dtgProdutos.CurrentCell.Item as Models.Produto;

                if (produto != null)
                {
                    Orcamentos.proRetPesquisa = produto;
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

            if (cvProdutos != null)
            {
                cvProdutos.Filter = TextFilter;
            }
        }

    }
}
