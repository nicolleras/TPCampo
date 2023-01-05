USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[DOMICILIO]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOMICILIO](
	[IdDomicilio] [int] IDENTITY(1,1) NOT NULL,
	[Calle] [varchar](25) NULL,
	[Altura] [varchar](25) NULL,
	[Ciudad] [varchar](25) NULL,
	[Provincia] [varchar](25) NULL,
	[Pais] [varchar](25) NULL,
	[CodigoPostal] [int] NULL,
	[IdUsuario] [int] NULL,
	CONSTRAINT fk_UsuarioDomicilio FOREIGN KEY (IdUsuario) REFERENCES USUARIO (IdUsuario),

PRIMARY KEY CLUSTERED 
(
	[IdDomicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[sp_EditarDomicilio]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarDomicilio](
@IdDomicilio int,
@Calle varchar(25),
@Altura varchar(25),
@Ciudad varchar(25),
@Provincia varchar(25),
@Pais varchar(25),
@CodigoPostal int,
@IdUsuario int
)
as
begin
	update [dbo].[DOMICILIO] set Calle = @Calle, Altura = @Altura, Ciudad = @Ciudad, Provincia = @Provincia, Pais = @Pais, CodigoPostal = @CodigoPostal, IdUsuario = @IdUsuario where IdDomicilio = @IdDomicilio
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarDomicilio]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarDomicilio](
@IdDomicilio int
)
as
begin
	delete from [dbo].[DOMICILIO] where IdDomicilio = @IdDomicilio
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDomicilio]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetDomicilio](
@IdDomicilio int
)
as
begin
	select * from [dbo].[DOMICILIO] where IdDomicilio = @IdDomicilio
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarDomicilio]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarDomicilio](
@Calle varchar(25),
@Altura varchar(25),
@Ciudad varchar(25),
@Provincia varchar(25),
@Pais varchar(25),
@CodigoPostal int,
@IdUsuario int
)
as
begin
	insert into [dbo].[DOMICILIO](Calle,Altura,Ciudad,Provincia,Pais,CodigoPostal,IdUsuario) values (@Calle,@Altura,@Ciudad,@Provincia,@Pais,@CodigoPostal,@IdUsuario)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarDomicilios]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarDomicilios]
as
begin
	select * from [dbo].[DOMICILIO]
	end
GO