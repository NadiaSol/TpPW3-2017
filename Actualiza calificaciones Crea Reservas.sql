  /*Crea reservas en distintos días*/
  SET IDENTITY_INSERT [20171C_TP].[dbo].[Reservas] ON
  INSERT INTO [20171C_TP].[dbo].[Reservas] ([IdReserva]
      ,[IdSede]
      ,[IdVersion]
      ,[IdPelicula]
      ,[FechaHoraInicio]
      ,[Email]
      ,[IdTipoDocumento]
      ,[NumeroDocumento]
      ,[CantidadEntradas]
      ,[FechaCarga])
	  VALUES (1,2,2,3,'2017/05/27 11:00:00','juana@live.com',1,'33.444.555',2,'2017/05/26 15:00:00')
INSERT INTO [20171C_TP].[dbo].[Reservas] ([IdReserva]
      ,[IdSede]
      ,[IdVersion]
      ,[IdPelicula]
      ,[FechaHoraInicio]
      ,[Email]
      ,[IdTipoDocumento]
      ,[NumeroDocumento]
      ,[CantidadEntradas]
      ,[FechaCarga])
VALUES (2,2,1,3,'2017/05/28 11:00:00','carlos@yahoo.com',1,'44.444.555',2,'2017/05/27 15:00:00')
  INSERT INTO [20171C_TP].[dbo].[Reservas] ([IdReserva]
      ,[IdSede]
      ,[IdVersion]
      ,[IdPelicula]
      ,[FechaHoraInicio]
      ,[Email]
      ,[IdTipoDocumento]
      ,[NumeroDocumento]
      ,[CantidadEntradas]
      ,[FechaCarga])
	  VALUES (3,2,2,3,'2017/05/28 11:00:00','juana@live.com',1,'25.444.885',2,'2017/05/26 15:00:00')
INSERT INTO [20171C_TP].[dbo].[Reservas] ([IdReserva]
      ,[IdSede]
      ,[IdVersion]
      ,[IdPelicula]
      ,[FechaHoraInicio]
      ,[Email]
      ,[IdTipoDocumento]
      ,[NumeroDocumento]
      ,[CantidadEntradas]
      ,[FechaCarga])
VALUES (4,2,1,3,'2017/05/29 11:00:00','carlos@yahoo.com',1,'18.458.555',2,'2017/05/27 15:00:00')
  SET IDENTITY_INSERT [20171C_TP].[dbo].[Reservas] OFF
/*Actualiza fechas que estaban mal cargadas en la query anterior*/
UPDATE [20171C_TP].[dbo].Carteleras SET FechaInicio='2017/05/25',FechaFin='2017/05/31',FechaCarga='2017/05/25 09:00:00' WHERE IdCartelera IN (1,2,3,4)

 /*Actualiza calificaciones según lo pedido en el enunciado del TP*/
UPDATE [20171C_TP].[dbo].Calificaciones SET Nombre='Mayores de 13' WHERE IdCalificacion=2
UPDATE [20171C_TP].[dbo].Calificaciones SET Nombre='Mayores de 16' WHERE IdCalificacion=3
UPDATE [20171C_TP].[dbo].Calificaciones SET Nombre='Mayores de 16 con Reserva' WHERE IdCalificacion=4
SET IDENTITY_INSERT [20171C_TP].[dbo].[Calificaciones] ON
INSERT INTO [20171C_TP].[dbo].Calificaciones (IdCalificacion,Nombre) VALUES(5,'Mayores de 13 con Reserva')
SET IDENTITY_INSERT [20171C_TP].[dbo].[Calificaciones] OFF