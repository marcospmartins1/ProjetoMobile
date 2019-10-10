using System;
using System.Collections.Generic;
using System.Text;

using AppBarbearia.Classes;
using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Usuario
    {
        public List<ModelUsuario> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelUsuario>("SELECT * FROM usuario");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }
        public bool Inserir(string nome, string senha, string email)
        {
            try
            {
                var query = $"INSERT INTO usuario (usuario, senha, email) VALUES ('{nome}', '{senha}', '{email}')";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }
        }
        public bool Update(string nome, string senha, string email, int id)
        {
            try
            {
                var query = $"UPDATE usuario SET usuario = '{nome}', senha = '{senha}', email = '{email}' WHERE ID = {id}";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao atualizar.\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteAll()
        {
            try
            {
                var query = $"DELETE FROM usuario";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar a lista.\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteItem(int id)
        {
            try
            {
                var query = $"DELETE FROM usuario WHERE ID = {id}";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar os dados.\nDetalhes:" + ex.Message);
            }
        }

        public bool Login(string usuario, string senha)
        {
            try
            {
                var query = $"SELECT COUNT (*) FROM usuario WHERE usuario = '{usuario}' AND senha = '{senha}'";
                var resultadoSQL = ((App)Application.Current).Conexao.Query<ModelUsuario>(query);

                if (resultadoSQL.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado.\nDetalhes:" + ex.Message);
            }
        }
    }
}
