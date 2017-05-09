﻿using Model;
using Repositorio;
using System.Windows;

namespace RavenDB
{
    public partial class MainWindow : Window
    {
        public string IdDoClienteSelecionado { get; set; }

        public RepositorioDeCliente Repositorio { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Repositorio = new RepositorioDeCliente();
            CarregueOsElementosDoBancoDeDados();
        }

        public void CarregueOsElementosDoBancoDeDados()
        {
            lstClientes.DataContext = Repositorio.Liste();
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

        private void btnAtualuzar_Click(object sender, RoutedEventArgs e)
        {
            CarregueOsElementosDoBancoDeDados();
        }

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
    }
}
