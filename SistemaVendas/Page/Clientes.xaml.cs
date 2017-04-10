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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Clientes : System.Windows.Controls.Page
    {
        private int tipoPessoa;
        private Models.Cliente cliente = new Models.Cliente();
        private List<Models.Cliente> clientes = new List<Models.Cliente>();
        private Models.Uf ufModel = new Models.Uf();
        private List<Models.Uf> ufs = new List<Models.Uf>();
        private List<Models.Cidade> cidades = new List<Models.Cidade>();
        private BLL.ClienteBLL bllCliente = new BLL.ClienteBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.UfBLL bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.CidadeBLL bllCidade = new BLL.CidadeBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        ICollectionView cvClientes;

        public Clientes()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarUf();
            CarregarCidade(ufModel);
            FocusInicio();
            tbcCliente.TabIndex = 0;
        }
        
        private void rdoTipoPessoa_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            if (button.Name.ToString() == "rdoJuridica")
            {
                tipoPessoa = 1;
            }
            else 
            {
                tipoPessoa = 2;
            }
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtRazaoSocial.Text != string.Empty || txtNomeFantasia.Text != string.Empty
                || txtCnpjCpf.Text != string.Empty || txtEndereco.Text != string.Empty)
            {
                try
                {
                    cliente.ClienteTipoPessoa = tipoPessoa;
                    cliente.ClienteNome = txtRazaoSocial.Text;
                    cliente.ClienteNomeFantasia = txtNomeFantasia.Text;
                    cliente.ClienteCnpjCpf = txtCnpjCpf.Text;
                    cliente.ClienteIeRg = txtIeRG.Text;
                    cliente.ClienteDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    cliente.ClienteTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    cliente.ClienteDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    cliente.ClienteCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    cliente.ClienteEmail = txtEmail.Text;
                    cliente.ClienteEndereco = txtEndereco.Text;
                    cliente.ClienteEnderecoComp = txtComplemento.Text;
                    cliente.ClienteBairro = txtBairro.Text;
                    cliente.ClienteCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    cliente.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    cliente.ClienteSite = txtSite.Text;
                    cliente.ClienteObservacao = txtObservacao.Text;
                    cliente.ClienteContatoNome1 = txtNomeCont1.Text;
                    cliente.ClienteContatoCargo1 = txtCargoCont1.Text;
                    cliente.ClienteContatoEmail1 = txtEmailCont1.Text;
                    cliente.ClienteContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    cliente.ClienteContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    cliente.ClienteContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    cliente.ClienteContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    cliente.ClienteContatoNome2 = txtNomeCont2.Text;
                    cliente.ClienteContatoCargo2 = txtCargoCont2.Text;
                    cliente.ClienteContatoEmail2 = txtEmailCont2.Text;
                    cliente.ClienteContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    cliente.ClienteContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    cliente.ClienteContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    cliente.ClienteContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllCliente.Incluir(cliente);

                    MessageBox.Show("Cliente Inserido com Sucesso!", "Cliente");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão deste Cliente! " + ex.ToString(), "Cliente");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios: Razão Social, Nome Fantasia, CNPJ/CPF e Endereço!","Cliente");
                FocusInicio();
            }
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    cliente.ClienteTipoPessoa = tipoPessoa;
                    cliente.ClienteNome = txtRazaoSocial.Text;
                    cliente.ClienteNomeFantasia = txtNomeFantasia.Text;
                    cliente.ClienteCnpjCpf = txtCnpjCpf.Text;
                    cliente.ClienteIeRg = txtIeRG.Text;
                    cliente.ClienteDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    cliente.ClienteTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); 
                    cliente.ClienteDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    cliente.ClienteCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); 
                    cliente.ClienteEmail = txtEmail.Text;
                    cliente.ClienteEndereco = txtEndereco.Text;
                    cliente.ClienteEnderecoComp = txtComplemento.Text;
                    cliente.ClienteBairro = txtBairro.Text;
                    cliente.ClienteCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    cliente.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    cliente.ClienteSite = txtSite.Text;
                    cliente.ClienteObservacao = txtObservacao.Text;
                    cliente.ClienteContatoNome1 = txtNomeCont1.Text;
                    cliente.ClienteContatoCargo1 = txtCargoCont1.Text;
                    cliente.ClienteContatoEmail1 = txtEmailCont1.Text;
                    cliente.ClienteContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    cliente.ClienteContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    cliente.ClienteContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    cliente.ClienteContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    cliente.ClienteContatoNome2 = txtNomeCont2.Text;
                    cliente.ClienteContatoCargo2 = txtCargoCont2.Text;
                    cliente.ClienteContatoEmail2 = txtEmailCont2.Text;
                    cliente.ClienteContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    cliente.ClienteContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    cliente.ClienteContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    cliente.ClienteContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllCliente.Excluir(cliente);

                    MessageBox.Show("Cliente Excluido com Sucesso!", "Cliente");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar excluir este Cliente! " + ex.ToString(), "Cliente");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Cliente");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    cliente.ClienteTipoPessoa = tipoPessoa;
                    cliente.ClienteNome = txtRazaoSocial.Text;
                    cliente.ClienteNomeFantasia = txtNomeFantasia.Text;
                    cliente.ClienteCnpjCpf = txtCnpjCpf.Text;
                    cliente.ClienteIeRg = txtIeRG.Text;
                    cliente.ClienteDddTel = Int32.Parse(txtDDDTelefone.Text);
                    cliente.ClienteTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    cliente.ClienteDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    cliente.ClienteCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    cliente.ClienteEmail = txtEmail.Text;
                    cliente.ClienteEndereco = txtEndereco.Text;
                    cliente.ClienteEnderecoComp = txtComplemento.Text;
                    cliente.ClienteBairro = txtBairro.Text;
                    cliente.ClienteCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    cliente.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    cliente.ClienteSite = txtSite.Text;
                    cliente.ClienteObservacao = txtObservacao.Text;
                    cliente.ClienteContatoNome1 = txtNomeCont1.Text;
                    cliente.ClienteContatoCargo1 = txtCargoCont1.Text;
                    cliente.ClienteContatoEmail1 = txtEmailCont1.Text;
                    cliente.ClienteContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    cliente.ClienteContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    cliente.ClienteContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    cliente.ClienteContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    cliente.ClienteContatoNome2 = txtNomeCont2.Text;
                    cliente.ClienteContatoCargo2 = txtCargoCont2.Text;
                    cliente.ClienteContatoEmail2 = txtEmailCont2.Text;
                    cliente.ClienteContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    cliente.ClienteContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    cliente.ClienteContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    cliente.ClienteContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllCliente.Atualizar(cliente);

                    MessageBox.Show("Cliente Alterado com Sucesso!", "Cliente");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar Alterar este Cliente! " + ex.ToString(), "Cliente");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Cliente");
                FocusInicio();
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            rdoFisica.IsChecked = false;
            rdoJuridica.IsChecked = false;
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
            txtNomeCont1.Text = string.Empty;
            txtCargoCont1.Text = string.Empty;
            txtEmailCont1.Text = string.Empty;
            txtDDDTelefoneCont1.Text = string.Empty;
            txtTelefoneCont1.Text = string.Empty;
            txtDDDCelularCont1.Text = string.Empty;
            txtCelularCont1.Text = string.Empty;

            txtNomeCont2.Text = string.Empty;
            txtCargoCont2.Text = string.Empty;
            txtEmailCont2.Text = string.Empty;
            txtDDDTelefoneCont2.Text = string.Empty;
            txtTelefoneCont2.Text = string.Empty;
            txtDDDCelularCont2.Text = string.Empty;
            txtCelularCont2.Text = string.Empty;
        }

        private void FocusInicio()
        {
            txtRazaoSocial.Focus();
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

        private void dtgClientes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                cliente = dtgClientes.CurrentCell.Item as Models.Cliente;

                if (cliente != null)
                {
                    txtCodigo.Text = cliente.ClienteId.ToString();

                    if (cliente.ClienteTipoPessoa == 1)
                    {
                        rdoJuridica.IsChecked = true;
                    }
                    else if (cliente.ClienteTipoPessoa == 2)
                    {
                        rdoFisica.IsChecked = true;
                    }
                    txtRazaoSocial.Text = cliente.ClienteNome;
                    txtNomeFantasia.Text = cliente.ClienteNomeFantasia;
                    txtCnpjCpf.Text = cliente.ClienteCnpjCpf;
                    txtIeRG.Text = cliente.ClienteIeRg;
                    txtDDDTelefone.Text = cliente.ClienteDddTel.ToString();
                    txtTelefone.Text = Validacao.MascaraTelefone(cliente.ClienteTel.ToString());
                    txtDDDCelular.Text = cliente.ClienteDddCel.ToString();
                    txtCelular.Text = Validacao.MascaraCelular(cliente.ClienteCel.ToString());
                    txtEmail.Text = cliente.ClienteEmail;
                    txtEndereco.Text = cliente.ClienteEndereco;
                    txtComplemento.Text = cliente.ClienteEnderecoComp;
                    txtBairro.Text = cliente.ClienteBairro;
                    txtCEP.Text = Validacao.MascaraCep(cliente.ClienteCep.ToString());
                    //Estado / Cidade
                    cmbEstado.SelectedValue = cliente.Cidade.Uf.UfId;
                    cmbCidade.SelectedValue = cliente.Cidade.CidadeId;
                    txtSite.Text = cliente.ClienteSite;
                    txtObservacao.Text = cliente.ClienteObservacao;
                    //Contatos 1
                    txtNomeCont1.Text = cliente.ClienteContatoNome1;
                    txtCargoCont1.Text = cliente.ClienteContatoCargo1;
                    txtEmailCont1.Text = cliente.ClienteContatoEmail1;
                    txtDDDTelefoneCont1.Text = cliente.ClienteContatoDddTel1.ToString();
                    txtTelefoneCont1.Text = Validacao.MascaraTelefone(cliente.ClienteContatoTel1.ToString());
                    txtDDDCelularCont1.Text = cliente.ClienteContatoDddCel1.ToString();
                    txtCelularCont1.Text = Validacao.MascaraCelular(cliente.ClienteContatoCel1.ToString());
                    //Contatos 2
                    txtNomeCont2.Text = cliente.ClienteContatoNome2;
                    txtCargoCont2.Text = cliente.ClienteContatoCargo2;
                    txtEmailCont2.Text = cliente.ClienteContatoEmail2;
                    txtDDDTelefoneCont2.Text = cliente.ClienteContatoDddTel2.ToString();
                    txtTelefoneCont2.Text = Validacao.MascaraTelefone(cliente.ClienteContatoTel2.ToString());
                    txtDDDCelularCont2.Text = cliente.ClienteContatoDddCel2.ToString();
                    txtCelularCont2.Text = Validacao.MascaraCelular(cliente.ClienteContatoCel2.ToString());

                    tbiCadastro.IsSelected = true;
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
                        if (Validacao.IsCpf(txtCnpjCpf.Text))
                        {
                            txtCnpjCpf.Text = Validacao.MascaraCnpjCpf(txtCnpjCpf.Text);
                        }
                        else
                        {
                            MessageBox.Show("CNPJ/CPF Inválido!", "Cliente");
                            txtCnpjCpf.Text = string.Empty;
                            txtCnpjCpf.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CNPJ/CPF apenas com numeros!", "Cliente");
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
                    MessageBox.Show("DDD ínvalido!", "Cliente");
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
                    MessageBox.Show("Telefone ínvalido!", "Cliente");
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
                    MessageBox.Show("DDD ínvalido!", "Cliente");
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
                    MessageBox.Show("Celular ínvalido!", "Cliente");
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
                    MessageBox.Show("Email ínvalido!", "Cliente");
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
                    MessageBox.Show("CEP ínvalido!", "Cliente");
                    txtCEP.Text = string.Empty;
                    txtCEP.Focus();
                }
            }
        }

        private void txtEmailCont1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmailCont1.Text != string.Empty)
            {
                if (!Validacao.ValidaEmail(txtEmailCont1.Text))
                {
                    MessageBox.Show("Email ínvalido!", "Cliente");
                    txtEmailCont1.Text = string.Empty;
                    txtEmailCont1.Focus();
                }
            }
        }

        private void txtDDDTelefoneCont1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDTelefoneCont1.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDTelefoneCont1.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Cliente");
                    txtDDDTelefoneCont1.Text = string.Empty;
                    txtDDDTelefoneCont1.Focus();
                }
            }
        }

        private void txtTelefoneCont1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTelefoneCont1.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtTelefoneCont1.Text)
                    && txtTelefoneCont1.Text.Length >= 8
                    )
                {
                    txtTelefoneCont1.Text = Validacao.MascaraTelefone(txtTelefoneCont1.Text);
                }
                else
                {
                    MessageBox.Show("Telefone ínvalido!", "Cliente");
                    txtTelefoneCont1.Text = string.Empty;
                    txtTelefoneCont1.Focus();
                }
            }
        }

        private void txtDDDCelularCont1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDCelularCont1.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDCelularCont1.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Cliente");
                    txtDDDCelularCont1.Text = string.Empty;
                    txtDDDCelularCont1.Focus();
                }
            }
        }

        private void txtCelularCont1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCelularCont1.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtCelularCont1.Text)
                    && txtCelularCont1.Text.Length >= 9
                    )
                {
                    txtCelularCont1.Text = Validacao.MascaraCelular(txtCelularCont1.Text);
                }
                else
                {
                    MessageBox.Show("Celular ínvalido!", "Cliente");
                    txtCelularCont1.Text = string.Empty;
                    txtCelularCont1.Focus();
                }
            }

        }

        private void txtEmailCont2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmailCont2.Text != string.Empty)
            {
                if (!Validacao.ValidaEmail(txtEmailCont2.Text))
                {
                    MessageBox.Show("Email ínvalido!", "Cliente");
                    txtEmailCont2.Text = string.Empty;
                    txtEmailCont2.Focus();
                }
            }
        }

        private void txtDDDTelefoneCont2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDTelefoneCont2.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDTelefoneCont2.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Cliente");
                    txtDDDTelefoneCont2.Text = string.Empty;
                    txtDDDTelefoneCont2.Focus();
                }
            }
        }

        private void txtTelefoneCont2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTelefoneCont2.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtTelefoneCont2.Text)
                    && txtTelefoneCont2.Text.Length >= 8
                    )
                {
                    txtTelefoneCont2.Text = Validacao.MascaraTelefone(txtTelefoneCont2.Text);
                }
                else
                {
                    MessageBox.Show("Telefone ínvalido!", "Cliente");
                    txtTelefoneCont2.Text = string.Empty;
                    txtTelefoneCont2.Focus();
                }
            }
        }

        private void txtDDDCelularCont2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDDDCelularCont2.Text != string.Empty)
            {
                if (!Validacao.ValidaNumero(txtDDDCelularCont2.Text))
                {
                    MessageBox.Show("DDD ínvalido!", "Cliente");
                    txtDDDCelularCont2.Text = string.Empty;
                    txtDDDCelularCont2.Focus();
                }
            }
        }

        private void txtCelularCont2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCelularCont2.Text != string.Empty)
            {
                if (Validacao.ValidaNumero(txtCelularCont2.Text)
                    && txtCelularCont2.Text.Length >= 9
                    )
                {
                    txtCelularCont2.Text = Validacao.MascaraCelular(txtCelularCont2.Text);
                }
                else
                {
                    MessageBox.Show("Celular ínvalido!", "Cliente");
                    txtCelularCont2.Text = string.Empty;
                    txtCelularCont2.Focus();
                }
            }
        }


    }
}
