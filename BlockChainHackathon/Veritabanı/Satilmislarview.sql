create view Satilmislar (SATICI,�NCEK�_HASH,SONRAK�_HASH)
as
select U.UserName,S.PrevHash,S.LastHash from Solds S Join Users U on U.UserID=S.UserID