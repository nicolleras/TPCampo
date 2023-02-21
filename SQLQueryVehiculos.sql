USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[VEHICULO]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICULO](
	[IdVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](20) NULL,
	[Modelo] [varchar](20) NULL,
	[Imagen] [varchar](200) NULL,
	[PrecioPorDia] [float] NULL,
	[CapacidadPasajeros] [varchar](50) NULL,
	[CapacidadEquipaje] [varchar](50) NULL,
	[TipoCaja] [varchar](50) NULL,
	[CantidadDePuertas] [int] NULL,
	[AireAcondicionado] [varchar](10) NULL,
	[TipoDeCobertura] [varchar](50) NULL,
	[KmHabilitado] [int] NULL,
	[IdEmpresaProveedora] [int] NULL,
	CONSTRAINT fk_EmpresaProveedora FOREIGN KEY (IdEmpresaProveedora) REFERENCES EMPRESA_PROVEEDORA (IdEmpresaProveedora), 
PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VEHICULO] ON 
GO
SET IDENTITY_INSERT [dbo].[VEHICULO] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarVehiculos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarVehiculo](
@idVehiculo int,
@Marca varchar(50),
@Modelo varchar(50),
@Imagen varchar(200),
@PrecioPorDia float,
@CapacidadPasajeros int,
@CapacidadEquipaje varchar(50),
@TipoCaja varchar(50),
@CantidadDePuertas varchar(50),
@AireAcondicionado varchar(10),
@TipoDeCobertura varchar(50),
@KmHabilitado int,
@IdEmpresaProveedora int
)
as
begin
	update [dbo].[VEHICULO] set Marca = @Marca, Modelo = @Modelo, Imagen = @Imagen, PrecioPorDia = @PrecioPorDia, CapacidadPasajeros = @CapacidadPasajeros, CapacidadEquipaje = @CapacidadEquipaje, TipoCaja = @TipoCaja, CantidadDePuertas = @CantidadDePuertas, AireAcondicionado = @AireAcondicionado, TipoDeCobertura = @TipoDeCobertura, KmHabilitado = @KmHabilitado, IdEmpresaProveedora = @IdEmpresaProveedora where IdVehiculo = @idVehiculo
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarVehiculos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarVehiculo](
@idVehiculo int
)
as
begin
	delete from [dbo].[VEHICULO] where IdVehiculo = @idVehiculo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetVehiculos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetVehiculo](
@idVehiculo int
)
as
begin
	select * from [dbo].[VEHICULO] where IdVehiculo = @idVehiculo
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarVehiculos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarVehiculo](
@Marca varchar(50),
@Modelo varchar(50),
@Imagen varchar(200),
@PrecioPorDia float,
@CapacidadPasajeros varchar(50),
@CapacidadEquipaje varchar(50),
@TipoCaja varchar(50),
@CantidadDePuertas int,
@AireAcondicionado varchar(10),
@TipoDeCobertura varchar(50),
@KmHabilitado int,
@IdEmpresaProveedora int
)
as
begin
	insert into [dbo].[VEHICULO](Marca, Modelo, Imagen, PrecioPorDia, CapacidadPasajeros, CapacidadEquipaje, TipoCaja, CantidadDePuertas, AireAcondicionado, TipoDeCobertura, KmHabilitado, IdEmpresaProveedora) values (@Marca,@Modelo,@Imagen,@PrecioPorDia,@CapacidadPasajeros,@CapacidadEquipaje,@TipoCaja,@CantidadDePuertas,@AireAcondicionado,@TipoDeCobertura,@KmHabilitado,@IdEmpresaProveedora)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarVehiculos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarVehiculos]
as
begin
	select * from [dbo].[VEHICULO]
	end
GO