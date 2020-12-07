--Abrir la base de datos
USE GestionCitas
GO

-- ** Procedimiento Almacenado para Verificar las credenciales de un usuario
CREATE PROCEDURE spValidarAcceso
@Usuario nvarchar(50),
@Clave nvarchar(50)
AS
BEGIN
	SELECT *
		FROM Perfil
		WHERE Correo=@Usuario
		AND Clave=HASHBYTES('SHA1',@Clave)

END
GO

exec spValidarAcceso 'frayosorio@gmail.com','123'


CREATE VIEW vwPerfil
AS
	SELECT P.*, S.Sexo Sexo, SI.Sexo SexoInteres, PS.Pais, E.Educacion, C.Contextura, CI.Contextura ContexturaInteres
		FROM Perfil P
			JOIN Sexo S ON P.IdSexo=S.Id
			JOIN Sexo SI ON P.IdSexoInteres=SI.Id
			JOIN Pais PS ON P.IdPais=PS.Id
			JOIN Educacion E ON P.IdEducacion=E.Id
			JOIN Contextura C ON P.IdContextura=C.Id
			JOIN Contextura CI ON P.IdContexturaInteres=CI.Id
GO

EXEC spObtenerPerfil 1
CREATE PROCEDURE spObtenerPerfil
@Id int
AS 
BEGIN
	SELECT *
		FROM vwPerfil
		WHERE Id=@Id
END
GO

CREATE PROCEDURE spObtenerPerfilEmail 
@Email varchar(50)
AS 
  BEGIN 
   SELECT * FROM vwPerfil where Correo=@Email
END

GO
CREATE PROCEDURE spObtenerFoto
@Id int
AS 
BEGIN
	SELECT Foto
		FROM vwPerfil
		WHERE Id=@Id
END
GO

CREATE PROCEDURE spListarPerfilAficion
@IdPerfil int
AS BEGIN
	SELECT A.*
		FROM PerfilAficion PA
			JOIN Aficion A ON A.Id=PA.IdAficion 
		WHERE IdPerfil=@IdPerfil
		ORDER BY Aficion
END
GO

EXEC spListarPerfilAficion 1
CREATE PROCEDURE spObtenerImagenAficion
@IdPerfil int,
@IdAficion int
AS 
BEGIN
	SELECT Foto
		FROM PerfilAficion
		WHERE IdPerfil=@IdPerfil
			AND IdAficion=@IdAficion
END
GO

CREATE PROCEDURE spListarPerfilLugar
@IdPerfil int
AS BEGIN
	SELECT L.*, PL.Conocido
		FROM PerfilLugar PL
			JOIN Lugar L ON L.Id=PL.IdLugar
		WHERE IdPerfil=@IdPerfil
		ORDER BY Lugar
END
GO
EXEC spListarPerfilLugar 1
CREATE PROCEDURE spObtenerImagenLugar
@IdPerfil int,
@IdLugar int
AS 
BEGIN
	SELECT Foto
		FROM PerfilLugar
		WHERE IdPerfil=@IdPerfil
			AND IdLugar=@IdLugar
END
GO