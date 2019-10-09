using System;
using System.Collections.Generic;
using System.Text;

using AppBarbearia.Classes;
using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Promocao
    {
        public List<ModelPromocao> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelPromocao>("SELECT * FROM promocao");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }

        public bool Inserir(Picker status, string nome, string descricao, Picker tempo, string valor)
        {
            try
            {
                var query = $"INSERT INTO promocao (status, nome_promocao, descricao, tempo, valor) VALUES ('{status.SelectedItem}', '{nome}', '{descricao}', '{tempo.SelectedItem}', '{valor}')";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }
        }

        public bool Update(Picker status, string nome, string descricao, Picker tempo, string valor, int id)
        {
            try
            {
                var query = $"UPDATE promocao SET status = '{status.SelectedItem}', nome_promocao = '{nome}', descricao = '{descricao}', tempo = '{tempo.SelectedItem}', valor = '{valor}' WHERE ID = {id}";
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
                var query = $"DELETE FROM promocao";
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
                var query = $"DELETE FROM promocao WHERE ID = {id}";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar os dados.\nDetalhes:" + ex.Message);
            }

        }
    }
}
