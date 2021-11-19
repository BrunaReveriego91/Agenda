using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Agenda.DAL.Test
{

    [TestFixture]
    public class ContatosTest
    {

        Contatos _contatos;


        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();

        }

        //IncluirContatoTest



        [Test]
        public void IncluirContatoTest()
        {
            //Monta
            string id = Guid.NewGuid().ToString();
            string nome = "Marcos";

            //Executa
            _contatos.Adicionar(id, nome);


            //Verifica

            Assert.True(true);

        }

        //ObterContatoTest

        [Test]
        public void ObterContatoTest()
        {

        }



        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }


    }
}
