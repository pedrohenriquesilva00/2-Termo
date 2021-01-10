----------------------------------DML----------------------------------------
-- Escolher Banco que quero --
USE T_Peoples;

-- Inserir dados no Banco --
INSERT INTO Funcionarios (Nome, Sobrenome)
VALUES	('Catarina', 'Strada')
	    ,('Tadeu', 'Vitelli')
GO

INSERT INTO TipoUsuario (Titulo)
VALUES	('Administrador'),
		('Comum')
GO

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES	('adm@email.com', 'adm123', 1),
		('pedro@email.com', 'pedro123', 2)
GO

UPDATE Funcionarios
SET DataNascimento = '13/04/1993'
WHERE IdFuncionario = 1;

SELECT * FROM Funcionarios;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuarios;