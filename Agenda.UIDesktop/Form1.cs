using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblContatoSalvo_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            txtContatoSalvo.Text = nome;

            string strCon = @"Data Source=.;Initial Catalog=Agenda;Integrated Security=True";
            var id = Guid.NewGuid().ToString();

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string sql = String.Format("insert into Contato(Id,Nome) values ('{0}','{1}')", id, nome);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            sql = String.Format("Select Nome from Contato where Id = '{0}' ;", id);

            cmd = new SqlCommand(sql, con);

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            con.Close();

        }

        private void txtContatoNovo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
