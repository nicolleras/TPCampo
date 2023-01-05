USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[EMPRESA_PROVEEDORA]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPRESA_PROVEEDORA](
	[IdEmpresaProveedora] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Logo] [varchar](20) NULL,
	[CalificacionPromedio] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpresaProveedora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].EMPRESA_PROVEEDORA ON 
GO
SET IDENTITY_INSERT [dbo].EMPRESA_PROVEEDORA OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarEmpresaProveedora]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarEmpresaProveedora](
@IdEmpresaProveedora int,
@Nombre varchar(50),
@Logo varchar(50),
@CalificacionPromedio varchar(50)
)
as
begin
	update [dbo].[EMPRESA_PROVEEDORA] set Nombre = @Nombre, Logo = @Logo, CalificacionPromedio = @CalificacionPromedio where IdEmpresaProveedora = @IdEmpresaProveedora
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEmpresaProveedora]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarEmpresaProveedora](
@IdEmpresaProveedora int
)
as
begin
	delete from [dbo].[EMPRESA_PROVEEDORA] where IdEmpresaProveedora = @IdEmpresaProveedora
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpresaProveedora]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetEmpresaProveedora](
@IdEmpresaProveedora int
)
as
begin
	select * from [dbo].[EMPRESA_PROVEEDORA] where IdEmpresaProveedora = @IdEmpresaProveedora
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarEmpresaProveedora]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarEmpresaProveedora](
@Nombre varchar(50),
@Logo varchar(50),
@CalificacionPromedio varchar(50)
)
as
begin
	insert into [dbo].[EMPRESA_PROVEEDORA](Nombre,Logo,CalificacionPromedio) values (@Nombre,@Logo,@CalificacionPromedio)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarEmpresasProveedoras]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarEmpresasProveedoras]
as
begin
	select * from [dbo].[EMPRESA_PROVEEDORA]
	end
GO