Create trigger TriggerGuncelle on Sells
instead of update 
as
Update Sells set GuncellemeGirisimi = GETDATE()