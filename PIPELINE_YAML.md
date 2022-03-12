# **Pipeline YAML**
- [**Pipeline YAML**](#pipeline-yaml)
  - [**Pré-requisitos**](#pré-requisitos)
    - [**Extensões**](#extensões)
    - [**Agent Pool**](#agent-pool)
    - [**Service Connection**](#service-connection)
    - [**Variable Group**](#variable-group)
    - [**Environments**](#environments)
    - [**Templates**](#templates)
  - [**Configuração**](#configuração)

## **Pré-requisitos**
***

### **Extensões**
Extensões instaladas via markteplace do Azure DevOps:
- SonarCloud
- SonarCloud build breaker
- Replace Tokens
- AWS Toolkit for Azure DevOps
- DbUp Migration

### **Agent Pool**
O team project deve ter permissão nos agent pools abaixo:
- Azure-Pool-Pottencial
- Servers
- Azure Pipelines

### **Service Connection**
Para executação da pipeline as seguintes service connections devem estar configuradas:

| Tipo       | Uso                         | Padrão                                                | Exemplo                          | Estágio                | Responsável |
| ---------- | --------------------------- | ----------------------------------------------------- | -------------------------------- | ---------------------- | ----------- |
| SonarCloud | Análise estática de código. | SonarCloud-\<ProjectName\>                            | SonarCloud-Samples               | Build                  | Arquitetura |
| Docker     | Registry docker Azure       | pottencialcrprdgeneral                                | pottencialcrprdgeneral           | Build                  | Cloud       |
| AWS        | Registry docker AWS         | DevOps-DockerRegistry-Deployment                      | DevOps-DockerRegistry-Deployment | Build                  | Cloud       |
| Kubernetes | Helm upgrade                | \<Cloud\>-K8S-General-\<Context\>-\<ShortEnviroment\> | AWS-K8S-General-Samples-Dev      | Deployment Development | Cloud       |
| Kubernetes | Helm upgrade                | \<Cloud\>-K8S-General-\<Context\>-\<ShortEnviroment\> | AWS-K8S-General-Samples-Hml      | Deployment Staging     | Cloud       |
| Kubernetes | Helm upgrade                | \<Cloud\>-K8S-General-\<Context\>-\<ShortEnviroment\> | Azure-K8S-General-Samples-Prd    | Deployment Prodcution  | Cloud       |


### **Variable Group**
Para publição do serviço os variable groups abaixo devem existir na seção Pipelines > Library > Variable groups:

| Tipo       | Padrão                         | Exemplo                          | Escopo      | Responsável                        |
| ---------- | ------------------------------ | -------------------------------- | ----------- | ---------------------------------- |
| New Relic  | New Relic - General            | New Relic - General              | Release     | Cloud                              |
| Helm Chart | General - Helm Chart Variables | General - Helm Chart Variables   | Release     | Cloud                              |
| Aplicação  | \<PipelineName\> - Development | Pottencial.Samples - Development | Development | Tech Leaders / Arquitetos          |
| Aplicação  | \<PipelineName\> - Staging     | Pottencial.Samples - Staging     | Staging     | Tech Leaders / Arquitetos          |
| Aplicação  | \<PipelineName\> - Prodcution  | Pottencial.Samples - Prodcution  | Prodcution  | Segurança / Cloud / Infraestrutura |

As variáveis com prefixo "#{" e sufixo "}#" nos arquivos yaml da pasta .helm, serão substuidas pelas variáveis do Azure DevOps durante a execução da task "Replace Tokens" em cada estágio de deployment, caso a variável não exista irá ocorrer um erro durante está etapa.

*Observação*: Todo variable group do tipo aplicação que use o DbUp Upgration deve possuir a variável "ConnectionStrings__DbUpConnection" com a connection string que permita a execução do scripts de banco de dados. As demais variáveis 

### **Environments**
Ambientes virtuais dentro do Azure DevOps para controle das publicações nos ambientes, devem existir três environments:
- Development
- Staging
- Production

### **Templates**
- Todo usuário que utilizar templates YAML referenciando o projeto [Devops\Pottencial.AzureDevOps.Templates](https://pottencial.visualstudio.com/DevOps/_git/Pottencial.AzureDevOps.Templates?path=%2Frelease-k8s-helm-general), devem estar no grupo global "[pottencial]\Azure DevOps Templates"

## **Configuração**
***
1. Acessar o respositório do serviço
2. Clicar em "Set up build"
3. Selecionar a opção "Existing Azure Pipelines YAML file"
4. Selecionar a "Branch" e o "Path" "/.ci/main.yml"
5. Clicar em "Continue"
6. Clicar em "Run"

Após a execução da pipeline solicitar o cadastro do DNS no Potter Help.