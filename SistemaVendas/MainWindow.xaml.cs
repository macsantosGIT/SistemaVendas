using System;
using System.Windows;
using System.Windows.Input;
using Util;

namespace SistemaVendas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int usuarioLogado = 0;

        public MainWindow()
        {
            InitializeComponent();
            //Utilizar esta propriedade para logar na pagina principal e habilitar e desabilitar o menu
            habilitaDesabilitaMenu(false);
            txtLogin.Focus();            
        }

        private void GoToPageExecuteHandler(object sender, ExecutedRoutedEventArgs e)
        {
            frmContent.NavigationService.Navigate(new Uri((string)e.Parameter, UriKind.Relative));
        }

        private void GoToPageCanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }



        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Models.Usuario usuario = new Models.Usuario();
            BLL.UsuarioBLL bllUsuario = new BLL.UsuarioBLL(DAL.SistemaVendasContexto.Instancia);

            if (txtLogin.Text != string.Empty || txtSenha.Password != string.Empty)
            {
                usuario.Login = txtLogin.Text;
                usuario.Senha = Seguranca.CriptyPass(txtLogin.Text, txtSenha.Password);

                if (bllUsuario.AutenticarUsuario(usuario))
                {
                    usuarioLogado = 1;
                }
                else
                {
                    usuarioLogado = 0;
                    MessageBox.Show("Falhou, tente novamente!", "Login");
                }

                if (usuarioLogado == 1)
                {
                    habilitaDesabilitaMenu(true);
                    this.frmContent.Source = new Uri("Page/Home.xaml", UriKind.Relative);
                }

                txtLogin.Text = string.Empty;
                txtSenha.Password = string.Empty;
            }
            else
            {
                //temporario
                usuarioLogado = 1;
                if (usuarioLogado == 1)
                {
                    habilitaDesabilitaMenu(true);
                    this.frmContent.Source = new Uri("Page/Home.xaml", UriKind.Relative);
                }
            }
        }

        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            usuarioLogado = 0;
            if (usuarioLogado == 0)
            {
                menuHome.IsEnabled = false;
                menuCadastro.IsEnabled = false;
                menuManutencao.IsEnabled = false;
                this.frmContent.Source = null;
            }

        }

        private void habilitaDesabilitaMenu(bool condicao)
        {
            menuHome.IsEnabled = condicao;
            menuCadastro.IsEnabled = condicao;
            menuManutencao.IsEnabled = condicao;
            menuRealtorio.IsEnabled = condicao;
        }


    }
}
