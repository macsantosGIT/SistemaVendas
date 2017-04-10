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
    /// Interaction logic for UF.xaml
    /// </summary>
    public partial class UFs : System.Windows.Controls.Page
    {
        private Models.Uf uf = new Models.Uf();
        private BLL.UfBLL bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);
        private List<Models.Uf> ufs = new List<Models.Uf>();

        public UFs()
        {
            InitializeComponent();
            cancelar_Click(null, null);
            CarregarGrid();
            FocusInicio();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text != string.Empty || txtSigla.Text != string.Empty)
            {
                try
                {
                    uf.UfNome = txtNome.Text.ToUpper();
                    uf.UfSigla = txtSigla.Text.ToUpper();

                    bllUf.Incluir(uf);

                    MessageBox.Show("UF Inserido com Sucesso!", "UF");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão deste UF! " + ex.ToString(), "UF");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("O preenchimento de todos os campos, é obrigatório!", "UF");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                { 
                    uf.UfId = Int32.Parse(txtCodigo.Text);
                    uf.UfNome = txtNome.Text;
                    uf.UfSigla = txtSigla.Text;

                    bllUf.Excluir(uf);

                    MessageBox.Show("UF Excluido com sucesso!","UF");
                    CarregarGrid();
                    cancelar_Click(null, null);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar exluir este UF! " + ex.ToString(), "UF");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "UF");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    uf.UfId = Int32.Parse(txtCodigo.Text);
                    uf.UfNome = txtNome.Text.ToUpper();
                    uf.UfSigla = txtSigla.Text.ToUpper();

                    bllUf.Atualizar(uf);

                    MessageBox.Show("Dados de UF Alterado com Sucesso!", "UF");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar alterar os dados deste UF! " + ex.ToString(), "UF");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "UF");
                FocusInicio();
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSigla.Text = string.Empty;
            FocusInicio();
        }

        private void CarregarGrid()
        {
            ufs = bllUf.getUfs();

            if (ufs.Count >= 1)
            {
                dtgUFs.ItemsSource = ufs;               
            }
            else
            {
                dtgUFs.ItemsSource = null;
            }
        }

        private void FocusInicio()
        {
            txtNome.Focus();
        }

        private void dtgUFs_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                uf = dtgUFs.CurrentCell.Item as Models.Uf;

                if (uf != null)
                {
                    txtCodigo.Text = uf.UfId.ToString();
                    txtNome.Text = uf.UfNome;
                    txtSigla.Text = uf.UfSigla;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
