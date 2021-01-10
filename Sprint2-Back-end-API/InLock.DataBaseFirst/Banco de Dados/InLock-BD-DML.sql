USE InLock_Games_Tarde;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
       ('Cliente');

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('cliente@cliente.com', 'cliente', 2),
       ('admin@admin.com', 'admin', 1);

INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizzard'),
       ('Rockstar Studios'),
	   ('Square Enix');

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja 
        voc� um novato ou um f�', '15/05/2012', 99.00, 1),
	   ('Red Dead Redemption', 'Jogo eletr�nico de a��o-aventura western',
	    '26/10/2018', 120.00, 2);

SELECT * FROM TipoUsuario;
SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;