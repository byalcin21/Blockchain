create procedure SatistakiAlanBilgi 
as
select U.Username, S.ServerIP,S.StorageSize,S.SellValue 
from Sells S join Users U 
on U.UserID=S.UserID
where S.State=1