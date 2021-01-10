-- Criar banco de dados --
CREATE DATABASE Musical_Tarde;

-- Apontar para o banco que quero usar --
USE Musical_Tarde;

-- Criar tabelas --
CREATE TABLE Estilos_Musicais (
	IdEstilos		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (200)
);

CREATE TABLE Artistas (
	IdArtista		INT PRIMARY KEY IDENTITY,
	NomeAutor		VARCHAR (200),
	IdEstilos		INT FOREIGN KEY REFERENCES Estilos_Musicais (IdEstilos)
);

SELECT * FROM Estilos_Musicais;
SELECT * FROM Artistas;