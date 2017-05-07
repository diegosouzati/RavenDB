using Model;
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
using System.Windows.Shapes;

namespace RavenDB
{
    public partial class FrmCliente : Window
    {
        public Cliente  Cliente { get; set; }
        public FrmCliente()
        {
            InitializeComponent();
            Cliente = new Cliente();
            //Cliente.Endereco = new Endereco(); uma forma de ser feito
            this.DataContext = Cliente; // criando um cliente novo
        }

        public FrmCliente(Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente; // editando um cliente
            Cliente = cliente;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cliente = (Cliente)this.DataContext;
            MessageBox.Show("Cliente Salvo com Sucesso");
            this.Close();
        }
    }
}
