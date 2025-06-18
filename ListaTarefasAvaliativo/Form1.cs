using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaTarefasAvaliativo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AtualizarDgvContatos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Vereficar se o nome é menor que 3:
            if (txbNome.Text.Length < 3)
            {
                MessageBox.Show("O nome é obrigatório!", "ERRO!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                // Instanciar um objeto do tipo contato:
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = txbNome.Text;
                tarefa.Prioridades = cmbPrioridade.Text;
                tarefa.Data = txbData.Text;

                if (tarefa.Cadastrar() == 1)
                {
                    MessageBox.Show("Tarefa cadastrada!", "Sucesso!",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDgvContatos();
                    // limpar os textbox:
                    txbNome.Clear();
                    txbData.Clear();
                    cmbPrioridade.SelectedIndex = -1;
                }

                else
                {
                    MessageBox.Show("Falha ao cadastrar tarefa!", "ERRO!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

                public void AtualizarDgvContatos()
        {
            Tarefa tarefa = new Tarefa();

            // Colocar o resultado do SELECT dentro do dgv:
            dgvTarefas.DataSource = tarefa.ListarTudo();
        }

        private void dgvTarefas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obter u número da linha que esta selecionada:
            int Ls = dgvTarefas.SelectedCells[0].RowIndex;
            // Obter o valor (id) da primeira coluna (0) da Linha selecionda (Ls)
            int idSelecionado = int.Parse(dgvTarefas.Rows[Ls].Cells[0].Value.ToString());
            // Obter o nome da pessoa selecionda:
            string nome = dgvTarefas.Rows[Ls].Cells[1].Value.ToString();

            //confirmar exclusão:
            DialogResult r = MessageBox.Show($"Quer realmente apagar {idSelecionado} - {nome}?",
                "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Id = idSelecionado;

                if (tarefa.Apagar() == 1)
                {
                    MessageBox.Show("Tarefa removida!", "Sucesso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDgvContatos();
                }
            }
        }
    }
}
    


