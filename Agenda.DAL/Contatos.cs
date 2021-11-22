using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Agenda.Domain;

namespace Agenda.DAL
{
    public class Contatos
    {
        private string _strCon { get; set; }


        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        }


        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Open();
                var sql = String.Format("insert into Contato(Id,Nome) values ('{0}','{1}')", contato.Id, contato.Nome);
                var cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }


        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                con.Open();
                string sql = String.Format("Select Id, Nome from Contato where Id = '{0}' ;", id);
                SqlCommand cmd = new SqlCommand(sql, con);


                var sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();

                contato = new Contato()
                {
                    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString()
                };


            }

            return contato;

        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                con.Open();
                string sql = String.Format("Select Id, Nome from Contato;");
                SqlCommand cmd = new SqlCommand(sql, con);


                var sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var contato = new Contato()
                    {
                        Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                        Nome = sqlDataReader["Nome"].ToString()
                    };

                    contatos.Add(contato);
                }
            }

          

            return contatos;
        }


    }
}
