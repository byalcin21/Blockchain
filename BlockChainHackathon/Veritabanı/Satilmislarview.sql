create view Satilmislar (SATICI,ÖNCEKÝ_HASH,SONRAKÝ_HASH)
as
select U.UserName,S.PrevHash,S.LastHash from Solds S Join Users U on U.UserID=S.UserID