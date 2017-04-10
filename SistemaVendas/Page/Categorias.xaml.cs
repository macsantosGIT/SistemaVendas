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
    /// Interaction logic for Categoria.xaml
    /// </summary>
    public partial class Categorias : System.Windows.Controls.Page
    {
        private Models.Categoria categoria = new Models.Categoria();
        private BLL.CategoriaBLL bllCategoria = new BLL.CategoriaBLL(DAL.SistemaVendasContexto.Instancia);
        private List<Models.Categoria> categorias = new List<Models.Categoria>();

        public Categorias()
        {
            InitializeComponent();
            cancelar_Click(null, null);
            CarregarGrid();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCategoria.Text != string.Empty)
            {
                try
                {
                    categoria.CategoriaNome = txtCategoria.Text.ToUpper();

                    bllCategoria.Incluir(categoria);

                    MessageBox.Show("Categoria Inserida com Sucesso!", "Categoria");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão desta Categoria! " + ex.ToString(), "Categoria");
                }
            }
            else
            {
                MessageBox.Show("O preenchimento de todos os campos, é obrigatório!", "Categoria");
                txtCategoria.Focus();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    categoria.CategoriaId = Int32.Parse(txtCodigo.Text);
                    categoria.CategoriaNome = txtCategoria.Text;

                    bllCategoria.Excluir(categoria);

                    MessageBox.Show("Categoria Exclida com Sucesso!", "Categoria");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar excluir esta Categoria! " + ex.ToString(), "Categoria");
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Categoria");
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    categoria.CategoriaId = Int32.Parse(txtCodigo.Text);
                    categoria.CategoriaNome = txtCategoria.Text.ToUpper();

                    bllCategoria.Atualizar(categoria);

                    MessageBox.Show("Dados de Categoria Alterado com Sucesso!", "Categoria");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar alterar os dados desta Categoria! " + ex.ToString(), "Categoria");
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Categoria");
            }
        }
        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtCategoria.Focus();
        }

        private void CarregarGrid()
        {
            categorias = bllCategoria.getCategorias();

            if (categorias.Count >= 1)
            {
                dtgCategorias.ItemsSource = categorias;
            }
            else
            {
                dtgCategorias.ItemsSource = null;
            }
        }

        private void dtgCategorias_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                categoria = dtgCategorias.CurrentCell.Item as Models.Categoria;

                if(categoria != null)
                {
                    txtCodigo.Text = categoria.CategoriaId.ToString();
                    txtCategoria.Text = categoria.CategoriaNome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
