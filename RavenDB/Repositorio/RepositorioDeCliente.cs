using System;
using Model;
using Raven.Client;
using System.Linq;
using System.Collections.Generic;

namespace Repositorio
{
    public class RepositorioDeCliente : RepositorioGenerico<Cliente>
    {
        public override Cliente Consulte(string IdDoItem)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var cliente = session.Load<Cliente>(IdDoItem);
                if (cliente.IndicadorId != null)
                {
                    cliente.Indicador = session.Load<Cliente>(cliente.IndicadorId);
                }
                return cliente;
            }
        }
      

        public List<Cliente>ConsultePorIdade(int idade)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                // Lambda para busca de cadastro através da idade do cliente
                return session
                    .Advanced
                    .DocumentQuery<Cliente>()
                    .Where($"Idade: *{idade}*")
                    .ToList();
            }
        }
    }
}
