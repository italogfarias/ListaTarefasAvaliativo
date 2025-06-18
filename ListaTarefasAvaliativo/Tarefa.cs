using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefasAvaliativo
{
    public class Tarefa
    {
        public string Nome { get; set; }
        public string Prioridades { get; set; }
        public int Id { get; set; }
        public string Data { get; set; }


     public int Cadastrar()
        {
            // Instanciar e conectar ao banco:
            Banco banco = new Banco();
            banco.Conectar();

            // Criar o objeto SQLiteCommand:
            var cmd = banco.conexao.CreateCommand();

            // Definir o comando SQL com parâmetros:
            cmd.CommandText = "INSERT INTO tarefas (nome, prioridade, data" +
                 ") VALUES (@nome, @prioridades, @data " +
                 ")";

            // Adicionar valores aos parâmetros:
            cmd.Parameters.AddWithValue("@nome", this.Nome);
            cmd.Parameters.AddWithValue("@prioridades", this.Prioridades);
            cmd.Parameters.AddWithValue("@data", this.Data);

            // Executar e capturar a quantidade de linhas inseridas/removidas:
            int linhasAfetadas = cmd.ExecuteNonQuery();

            // Desconectar
            banco.Desconectar();

            // Retornar a quantidade de linhas inseridas
            return linhasAfetadas;



        }


        public DataTable ListarTudo()
        {


            DataTable tabela = new DataTable();
            Banco banco = new Banco();
            banco.Conectar();
            var cmd = banco.conexao.CreateCommand();
            cmd.CommandText = "SELECT * from tarefas ";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(tabela);
            banco.Desconectar();
            return tabela;
        }

        public int Apagar()
        {
            Banco banco = new Banco();
            banco.Conectar();
            var cmd = banco.conexao.CreateCommand();
            cmd.CommandText = "DELETE FROM tarefas WHERE id=@id";

            // Adicionar valores aos parâmetros:
            cmd.Parameters.AddWithValue("@id", this.Id);

            // Executar e capturar a quantidade de linhas inseridas/removidas:
            int linhasAfetadas = cmd.ExecuteNonQuery();

            // Desconectar
            banco.Desconectar();

            // Retornar a quantidade de linhas inseridas
            return linhasAfetadas;
        }
    }
}
