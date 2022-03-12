## Checklist

Release:
    - [ ] O campo "Release Notes" foi preenchido no card da feature?

Build:
    - [ ] Os testes unitários tratam cenários/possibilidades reais do caso de uso?

Código:
    - [ ] Foi feito desk check para certificar que os critérios de aceite foram satisfeitos?
    - [ ] Respeita as convenções de código predeterminadas do projeto?
    - [ ] O título do PR esta seguindo o [padrão existente](https://pottencial.sharepoint.com/sites/Plataforma/SitePages/Guidelines/Contributing.aspx#commits-e-prs)? 
    - [ ] Arquivos (docker-compose, appsettings.Local, README) foram atualizados informações necessárias para rodar o projeto local?
    - [ ] Foram incluídas as descrições nos controllers e DTOs para exibição no swagger? 

Segurança:
    - [ ] Todos payloads recebidos nos controllers foram validados?
    - [ ] Dados sensíveis foram mascarados ao serem logados?

Banco de dados:
    - [ ] As migrations foram bem testadas?

Caso tenha integrado com serviço novo:
    - [ ] Foi adicionado health check?
    - [ ] Foi utilizado url interna do cluster?

Caso foi feita alterações que dependem de variáveis de ambiente:
    - [ ] Foi adicionado as variáveis nos arquivos do helm e nas releases?

Caso teve alterações em validators:
    - [ ] Todas as regras possuem ".WithErrorCode"?
    - [ ] Códigos de erro foram adicionados na Wiki?