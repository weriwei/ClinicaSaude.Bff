# ClinicaSaude.Bff

## Configuração de desenvolvimento

### Pré-requisitos

Ter instalado:

- [Docker](https://www.docker.com/get-started) e [docker-compose](https://docs.docker.com/compose/install/)
- [PowerShell Core](https://docs.microsoft.com/pt-br/powershell/scripting/install/installing-powershell?view=powershell-7.1)
- [.NET e ASP.NET](https://dotnet.microsoft.com/download) versões 2.1 e 6.0

### Criação de arquivos de configuração

No diretório `ClinicaSaude.Bff.Api`, duplique o arquivo `appsettings.Local-example.json` e salve com o nome `appsettings.Local.json`.

No diretório `ClinicaSaude.Bff.Api/Properties`, duplique o arquivo `launchSettings-example.json` e salve com o nome `launchSettings.json`.

### Inicializando dependências

#### Banco de dados

Na raiz do repositório, execute o comando:

_(Este comando assume que o Docker foi instalado e está em execução)_

```sh
docker-compose up -d
```

O comando anterior irá iniciar o SQL Server 2017

Connection string: `Server=localhost,9003;User Id=sa;Password=Senha123!;Database=master;`

#### Migração do banco de dados

Após o banco de dados ter sido inicializado no passo anterior, execute o comando:

_(Este comando assume que o PowerShell Core foi instalado)_

```sh
pwsh -wd .scripts .scripts/setup.ps1
```

**Nota**: Este comando irá aplicar os scripts de migração de schema presentes no diretório `ClinicaSaude.Bff.Repositories/Scripts`. Sendo assim, é necessário executar este comando sempre que um novo script for adicionado.


### Iniciando o serviço

#### Visual Studio

Incie o projeto `ClinicaSaude.Bff.Api` utilizando o perfil `Default`.

#### VSCode

Configurações para inicialização do projeto estão disponíveis em `.vscode/launch.json`.

Pra iniciar, aperte `f5` ou inicie o debug com a configuração `.NET Core Launch (web)`.

### Checar funcionamento do serviço

O serviço irá ouvir na porta `9103`, para checar que tudo está funcionando, acesse o [Swagger](http://localhost:9103/api-docs) e execute a chamada `GET /api/healthcheck`. Se for retornado 200, a configuração está completa.

### Configuração de Pipeline
[Pipeline YAML](PIPELINE_YAML.md)
