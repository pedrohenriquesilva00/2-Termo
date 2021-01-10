-----------------------------------------DDL---------------------------------------
-- Criar banco de dados --
CREATE DATABASE Gufi_Tarde;

-- Escolher o banco que quero --
USE Gufi_Tarde;

DROP DATABASE Gufi_Tarde;

-- Criar tabelas --
CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	TituloTipo		VARCHAR (200) NOT NULL UNIQUE
);

CREATE TABLE TipoEvento (
	IdTipoEvento	INT PRIMARY KEY IDENTITY,
	TituloTipo		VARCHAR (200) NOT NULL UNIQUE
);

CREATE TABLE Instituicao (
	IdInstituicao	INT PRIMARY KEY IDENTITY,
	CNPJ			CHAR(14) NOT NULL UNIQUE,
	NomeFantasia	VARCHAR (200) NOT NULL UNIQUE,
	Endereco		VARCHAR (200) NOT NULL UNIQUE
);

-- Criar tabelas com chave estrangeira --
CREATE TABLE Usuario (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	NomeUsuario		VARCHAR (200) NOT NULL,
	Email			VARCHAR (200) NOT NULL UNIQUE,
	Senha			VARCHAR (200) NOT NULL,
	Genero			VARCHAR (200) NOT NULL,
	DataNascimento	DATETIME2 NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE Evento (
	IdEvento		INT PRIMARY KEY IDENTITY,
	NomeEvento		VARCHAR (200) NOT NULL,
	DataEvento		DATETIME2 NOT NULL,
	Descricao		VARCHAR (200) NOT NULL,
	AcessoLivre		BIT DEFAULT (1) NOT NULL,
	IdInstituicao	INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao),
	IdTipoEvento	INT FOREIGN KEY REFERENCES TipoEvento (IdTipoEvento)
);

CREATE TABLE Presenca (
	IdPresenca		INT PRIMARY KEY IDENTITY,
	IdUsuario		INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdEvento		INT FOREIGN KEY REFERENCES Evento (IdEvento),
	Situacao		VARCHAR (200) NOT NULL
);

-- Visualizar as tabelas e os dados --
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;