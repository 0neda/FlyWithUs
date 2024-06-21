![Portfolio Badge](https://img.shields.io/badge/Portfolio-%23ff8400?style=for-the-badge&logo=About.me&logoColor=white&labelColor=%23303030)
![C# Badge](https://img.shields.io/badge/C%23-%231b9100?style=for-the-badge&logo=csharp&logoColor=white&logoSize=auto&labelColor=%23303030)
![MySQL Badge](https://img.shields.io/badge/MySQL-blue?style=for-the-badge&logo=mysql&logoColor=white&logoSize=auto&labelColor=%23303030&color=blue)
![GitHub repo size](https://img.shields.io/github/repo-size/0neda/FlyWithUs?style=for-the-badge&logo=files&logoColor=white&logoSize=auto&label=%20&labelColor=%23303030&color=%238800ff)




# FlyWithUs ✈️

Projeto em desenvolvimento em conjunto para a matéria de **Programação I** do curso de **Ciência da Computação** na universidade **UNOESC**.

O projeto está sendo desenvolvido no modelo de estruturização **MVC (Model-View-Controller)** com intuíto de ser um sistema breve simulando o gerenciamento de vôos, aeroportos, aviões e demais pertencentes.

Foi desenvolvido com interface gráfica e com foco em **C#**, foi também integrado com um banco de dados *(MySQL)* próprio, desenvolvido para a matéria de **Banco de Dados I**. No projeto utilizamos injeção SQL em conjunto de C# para gerenciar a criação de Companhias Aéreas, Aeronaves e visualização em lista para os mesmos e Poltronas.

*Em suma, utilizamos **C# (Winforms) e MySQL** para desenvolver um aplicativo de gerenciamento de vôos.*

###### ✍️ Responsáveis:  Alex Rafael Oneda, Layne Laís de Castilho Firmino, Rafaela Correa, Guilherme Schweitzer.

## 📂 Resumo da estrutura e arquivos contidos:
```
FlyWithUs
├── Auxiliares BD (Contém os scripts SQL para auxiliar o programa e criar o BD)
│   ├── QUERIES-Sistema-Aviacao.sql
│   ├── SCHEMA-Sistema-Aviacao.sql
│   ├── SEED-Sistema-Aviacao.sql
│   └── TRIGGERS-Sistema-Aviacao.sql
├── Controllers (Contém os controladores responsáveis pela interação com o usuário)
│   ├── CompanyController.cs
│   ├── PlaneController.cs
│   └── SeatController.cs
├── Models (Responsáveis por conter os modelos de objetos C# em relação ao BD)
│   ├── Airport.cs
│   ├── Company.cs
│   ├── Connection.cs
│   ├── Customer.cs
│   ├── Flight.cs
│   ├── FlightTicket.cs
│   ├── Plane.cs
│   ├── Seat.cs
│   └── Suitcase.cs
├── Repositories (Responsáveis pelos métodos CRUD)
│   ├── CompanyRepository.cs
│   ├── PlaneRepository.cs
│   └── SeatRepository.cs
├── Services (Atualmente sem implementação)
│   ├── SeatServices.cs
├── Utils (Atualmente contém scripts auxiliares em geral)
│   ├── Database.cs
│   └── ViewsHelper.cs
└── Views (Contém as visualizações do projeto)
    ├── MainView.cs
    ├── CompaniesView.cs
    ├── PlanesView.cs
    └── SeatsView.cs
```
