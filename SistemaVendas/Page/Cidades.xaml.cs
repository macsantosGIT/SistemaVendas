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
    /// Interaction logic for Cidade.xaml
    /// </summary>
    public partial class Cidades : System.Windows.Controls.Page
    {
        private Models.Cidade cidade = new Models.Cidade();
        private Models.Uf uf = new Models.Uf();
        private BLL.CidadeBLL bllCidade = new BLL.CidadeBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.UfBLL bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);
        private List<Models.Cidade> cidades = new List<Models.Cidade>();
        private List<Models.Uf> ufs = new List<Models.Uf>();
        
        public Cidades()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarUf();
            FocusInicio();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text != string.Empty || cmbEstado.SelectedItem != null)
            {
                try
                {
                    cidade.CidadeNome = txtNome.Text.ToUpper();
                    cidade.Uf = cmbEstado.SelectedItem as Models.Uf;

                    bllCidade.Incluir(cidade);

                    MessageBox.Show("Cidade Inserida com Sucesso!", "Cidade");
                    CarregarGrid();
                    CarregarUf();
                    cancelar_Click(null, null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão desta Cidade! " + ex.ToString(), "Cidade");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("O preenchimento de todos os campos, é obrigatório!", "Cidade");
                FocusInicio();
            }
        }   

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text != string.Empty || cmbEstado.SelectedItem != null)
            {
                try
                {
                    cidade.CidadeId = Int32.Parse(txtCodigo.Text);
                    cidade.CidadeNome = txtNome.Text;
                    cidade.Uf = cmbEstado.SelectedItem as Models.Uf;

                    bllCidade.Excluir(cidade);

                    MessageBox.Show("Cidade Excluida com Sucesso!", "Cidade");
                    CarregarGrid();
                    CarregarUf();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na exclusão desta Cidade! " + ex.ToString(), "Cidade");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Cidade");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text != string.Empty || cmbEstado.SelectedItem != null)
            {
                try
                {
                    cidade.CidadeId = Int32.Parse(txtCodigo.Text);
                    cidade.CidadeNome = txtNome.Text.ToUpper();
                    cidade.Uf = cmbEstado.SelectedItem as Models.Uf;

                    bllCidade.Atualizar(cidade);

                    MessageBox.Show("Cidade Alterada com Sucesso!", "Cidade");
                    CarregarGrid();
                    CarregarUf();
                    cancelar_Click(null, null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Houve um erro na alteração desta Cidade! " + ex.ToString(), "Cidade");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Cidade");
                FocusInicio();
            }
        }

        private void CarregarUf()
        {
            ufs = new List<Models.Uf>();
            bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);

            ufs = bllUf.getUfs();

            if (ufs.Count >= 1)
            {
                cmbEstado.ItemsSource = ufs;
            }
            else
            {
                cmbEstado.ItemsSource = null;
            }
        }

        private void CarregarGrid()
        {
            cidades = bllCidade.getCidades();
            if (cidades.Count >= 1)
            {
                dtgCidades.ItemsSource = cidades;
            }
            else
            {
                dtgCidades.ItemsSource = null;
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            cmbEstado.ItemsSource = null;
            CarregarUf();
            FocusInicio();
        }

        private void FocusInicio()
        {
            txtNome.Focus();
        }

        private void dtgCidades_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                cidade = dtgCidades.CurrentCell.Item as Models.Cidade;

                if (cidade != null)
                {
                    txtCodigo.Text = cidade.CidadeId.ToString();
                    txtNome.Text = cidade.CidadeNome;
                    cmbEstado.SelectedItem = cidade.Uf;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
