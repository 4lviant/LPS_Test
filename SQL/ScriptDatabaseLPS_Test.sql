USE [master]
GO
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'[NamaDatabase]', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'[NamaDatabase]_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

Use [Test]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama_barang] [varchar](200) NOT NULL,
	[kode_barang] [varchar](50) NOT NULL,
	[jumlah_barang] [int] NOT NULL,
	[tanggal] [datetime] NOT NULL,
 CONSTRAINT [PK_produk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: allfian nugraha
-- Create date: 3-10-2023
-- Description:	Delete produk
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Produk](@id int)
	
AS
BEGIN
	delete from produk where id=@id

	--check data
	select * from produk where id=@id
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: allfian nugraha
-- Create date: 3-10-2023
-- Description:	Find produk
-- =============================================
CREATE PROCEDURE [dbo].[Find_Produk](@namabarang varchar(200))
	
AS
BEGIN
	select * from produk where nama_barang like '%' +@namabarang+'%'
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: allfian nugraha
-- Create date: 3-10-2023
-- Description:	Find produk
-- =============================================
CREATE PROCEDURE [dbo].[Find_ProdukbyId](@id int)
	
AS
BEGIN
	select * from produk where Id=@id
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: allfian nugraha
-- Create date: 3-10-2023
-- Description:	insert produk
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Produk](@namabarang varchar(200), @kodebarang varchar(50),@jmlbarang int, @tgl datetime)
	
AS
BEGIN
	insert into produk (nama_barang,kode_barang,jumlah_barang,tanggal) values (@namabarang,@kodebarang,@Jmlbarang,@tgl)
	--checking data
	declare @id int = scope_identity();
	select * from produk where id=@id
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: allfian nugraha
-- Create date: 3-10-2023
-- Description:	update produk
-- =============================================
CREATE PROCEDURE [dbo].[Update_Produk](@id int,@namabarang varchar(200), @kodebarang varchar(50),@Jmlbarang int, @tgl datetime)
	
AS
BEGIN
	update produk set nama_barang=@namabarang,kode_barang=@kodebarang,jumlah_barang=@Jmlbarang,tanggal=@tgl where id=@id
--check data
select * from produk where id =@id
END
