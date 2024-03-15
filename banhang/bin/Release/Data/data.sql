CREATE DATABASE QuanBanhang
GO

USE QuanBanhang
Go


CREATE TABLE TableFood
(
     id int identity primary key,
	 name1 nvarchar(100)  default N'Bản chưa có tên' not null,
	 stat nvarchar(100)  default N'Trống'  not null
)
GO

CREATE TABLE Dangnhap
(
    dlname  nvarchar(100)  default N'DQ' not null,
	usename  nvarchar(100) primary key,
	pw  nvarchar(1000) default 0 not null ,
	loai int  default 0 not null--1 là admin  0 la thanh vien

)
go

CREATE TABLE FoodCate
(
    id int identity primary key,
	 name1  nvarchar(100) default N'Chưa đặt tên'  not null

)
go

CREATE TABLE Food
(
    id int identity primary key,
    name1  nvarchar(100) default N'Chưa đặt tên'  not null,
    idcate int not null,
	gia float  default 0 not null

	foreign key(idcate) references  dbo.FoodCate(id)
)
go

CREATE TABLE Bill
(
    id int identity primary key,
    datein date default getdate()  not null,
	dateout date,
	idtable int not null,
	stat int  default 0 not null,
    giamgia int default 0 not null,
	tongtien float ,

	foreign key(idtable) references  dbo.TableFood(id),
)
go

CREATE TABLE Billist
(
    id int identity primary key,
    idbill int not null,
	idfool int not null,
	sl int default 0 not null 

	foreign key(idbill) references  dbo.Bill(id),
	foreign key(idfool) references  dbo.Food(id)
)
go

create table Thongke
(
 id int identity primary key, 
name1 nvarchar(100)  default N'Bản chưa có tên' not null,
 datein date default getdate()  not null,
dateout date,
giamgia int default 0 not null,
tongtien float default 0 
)
go


insert into Dangnhap 
values(  N'Quang', N'quang', N'123', 1),
	  (  N'staff1', N'staff1', N'123', 0),
	  (  N'Hanh', N'hanh', N'123', 1)

go

insert  TableFood (name1)
values( N'Bàn 1A'),
	  ( N'Bàn 2A'),
	  ( N'Bàn 3A'),
	  ( N'Bàn 4A'),
	  ( N'Bàn 5A'),
	  ( N'Bàn 1B'),
	  ( N'Bàn 2B'),
	  ( N'Bàn 3B'),
	  ( N'Bàn 4B'),
	  ( N'Bàn 5B')
go
create procedure pro_GetTableList
as select *from TableFood
go

create procedure pro_ThemBill
@idtable int
as
begin
   insert Bill(datein,dateout,idtable,stat,giamgia)
    values     (GETDATE(),null,@idtable,0,0)
end
go

create procedure pro_ThemBillist
@idbill int,@idfool int,@sl int
as
begin
   declare @isExitbillist int
   declare @foodcout int =0

   select @isExitbillist = id,@foodcout=bl.sl from Billist as bl where idbill=@idbill and idfool=@idfool

   if(@isExitbillist>0)
   begin
   declare @newsl int=@foodcout+@sl
   if(@newsl>0)
   update Billist set sl=@foodcout+@sl where idfool=@idfool and idbill=@idbill
   else 
   delete Billist where idbill=@idbill and idfool=@idfool
   end
   else
   begin
   insert Billist (idbill,idfool,sl)
   values         (@idbill,@idfool,@sl)
   end
end
go

create trigger tr_UpdateBillist
on Billist for insert,update
as
begin
  Declare @idbill int
  select  @idbill=idbill from inserted
  declare @idtable int
  select @idtable=idtable from Bill where id=@idbill and stat=0
  declare @sl int
  select @sl=COUNT(*) from Billist where idbill=@idbill
  if(@sl>0)
  update TableFood set stat=N'Có người' where id=@idtable
  else 
  update TableFood set stat=N'Trống' where id=@idtable
end
go


create trigger tr_UpdateBill
on Bill for update
as
begin
   Declare @idbill int
   select  @idbill=id from inserted
   declare @idtable int
   select @idtable=idtable from Bill where id=@idbill
   declare @sl int =0
   select @sl=COUNT(*) from Bill where idtable=@idtable and stat=0
   if(@sl=0)
   update TableFood set stat=N'Trống' where id=@idtable
end
go


create procedure USP_SwapTable
@idtable1 int,@idtable2 int
as begin 
declare @id1bill int
declare @id2bill int
declare @istable1 int =1
declare @istable2 int =1
select @id2bill= id from Bill where idtable =@idtable2 and stat = 0
select @id1bill= id from Bill where idtable =@idtable1 and stat = 0
 if(@id1bill is null)
