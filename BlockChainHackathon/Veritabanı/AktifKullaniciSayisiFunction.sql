Create function AktifKullaniciSayisi(@State bit)
returns int
as 
  begin
     Declare @sayac int
	 select @sayac =COUNT (UserID) from Users
	 where State=@State
	 return @sayac
  end