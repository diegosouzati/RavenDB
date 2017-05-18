using Model;
using Repositorio;
using System.Windows;

namespace RavenDB
{
    public partial class FrmCliente : Window
    {
        public Cliente  Cliente { get; set; }

        RepositorioDeCliente repositorio;
        public FrmCliente()
        {
            InitializeComponent();
            Cliente = new Cliente(); // Cliente da Edição
            //Cliente.Endereco = new Endereco(); uma forma de ser feito
            this.DataContext = Cliente; // criando um cliente novo
            repositorio = new RepositorioDeCliente();
        }

        public FrmCliente(Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente; // editando um cliente
            Cliente = cliente;
            repositorio = new RepositorioDeCliente();

            if (cliente.Indicador != null)
            {
                cmbIndicador.SelectedValue = cliente.Indicador.Id;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbIndicador.ItemsSource = repositorio.Liste();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cliente = (Cliente)this.DataContext; // salva um cliente novo no banco de dados
            Cliente.Indicador = (Cliente)cmbIndicador.SelectedItem; // Salva o indicador de um novo cliente

            if (Cliente.IndicadorId != null)
            {
                Cliente.IndicadorId = ((Cliente)cmbIndicador.SelectedItem).Id; // retorna o id do cliente indicador
            }
            MessageBox.Show("Cliente Salvo com Sucesso"); //Mensagem de aviso de conclusão
            this.Close();
        }
    }
}
