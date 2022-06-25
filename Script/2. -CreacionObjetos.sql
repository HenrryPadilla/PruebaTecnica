USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [app_albatroslab]    Script Date: 25/6/2022 15:25:59 ******/
CREATE LOGIN [app_albatroslab] WITH PASSWORD=N'zhhonmvZm7HIUQ2S9Js2SvmdFa/vR8ROP0odfNsREDE=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [app_albatroslab] DISABLE
GO
USE [AlbatrosLab]
GO
/****** Object:  User [app_albatroslab]    Script Date: 25/6/2022 15:19:12 ******/
CREATE USER [app_albatroslab] FOR LOGIN [app_albatroslab] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [app_albatroslab]
GO
ALTER ROLE [db_datareader] ADD MEMBER [app_albatroslab]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [app_albatroslab]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 25/6/2022 15:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[codigo_Cliente] [varchar](15) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[rtn] [varchar](16) NOT NULL,
	[direccion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[codigo_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fac_Detalle]    Script Date: 25/6/2022 15:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fac_Detalle](
	[No_Registro] [int] IDENTITY(1,1) NOT NULL,
	[No_Factura] [int] NOT NULL,
	[codigo_Producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[id_Impuesto] [int] NOT NULL,
	[precio_total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Fac_Detalle] PRIMARY KEY CLUSTERED 
(
	[No_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fac_Encabezado]    Script Date: 25/6/2022 15:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fac_Encabezado](
	[No_Factura] [int] IDENTITY(1,1) NOT NULL,
	[codigo_Cliente] [varchar](15) NOT NULL,
	[fecha_Factura] [datetime] NOT NULL,
	[total_Impuesto] [decimal](18, 2) NOT NULL,
	[total_Factura] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Fac_Encabezado] PRIMARY KEY CLUSTERED 
(
	[No_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuesto]    Script Date: 25/6/2022 15:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuesto](
	[id_Impuesto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_Impuesto] [varchar](5) NOT NULL,
	[porcentaje_Impuesto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Impuesto] PRIMARY KEY CLUSTERED 
(
	[id_Impuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/6/2022 15:19:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[codigo_Producto] [int] NOT NULL,
	[descripcion] [varchar](70) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[id_Impuesto] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[codigo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([codigo_Cliente], [nombre], [rtn], [direccion]) VALUES (N'0501199806755', N'Luis Suarez', N'05011998067551', N'Res Villa Las Aguas')
GO
INSERT [dbo].[Clientes] ([codigo_Cliente], [nombre], [rtn], [direccion]) VALUES (N'0501199806767', N'Henrry Mauricio Padilla Dominguez', N'05011998067671', N'Res Villa Los Geraneos Dos Caminos')
GO
INSERT [dbo].[Clientes] ([codigo_Cliente], [nombre], [rtn], [direccion]) VALUES (N'0501199806799', N'Cristhiano Ronaldooooo', N'05011998067991', N'Res Villa OTRA')
GO
SET IDENTITY_INSERT [dbo].[Fac_Detalle] ON 
GO
INSERT [dbo].[Fac_Detalle] ([No_Registro], [No_Factura], [codigo_Producto], [cantidad], [precio], [id_Impuesto], [precio_total]) VALUES (1, 1, 1, 1, CAST(1000.00 AS Decimal(18, 2)), 2, CAST(1100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Fac_Detalle] ([No_Registro], [No_Factura], [codigo_Producto], [cantidad], [precio], [id_Impuesto], [precio_total]) VALUES (2, 1, 2, 1, CAST(300.00 AS Decimal(18, 2)), 1, CAST(315.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Fac_Detalle] ([No_Registro], [No_Factura], [codigo_Producto], [cantidad], [precio], [id_Impuesto], [precio_total]) VALUES (3, 1, 3, 1, CAST(200.00 AS Decimal(18, 2)), 3, CAST(30.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Fac_Detalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Fac_Encabezado] ON 
GO
INSERT [dbo].[Fac_Encabezado] ([No_Factura], [codigo_Cliente], [fecha_Factura], [total_Impuesto], [total_Factura]) VALUES (1, N'0501199806767', CAST(N'2022-06-25T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(1645.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Fac_Encabezado] OFF
GO
SET IDENTITY_INSERT [dbo].[Impuesto] ON 
GO
INSERT [dbo].[Impuesto] ([id_Impuesto], [descripcion_Impuesto], [porcentaje_Impuesto]) VALUES (1, N'5%', CAST(0.05 AS Decimal(18, 2)))
GO
INSERT [dbo].[Impuesto] ([id_Impuesto], [descripcion_Impuesto], [porcentaje_Impuesto]) VALUES (2, N'10%', CAST(0.10 AS Decimal(18, 2)))
GO
INSERT [dbo].[Impuesto] ([id_Impuesto], [descripcion_Impuesto], [porcentaje_Impuesto]) VALUES (3, N'15%', CAST(0.15 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Impuesto] OFF
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (1, N'PC', CAST(1000.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (2, N'Teclado', CAST(900.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (3, N'Mouse', CAST(200.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (4, N'Mouse Inalambrico', CAST(250.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (5, N'Pantalla', CAST(700.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (6, N'Parlantes', CAST(900.00 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (7, N'USB', CAST(90.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[Producto] ([codigo_Producto], [descripcion], [precio], [id_Impuesto]) VALUES (8, N'CD', CAST(700.00 AS Decimal(18, 2)), 2)
GO
ALTER TABLE [dbo].[Fac_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Fac_Detalle_Fac_Encabezado] FOREIGN KEY([No_Factura])
REFERENCES [dbo].[Fac_Encabezado] ([No_Factura])
GO
ALTER TABLE [dbo].[Fac_Detalle] CHECK CONSTRAINT [FK_Fac_Detalle_Fac_Encabezado]
GO
ALTER TABLE [dbo].[Fac_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Fac_Detalle_impuesto] FOREIGN KEY([id_Impuesto])
REFERENCES [dbo].[Impuesto] ([id_Impuesto])
GO
ALTER TABLE [dbo].[Fac_Detalle] CHECK CONSTRAINT [FK_Fac_Detalle_impuesto]
GO
ALTER TABLE [dbo].[Fac_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Fac_Detalle_Producto] FOREIGN KEY([codigo_Producto])
REFERENCES [dbo].[Producto] ([codigo_Producto])
GO
ALTER TABLE [dbo].[Fac_Detalle] CHECK CONSTRAINT [FK_Fac_Detalle_Producto]
GO
ALTER TABLE [dbo].[Fac_Encabezado]  WITH CHECK ADD  CONSTRAINT [FK_Fac_Encabezado_Clientes] FOREIGN KEY([codigo_Cliente])
REFERENCES [dbo].[Clientes] ([codigo_Cliente])
GO
ALTER TABLE [dbo].[Fac_Encabezado] CHECK CONSTRAINT [FK_Fac_Encabezado_Clientes]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Impuesto] FOREIGN KEY([id_Impuesto])
REFERENCES [dbo].[Impuesto] ([id_Impuesto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Impuesto]
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminaProductos]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Elimina productos en la tabla Productos>
-- =============================================
Create PROCEDURE [dbo].[usp_EliminaProductos]
@codigo_Producto int
AS
BEGIN
	 IF((SELECT COUNT(*) FROM [dbo].[Producto] WHERE codigo_Producto=@codigo_Producto)>0)
      BEGIN
         DELETE FROM [dbo].[Producto] WHERE [codigo_Producto]=@codigo_Producto
	  select 0 as Codigo
      END
   ELSE
      BEGIN
         
			select 1 as Codigo
      END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarClientes]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Elimian Clientes en la tabla Clientes>
-- =============================================
Create PROCEDURE [dbo].[usp_EliminarClientes]
@codigo_Cliente varchar(15),
@rtn varchar(16)
AS
BEGIN
	IF((SELECT COUNT(*) FROM [dbo].[Clientes] WHERE codigo_Cliente=@codigo_Cliente)=0 OR
	(SELECT COUNT(*) FROM [dbo].[Clientes] WHERE rtn=@rtn)=0) 
		BEGIN
			select 1 as Codigo
		END
   ELSE  
	   BEGIN
		   IF((SELECT COUNT(*) FROM [dbo].[Clientes] WHERE codigo_Cliente=@codigo_Cliente)>0 )
			  BEGIN
					DELETE [dbo].[Clientes]	WHERE[codigo_Cliente]=@codigo_Cliente
					select 0 as Codigo
			END
		ELSE
			if( (SELECT COUNT(*) FROM [dbo].[Clientes] WHERE rtn=@rtn)>0)
				BEGIN
					DELETE [dbo].[Clientes]	WHERE [rtn] = @rtn
					  select 0 as Codigo
			
				END
		END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GuardaClientes]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Guarda cleitnes en la tabla clientes>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GuardaClientes]
@codigo_Cliente varchar(15),
@nombre varchar(80),
@rtn varchar(16),
@direccion varchar(200)
AS
BEGIN
	 IF((SELECT COUNT(*) FROM [dbo].[Clientes] WHERE codigo_Cliente=@codigo_Cliente)>0 
	 or (SELECT COUNT(*) FROM [dbo].[Clientes] WHERE rtn=@rtn)>0)
      BEGIN
         select 1 as Codigo
      END
   ELSE
      BEGIN
         INSERT INTO [dbo].[Clientes]
           ([codigo_Cliente]
           ,[nombre]
           ,[rtn]
           ,[direccion])
     VALUES
           (@codigo_Cliente
           ,@nombre
           ,@rtn
           ,@direccion)
			select 0 as Codigo
      END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GuardaProductos]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Guarda productos en la tabla Productos>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GuardaProductos]
@codigo_Producto int,
@descripcion varchar(70),
@precio decimal(18,2),
@id_Impuesto int
AS
BEGIN
	 IF((SELECT COUNT(*) FROM [dbo].[Producto] WHERE codigo_Producto=@codigo_Producto)>0)
      BEGIN
         select 1 as Codigo
      END
   ELSE
      BEGIN
         INSERT INTO [dbo].[Producto]
           ([codigo_Producto]
           ,[descripcion]
           ,[precio]
           ,[id_Impuesto])
		 VALUES
           (@codigo_Producto,
		    @descripcion,
			@precio,
			@id_Impuesto)
			select 0 as Codigo
      END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModificaProductos]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<MOdifica productos en la tabla Productos>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ModificaProductos]
@codigo_Producto int,
@descripcion varchar(70),
@precio decimal(18,2),
@id_Impuesto int
AS
BEGIN
	 IF((SELECT COUNT(*) FROM [dbo].[Producto] WHERE codigo_Producto=@codigo_Producto)>0)
      BEGIN
         UPDATE [dbo].[Producto]
	  SET [descripcion] = @descripcion
      ,[precio] = @precio
      ,[id_Impuesto] = @id_Impuesto
	  WHERE [codigo_Producto]=@codigo_Producto
	  select 0 as Codigo
      END
   ELSE
      BEGIN
         
			select 1 as Codigo
      END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModificarClientes]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<MOdifica Clientes en la tabla Clientes>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ModificarClientes]
@codigo_Cliente varchar(15),
@nombre varchar(80),
@rtn varchar(16),
@direccion varchar(200)
AS
BEGIN
	IF((SELECT COUNT(*) FROM [dbo].[Clientes] WHERE codigo_Cliente=@codigo_Cliente)=0 OR
	(SELECT COUNT(*) FROM [dbo].[Clientes] WHERE rtn=@rtn)=0) 
		BEGIN
			select 1 as Codigo
		END
   ELSE  
	   BEGIN
		   IF((SELECT COUNT(*) FROM [dbo].[Clientes] WHERE codigo_Cliente=@codigo_Cliente)>0 )
			  BEGIN
					UPDATE [dbo].[Clientes]
						SET [nombre] = @nombre
					  ,[rtn] = @rtn 
					  ,[direccion] = @direccion
					WHERE[codigo_Cliente]=@codigo_Cliente
					select 0 as Codigo
			END
		ELSE
			if( (SELECT COUNT(*) FROM [dbo].[Clientes] WHERE rtn=@rtn)>0)
				BEGIN
					 UPDATE [dbo].[Clientes]
						SET [codigo_Cliente] = @codigo_Cliente
						  ,[nombre] = @nombre
						  ,[direccion] = @direccion
						WHERE [rtn] = @rtn
					  select 0 as Codigo
			
				END
		END
	  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ObtieneClientes]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Obtiene los CLIENTES parametrizados en la tabla CLIENTES>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ObtieneClientes]
	
AS
BEGIN
 SELECT * FROM [AlbatrosLab].[dbo].[Clientes]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ObtieneImpuestos]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Obtiene los impuestos parametrizados en la tabla Impuestos>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ObtieneImpuestos]
	
AS
BEGIN
	SELECT * FROM [AlbatrosLab].[dbo].[Impuesto]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ObtieneProductos]    Script Date: 25/6/2022 15:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Henrry Padilla>
-- Create date: <2022-06-25>
-- Description:	<Obtiene los productos parametrizados en la tabla Productos>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ObtieneProductos]
	
AS
BEGIN
 SELECT * FROM [AlbatrosLab].[dbo].[Producto]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK_Producto_id_Impuesto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Producto', @level2type=N'CONSTRAINT',@level2name=N'FK_Producto_Impuesto'
GO
