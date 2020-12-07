USE GestionCitas
GO

UPDATE Perfil
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Perfil.jpg', SINGLE_BLOB) AS Imagen)
	WHERE Id=1

UPDATE Perfil
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Perfil2.jpg', SINGLE_BLOB) AS Imagen)
	WHERE Id=2

UPDATE Perfil
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Perfil3.jpg', SINGLE_BLOB) AS Imagen)
	WHERE Id=3

UPDATE PerfilAficion
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\InstrumentoMusical.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdAficion=14

UPDATE PerfilAficion
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Pintura.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdAficion=2

UPDATE PerfilLugar
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Amsterdam.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdLugar=1

UPDATE PerfilLugar
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Helsinki.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdLugar=2

UPDATE PerfilLugar
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Milan.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdLugar=3

UPDATE PerfilLugar
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Moscu.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdLugar=4

UPDATE PerfilLugar
	SET Foto=(SELECT * 
		FROM OPENROWSET(BULK 'C:\Fotos\Paris.jpg', SINGLE_BLOB) AS Imagen)
	WHERE IdPerfil=1 AND IdLugar=5