begin
 insert Bill(datein,dateout,idtable,stat,giamgia)
    values     (GETDATE(),null,@idtable1,0,0)
	select @id1bill=MAX(id) from Bill where idtable =@idtable1 and stat = 0
end
   select @istable1= COUNT(*) from Billist  where idbill=@id1bill
 if(@id2bill is null)
begin
 insert Bill(datein,dateout,idtable,stat,giamgia)
    values     (GETDATE(),null,@idtable2,0,0)
	select @id2bill=MAX(id) from Bill where idtable =@idtable2 and stat = 0
end
 select @istable2= COUNT(*) from Billist  where idbill=@id2bill
 select id into idbillisttable from Billist where idbill=@id2bill
 update Billist set idbill=@id2bill where idbill=@id1bill
 update Billist set idbill=@id1bill where id in(select*from idbillisttable)
 drop table idbillisttable
 if(@istable1=0)
 update TableFood set stat=N'Trống' where id=@idtable2
 if(@istable2=0)
 update TableFood set stat=N'Trống' where id=@idtable1
end
go




create trigger Utg_Copytable
on Bill for update
as begin
delete Thongke
insert into Thongke select t.name1, b.datein,b.dateout,b.giamgia,b.tongtien from Bill as b, TableFood as t
where  b.stat=1 and t.id=b.idtable and b.stat=1
end
go

create procedure pro_Gethongke
@datein date,@dateout date
as begin
select *from Thongke
where datein>=@datein and dateout<=@dateout
end
go

create procedure pro_updatetaikhoai
@username nvarchar(100),@dlname nvarchar(100),@pw nvarchar(100),@newpw nvarchar(100)
as begin
  declare @isrightpw int=0
  select @isrightpw =COUNT(*) from Dangnhap where usename=@username and pw=@pw
  if(@isrightpw=1)
  begin
     if(@newpw=null and @newpw='') 
	 begin 
	 update Dangnhap set dlname=@dlname where usename=@username 
	 end
	 else 
	 begin
	 update Dangnhap set dlname=@dlname , pw=@newpw where usename=@username 
	 end
  end
end
go

create FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END 
go
create procedure pro_searchfood 
@name nvarchar(100)
as
begin
set @name='%'+@name+'%'
select *from Food where dbo.fuConvertToUnsign1(name1) like dbo.fuConvertToUnsign1(@name)
end
go

create procedure pro_searchFoodCate
@name nvarchar(100)
as
begin
set @name='%'+@name+'%'
select *from FoodCate where dbo.fuConvertToUnsign1(name1) like dbo.fuConvertToUnsign1(@name)
end
go


create procedure pro_searchTableFood
@name nvarchar(100)
as
begin
set @name='%'+@name+'%'
select *from TableFood where dbo.fuConvertToUnsign1(name1) like dbo.fuConvertToUnsign1(@name)
end
go

create procedure pro_searchUserName 
@username nvarchar(100)
as
begin
set @username='%'+@username+'%'
select *from Dangnhap where dbo.fuConvertToUnsign1(usename) like dbo.fuConvertToUnsign1(@username)
end
go

create trigger UTG_DeleteBiilist
on Billist for delete
as begin
declare @idBill int
declare @idBillist int 

select @idBillist=id ,@idBill=deleted.idbill from deleted

declare @idtable int
select @idtable=idtable from Bill where id=@idBill
declare @sl int=0 
select @sl=COUNT(*) from Billist as bi,Bill as b where bi.idbill=b.id and b.id=@idBill and stat=0
if(@sl=0)
update TableFood set stat=N'Trống' where id=@idtable

end
go

create procedure  Pro_DeeteCatefood
@idcate int
as begin
delete Billist from Billist b,Food f,FoodCate fc
where b.idfool=f.id and fc.id=f.idcate and fc.id=@idcate
delete Food from Food f,FoodCate fc
where fc.id=f.idcate and fc.id=@idcate
delete FoodCate from FoodCate fc
where fc.id=@idcate
end
go
create procedure Pro_DeleteTable
@idtable int
as begin
delete Billist from  Billist bi,Bill b,TableFood t where bi.idbill=b.id and b.idtable=t.id and t.id=@idtable 
delete Bill from  Bill b,TableFood t where b.idtable=t.id and t.id=@idtable 
delete TableFood from  TableFood t where t.id=@idtable
end
go

select *from Billist