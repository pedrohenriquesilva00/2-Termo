----------------------------------DDL----------------------------------------
-- Criar Banco de dados --
CREATE DATABASE T_Peoples;

DROP DATABASE T_Peoples;

-- Escolher Banco que quero --
USE T_Peoples;

-- Criar tabelas do Banco de Dados --
CREATE TABLE Funcionarios (
	IdFuncionario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (255) NOT NULL,
	Sobrenome		VARCHAR (255) NOT NULL
);
GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Titulo			VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Usuarios (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	Email			VARCHAR(255) NOT NULL UNIQUE,
	Senha			VARCHAR(255) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)			
);
GO

ALTER TABLE Funcionarios
ADD DataNascimento	DATETIME;

SELECT * FROM Funcionarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuarios;