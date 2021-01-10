-- Comentário --
-- Criar banco de dados --
CREATE DATABASE Biblioteca_Tarde;

-- Apontar para o banco que quero usar --
USE Biblioteca_Tarde;

-- Criar Tabelas --
CREATE TABLE Autores (
	IdAutor     INT PRIMARY KEY IDENTITY,
	NomeAutor   VARCHAR (200) NOT NULL
);

CREATE TABLE Generos (
	IdGenero	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR (200)
);

CREATE TABLE Livros (
	IdLivro		INT PRIMARY KEY IDENTITY,
	Titulo		VARCHAR (255),
	IdAutor		INT FOREIGN KEY REFERENCES Autores (IdAutor),
	IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

-- Visualizar tabelas criadas --
SELECT * FROM Generos;
SELECT * FROM Autores;
SELECT * FROM Livros;

-- Excluir tabela --
DROP TABLE Livros;
DROP TABLE Generos;
DROP TABLE Autores;

-- Excluir banco de dados --
DROP DATABASE Biblioteca_Tarde;

-- DML Linguagem de Manipulação de dados --

INSERT INTO Generos (Nome)
VALUES ('Ficção'),('Autobiografia'), ('Drama'), ('Romance'), ('Suspense');

INSERT INTO Autores (NomeAutor)
VALUES ('Ray Bradbury'),('Anne Frank'), ('Khaled Hosseini'), ('John Green'), ('Richard Matheson');

INSERT INTO Livros (Titulo, IdAutor, IdGenero)
VALUES ('Fahrenheit 451', 1, 1),
       ('Diário de Anne Frank', 2, 2),
	   ('O Caçador de Pipas', 3, 3),
	   ('A Culpa É das Estrelas', 4, 4),
	   ('I Am Legend', 5, 5);