﻿using Model;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorio
{
    public class RepositorioGenerico<T> where T : ElementoBase, new()
    {
        public DocumentStore store { get; set; }

        // Método de inicialização
        public RepositorioGenerico()
        {
            store = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "DbRaven"

            };
            store.Initialize();
        }

        // Método de novo cadastro
        public virtual string Cadastrar(T item)
        {
            item.Id = null; // o ID tem que ser nulo quando é um novo Cadastro
            return Salvar(item);
        }

        // Método para Editar um cadastro
        public virtual string Editar(T item) 
        {
            return Salvar(item);
        }

        // Método de Salvar 
        public virtual string Salvar(T item)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
            return item.Id;
        }

        // Método de Consultar
        public virtual T Consulte(string IdDoItem)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Load<T>(IdDoItem);
            }
        }

        // Método Listar os dados do banco na tela
        public virtual List<T> Liste()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                return session.Query<T>().ToList(); //Listar Dados Na tela
            }
        }

        // Método Deletar um cadastro do banco
        public virtual void Deletar(string IdDoItemSalvo)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(IdDoItemSalvo); // deleta um cliente do banco
                session.SaveChanges();// salva as alterações feitas no banco
            }
        }

    }
}
