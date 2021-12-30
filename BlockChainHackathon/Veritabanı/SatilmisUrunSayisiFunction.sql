Create function SatilmisUrunSayisi(@UserID int)
returns int 
as 
  begin
     Declare @sayac int
	 select @sayac =COUNT (SoldID) from Solds
	 where UserID=@UserID
	 return @sayac
  end