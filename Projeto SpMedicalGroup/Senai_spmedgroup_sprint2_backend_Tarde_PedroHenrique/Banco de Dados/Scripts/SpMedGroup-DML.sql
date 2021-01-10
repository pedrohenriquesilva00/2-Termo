-----------------------------------------DML---------------------------------------
-- Escolher banco que quero --
USE SpMedGroup_Tarde;

-- Comandos para inserir dados nas tabelas --
INSERT INTO TipoUsuario (Titulo)
VALUES	('Administrador'),
		('Médico'),
		('Paciente')
GO

INSERT INTO Especialidade (Nome)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria')
GO

INSERT INTO Clinica (NomeClinica, CNPJ, RazaoSocial, Endereco)
VALUES ('Clinica Possarle', '86.400.902/0001-30', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP')
GO

INSERT INTO Usuario (NomeUsuario, Email, Senha, IdTipoUsuario)
VALUES ('Administrador', 'adm@adm.com', 'adm123', 1),
       ('Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123', 2),
	   ('Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', 'roberto123', 2),
	   ('Helena Strada', 'helena.souza@spmedicalgroup.com.br', 'helena123', 2),
	   ('Ligia', 'ligia@gmail.com', 'ligia123', 3),
	   ('Alexandre', 'alexandre@gmail.com', 'alexandre123', 3),
	   ('Fernando', 'fernando@gmail.com', 'fernando123', 3),
	   ('Henrique', 'henrique@gmail.com', 'henrique123', 3),
	   ('João', 'joao@hotmail.com', 'joao123', 3),
	   ('Bruno', 'bruno@gmail.com', 'bruno123', 3),
	   ('Mariana', 'mariana@outlook.com', 'mariana123', 3)
GO

INSERT INTO Paciente (IdUsuario, DataNascimento, Telefone, RG, CPF, Endereco)
VALUES (5, '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
	   (6, '23/07/2001', '11 98765-6543', '32654345-7', '7355694407', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
	   (7, '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927, São Paulo - SP, 04029-200'),
	   (8, '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila São Jorge, Barueri - SP, 06402-030'),
	   (9, '27/08/1975', '11 7656-6377', '32544444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
	   (10, '21/03/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
	   (11, '05/03/2018', '', '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140')
GO

INSERT INTO Medico (CRM, IdUsuario,IdEspecialidade, IdClinica)
VALUES ('54356-SP', 2, 2, 1),
	   ('53452-SP', 3, 17, 1),
	   ('65463-SP', 4, 16, 1)
GO

INSERT INTO Consulta (DataConsulta, Situacao, IdPaciente, IdMedico, IdClinica)
VALUES ('20/01/2020 15:00', 'Realizada', 7, 3, 1),
       ('06/01/2020 10:00', 'Cancelada', 2, 2, 1),
	   ('07/02/2020 11:00', 'Realizada', 3, 2, 1),
	   ('06/02/2018 10:00', 'Realizada', 2, 2, 1),
	   ('07/02/2019 11:00', 'Cancelada', 4, 1, 1),
	   ('08/03/2020 15:00', 'Agendada', 7, 3, 1),
	   ('09/03/2020 11:00', 'Agendada', 4, 1, 1)
GO

-- Consultar dados das tabelas criadas --
SELECT * FROM TipoUsuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Usuario;
SELECT * FROM Paciente;
SELECT * FROM Medico;
SELECT * FROM Consulta;