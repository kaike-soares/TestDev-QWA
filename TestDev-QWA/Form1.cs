using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDev_QWA
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;

        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Descobrir idade do cliente
            if (txtNascimento.Value < DateTime.Now)
            {
                int resultado = CalculaIdade(txtNascimento.Value);
                txtIdade.Text = $" {resultado} Anos";
            }
            else
            {
                MessageBox.Show("Data inválida");
            }
                    

            foreach (Pessoa pessoa in pessoas)
            {
               
                if (pessoa.CPF == txtCPF.Text)
                {
                    MessageBox.Show("CPF já cadastrado.");
                    txtCPF.Clear();
                    txtCPF.Focus();
                    return;
                }
            }

            //Verifica se o nome foi preenchido
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo Nome é obrigatório.");
                txtNome.Focus();
                return;
            }
            //Verifica se o sobrenome foi preenchido
            if (txtSobrenome.Text == "")
            {
                MessageBox.Show("O campo Sobrenome é obrigatório.");
                txtSobrenome.Focus();
                return;
            }
            //Verifica se o CPF foi preenchido
            if (txtCPF.Text == "")
            {
                MessageBox.Show("O campo CPF é obrigatório.");
                txtCPF.Focus();
                return;
            }
            //Verifica se a data de nascimento foi preenchido
            if (txtNascimento.Text == "")
            {
                MessageBox.Show("O campo Data de Nascimento é obrigatório.");
                txtNascimento.Focus();
                return;
            }

            string maiorIdade;
            
            if (txtIdade.Text == "18 Anos")
            {
                maiorIdade = "Maior de idade";
            } 
            else 
            {
                maiorIdade = "Menor de idade";
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Sobrenome = txtSobrenome.Text;
            p.CPF = txtCPF.Text;
            p.DataNascimento = txtNascimento.Text;
            p.Idade = txtIdade.Text;

            int index = -1;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            txtNome.Clear();
            txtSobrenome.Clear();
            txtCPF.Clear();
            
            btnLimpar_Click(btnLimpar, EventArgs.Empty);
            listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private static int CalculaIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
        private void listar()
        {
            listBox.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                listBox.Items.Add(p.Nome + " "
                    +p.Sobrenome + " - " 
                    +p.CPF + " - "
                    +p.DataNascimento + " - "
                    +p.Idade);
            }
        }
    }
}
