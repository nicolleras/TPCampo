USE [TPCampoDB]
GO
/****** Object:  Table [dbo].[PAGO]    Script Date: 3/11/2022 18:56:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAGO](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[MontoFinal] [float] NULL,
	[Estado] [varchar](12) NOT NULL CHECK (Estado IN('CONFIRMADO', 'RECHAZADO')),
	[ServicioPago] [varchar](14) NOT NULL CHECK (ServicioPago IN('PRISMA', 'MERCADO_PAGO', 'RAPIPAGO', 'PAGOFACIL')),
	[MedioPago] [varchar](10) NOT NULL CHECK (MedioPago IN('CREDITO', 'DEBITO', 'EFECTIVO')),
	[UltimosCuatro] [int] NULL,
	[Cuotas] [int] NULL,
	[CodigoBarras] [bigint] NULL,
	[Cvu] [bigint] NULL,
	[IdReserva] [int] NULL,
	CONSTRAINT fk_Reserva FOREIGN KEY (IdReserva) REFERENCES RESERVA (IdReserva),
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[sp_EditarPago]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EditarPago](
@IdPago int,
@MontoFinal float,
@Estado varchar(12),
@ServicioPago varchar(14),
@MedioPago varchar(10),
@UltimosCuatro int,
@Cuotas int,
@CodigoBarras bigint,
@Cvu bigint,
@IdReserva int
)
as
begin
	update [dbo].[PAGO] set MontoFinal = @MontoFinal, Estado = @Estado, ServicioPago = @ServicioPago, MedioPago = @MedioPago, UltimosCuatro = @UltimosCuatro, Cuotas = @Cuotas, CodigoBarras = @CodigoBarras, Cvu = @Cvu, IdReserva = @IdReserva where IdPago = @IdPago
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPago]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarPago](
@IdPago int
)
as
begin
	delete from [dbo].[PAGO] where IdPago = @IdPago
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPago]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetPago](
@IdPago int
)
as
begin
	select * from [dbo].[PAGO] where IdPago = @IdPago
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarPago]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GuardarPago](
@MontoFinal float,
@Estado varchar(12),
@ServicioPago varchar(14),
@MedioPago varchar(10),
@UltimosCuatro int,
@Cuotas int,
@CodigoBarras bigint,
@Cvu bigint,
@IdReserva int
)
as
begin
	insert into [dbo].[PAGO](MontoFinal,Estado,ServicioPago,MedioPago,UltimosCuatro,Cuotas,CodigoBarras,Cvu,IdReserva) values (@MontoFinal,@Estado,@ServicioPago,@MedioPago,@UltimosCuatro,@Cuotas,@CodigoBarras,@Cvu,@IdReserva)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPagos]    Script Date: 3/11/2022 18:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarPagos]
as
begin
	select * from [dbo].[PAGO]
	end
GO