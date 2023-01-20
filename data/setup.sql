CREATE DATABASE WebApiDB;
GO
USE WebApiDB;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

insert [ProductType] ([Id],[Name])
select '070e30e7-488b-47e3-ad28-4379b9be6185','Food' UNION ALL
select '74ca9e4c-2f51-4bfb-8ee0-12efe0db187f','Furniture' UNION ALL
select 'b00db9eb-7650-4878-b814-8a96d5a8220e','Books' UNION ALL
select 'd6d124a9-df5b-4ae8-848d-d15bb33bbd19','Toys' UNION ALL
select 'f30e74cd-2494-4fc8-8eb3-8de05c4a821e','Electronics';

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [real] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ProductTypeId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [IX_Product_ProductTypeId] ON [dbo].[Product]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType_ProductTypeId]
GO

insert [Product] ([Id],[Name],[Price],[IsActive],[ProductTypeId])
select '50909b94-5134-4392-be80-13bcccd2086c','Pizza',15,1,'070e30e7-488b-47e3-ad28-4379b9be6185' UNION ALL
select '7a852c93-ca4f-4ab5-84ac-c8b70927506e','Lego',30,1,'d6d124a9-df5b-4ae8-848d-d15bb33bbd19' UNION ALL
select '7caba613-eaa2-4c83-9d47-97b438169f95','Chair',25,1,'74ca9e4c-2f51-4bfb-8ee0-12efe0db187f' UNION ALL
select 'cf994cb1-dc3c-4822-93f7-a7422a016ca9','Microwave',30,1,'f30e74cd-2494-4fc8-8eb3-8de05c4a821e' UNION ALL
select 'f6095b43-57f1-49a7-9acf-ac3d145fef4f','Don Quixote',12,1,'b00db9eb-7650-4878-b814-8a96d5a8220e';