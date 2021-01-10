-----------------------------------------DQL---------------------------------------
-- Escolher banco que quero --
USE Gufi_Tarde;

-- Consulta de dados --
-- Listar todos os usu�rios cadastrados INNER JOIN --
SELECT Usuario.NomeUsuario AS Nome, Usuario.Email, Usuario.DataNascimento, Usuario.Genero AS G�nero, TipoUsuario.TituloTipo AS Logon
FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario

--Lista todas as Institui��es cadastradas --
SELECT * FROM Instituicao;

-- Lista todos os tipos de eventos --
SELECT * FROM TipoEvento;

-- Lista todos os eventos --
SELECT Evento.NomeEvento AS Nome, Evento.DataEvento AS Agendamento, Evento.Descricao, Evento.AcessoLivre, Instituicao.NomeFantasia AS Instituicao, TipoEvento.TituloTipo AS Tema 
FROM Evento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento

-- Lista todos os evento p�blicos --
SELECT CASE  WHEN AcessoLivre =  1  THEN  ' P�blico'  ELSE  ' Privado'  END  AS AcessoLivre, NomeEvento AS Nome, DataEvento, Descricao, Instituicao.NomeFantasia AS Instituicao, TipoEvento.TituloTipo AS Tema 
FROM Evento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento

-- Lista todos os eventos que um determinado usu�rio participa -- 
SELECT CASE  WHEN AcessoLivre =  1  THEN  ' P�blico'  ELSE  ' Privado'  END  AS Acesso, NomeUsuario AS Nome, Usuario.Email, TipoEvento.TituloTipo AS Tema, Evento.NomeEvento, Evento.Descricao,
                  Evento.DataEvento AS Dia, Instituicao.NomeFantasia AS Institui��o, Instituicao.Endereco, TipoUsuario.TituloTipo AS Logon, Presenca.Situacao
FROM Presenca
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento
INNER JOIN Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
WHERE Situacao = 'Confirmada'

-- Visualizar as tabelas e os dados --
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;