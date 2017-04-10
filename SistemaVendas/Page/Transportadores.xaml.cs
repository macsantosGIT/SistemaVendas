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
    /// Interaction logic for Transportadores.xaml
    /// </summary>
    public partial class Transportadores : System.Windows.Controls.Page
    {
        private int tipoPessoa;
        private Models.Transportadora transportadora = new Models.Transportadora();
        private Models.Transportadora transportadoraArea = new Models.Transportadora();
        private List<Models.Transportadora> transportadoras = new List<Models.Transportadora>();
        private List<Models.Transportadora> transportadorasArea = new List<Models.Transportadora>();
        private Models.Uf ufModel = new Models.Uf();
        private List<Models.Uf> ufs = new List<Models.Uf>();
        private List<Models.Cidade> cidades = new List<Models.Cidade>();
        private Models.AreaTransportadora areaTransportadora = new Models.AreaTransportadora();
        private List<Models.AreaTransportadora> areasTransportadora = new List<Models.AreaTransportadora>();
        private BLL.TransportadoraBLL bllTransportadora = new BLL.TransportadoraBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.UfBLL bllUf = new BLL.UfBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.CidadeBLL bllCidade = new BLL.CidadeBLL(DAL.SistemaVendasContexto.Instancia);
        private BLL.AreaTransportadoraBLL bllArea = new BLL.AreaTransportadoraBLL(DAL.SistemaVendasContexto.Instancia);
        private TextBox tPesquisa;
        private TextBox tPesqTrans;
        private TextBox tPesqArea;
        ICollectionView cvTransportadoras;
        ICollectionView cvTransportadorasArea;
        ICollectionView cvAreaTransportadora;

        public Transportadores()
        {
            InitializeComponent();
            CarregarGrid();
            CarregarUf();
            CarregarCidade(ufModel);
            CarregarGridArea();
            CarregarGridTransArea();
            CarregarUfArea();
            FocusInicio();
            tbiCadastro.TabIndex = 0;
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
                    transportadora.TransportadoraTipoPessoa = tipoPessoa;
                    transportadora.TransportadoraNome = txtRazaoSocial.Text;
                    transportadora.TransportadoraNomeFantasia = txtNomeFantasia.Text;
                    transportadora.TransportadoraCnpjCpf = txtCnpjCpf.Text;
                    transportadora.TransportadoraIeRg = txtIeRG.Text;
                    transportadora.TransportadoraDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    transportadora.TransportadoraTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    transportadora.TransportadoraDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    transportadora.TransportadoraCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    transportadora.TransportadoraEmail = txtEmail.Text;
                    transportadora.TransportadoraEndereco = txtEndereco.Text;
                    transportadora.TransportadoraEnderecoComp = txtComplemento.Text;
                    transportadora.TransportadoraBairro = txtBairro.Text;
                    transportadora.TransportadoraCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    transportadora.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    transportadora.TransportadoraSite = txtSite.Text;
                    transportadora.TransportadoraObservacao = txtObservacao.Text;
                    transportadora.TransportadoraContatoNome1 = txtNomeCont1.Text;
                    transportadora.TransportadoraContatoCargo1 = txtCargoCont1.Text;
                    transportadora.TransportadoraContatoEmail1 = txtEmailCont1.Text;
                    transportadora.TransportadoraContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    transportadora.TransportadoraContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    transportadora.TransportadoraContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    transportadora.TransportadoraContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    transportadora.TransportadoraContatoNome2 = txtNomeCont2.Text;
                    transportadora.TransportadoraContatoCargo2 = txtCargoCont2.Text;
                    transportadora.TransportadoraContatoEmail2 = txtEmailCont2.Text;
                    transportadora.TransportadoraContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    transportadora.TransportadoraContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    transportadora.TransportadoraContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    transportadora.TransportadoraContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllTransportadora.Incluir(transportadora);

                    MessageBox.Show("Transportadora Inserido com Sucesso!", "Transportadora");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na inclusão desta Transportadora! " + ex.ToString(), "Transportadora");
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
                    transportadora.TransportadoraTipoPessoa = tipoPessoa;
                    transportadora.TransportadoraNome = txtRazaoSocial.Text;
                    transportadora.TransportadoraNomeFantasia = txtNomeFantasia.Text;
                    transportadora.TransportadoraCnpjCpf = txtCnpjCpf.Text;
                    transportadora.TransportadoraIeRg = txtIeRG.Text;
                    transportadora.TransportadoraDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    transportadora.TransportadoraTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    transportadora.TransportadoraDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    transportadora.TransportadoraCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    transportadora.TransportadoraEmail = txtEmail.Text;
                    transportadora.TransportadoraEndereco = txtEndereco.Text;
                    transportadora.TransportadoraEnderecoComp = txtComplemento.Text;
                    transportadora.TransportadoraBairro = txtBairro.Text;
                    transportadora.TransportadoraCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    transportadora.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    transportadora.TransportadoraSite = txtSite.Text;
                    transportadora.TransportadoraObservacao = txtObservacao.Text;
                    transportadora.TransportadoraContatoNome1 = txtNomeCont1.Text;
                    transportadora.TransportadoraContatoCargo1 = txtCargoCont1.Text;
                    transportadora.TransportadoraContatoEmail1 = txtEmailCont1.Text;
                    transportadora.TransportadoraContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    transportadora.TransportadoraContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    transportadora.TransportadoraContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    transportadora.TransportadoraContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    transportadora.TransportadoraContatoNome2 = txtNomeCont2.Text;
                    transportadora.TransportadoraContatoCargo2 = txtCargoCont2.Text;
                    transportadora.TransportadoraContatoEmail2 = txtEmailCont2.Text;
                    transportadora.TransportadoraContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    transportadora.TransportadoraContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    transportadora.TransportadoraContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    transportadora.TransportadoraContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllTransportadora.Excluir(transportadora);

                    MessageBox.Show("Transportadora Excluido com Sucesso!", "Transportadora");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar excluir esta Transportadora! " + ex.ToString(), "Transportadora");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Transportadora");
                FocusInicio();
            }
        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != string.Empty)
            {
                try
                {
                    transportadora.TransportadoraTipoPessoa = tipoPessoa;
                    transportadora.TransportadoraNome = txtRazaoSocial.Text;
                    transportadora.TransportadoraNomeFantasia = txtNomeFantasia.Text;
                    transportadora.TransportadoraCnpjCpf = txtCnpjCpf.Text;
                    transportadora.TransportadoraIeRg = txtIeRG.Text;
                    transportadora.TransportadoraDddTel = Int32.Parse(Validacao.StringEmpity(txtDDDTelefone.Text));
                    transportadora.TransportadoraTel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefone.Text))); //formatar
                    transportadora.TransportadoraDddCel = Int32.Parse(Validacao.StringEmpity(txtDDDCelular.Text));
                    transportadora.TransportadoraCel = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelular.Text))); //formatar
                    transportadora.TransportadoraEmail = txtEmail.Text;
                    transportadora.TransportadoraEndereco = txtEndereco.Text;
                    transportadora.TransportadoraEnderecoComp = txtComplemento.Text;
                    transportadora.TransportadoraBairro = txtBairro.Text;
                    transportadora.TransportadoraCep = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCEP.Text))); //formatar
                    transportadora.Cidade = cmbCidade.SelectedItem as Models.Cidade;
                    transportadora.TransportadoraSite = txtSite.Text;
                    transportadora.TransportadoraObservacao = txtObservacao.Text;
                    transportadora.TransportadoraContatoNome1 = txtNomeCont1.Text;
                    transportadora.TransportadoraContatoCargo1 = txtCargoCont1.Text;
                    transportadora.TransportadoraContatoEmail1 = txtEmailCont1.Text;
                    transportadora.TransportadoraContatoDddTel1 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont1.Text));
                    transportadora.TransportadoraContatoTel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont1.Text)));
                    transportadora.TransportadoraContatoDddCel1 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont1.Text));
                    transportadora.TransportadoraContatoCel1 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont1.Text)));
                    transportadora.TransportadoraContatoNome2 = txtNomeCont2.Text;
                    transportadora.TransportadoraContatoCargo2 = txtCargoCont2.Text;
                    transportadora.TransportadoraContatoEmail2 = txtEmailCont2.Text;
                    transportadora.TransportadoraContatoDddTel2 = Int32.Parse(Validacao.StringEmpity(txtDDDTelefoneCont2.Text));
                    transportadora.TransportadoraContatoTel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtTelefoneCont2.Text)));
                    transportadora.TransportadoraContatoDddCel2 = Int32.Parse(Validacao.StringEmpity(txtDDDCelularCont2.Text));
                    transportadora.TransportadoraContatoCel2 = Int32.Parse(Validacao.RetiraMascara(Validacao.StringEmpity(txtCelularCont2.Text)));

                    bllTransportadora.Atualizar(transportadora);

                    MessageBox.Show("Transportadora Alterada com Sucesso!", "Transportadora");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao tentar Alterar esta Transportadora! " + ex.ToString(), "Transportadora");
                    FocusInicio();
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Transportadora");
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
            transportadoras = bllTransportadora.getTransportadoras();

            cvTransportadoras = CollectionViewSource.GetDefaultView(transportadoras);

            if (transportadoras.Count >= 1)
            {
                dtgTransportadores.ItemsSource = cvTransportadoras;
            }
            else
            {
                dtgTransportadores.ItemsSource = null;
            }
        }

        private void CarregarGridTransArea()
        {
            transportadorasArea = bllTransportadora.getTransportadoras();

            cvTransportadorasArea = CollectionViewSource.GetDefaultView(transportadorasArea);

            if (transportadorasArea.Count >= 1)
            {
                dtgTransportadoresAreaPesq.ItemsSource = cvTransportadorasArea;
            }
            else
            {
                dtgTransportadoresAreaPesq.ItemsSource = null;
            }
        }

        private void CarregarGridArea()
        {
            areasTransportadora = bllArea.getAreas();

            cvAreaTransportadora = CollectionViewSource.GetDefaultView(areasTransportadora);

            if (areasTransportadora.Count >= 1)
            {
                dtgTransportadoresArea.ItemsSource = cvAreaTransportadora;
            }
            else
            {
                dtgTransportadoresArea.ItemsSource = null;
            }
        }

        public bool TextFilter(object o)
        {
            bool retorno = false;
            Models.Transportadora p = (o as Models.Transportadora);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesquisa.Name == "txtRazaoSocialPesq")
            {
                if (p.TransportadoraNome.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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
                if (p.TransportadoraNomeFantasia.ToUpper().Contains(tPesquisa.Text.ToUpper()))
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

        public bool TextFilterTrnasPesq(object o)
        {
            bool retorno = false;
            Models.Transportadora t = (o as Models.Transportadora);

            if (t == null)
            {
                retorno = false;
            }

            if (tPesqTrans.Name == "txtRazaoSocialAreaPesq")
            {
                if (t.TransportadoraNome.ToUpper().Contains(tPesqTrans.Text.ToUpper()))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else if (tPesqTrans.Name == "txtNomeFantasiaAreaPesq")
            {
                if (t.TransportadoraNomeFantasia.ToUpper().Contains(tPesqTrans.Text.ToUpper()))
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

        public bool TextFilterArea(object o)
        {
            bool retorno = false;
            Models.AreaTransportadora p = (o as Models.AreaTransportadora);

            if (p == null)
            {
                retorno = false;
            }

            if (tPesqArea.Name == "txtTransportadoraArea")
            {
                if (p.Transportadora.TransportadoraNome.ToUpper().Contains(tPesqArea.Text.ToUpper()))
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

            if (cvTransportadoras != null)
            {
                cvTransportadoras.Filter = TextFilter;
            }
        }

        private void txtPesqTrans_TextChanged(object sender, TextChangedEventArgs e)
        {
            tPesqTrans = (TextBox)sender;

            if (cvTransportadorasArea != null)
            {
                cvTransportadorasArea.Filter = TextFilterTrnasPesq;
            }
        }

        private void txtPesqArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            tPesqArea = (TextBox)sender;

            if (cvAreaTransportadora != null)
            {
                cvAreaTransportadora.Filter = TextFilterArea;
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

        private void CarregarUfArea()
        {
            ufs = bllUf.getUfs();
            if (ufs.Count >= 1)
            {
                cmbEstadoArea.ItemsSource = ufs;
            }
            else
            {
                cmbEstadoArea.ItemsSource = null;
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

        private void dtgTransportadores_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                transportadora = dtgTransportadores.CurrentCell.Item as Models.Transportadora;

                if (transportadora != null)
                {
                    txtCodigo.Text = transportadora.TransportadoraId.ToString();

                    if (transportadora.TransportadoraTipoPessoa == 1)
                    {
                        rdoJuridica.IsChecked = true;
                    }
                    else if (transportadora.TransportadoraTipoPessoa == 2)
                    {
                        rdoFisica.IsChecked = true;
                    }
                    txtRazaoSocial.Text = transportadora.TransportadoraNome;
                    txtNomeFantasia.Text = transportadora.TransportadoraNomeFantasia;
                    txtCnpjCpf.Text = transportadora.TransportadoraCnpjCpf;
                    txtIeRG.Text = transportadora.TransportadoraIeRg;
                    txtDDDTelefone.Text = transportadora.TransportadoraDddTel.ToString();
                    txtTelefone.Text = Validacao.MascaraTelefone(transportadora.TransportadoraTel.ToString());
                    txtDDDCelular.Text = transportadora.TransportadoraDddCel.ToString();
                    txtCelular.Text = Validacao.MascaraCelular(transportadora.TransportadoraCel.ToString());
                    txtEmail.Text = transportadora.TransportadoraEmail;
                    txtEndereco.Text = transportadora.TransportadoraEndereco;
                    txtComplemento.Text = transportadora.TransportadoraEnderecoComp;
                    txtBairro.Text = transportadora.TransportadoraBairro;
                    txtCEP.Text = Validacao.MascaraCep(transportadora.TransportadoraCep.ToString());
                    //Estado / Cidade
                    cmbEstado.SelectedValue = transportadora.Cidade.Uf.UfId;
                    cmbCidade.SelectedValue = transportadora.Cidade.CidadeId;
                    txtSite.Text = transportadora.TransportadoraSite;
                    txtObservacao.Text = transportadora.TransportadoraObservacao;
                    //Contatos 1
                    txtNomeCont1.Text = transportadora.TransportadoraContatoNome1;
                    txtCargoCont1.Text = transportadora.TransportadoraContatoCargo1;
                    txtEmailCont1.Text = transportadora.TransportadoraContatoEmail1;
                    txtDDDTelefoneCont1.Text = transportadora.TransportadoraContatoDddTel1.ToString();
                    txtTelefoneCont1.Text = Validacao.MascaraTelefone(transportadora.TransportadoraContatoTel1.ToString());
                    txtDDDCelularCont1.Text = transportadora.TransportadoraContatoDddCel1.ToString();
                    txtCelularCont1.Text = Validacao.MascaraCelular(transportadora.TransportadoraContatoCel1.ToString());
                    //Contatos 2
                    txtNomeCont2.Text = transportadora.TransportadoraContatoNome2;
                    txtCargoCont2.Text = transportadora.TransportadoraContatoCargo2;
                    txtEmailCont2.Text = transportadora.TransportadoraContatoEmail2;
                    txtDDDTelefoneCont2.Text = transportadora.TransportadoraContatoDddTel2.ToString();
                    txtTelefoneCont2.Text = Validacao.MascaraTelefone(transportadora.TransportadoraContatoTel2.ToString());
                    txtDDDCelularCont2.Text = transportadora.TransportadoraContatoDddCel2.ToString();
                    txtCelularCont2.Text = Validacao.MascaraCelular(transportadora.TransportadoraContatoCel2.ToString());

                    tbiCadastro.IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtgTransportadoresAreaPesq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                transportadoraArea = dtgTransportadoresAreaPesq.CurrentCell.Item as Models.Transportadora;
                txtTransportadoraArea.Text = transportadoraArea.TransportadoraNomeFantasia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgTransportadoresArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                areaTransportadora = dtgTransportadoresArea.CurrentCell.Item as Models.AreaTransportadora;
                transportadoraArea = areaTransportadora.Transportadora;
                txtCodigoArea.Text = areaTransportadora.AreaTransportadoraId.ToString();
                txtTransportadoraArea.Text = areaTransportadora.Transportadora.TransportadoraNomeFantasia;
                cmbEstadoArea.SelectedValue = areaTransportadora.Uf.UfId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                            MessageBox.Show("CNPJ/CPF Inválido!", "Transporadora");
                            txtCnpjCpf.Text = string.Empty;
                            txtCnpjCpf.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CNPJ/CPF apenas com numeros!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Telefone ínvalido!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Celular ínvalido!", "Transporadora");
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
                    MessageBox.Show("Email ínvalido!", "Transporadora");
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
                    MessageBox.Show("CEP ínvalido!", "Transporadora");
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
                    MessageBox.Show("Email ínvalido!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Telefone ínvalido!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Celular ínvalido!", "Transporadora");
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
                    MessageBox.Show("Email ínvalido!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Telefone ínvalido!", "Transporadora");
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
                    MessageBox.Show("DDD ínvalido!", "Transporadora");
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
                    MessageBox.Show("Celular ínvalido!", "Transporadora");
                    txtCelularCont2.Text = string.Empty;
                    txtCelularCont2.Focus();
                }
            }
        }

        private void incluirA_Click(object sender, RoutedEventArgs e)
        {
            if (cmbEstadoArea.SelectedIndex >= 0 && txtTransportadoraArea.Text != string.Empty)
            {
                try
                {
                    areaTransportadora.Transportadora = transportadoraArea;
                    areaTransportadora.Uf = cmbEstadoArea.SelectedItem as Models.Uf;

                    bllArea.Incluir(areaTransportadora);

                    MessageBox.Show("Associação de Área com Transportadora, ocorreu com Sucesso!","Área Transportadora");
                    CarregarGridArea();
                    CarregarGridTransArea();
                    cancelarA_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro na associação desta Área de Atuação! " + ex.ToString(), "Área Transportadora");
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios: Nome Fantasia e Estado. Favor preencher!", "Área Transportadora");
            }
        }

        private void excluirA_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigoArea.Text != string.Empty)
            {
                try
                {
                    areaTransportadora.AreaTransportadoraId = Convert.ToInt32(txtCodigoArea.Text);
                    areaTransportadora.Transportadora = transportadoraArea;
                    areaTransportadora.Uf = cmbEstadoArea.SelectedItem as Models.Uf;

                    bllArea.Excluir(areaTransportadora);

                    MessageBox.Show("Área excuida com sucesso!", "Área Transportadora");
                    CarregarGridArea();
                    CarregarGridTransArea();
                    cancelarA_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro ao excluir esta Área de Atuação! " + ex.ToString(), "Área Transportadora");
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Área Transportadora");
            }
        }

        private void atualizarA_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigoArea.Text != string.Empty)
            {
                try
                {
                    areaTransportadora.AreaTransportadoraId = Convert.ToInt32(txtCodigoArea.Text);
                    areaTransportadora.Transportadora = transportadoraArea;
                    areaTransportadora.Uf = cmbEstadoArea.SelectedItem as Models.Uf;

                    bllArea.Atualizar(areaTransportadora);

                    MessageBox.Show("Área alterada com sucesso!", "Área Transportadora");
                    CarregarGridArea();
                    CarregarGridTransArea();
                    cancelarA_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um erro alterar esta Área de Atuação! " + ex.ToString(), "Área Transportadora");
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para alteração!", "Área Transportadora");
            }
        }

        private void cancelarA_Click(object sender, RoutedEventArgs e)
        {
            txtCodigoArea.Text = string.Empty;
            txtTransportadoraArea.Text = string.Empty;
            txtRazaoSocialAreaPesq.Text = string.Empty;
            txtNomeFantasiaAreaPesq.Text = string.Empty;
            CarregarUfArea();
        }

    }
}
