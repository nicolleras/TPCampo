USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[RESERVA]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[Destino] [varchar](50) NULL,
	[FechaInicio] [varchar](50) NULL,
	[FechaFin] [varchar](50) NULL,
	[Estado] [varchar](12) NOT NULL CHECK (Estado IN('PENDIENTE', 'CONFIRMADA')),
	[MontoTotal] [float] NULL,
	[IdVehiculo] [int] NULL,
	[IdUsuario] [int] NULL,
	CONSTRAINT fk_Vehiculo FOREIGN KEY (IdVehiculo) REFERENCES VEHICULO (IdVehiculo),
	CONSTRAINT fk_Usuario FOREIGN KEY (IdUsuario) REFERENCES USUARIO (IdUsuario),

PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[sp_EditarReserva]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarReserva](
@IdReserva int,
@Destino varchar(50),
@FechaInicio varchar(50),
@FechaFin varchar(50),
@Estado varchar(12),
@MontoTotal float,
@IdVehiculo int,
@IdUsuario int
)
as
begin
	update [dbo].[RESERVA] set Destino = @Destino, FechaInicio = @FechaInicio, FechaFin = @FechaFin, Estado = @Estado, MontoTotal = @MontoTotal, IdVehiculo = @IdVehiculo, IdUsuario = @IdUsuario where IdReserva = @IdReserva
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarReserva]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarReserva](
@IdReserva int
)
as
begin
	delete from [dbo].[RESERVA] where IdReserva = @IdReserva
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetReserva]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetReserva](
@IdReserva int
)
as
begin
	select * from [dbo].[RESERVA] where IdReserva = @IdReserva
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarReserva]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarReserva](
@Destino varchar(50),
@FechaInicio varchar(50),
@FechaFin varchar(50),
@Estado varchar(12),
@MontoTotal float,
@IdVehiculo int,
@IdUsuario int
)
as
begin
	insert into [dbo].[RESERVA](Destino,FechaInicio,FechaFin,Estado,MontoTotal,IdVehiculo,IdUsuario) values (@Destino,@FechaInicio,@FechaFin,@Estado,@MontoTotal,@IdVehiculo,@IdUsuario)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarReservas]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarReservas]
as
begin
	select * from [dbo].[RESERVA]
	end
GO