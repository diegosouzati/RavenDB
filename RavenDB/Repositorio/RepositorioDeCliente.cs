﻿using System;
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
                cliente.Indicador = session.Load<Cliente>(cliente.IndicadorId);
                return cliente;
            }
        }
        public List<Cliente>ConsultePorTermo(string termo)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Query<Cliente>().Where(x => x.Nome == termo).ToList();  
                // Lambda para busca de cadastro através de nome do cliente              
            }
        }

        public List<Cliente>ConsultePorIdade(int idade)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                // Lambda para busca de cadastro através da idade do cliente
                return session.Query<Cliente>().Where(x => x.Idade == idade).ToList();
            }
        }
    }
}
