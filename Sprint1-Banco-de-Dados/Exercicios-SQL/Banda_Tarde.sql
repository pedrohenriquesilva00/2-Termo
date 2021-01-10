------------------------------ DDL Linguagem de definição de dados ---------------------------------------
-- Criar banco de dados --
CREATE DATABASE Banda_Tarde;

--Apontar para o banco que quero --
USE Banda_Tarde;

-- Criar tabelas --
-- IDENTITY: Senão colocar ele não gera a chave primária automático. Ele não consegue gerar um número --
CREATE TABLE Estilos (
	IdEstilo		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Artistas (
	IdArtista		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Usuarios (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200),
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE Albuns (
	IdAlbum			INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

-- Visualizar a tabela criada que quero --
SELECT * FROM Albuns;

-- Alterar e Adicionar --
ALTER TABLE Albuns
ADD IdEstilo		INT FOREIGN KEY REFERENCES Estilos(IdEstilo);

-- Apagar dados da tabela --

-------------------------------------- DML Linguagem de Manipulação de dados -------------------------------
SELECT * FROM Estilos;
SELECT * FROM Albuns;
SELECT * FROM Artistas;
SELECT * FROM Usuarios;
SELECT * FROM TipoUsuario;

-- Comando de Inserir dados --
INSERT INTO Estilos (Nome)
VALUES ('Rock'),('Pop');

INSERT INTO Artistas (Nome)
VALUES ('Pink Floyd'),('Imagine Dragons');

-- Inserir com chaves estrangeiras --
INSERT INTO Albuns (Nome, IdArtista, IdEstilo)
VALUES ('Mais Feliz', 1, 1),
       ('Encanto', 2, 2),
	   ('Menos é Mais', 3, 3),
	   ('Wish You Were Here', 4, 4),
	   ('Origins', 5, 5);

INSERT INTO Usuarios (Nome, IdTipoUsuario)
VALUES ('Dioguera', 2),
	   ('Erick', 2);

INSERT INTO TipoUsuario (Nome)
VALUES ('Administrador'),
       ('Usuário');

-- Deletar dados --
DELETE FROM Albuns
WHERE IdAlbum = 2;

-- Limpar todos os dados da tabela --
TRUNCATE TABLE Estilos;

-- Alterar um dado da tabela --
UPDATE Artistas
SET Nome = 'Zeca Pagode'
WHERE IdArtista = 1;

-- Selecionar os albuns do mesmo artista --
SELECT * FROM Albuns WHERE IdArtista = 3;

-- Usando INNER JOIN (Junção de duas ou mais tabelas) --
SELECT Artistas.Nome, Albuns.Nome FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtista = Albuns.IdArtista
WHERE Albuns.IdArtista = 3;

-- Apenas exemplo: Selecionar os albuns lançados na mesma data --
SELECT * FROM Albuns WHERE DataLancamento = '2020-01-23'
GO

-- INNER JOIN --
SELECT * FROM Artistas
INNER JOIN  Albuns ON Artistas.IdArtista = Albuns.IdArtista
WHERE DataLancamento = '2020-01-23';

-- Selecionar albuns e artistas e ordenar por data de lancamento (Antigo para o mais recente) --
-- ASC: Ordem crescente --
-- DESC: Ordem decrescente --
SELECT * FROM Albuns ORDER BY DataLancamento ASC;

-- INNER JOIN --
SELECT Artistas.Nome AS NomeArtista, Albuns.Nome AS NomeAlbum, Albuns.DataLancamento
FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtista = Albuns.IdArtista
ORDER BY DataLancamento ASC;

-- Selecionar artistas com o mesmo estilo musical --
SELECT IdArtista, IdEstilo FROM Albuns WHERE IdEstilo = 3;

-- INNER JOIN --
SELECT Artistas.Nome AS NomeArtista, Estilos.Nome AS NomeEstilo, Albuns.Nome AS NomeAlbum
FROM Albuns
INNER JOIN Artistas ON Artistas.IdArtista = Albuns.IdArtista
INNER JOIN Estilos ON Estilos.IdEstilo = Albuns.IdEstilo;