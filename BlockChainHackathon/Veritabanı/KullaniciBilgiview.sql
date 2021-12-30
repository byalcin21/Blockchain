create view KullaniciBilgi (ADI,SOYADI,TC,MAIL,PASSWORD)
as
select UserName,UserSurname,TCNumber,UserMail,UserPassword from Users