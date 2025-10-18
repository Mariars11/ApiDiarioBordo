using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioBordo.Migrations
{
    /// <inheritdoc />
    public partial class CargaTripulantes : Migration
    {
        /// <inheritdoc />
         protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Maria Clara', 'Comandante', 1)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('João Pedro', 'Piloto', 1)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Ana Beatriz', 'Engenheira de Sistemas', 1)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Lucas Henrique', 'Especialista em Comunicação', 2)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Fernanda Lima', 'Médica da Missão', 2)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Carlos Eduardo', 'Técnico de Navegação', 2)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Patrícia Souza', 'Cientista de Bordo', 3)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Bruno Rafael', 'Especialista em Sistemas de Vida', 3)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Letícia Silva', 'Bióloga', 3)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Rafael Gomes', 'Segurança', 1)");
            mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Eduardo Santos', 'Engenheiro de Propulsão', 1)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Mariana Oliveira', 'Especialista em Robótica', 2)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Pedro Almeida', 'Técnico de Comunicação', 3)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Sofia Costa', 'Médica de Emergência', 4)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Ricardo Fernandes', 'Cientista de Dados', 5)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Juliana Martins', 'Especialista em Sistemas de Vida', 6)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Thiago Ribeiro', 'Piloto de Testes', 7)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Larissa Lima', 'Técnica em Navegação', 8)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Felipe Nunes', 'Analista de Missão', 9)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Camila Souza', 'Engenheira Química', 10)");

mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Gabriel Rocha', 'Especialista em Energia', 1)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Bianca Melo', 'Especialista em Comunicações', 2)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Vinicius Barbosa', 'Técnico em Suporte', 3)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Amanda Ferreira', 'Cientista Atmosférica', 4)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Daniel Castro', 'Mecânico de Bordo', 5)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Patrícia Azevedo', 'Especialista em Sistemas de Controle', 6)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Rafael Lima', 'Engenheiro Eletrônico', 7)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Vanessa Ribeiro', 'Médica Generalista', 8)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Carlos Moreira', 'Especialista em Robótica', 9)");
mb.Sql(@"INSERT INTO Tripulantes (Nome, Cargo, NaveId) VALUES ('Isabela Gomes', 'Técnica de Laboratório', 10)");
      
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(@"Delete from Naves");
        }
    }
}
