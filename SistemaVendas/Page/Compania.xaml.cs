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
    /// Interaction logic for Compania.xaml
    /// </summary>
    public partial class Compania : System.Windows.Controls.Page
    {
        //private int tipoPessoa;
        private Models.Empresa empresa = new Models.Empresa();
        private List<Models.Empresa> empresas = new List<Models.Empresa>();
        private Models.Uf ufModel = new Models.Uf();
        private List<Models.Uf> ufs = new List<Models.Uf>();
        private List<Models.Cidade> cidades = new List<Models.Cidade>();
        private BLL.EmpresaBLL bllEmpresa = new BLL.EmpresaBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.UfBLL bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.CidadeBLL bllCidade = new BLL.CidadeBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        ICollectionView cvEmpresas;

        public Compania()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarUf();
            CarregarCidade(ufModel);
            FocusInicio();
            tbiCadastro.TabIndex = 0;
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtRazaoSocial.Text != string.Empty || txtNomeFantasia.Text != string.Empty
                || txtCnpjCpf.Text != string.Empty || txtEndereco.Text != string.Empty)
            {
                try
                {
                    empresa.EmpresaNome = txtRazaoSocial.Text;
                    empresa.EmpresaNomeFantasia = txtNomeFantasia.Text;
                    empresa.EmpresaCnpj = txtCnpjCpf.Text;
                    empresa.EmpresaIe = txtIeRG.Text;
                    empresa.EmpresaDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    empresa.EmpresaTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    empresa.EmpresaDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    empresa.EmpresaCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    empresa.EmpresaEmail = txtEmail.Text;
                    empresa.EmpresaEndereco = txtEndereco.Text;
                    empresa.EmpresaEnderecoComp = txtComplemento.Text;
                    empresa.EmpresaBairro = txtBairro.Text;
                    empresa.EmpresaCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    empresa.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    empresa.EmpresaSite = txtSite.Text;
                    empresa.EmpresaObservacao = txtObservacao.Text;

                    bllEmpresa.Incluir(empresa);

                    MessageBox.Show("Empresa Inserida com Sucesso!", "Compania");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão desta Empresa! " + ex.ToString(), "Compania");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios: Razão Social, Nome Fantasia, CNPJ/CPF e Endereço");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    empresa.EmpresaNome = txtRazaoSocial.Text;
                    empresa.EmpresaNomeFantasia = txtNomeFantasia.Text;
                    empresa.EmpresaCnpj = txtCnpjCpf.Text;
                    empresa.EmpresaIe = txtIeRG.Text;
                    empresa.EmpresaDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    empresa.EmpresaTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    empresa.EmpresaDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    empresa.EmpresaCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    empresa.EmpresaEmail = txtEmail.Text;
                    empresa.EmpresaEndereco = txtEndereco.Text;
                    empresa.EmpresaEnderecoComp = txtComplemento.Text;
                    empresa.EmpresaBairro = txtBairro.Text;
                    empresa.EmpresaCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    empresa.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    empresa.EmpresaSite = txtSite.Text;
                    empresa.EmpresaObservacao = txtObservacao.Text;

                    bllEmpresa.Excluir(empresa);

                    MessageBox.Show("Empresa Excluido com Sucesso!", "Compania");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar excluir esta Empresa! " + ex.ToString(), "Compania");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Compania");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    empresa.EmpresaNome = txtRazaoSocial.Text;
                    empresa.EmpresaNomeFantasia = txtNomeFantasia.Text;
                    empresa.EmpresaCnpj = txtCnpjCpf.Text;
                    empresa.EmpresaIe = txtIeRG.Text;
                    empresa.EmpresaDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    empresa.EmpresaTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    empresa.EmpresaDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    empresa.EmpresaCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    empresa.EmpresaEmail = txtEmail.Text;
                    empresa.EmpresaEndereco = txtEndereco.Text;
                    empresa.EmpresaEnderecoComp = txtComplemento.Text;
                    empresa.EmpresaBairro = txtBairro.Text;
                    empresa.EmpresaCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    empresa.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    empresa.EmpresaSite = txtSite.Text;
                    empresa.EmpresaObservacao = txtObservacao.Text;

                    bllEmpresa.Atualizar(empresa);

                    MessageBox.Show("Empresa Alterada com Sucesso!", "Compania");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar Alterar esta Empresa! " + ex.ToString(), "Compania");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Compania");
                FocusInicio();
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtRazaoSocial.Text = string.Empty;
            txtNomeFantasia.Text = string.Empty;
            txtCnpjCpf.Text = string.Empty;
            txtIeRG.Text = string.Empty;
            txtDDDTelefone.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtDDDCelular.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCEP.Text = string.Empty;
            CarregarUf();
            CarregarCidade(ufModel);
            txtSite.Text = string.Empty;
            txtObservacao.Text = string.Empty;
        }

        private void FocusInicio()
        {
            txtRazaoSocial.Focus();
        }

        private void CarregarGrid()
        {
            empresas = bllEmpresa.getEmpresas();

            cvEmpresas = CollectionViewSource.GetDefaultView(empresas);
            
            if (empresas.Count >= 1)
            {
                dtgEmpresas.ItemsSource = cvEmpresas;
            }
            else
            {
                dtgEmpresas.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Empresa p = (o as Models.Empresa);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtRazaoSocialPesq")
            {
                if (p.EmpresaNome.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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
                if (p.EmpresaNomeFantasia.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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

            if (cvEmpresas != null)
            {
                cvEmpresas.Filter = TextFilter;
            }
        }

        private void CarregarUf()
        {
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

        private void CarregarCidade(Models.Uf estado)
        {
            cidades = bllCidade.getCidades();

            if (estado.UfId > 0)
            {
                cidades = cidades.Where(x => x.Uf.UfId == estado.UfId).ToList();
            }

            if (cidades.Count >= 1)
            {
                cmbCidade.ItemsSource = cidades;
            }
            else
            {
                cmbCidade.ItemsSource = null;
            }
        }

        private void cmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cidades.Count >= 1)
            {
                ufModel = cmbEstado.SelectedItem as Models.Uf;
                CarregarCidade(ufModel);
            }
        }

        private void dtgEmpresas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                empresa = dtgEmpresas.CurrentCell.Item as Models.Empresa;

                if (empresas != null)
                {
                    txtCodigo.Text = empresa.EmpresaId.ToString();
                    txtRazaoSocial.Text = empresa.EmpresaNome;
                    txtNomeFantasia.Text = empresa.EmpresaNomeFantasia;
                    txtCnpjCpf.Text = empresa.EmpresaCnpj;
                    txtIeRG.Text = empresa.EmpresaIe;
                    txtDDDTelefone.Text = empresa.EmpresaDddTel.ToString();
                    txtTelefone.Text = Validacao.MascaraTelefone(empresa.EmpresaTel.ToString());
                    txtDDDCelular.Text = empresa.EmpresaDddCel.ToString();
                    txtCelular.Text = Validacao.MascaraCelular(empresa.EmpresaCel.ToString());
                    txtEmail.Text = empresa.EmpresaEmail;
                    txtEndereco.Text = empresa.EmpresaEndereco;
                    txtComplemento.Text = empresa.EmpresaEnderecoComp;
                    txtBairro.Text = empresa.EmpresaBairro;
                    txtCEP.Text = Validacao.MascaraCep(empresa.EmpresaCep.ToString());
                    //Estado / Cidade
                    cmbEstado.SelectedValue = empresa.Cidade.Uf.UfId;
                    cmbCidade.SelectedValue = empresa.Cidade.CidadeId;
                    txtSite.Text = empresa.EmpresaSite;
                    txtObservacao.Text = empresa.EmpresaObservacao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCnpjCpf_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCnpjCpf.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtCnpjCpf.Text))
                {
                    if (Validacao.IsCnpj(txtCnpjCpf.Text))
                    {
                        txtCnpjCpf.Text = Validacao.MascaraCnpjCpf(txtCnpjCpf.Text);
                    }
                    else
                    {
                        MessageBox.Show("CNPJ Inválido!", "Compania");
                        txtCnpjCpf.Text = string.Empty;
                        txtCnpjCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CNPJ apenas com numeros!", "Compania");
                    txtCnpjCpf.Text = string.Empty;
                    txtCnpjCpf.Focus();
                }
            }
        }

        private void txtDDDTelefone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDTelefone.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDTelefone.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Compania");
                    txtDDDTelefone.Text = string.Empty;
                    txtDDDTelefone.Focus();
                }
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
                    MessageBox.Show("Telefone ínvalido!", "Compania");
                    txtTelefone.Text = string.Empty;
                    txtTelefone.Focus();
                }
            }
        }

        private void txtDDDCelular_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDCelular.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDCelular.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Compania");
                    txtDDDCelular.Text = string.Empty;
                    txtDDDCelular.Focus();
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
                    MessageBox.Show("Celular ínvalido!", "Compania");
                    txtCelular.Text = string.Empty;
                    txtCelular.Focus();
                }
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                if (!Validacao.ValidaEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email ínvalido!", "Compania");
                    txtEmail.Text = string.Empty;
                    txtEmail.Focus();
                }
            }
        }

        private void txtCEP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCEP.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtCEP.Text) && txtCEP.Text.Length == 8)
                {
                    txtCEP.Text = Validacao.MascaraCep(txtCEP.Text);
                }
                else
                {
                    MessageBox.Show("CEP ínvalido!", "Compania");
                    txtCEP.Text = string.Empty;
                    txtCEP.Focus();
                }
            }
        }

    }
}
