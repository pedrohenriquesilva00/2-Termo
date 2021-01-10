-----------------------------------------DQL---------------------------------------
-- Escolher banco que quero --
USE SpMedGroup_Tarde;

-- INNER JOIN --
-- Tabela Paciente(Prontu�rio) relacionada com a tabela Consulta --
SELECT Usuario.NomeUsuario, Paciente.DataNascimento, Paciente.Telefone, Paciente.RG, Paciente.CPF, Paciente.Endereco, Consulta.DataConsulta, Consulta.Situacao
FROM Consulta
INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Usuario ON Paciente.IdUsuario = Usuario.IdUsuario

-- Tabela Paciente(Pront�rio) relacionada com as tabelas Consulta e Medico --
SELECT up.NomeUsuario AS Paciente, Paciente.DataNascimento, Paciente.Telefone, Paciente.RG, Paciente.CPF, um.NomeUsuario AS M�dico,Consulta.DataConsulta, Consulta.Situacao
FROM Consulta
INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Usuario up ON Paciente.IdUsuario = up.IdUsuario
INNER JOIN Usuario um ON Medico.IdUsuario = Um.IdUsuario

-- Tabela Medico relacionada com a tabelas Especialidade --
SELECT Medico.CRM, Usuario.NomeUsuario AS M�dico, Especialidade.Nome AS �rea
FROM Medico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Usuario ON Medico.IdUsuario = Usuario.IdUsuario

-- Tabela Medico relacionada com a tabela Clinica --
SELECT  Usuario.NomeUsuario AS M�dico, Medico.CRM, Clinica.NomeClinica AS Cl�nica, Clinica.RazaoSocial AS Raz�oSocial, Clinica.Endereco
FROM Medico
INNER JOIN Clinica ON Medico.IdClinica = Clinica.IdClinica
INNER JOIN Usuario ON Medico.IdUsuario = Usuario.IdUsuario

-- Func�o nativa do banco, quantidade de Usu�rios --
SELECT COUNT (IdUsuario) AS Usuarios FROM Usuario

-- Data de nascimento no formato correto --
SELECT Paciente.IdUsuario, Paciente.IdPaciente, FORMAT (DataNascimento, 'dd-MM-yyyy') AS DataNascimento FROM Paciente

-- retornar � quantidade de m�dicos de uma determinada especialidade --=
GO
CREATE FUNCTION Formacao (@IdEspecialidade INT)
RETURNS TABLE 
RETURN SELECT Medico.IdMedico, Usuario.NomeUsuario AS M�dico, Especialidade.IdEspecialidade,Especialidade.Nome AS �rea
FROM Medico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Usuario ON Medico.IdUsuario = Usuario.IdUsuario
WHERE @IdEspecialidade = Medico.IdEspecialidade
GO

SELECT * FROM Formacao (17);

-- Buscar idade dos Usu�rios --
GO
CREATE PROCEDURE BuscarIdade
As
SELECT DATEDIFF (YY, DataNascimento, GETDATE()) AS Idade
FROM Paciente
BuscarIdade
GO

-- Consultar dados das tabelas criadas --
SELECT * FROM TipoUsuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Usuario;
SELECT * FROM Paciente;
SELECT * FROM Medico;
SELECT * FROM Consulta;

