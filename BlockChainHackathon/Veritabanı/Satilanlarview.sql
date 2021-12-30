create view Satilanlar (SATICI,DEPOLAMA_ALANI,FÝYAT,DURUM)
as
select U.UserName,S.StorageSize,S.SellValue,S.State from Sells S Join Users U on U.UserID=S.UserID