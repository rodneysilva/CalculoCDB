## CalculoCDB

O projeto foi gerado usando a versão 9.0.12 do [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/CleanArchitecture).

-----

### Compilação

Execute o comando `dotnet build -tl` para compilar a solução.

-----

### Execução

Para executar a aplicação web:

```bash
cd .\src\Web\
dotnet watch run
```

Navegue até https://localhost:5001. A aplicação será recarregada automaticamente se você alterar qualquer um dos arquivos fonte.

-----

### Estilos e Formatação de Código

O template inclui suporte ao [EditorConfig](https://editorconfig.org/) para ajudar a manter estilos de codificação consistentes entre vários desenvolvedores trabalhando no mesmo projeto em diversos editores e IDEs. O arquivo **.editorconfig** define os estilos de codificação aplicáveis a esta solução.

-----

### Criação de Código (Scaffolding)

O template inclui suporte para criar novos comandos e consultas.

Comece na pasta `.\src\Application\`.

Para criar um novo comando:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Para criar uma nova consulta:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

Se você encontrar o erro *"No templates or subcommands found matching: 'ca-usecase'."*, instale o template e tente novamente:

```bash
dotnet new install Clean.Architecture.Solution.Template::9.0.12
```

-----

### Testes

A solução contém testes de unidade, de integração, funcionais e de aceitação.

Para executar os testes de unidade, integração e funcionais (excluindo os de aceitação):

```bash
dotnet test --filter "FullyQualifiedName!~AcceptanceTests"
```

Para executar os testes de aceitação, primeiro inicie a aplicação:

```bash
cd .\src\Web\
dotnet run
```

Em seguida, em um novo console, execute os testes:

```bash
cd .\src\Web\
dotnet test
```

-----

### Ajuda

Para saber mais sobre o template, acesse o [site do projeto](https://github.com/jasontaylordev/CleanArchitecture). Lá você pode encontrar orientações adicionais, solicitar novos recursos, relatar um bug e discutir o template com outros usuários.