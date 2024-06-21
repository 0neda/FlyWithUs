
# FlyWithUs ✈️

Projeto em desenvolvimento em conjunto para a matéria de **Programação I** do curso de **Ciência da Computação** na universidade **UNOESC**.

O projeto está sendo desenvolvido no modelo de estruturização **MVC (Model-View-Controller)** com intuíto de ser um sistema breve simulando o gerenciamento de vôos, aeroportos, aviões e demais pertencentes.

Foi desenvolvido com interface gráfica e com foco em **C#** e também integrado com um banco de dados *(MySQL)* próprio, desenvolvido para a matéria de **Banco de Dados I**. No projeto utilizamos injeção SQL em conjunto de C# para gerenciar a criação de Companhias Aéreas, Aeronaves e visualização em lista para os mesmos e Poltronas.

*Em suma, utilizamos **C# (Winforms) e MySQL** para desenvolver um aplicativo de gerenciamento de vôos.*

###### ✍️ Responsáveis:  Alex Rafael Oneda, Layne Laís de Castilho Firmino, Rafaela Correa, Guilherme Schweitzer.

## 📂 Resumo da estrutura e arquivos contidos:
```
FlyWithUs
├── Auxiliares BD (Contém os scripts SQL para auxiliar o programa e criar o BD)
│   ├── QUERIES-Companhia-Aerea.sql
│   ├── SCHEMA-Companhia-Aerea.sql
│   ├── SEED-Companhia-Aerea.sql
│   └── TRIGGERS-Companhia-Aerea.sql
├── Controllers (Contém os controladores responsáveis por seus repositórios/modelos/etc)
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
├── Repositories
│   ├── CompanyRepository.cs
│   ├── PlaneRepository.cs
│   └── SeatRepository.cs
├── Utils (Atualmente contém scripts auxiliares em geral)
│   ├── Database.cs
│   └── ViewAux.cs
└── Views (Contém as visualizações do projeto)
    ├── MainView.cs
    ├── CompaniesView.cs
    ├── PlanesView.cs
    └── SeatsView.cs
```
