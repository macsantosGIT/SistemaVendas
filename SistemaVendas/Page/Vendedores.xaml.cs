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
using Util;

namespace SistemaVendas.Page
{
    /// <summary>
    /// Interaction logic for Vendedores.xaml
    /// </summary>
    public partial class Vendedores : System.Windows.Controls.Page
    {
        private Models.Vendedor vendedor = new Models.Vendedor();
        private List<Models.Vendedor> vendedores = new List<Models.Vendedor>();
        private BLL.VendedorBLL bllVendedor = new BLL.VendedorBLL(DAL.SistemaVendasContexto.Instancia);

        public Vendedores()
        {
            InitializeComponent();
            CarregarGrid();
            FocusInicio();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text != string.Empty)
            {
                try
                {
                    vendedor.VendedorNome = txtNome.Text.ToUpper();
                    vendedor.VendedorDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    vendedor.VendedorTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text)));
                    vendedor.VendedorDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    vendedor.VendedorCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text)));
                    vendedor.VendedorEmail = txtEmail.Text;

                    bllVendedor.Incluir(vendedor);

                    MessageBox.Show("Vendedor Inserido com Sucesso!", "Vendedor");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão deste Vendedor! " + ex.ToString(), "Vendedor");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("O preenchimento do nome do vendedor, é obrigatório!", "Vendedor");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    vendedor.VendedorId = Int32.Parse(txtCodigo.Text);
                    vendedor.VendedorNome = txtNome.Text.ToUpper();
                    vendedor.VendedorDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    vendedor.VendedorTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text)));
                    vendedor.VendedorDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    vendedor.VendedorCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text)));
                    vendedor.VendedorEmail = txtEmail.Text;

                    bllVendedor.Excluir(vendedor);

                    MessageBox.Show("Vendedor Excluido com sucesso!", "Vendedor");
                    CarregarGrid();
                    cancelar_Click(null, null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar exluir este Vendedor! " + ex.ToString(), "Vendedor");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Vendedor");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    vendedor.VendedorId = Int32.Parse(txtCodigo.Text);
                    vendedor.VendedorNome = txtNome.Text.ToUpper();
                    vendedor.VendedorDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    vendedor.VendedorTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text)));
                    vendedor.VendedorDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    vendedor.VendedorCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text)));
                    vendedor.VendedorEmail = txtEmail.Text;

                    bllVendedor.Atualizar(vendedor);

                    MessageBox.Show("Dados do Vendedor Alterado com sucesso!", "Vendedor");
                    CarregarGrid();
                    cancelar_Click(null, null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar alterar este Vendedor! " + ex.ToString(), "Vendedor");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Vendedor");
                FocusInicio();
            }

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDDDTelefone.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtDDDCelular.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            FocusInicio();
        }

        private void CarregarGrid()
        {
            vendedores = bllVendedor.getVendedores();
            if (vendedores.Count >= 1)
            {
                dtgVendedores.ItemsSource = vendedores;
            }
            else
            {
                dtgVendedores.ItemsSource = null;
            }
        }

        private void FocusInicio()
        {
            txtNome.Focus();
        }

        private void dtgVendedores_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                vendedor = dtgVendedores.CurrentCell.Item as Models.Vendedor;

                if (vendedor != null)
                {
                    txtCodigo.Text = vendedor.VendedorId.ToString();
                    txtNome.Text = vendedor.VendedorNome;
                    txtDDDTelefone.Text = vendedor.VendedorDddTel.ToString();
                    txtTelefone.Text = Validacao.MascaraTelefone(vendedor.VendedorTel.ToString());
                    txtDDDCelular.Text = vendedor.VendedorDddCel.ToString();
                    txtCelular.Text = Validacao.MascaraCelular(vendedor.VendedorCel.ToString());
                    txtEmail.Text = vendedor.VendedorEmail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTelefone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTelefone.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtTelefone.Text)
                    && txtTelefone.Text.Length >= 8
                    )
                {
                    txtTelefone.Text = Validacao.MascaraTelefone(txtTelefone.Text);
                }
                else
                {
                    MessageBox.Show("Telefone ínvalido!", "Vendedor");
                    txtTelefone.Focus();
                    txtTelefone.Text = string.Empty;
                }
            }
        }

        private void txtDDDTelefone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDTelefone.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDTelefone.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Vendedor");
                    txtDDDTelefone.Focus();
                    txtDDDTelefone.Text = string.Empty;
                }
            }
        }

        private void txtDDDCelular_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDCelular.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDCelular.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Vendedor");
                    txtDDDCelular.Focus();
                    txtDDDCelular.Text = string.Empty;
                }
            }
        }

        private void txtCelular_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCelular.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtCelular.Text)
                    && txtCelular.Text.Length >= 9
                    )
                {
                    txtCelular.Text = Validacao.MascaraCelular(txtCelular.Text);
                }
                else
                {
                    MessageBox.Show("Celular ínvalido!", "Vendedor");
                    txtCelular.Focus();
                    txtCelular.Text = string.Empty;
                }
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                if (!Validacao.ValidaEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email ínvalido!", "Vendedor");
                    txtEmail.Focus();
                }
            }
        }

    }
}
