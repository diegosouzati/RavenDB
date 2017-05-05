using Model;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorio
{
    public class RepositorioGenerico
    {
        public DocumentStore store { get; set; }
        public RepositorioGenerico()
        {
            store = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "DbRaven"

            };
            store.Initialize();
        }
        public string Cadastrar(Cliente cliente)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Store(cliente);
                session.SaveChanges();
            }
            return cliente.Id;
        }
        public Cliente Consulte(string IdDoClienteSelecionado)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Load<Cliente>(IdDoClienteSelecionado);               
            }
        }
        public void Deletar(string IdDoClienteSelecionado)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(IdDoClienteSelecionado);
                session.SaveChanges();
            }
        }
    }
}
