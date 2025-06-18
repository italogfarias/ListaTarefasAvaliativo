# Lista de Tarefas Avaliativo

Este é um projeto de uma aplicação Windows Forms em C# para gerenciamento de tarefas, desenvolvido no Visual Studio. A aplicação permite cadastrar, listar e excluir tarefas com informações como nome, prioridade e data, utilizando um banco de dados SQLite para persistência.

## Funcionalidades

- **Cadastrar Tarefa**: Adiciona uma nova tarefa com nome (mínimo 3 caracteres), prioridade e data.
- **Listar Tarefas**: Exibe todas as tarefas cadastradas em um DataGridView.
- **Excluir Tarefa**: Remove uma tarefa selecionada com dupla confirmação via double-click no DataGridView.
- **Validação**: Verifica se o nome da tarefa tem pelo menos 3 caracteres antes de cadastrar.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET Windows Forms
- **Banco de Dados**: SQLite (utilizando `System.Data.SQLite`)
- **IDE**: Visual Studio
- **Bibliotecas**:
  - `System.Windows.Forms` para interface gráfica
  - `System.Data.SQLite` para conexão com o banco de dados

## Estrutura do Código

O código principal está na classe `Form1` (arquivo `Form1.cs`), que contém:

- **Construtor**: Inicializa o formulário e atualiza o DataGridView com as tarefas existentes.
- **Evento `btnCadastrar_Click`**: Valida e cadastra uma nova tarefa, limpando os campos após sucesso.
- **Método `AtualizarDgvContatos`**: Atualiza o DataGridView com os dados do método `ListarTudo` da classe `Tarefa`.
- **Evento `dgvTarefas_CellDoubleClick`**: Permite excluir uma tarefa selecionada após confirmação do usuário.

A classe `Tarefa` (não fornecida no trecho) é responsável por:
- Propriedades: `Id`, `Nome`, `Prioridades`, `Data`
- Métodos: `Cadastrar`, `ListarTudo`, `Apagar`

## Pré-requisitos

- Visual Studio (qualquer versão recente com suporte a .NET Framework)
- Pacote NuGet `System.Data.SQLite` instalado no projeto
- Banco de dados SQLite configurado com uma tabela de tarefas (campos sugeridos: `id`, `nome`, `prioridade`, `data`)

## Como Executar

1. Clone ou copie o projeto para sua máquina.
2. Abra a solução no Visual Studio.
3. Instale o pacote `System.Data.SQLite` via NuGet:
   ```bash
   Install-Package System.Data.SQLite
   ```
4. Crie o banco de dados SQLite e a tabela de tarefas (consulte a classe `Tarefa` para a estrutura exata).
5. Compile e execute o projeto no Visual Studio.

## Observações

- O código assume a existência da classe `Tarefa` com métodos para interação com o banco de dados.
- A interface contém:
  - `txbNome`: TextBox para o nome da tarefa
  - `cmbPrioridade`: ComboBox para selecionar a prioridade
  - `txbData`: TextBox para a data
  - `dgvTarefas`: DataGridView para exibir as tarefas
  - `btnCadastrar`: Botão para cadastrar uma tarefa
- A exclusão de tarefas é feita com double-click no DataGridView, com uma mensagem de confirmação.

## Melhorias Futuras

- Adicionar funcionalidade de edição de tarefas.
- Implementar filtros para o DataGridView (ex.: por prioridade ou data).
- Melhorar a validação de campos (ex.: formato de data, prioridade obrigatória).
- Adicionar tratamento de erros mais robusto para operações no banco de dados.

## Autor

Desenvolvido como parte de um projeto avaliativo. Para dúvidas ou sugestões, contate o desenvolvedor.