-----------------------------------------DDL---------------------------------------
-- Criar banco de dados --
CREATE DATABASE SpMedGroup_Tarde;

-- Caso necessário, apaga o Banco de Dados --
DROP DATABASE SpMedGroup_Tarde;

-- Escolher banco que quero --
USE SpMedGroup_Tarde;

-- Criar tabelas --
CREATE TABLE TipoUsuario (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	Titulo				VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Especialidade (
	IdEspecialidade		INT PRIMARY KEY IDENTITY,
	Nome				VARCHAR (255) NOT  NULL
);

CREATE TABLE Clinica (
	IdClinica			INT PRIMARY KEY IDENTITY,
	NomeClinica			VARCHAR (255) NOT NULL,
	CNPJ				VARCHAR (255) NOT NULL,
	RazaoSocial			VARCHAR (255) NOT NULL,
	Endereco			VARCHAR (255) NOT NULL
);

-- Criar tabelas com chave estrangeira --
CREATE TABLE Usuario (
	IdUsuario			INT PRIMARY KEY IDENTITY,
	NomeUsuario			VARCHAR (255) NOT NULL,
	Email			    VARCHAR (255) NOT NULL UNIQUE,
	Senha				VARCHAR (255) NOT NULL,
	IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
);

CREATE TABLE Paciente (
	IdPaciente			INT PRIMARY KEY IDENTITY,
	DataNascimento		DATE NOT NULL,
	Telefone			VARCHAR (255),
	RG					VARCHAR (10) NOT NULL UNIQUE,
	CPF					VARCHAR (11) NOT NULL UNIQUE,
	Endereco			VARCHAR (255),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);



CREATE TABLE Medico (
	IdMedico			INT PRIMARY KEY IDENTITY,
	CRM					VARCHAR (255) NOT NULL,
	IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidade (IdEspecialidade),
	IdClinica			INT FOREIGN KEY REFERENCES Clinica (IdClinica),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

CREATE TABLE Consulta (
	IdConsulta			INT PRIMARY KEY IDENTITY,
	DataConsulta		DATETIME2 NOT NULL,
	Situacao			VARCHAR (255) NOT NULL,
	IdPaciente			INT FOREIGN KEY REFERENCES Paciente (IdPaciente),
	IdMedico			INT FOREIGN KEY REFERENCES Medico (IdMedico),
	IdClinica			INT FOREIGN KEY REFERENCES Clinica (IdClinica)
);

-- Consultar dados das tabelas criadas --
SELECT * FROM TipoUsuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Usuario;
SELECT * FROM Paciente;
SELECT * FROM Medico;
SELECT * FROM Consulta;