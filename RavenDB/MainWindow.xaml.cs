using Model;
using Raven.Client;
using Repositorio;
using System;
using System.Windows;

namespace RavenDB
{
    public partial class MainWindow : Window
    {
        public int PaginaAtual { get; set; } = 1;
        public string IdDoClienteSelecionado { get; set; }
        public RepositorioDeCliente Repositorio { get; set; }

        public int QuantidadeTotalDePaginas { get; set; }

        const int QUANTIDADE_POR_PAGINA = 10;

        public MainWindow()
        {
            InitializeComponent();
            Repositorio = new RepositorioDeCliente();
            CarregueOsElementosDoBancoDeDados();
        }

        public void CarregueOsElementosDoBancoDeDados()
        {
            RavenQueryStatistics estatisticas;
            lstClientes.DataContext = Repositorio.Liste(PaginaAtual, QUANTIDADE_POR_PAGINA, out estatisticas);
            QuantidadeTotalDePaginas = (int)Math.Ceiling((decimal)estatisticas.TotalResults / (decimal)QUANTIDADE_POR_PAGINA);
            txtPaginaAtual.Text = $"Página {PaginaAtual} de {QuantidadeTotalDePaginas}";
        }




        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var cliente = ChameOEditorDeCliente(new Cliente());
            Repositorio.Cadastrar(cliente);
            CarregueOsElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se tem um item selecionado, se não manda o usuario selecionar um usuário
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista!");
                return;
            }
            var cliente = (Cliente)lstClientes.SelectedItem; // Casting da classe cliente para mostrar os dados da tela no formulário            

            cliente = Repositorio.Consulte(cliente.Id); // busca o cliente já editado

            ChameOEditorDeCliente(cliente);// Chama o método para editar o cadastro

            Repositorio.Editar(cliente);// operação do repositorio para salvar as edições feitas             
            CarregueOsElementosDoBancoDeDados();// carrega os dados do banco na lista do formulário
        }

        // Chamar o Metodo para cadastrar ou editar
        private Cliente ChameOEditorDeCliente(Cliente cliente)
        {
            var frmCliente = new FrmCliente(cliente);// instancia o formulario preenchido com os dados do banco

            frmCliente.ShowDialog();// exibe o formulário ao usuario            
            return frmCliente.Cliente;// retorna o formulário preenchido
        }

        // Método para Atualizar a lista
        private void btnAtualuzar_Click(object sender, RoutedEventArgs e)
        {
            CarregueOsElementosDoBancoDeDados();
        }

        // Método para remover um cadastro 
        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista!");
                return;
            }

            var cliente = ((Cliente)(lstClientes.SelectedItem));
            Repositorio.Deletar(cliente.Id);

            MessageBox.Show("Cliente deletado com sucesso");
            CarregueOsElementosDoBancoDeDados();
        }

        // Método para consultar por nome 
        private void txtConsultaIdade_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsultaIdade.Text))
            {
                CarregueOsElementosDoBancoDeDados();
            }

            int idade;
            if (int.TryParse(txtConsultaIdade.Text, out idade)) // conversão de uma string para um inteiro
            {
                lstClientes.DataContext = Repositorio.ConsultePorIdade(idade);
            }
            else
            {
            }
        }

        // Método para consultar por idade 
        private void txtConsultaNome_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsultaNome.Text))
            {
                CarregueOsElementosDoBancoDeDados();
                return;
            }
            lstClientes.DataContext = Repositorio.ConsultePorTermo(txtConsultaNome.Text);
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (PaginaAtual > 1)
            {
                PaginaAtual--;
            }
            CarregueOsElementosDoBancoDeDados();
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            if (PaginaAtual < QuantidadeTotalDePaginas)
            {
                PaginaAtual++;
            }
            CarregueOsElementosDoBancoDeDados();
        }

    }
}
