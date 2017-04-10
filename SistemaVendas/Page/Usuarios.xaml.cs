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
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : System.Windows.Controls.Page
    {
        private Models.Usuario usuario;
        private BLL.UsuarioBLL bllUsuario;
        private List<Models.Usuario> usuarios;
        private int validacao;


        public Usuarios()
        {
            InitializeComponent();
            cancelar_Click(null, null);
            CarregarGrid();
        }

        private void incluir_Click(object sender, RoutedEventArgs e)
        {
            usuario = new Models.Usuario();
            bllUsuario = new BLL.UsuarioBLL(DAL.SistemaVendasContexto.Instancia);
            validacao = 0;
            if (txtSenha.Password == txtReSenha.Password)
            {
                if (txtNome.Text != string.Empty || txtLogin.Text != string.Empty || txtSenha.Password != string.Empty || txtReSenha.Password != string.Empty)
                {
                    usuario.Nome = txtNome.Text;
                    usuario.Login = txtLogin.Text;
                    usuario.Senha = Seguranca.CriptyPass(txtLogin.Text, txtSenha.Password);

                    validacao = bllUsuario.Incluir(usuario);

                    if (validacao == 1)
                    {
                        MessageBox.Show("Usuario Inserido com Sucesso!", "Usuário");
                        CarregarGrid();
                        cancelar_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Houve um erro na inclusao deste cliente!", "Usuário");
                    }
                }
                else
                {
                    MessageBox.Show("O preenchimento de todos os campos, é obrigatório!", "Usuário");
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem, favor corrigir!", "Usuário");
                txtSenha.Focus();
            }

        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {
            usuario = new Models.Usuario();
            bllUsuario = new BLL.UsuarioBLL(DAL.SistemaVendasContexto.Instancia);
            validacao = 0;

            if (txtCodigo.Text != string.Empty)
            {
                usuario.Codigo = Int32.Parse(txtCodigo.Text);
                usuario.Nome = txtNome.Text;
                usuario.Login = txtLogin.Text;
                usuario.Senha = Seguranca.CriptyPass(txtLogin.Text, txtSenha.Password);

                validacao = bllUsuario.Excluir(usuario);

                if (validacao == 1)
                {
                    MessageBox.Show("Usuario Excluido com Sucesso!", "Usuário");
                    CarregarGrid();
                    cancelar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Houve um erro ao tentar excluir este cliente!", "Usuário");
                }
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro para exclusão!", "Usuário");
            }

        }

        private void atualizar_Click(object sender, RoutedEventArgs e)
        {
            usuario = new Models.Usuario();
            bllUsuario = new BLL.UsuarioBLL(DAL.SistemaVendasContexto.Instancia);
            validacao = 0;

            if (txtSenha.Password == txtReSenha.Password)
            {
                if (txtCodigo.Text != string.Empty)
                {
                    usuario.Codigo = Int32.Parse(txtCodigo.Text);
                    usuario.Nome = txtNome.Text;
                    usuario.Login = txtLogin.Text;
                    usuario.Senha = Seguranca.CriptyPass(txtLogin.Text, txtSenha.Password);

                    validacao = bllUsuario.Atualizar(usuario);

                    if (validacao == 1)
                    {
                        MessageBox.Show("Dados do Usuario Alterado com Sucesso!","Usuário");
                        CarregarGrid();
                        cancelar_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Houve um erro ao tentar alterar os dados deste usuario!", "Usuário");
                    }
                }
                else
                {
                    MessageBox.Show("Favor selecionar um registro para alteração!", "Usuário");
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem, favor corrigir!", "Usuário");
                txtSenha.Focus();
            }

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Password = string.Empty;
            txtReSenha.Password = string.Empty;
            txtNome.Focus();
        }

        private void dtgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            usuario = new Models.Usuario();
            try
            {
                usuario = dtgUsuarios.CurrentCell.Item as Models.Usuario;

                if (usuario != null)
                {
                    txtCodigo.Text = usuario.Codigo.ToString();
                    txtNome.Text = usuario.Nome;
                    txtLogin.Text = usuario.Login;
                    txtSenha.Password = string.Empty;
                    txtReSenha.Password = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void CarregarGrid()
        {
            bllUsuario = new BLL.UsuarioBLL(DAL.SistemaVendasContexto.Instancia);
            usuarios = new List<Models.Usuario>();

            usuarios = bllUsuario.getUsuarios();

            if (usuarios.Count >= 1)
            {
                dtgUsuarios.ItemsSource = usuarios;
            }
            else
            {
                dtgUsuarios.ItemsSource = null;
            }

        }
    }
}
