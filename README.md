# InvestmentSimulator
Simulador de investimentos feito em .NET Framework 4.8 (WebAPI) e Angular 17 (Frontend).

## Funcionalidade
* O sistema permite que o usuário infome um valor e um prazo em meses para o resgate da aplicação. Após inserir os dados, o usuário pode solicitar o cálculo do investimento. A tela apresentará o resultado bruto e o resultado líquido do investimento.

## Estrutura da aplicação

O backend do sistema foi feito em .NET Framework (WebAPI) e o frontend em Angular 17 (SPA), ambos utilizando boas práticas, princípios do SOLID e possuindo uma comunicação Client/Server. Segue arquitetura principal da aplicação:

###### WebApi
```
📁 
  |- 📁 Application
  |    | - 📁 Services
  |- 📁 Controllers
  |- 📁 Core
  |   | - 📁 Entities
  |   | - 📁 Interfaces
```
O projeto backend foi estruturado em camadas, a princípio através de pastas, por se tratar de um projeto pequeno. Com esta arquitetura permite diminuir a complexidade e aumentar performance do carregamento do mesmo, ao mesmo tempo que mantem uma divisão clara das responsabilidades. Obs: Conforme o projeto for crescendo, é interessante fazer essa separação por projetos diferentes (Class Library), interligando-os por meio de referências.

