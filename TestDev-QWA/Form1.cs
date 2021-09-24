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
        int resultIdade;
        int contagem = 0;
        string maiorIdade;
        int vagas = 1;
        int cand = 1;

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Verifica se o nome foi preenchido
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo Nome é obrigatório.\nO Candidato não foi adicionado à lista");
                txtNome.Focus();
                return;
            }

            //Verifica se o sobrenome foi preenchido
            if (txtSobrenome.Text == "")
            {
                MessageBox.Show("O campo Sobrenome é obrigatório.\nO Candidato não foi adicionado à lista");
                txtSobrenome.Focus();
                return;
            }

            //Verifica se o CPF foi preenchido
            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("O campo CPF é obrigatório.\nO Candidato não foi adicionado à lista");
                txtCPF.Focus();
                return;
            }

            //Verifica se o CPF já existe na lista
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
            //Verifica se a data de nascimento foi preenchido
            if (txtNascimento.Text == "")
            {
                MessageBox.Show("O campo Data de Nascimento é obrigatório.\nO Candidato não foi adicionado à lista");
                txtNascimento.Focus();
                return;
            }
            //Descobrir idade do cadastrado
            if (txtNascimento.Value < DateTime.Now)
            {
                resultIdade = CalculaIdade(txtNascimento.Value);
            }
            else
            {
                MessageBox.Show("Data inválida");
            }

            //É maior de idade?
            if (resultIdade >= 18)
            {
                maiorIdade = "É maior de idade";
            }
            else
            {
                maiorIdade = "Não é maior de idade";
            }

            //Número de vagas
           
            {
                cand++;

                Pessoa p = new Pessoa();
                p.Nome = txtNome.Text;
                p.Sobrenome = txtSobrenome.Text;
                p.CPF = txtCPF.Text;
                p.DataNascimento = txtNascimento.Text;
                p.Idade = $"{resultIdade} Anos";
                p.maiorIdade = maiorIdade;

                int index = -1;
                if (index < 0)
                {
                    pessoas.Add(p);
                }
                else
                {
                    pessoas[index] = p;
                }

                //Cadastros já realizados
                contagem++;
                txtContagem.Text = contagem.ToString();
                txtNome.Focus();

            }
            else
            {
                MessageBox.Show("\nCandidato não cadastrado.\nNº de candidatos atingiu o limite permitido por vaga.\nClique em cadastrar para gravar os candidatos");
                cand = 0;
            }
            
            txtNome.Clear();
            txtSobrenome.Clear();
            txtCPF.Clear();
            txtNascimento.Value = DateTime.Now;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (contagem <= 9)
            {
                MessageBox.Show("Candidatos cadastrados com sucesso");
            }
            else
            {
                MessageBox.Show("Não é possivel cadastrar mais candidatos");
            }
            listar();


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
                    +p.Idade + " - "
                    +p.maiorIdade);
            }
        }

        
    }
}
