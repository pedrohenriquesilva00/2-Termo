-----------------------------------------DML---------------------------------------
-- Escolher o banco que quero --
USE Gufi_Tarde;

-- Inserir dados nas tabelas --
INSERT INTO TipoUsuario (TituloTipo)
VALUES	('Administrador'),
		('Comum');

INSERT INTO TipoEvento (TituloTipo)
VALUES	('C#'),
		('React'),
		('SQL');

INSERT INTO Instituicao (CNPJ, NomeFantasia, Endereco)
VALUES	('2123434556', 'Escola SENAI de Informática', 'Alameda Barão de Limeira, 538');

-- Inserir dados com chave estrangeira --
INSERT INTO Usuario (NomeUsuario, Email, Senha, Genero, DataNascimento, IdTipoUsuario)
VALUES	('Administrador', 'adm@adm.com', 'adm123', 'Não informado' , '06/02/2020', 1),
		('Carol', 'carol@email.com', 'carol123', 'Feminino' , '06/02/2020', 2),
		('Saulo', 'saulo@email.com', 'saulo123', 'Masculino' , '06/02/2020', 2);

INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre, IdInstituicao, IdTipoEvento)
VALUES	('Introdução ao C#', '07/02/2020', 'Conceitos sobre os pilares da programação orientada a objetos', 1, 1, 1),
		('Ciclo de vida', '07/02/2020', 'Como utilizar o ciclo de vida com ReactJs', 0, 1, 2),
		('SQL', '07/02/2020', 'Aplicação de índices clusterizados e não clusterizados', 1, 1, 3);

-- Alterar um dado da tabela --
UPDATE Presenca
SET Situacao = 'Confirmada'
WHERE IdPresenca = 1;

INSERT INTO Presenca (Situacao, IdUsuario, IdEvento)
VALUES	('Agendada', 2, 2),
		('Confirmada', 2, 3),
		('Não compareceu', 3, 1);

-- Visualizar as tabelas e os dados --
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;