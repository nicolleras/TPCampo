USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Contraseña] [varchar](500) NULL,
	[Rol] [varchar](20) NULL,
	[FechaNacimiento] [varchar](20) NULL,
	[TipoDocumento] [varchar](50) NULL,
	[Dni] [int] NULL,
	[Telefono] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 
GO
INSERT [dbo].[USUARIO] ([IdUsuario], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [FechaNacimiento], [TipoDocumento], [Dni], [Telefono]) VALUES (1, N'Nicolas', N'Pavoni', N'npavoni10@gmail.com', N'hola', N'Administrador', N'10/10/1990', N'Dni', 405558, 221999)
GO
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarUsuario]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarUsuario](
@idUsuario int,
@Nombre varchar(20),
@Apellido varchar(20),
@Email varchar(100),
@Contraseña varchar(500),
@Rol varchar(20),
@FechaNacimiento varchar(20),
@TipoDocumento varchar(50),
@Dni int,
@Telefono bigint
)
as
begin
	update [dbo].[USUARIO] set Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Contraseña = @Contraseña, Rol = @Rol, FechaNacimiento = @FechaNacimiento, TipoDocumento = @TipoDocumento, Dni = @Dni, Telefono = @Telefono where IdUsuario = @idUsuario
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Eliminar](
@IdUsuario int
)
as
begin
	delete from [dbo].[USUARIO] where IdUsuario = @IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsuario]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetUsuario](
@idUsuario int
)
as
begin
	select * from [dbo].[USUARIO] where IdUsuario = @idUsuario
end

GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Guardar](
@Nombre varchar(20),
@Apellido varchar(20),
@Email varchar(100),
@Contraseña varchar(500),
@Rol varchar(20),
@FechaNacimiento varchar(20),
@TipoDocumento varchar(50),
@Dni int,
@Telefono bigint
)
as
begin
	insert into [dbo].[USUARIO](Nombre,Apellido,Email,Contraseña,Rol,FechaNacimiento,TipoDocumento,Dni,Telefono) values (@Nombre,@Apellido,@Email,@Contraseña,@Rol,@FechaNacimiento,@TipoDocumento,@Dni,@Telefono)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarUsuarios]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarUsuarios]
as
begin
	select * from [dbo].[USUARIO]
	end
GO


create procedure [dbo].[sp_RegistrarUsuario](
@Nombre varchar(20),
@Apellido varchar(20),
@Email varchar(100),
@Contraseña varchar(500),
@Rol varchar(20),
@FechaNacimiento varchar(20),
@TipoDocumento varchar(50),
@Dni int,
@Telefono bigint,
@Registrado bit output,
@Mensaje varchar(100) output

)
as
begin
	if(not exists(select*from [dbo].[USUARIO] where Email= @Email))
	begin
		insert into [dbo].[USUARIO](Nombre,Apellido,Email,Contraseña,Rol,FechaNacimiento,TipoDocumento,Dni,Telefono) values (@Nombre,@Apellido,@Email,@Contraseña,@Rol,@FechaNacimiento,@TipoDocumento,@Dni,@Telefono)
		set @Registrado = 1
		set @Mensaje = 'Usuario registrado'
	end
	else
	begin
		set @Registrado = 0 
		set @Mensaje='El email ya existe'
	end
end
GO

create procedure [dbo].[sp_ValidarUsuario](
@Email varchar(100),
@Contraseña varchar(500)
)
as
begin
	if(exists(select * from [dbo].[USUARIO] where Email= @Email and Contraseña=@Contraseña))
		select IdUsuario from [dbo].[USUARIO] where Email= @Email and Contraseña=@Contraseña
	else
		select '0'
end
GO