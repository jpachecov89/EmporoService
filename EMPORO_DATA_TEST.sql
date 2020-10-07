USE EmporoDatabase
GO
DECLARE @hospitalId1 UNIQUEIDENTIFIER = NEWID()
INSERT INTO dbo.Hospital VALUES(@hospitalId1,'Loayza','Cercado de Lima')
DECLARE @hospitalId2 UNIQUEIDENTIFIER = NEWID()
INSERT INTO dbo.Hospital VALUES(@hospitalId2,'2 de Mayo','Alfonso Ugarte')

INSERT INTO dbo.Pharmacy VALUES(NEWID(),@hospitalId1,'MiSalud','Ovalo Santa Anita')
INSERT INTO dbo.Pharmacy VALUES(NEWID(),@hospitalId1,'MiFarma','Av Corregidor')
INSERT INTO dbo.Pharmacy VALUES(NEWID(),@hospitalId2,'InkaFarma','Av Ruiseñores')
INSERT INTO dbo.Pharmacy VALUES(NEWID(),@hospitalId2,'EsSalud','Jr. Leon Velarde')

INSERT INTO dbo.ItemVendor VALUES(NEWID(),'Química Suiza','Paseo La República')
INSERT INTO dbo.ItemVendor VALUES(NEWID(),'Bayern','Av. Alemania')