CREATE DATABASE Senatur_Tarde;

USE Senatur_Tarde;

DROP DATABASE Senatur_Tarde;

CREATE TABLE Pacotes(
	IdPacote	    INT PRIMARY KEY IDENTITY,
	NomePacote		VARCHAR (255) NOT NULL UNIQUE,
	Descricao       VARCHAR (1000),
	DataIda         DATE NOT NULL,
	DataVolta       DATE NOT NULL,
	Valor           DECIMAL (18,2),
	Ativo			BIT NOT NULL,
	NomeCidade      VARCHAR (255)
);

CREATE TABLE TiposUsuario (
	IdTipoUsuario			    INT PRIMARY KEY IDENTITY,
	Titulo						VARCHAR (255) NOT NULL 
);

CREATE TABLE Usuarios (
  IdUsuario			INT PRIMARY KEY IDENTITY,
  Email				VARCHAR (200) NOT NULL UNIQUE,
  Senha				VARCHAR(200) NOT NULL,
  IdTipoUsuario		INT FOREIGN  KEY REFERENCES TiposUsuario (IdTipoUsuario)
  );

