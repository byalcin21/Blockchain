Create function SatilanUrunSayisi(@UserID int)
returns int 
as 
  begin
         Declare @sayac int
	 select @sayac =COUNT (SellID) from Sells
	 where UserID=@UserID
	 return @sayac
  end