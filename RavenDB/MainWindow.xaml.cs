using Model;
using Repositorio;
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

namespace RavenDB
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public string IdDoClienteSelecionado { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //var cliente = new Cliente
            //{
            //  //  Nome = txtNome.Text,
            //    CPF = "038.185.156-43",
            //    Email = "diegosouzati@outlook.com",
            //    Telefone = "75 99221-9089",
            //    Endereco = new Endereco
            //    {
            //        Logradouro = "Rua.: Monteiro Lobato",
            //        Complemento = "Casa", 
            //        Numero = 34,
            //        Cidade = "Santaluz",
            //        Estado = "Bahia"
            //    }

            //};

            //var repositorio = new RepositorioGenerico();
            //var idCliente =  repositorio.Cadastrar(cliente);
            //IdDoClienteSelecionado = idCliente;

            //MessageBox.Show($"Cliente Salvo com Sucesso! ({idCliente}");
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var repositorio = new RepositorioGenerico();
            var cliente = repositorio.Consulte(IdDoClienteSelecionado);
            MessageBox.Show($"Cliente concultado {cliente.Nome} ");
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if(IdDoClienteSelecionado == null)
            {
                MessageBox.Show("Não há o que remover");
                return;
            }
            var repositorio = new RepositorioGenerico();
            repositorio.Deletar(IdDoClienteSelecionado);

            MessageBox.Show("Cliente deletado com sucesso");

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
            var cliente = frmCliente.Cliente;

            var repositiorio = new RepositorioGenerico();
            repositiorio.Cadastrar(cliente);
        }
    }
}
