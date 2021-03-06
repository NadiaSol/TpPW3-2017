/****** Script for SelectTopNRows command from SSMS  ******/
/*VERSIONES*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Versiones ON 
INSERT INTO [20171C_TP].[dbo].[Versiones] (IdVersion,Nombre) VALUES (1,'Subtitulada')
INSERT INTO [20171C_TP].[dbo].[Versiones] (IdVersion,Nombre) VALUES (2,'Doblada')
INSERT INTO [20171C_TP].[dbo].[Versiones] (IdVersion,Nombre) VALUES (3,'3D Doblada')
SET IDENTITY_INSERT [20171C_TP].[dbo].Versiones OFF
/*GENEROS*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Generos ON
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (1,'Comedia')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (2,'Drama')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (3,'Thriller')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (4,'Infantil')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (5,'Terror')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (6,'Comedia Romántica')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (7,'Acción')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (8,'Aventura')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (9,'Suspenso')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (10,'Animación')
INSERT INTO [20171C_TP].[dbo].Generos (IdGenero,Nombre) VALUES (11,'Ciencia Ficción')
SET IDENTITY_INSERT [20171C_TP].[dbo].Generos OFF
/*Tipo Documento*/
SET IDENTITY_INSERT [20171C_TP].[dbo].TiposDocumentos ON
INSERT INTO [20171C_TP].[dbo].TiposDocumentos(IdTipoDocumento,Descripcion) VALUES (1,'DNI')
INSERT INTO [20171C_TP].[dbo].TiposDocumentos (IdTipoDocumento,Descripcion) VALUES (2,'Cédula')
INSERT INTO [20171C_TP].[dbo].TiposDocumentos (IdTipoDocumento,Descripcion) VALUES (3,'Pasaporte')
SET IDENTITY_INSERT [20171C_TP].[dbo].TiposDocumentos OFF
/*Calificación*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Calificaciones ON
INSERT INTO [20171C_TP].[dbo].Calificaciones (IdCalificacion,Nombre) VALUES (1,'ATP')
INSERT INTO [20171C_TP].[dbo].Calificaciones (IdCalificacion,Nombre) VALUES (2,'+13')
INSERT INTO [20171C_TP].[dbo].Calificaciones (IdCalificacion,Nombre) VALUES (3,'+16')
INSERT INTO [20171C_TP].[dbo].Calificaciones (IdCalificacion,Nombre) VALUES (4,'+18')
SET IDENTITY_INSERT [20171C_TP].[dbo].Calificaciones OFF
GO

/*Películas*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Peliculas ON
INSERT INTO 
[20171C_TP].[dbo].Peliculas(IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga)
VALUES (1,'Mujer Maravilla',
'Antes de ser Wonder Woman, era Diana, princesa de las Amazonas, entrenada para ser una guerrera invencible. Habiendo crecido en una apartada isla paradisíaca, cuando un piloto americano se estrella en sus orillas y le advierte de un conflicto masivo que sacude el mundo exterior, Diana abandona su hogar, convencida de que puede detener la amenaza. Luchando junto a los hombres en una guerra para acabar con todas las guerras, Diana descubrirá el alcance de su poder y su verdadero destino',
'~\img\mujer_maravilla.jpg',2,11,141,'2017/06/01 15:00:00')
INSERT INTO 
[20171C_TP].[dbo].Peliculas(IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga)
VALUES (2,'Alien Covenant',
'El equipo enviado a un remoto planeta en el extremo de la galaxia con la nave colonizadora: Covenant, descubre lo que aparenta ser un verdadero paraíso, pero es en realidad un peligroso mundo.',
'~\img\alien.jpg',3,5,125,'2017/06/01 15:00:00')
INSERT INTO 
[20171C_TP].[dbo].Peliculas(IdPelicula,Nombre,Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga)
VALUES (3,'Piratas del Caribe 5',
'El capitán Jack Sparrow se enfrentará a un grupo de piratas-fantasma comandados por una de sus viejos némesis, el terrorífico capitán Salazar, recién escapado del Triángulo de las Bermudas. La única posibilidad de Sparrow para salir con vida es encontrar el legendario Tridente de Poseidón, un poderoso artefacto que le da a su poseedor el control de los mares.',
'~\img\piratas.jpg',2,8,130,'2017/06/01 15:00:00')
SET IDENTITY_INSERT [20171C_TP].[dbo].Peliculas OFF
/*Sedes*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Sedes ON 
INSERT INTO [20171C_TP].[dbo].[Sedes](IdSede,Nombre,Direccion,PrecioGeneral) VALUES (1,'San Justo','Arieta 3220',97.50)
INSERT INTO [20171C_TP].[dbo].[Sedes](IdSede,Nombre,Direccion,PrecioGeneral) VALUES (2,'Ramos Mejía','Av. Rivadavia 13900',105)
INSERT INTO [20171C_TP].[dbo].[Sedes](IdSede,Nombre,Direccion,PrecioGeneral) VALUES (3,'Laferrere','Av. Luro 200',110.50)
SET IDENTITY_INSERT [20171C_TP].[dbo].Sedes OFF
/*Usuario ADMIN*/
SET IDENTITY_INSERT [20171C_TP].[dbo].Usuarios ON
INSERT INTO [20171C_TP].[dbo].Usuarios (IdUsuario,NombreUsuario,Password) VALUES(1,'admin','123')
SET IDENTITY_INSERT [20171C_TP].[dbo].Usuarios OFF

    UPDATE [20171C_TP].[dbo].Peliculas SET Imagen='/img/mujer_maravilla.jpg' WHERE IdPelicula=1
    UPDATE [20171C_TP].[dbo].Peliculas SET Imagen='/img/alien.jpg' WHERE IdPelicula=2
	UPDATE [20171C_TP].[dbo].Peliculas SET Imagen='/img/piratas.jpg' WHERE IdPelicula=3

SET IDENTITY_INSERT [20171C_TP].[dbo].Carteleras ON

  INSERT INTO [20171C_TP].[dbo].[Carteleras] 
  (IdCartelera,IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga)
  VALUES (1,2,3,10,'20170525','20170531',1,2,1,1,1,1,1,1,1,'20170525')
    SET IDENTITY_INSERT [20171C_TP].[dbo].Carteleras OFF
/*Nuevas Carteleras*/
  INSERT INTO Carteleras (IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga)
  values (2,3,10,'20170525','20170531',3,1,1,0,1,0,1,1,1,'20170525')
	  INSERT INTO Carteleras (IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga)
  values (3,3,10,'20170525','20170531',3,3,1,0,1,0,1,1,1,'20170525')

  USE [20171C_TP]
  GO

  SELECT * FROM Peliculas;

  DELETE FROM Peliculas WHERE IdPelicula = 1023;