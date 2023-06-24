create database demo_btl	
use demo_btl
CREATE TABLE LoaiSP(
id INT IDENTITY(1,1) primary key , 
TenLoai nvarchar(200) NOT NULL,
Anh nvarchar(500) ,
)
insert into LoaiSP(TenLoai,Anh)
values(N'Bánh Kem','kemcanhhoa.jpg')
insert into LoaiSP(TenLoai,Anh)
values(N'Bánh M?n','BEEFBBQPIZZA.jpg')
insert into LoaiSP(TenLoai,Anh)
values(N'Bánh Mousse','mousechanh2.jpg')
insert into LoaiSP(TenLoai,Anh)
values(N'Bánh Ng?t','crepe.jpg')
--SP
create proc SP_LoaiSP
@id int,
@TenLoai nvarchar(200),
@Anh nvarchar(500),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into LoaiSP
(
TenLoai,
Anh
)
values(
@TenLoai,
@Anh
)
end 
else if(@type='get')
begin
select * from LoaiSP order by id desc
end
else if(@type='getid')
begin
select * from LoaiSP where id=@id
end
else If(@type='update')
begin
update LoaiSP set
TenLoai=@TenLoai,
Anh=@Anh
where id=@id
end 
else if(@type='delete')
begin
Delete from LoaiSP where id=@id
end
end

create table SanPham(
id INT IDENTITY(1,1) primary key ,
MaLoai int foreign key references LoaiSP(id) on delete cascade on update cascade NOT NULL,
TenSP nvarchar(500) not null,
GiaBan int,
Sale int ,
SoLuong int,
TinhTrang nvarchar(50),
Anh text,
)
insert into SanPham(MaLoai,TenSP,GiaBan,Sale,SoLuong,TinhTrang,Anh)
values('1',N'Sản phẩm 1',500000,450000,10,N'Giảm giá','giay1.jpg')

alter proc SP_SanPham
@id int,
@MaLoai int,
@TenSP nvarchar(500),
@GiaBan int,
@Sale int,
@SoLuong int,
@TinhTrang nvarchar(50),
@Anh text,
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into SanPham
(
MaLoai,
TenSP,
GiaBan,
Sale,
SoLuong,
TinhTrang,
Anh
)
values(
@MaLoai ,
@TenSP ,
@GiaBan ,
@Sale ,
@SoLuong ,
@TinhTrang,
@Anh 

)
end 
else if(@type='get')
begin
select * from SanPham order by id desc
end
else if(@type='getid')
begin
select * from SanPham where id=@id
end
else If(@type='update')
begin
update SanPham set
MaLoai=@MaLoai,
TenSP=@TenSP,
GiaBan=@GiaBan,
Sale=@Sale,
SoLuong=@SoLuong,
TinhTrang=@TinhTrang,
Anh=@Anh
where id=@id
end 
else if(@type='delete')
begin
Delete from SanPham where id=@id
end
end


--kh
CREATE TABLE KhachHang(
id INT IDENTITY(1,1) not null primary key,
TenKH nvarchar(500) NULL,
DiaChi nvarchar(500) NULL,
SDT nvarchar(500) NULL,
TK nvarchar(500) NULL,
Pass nvarchar(500) NULL,
Anh nvarchar(500) NULL,)
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Nguy?n V?n A',N'H?ng Yên','0352368763','Kid3092001','123@123','avt.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Nguy?n V?n B',N'H?ng Yên','0352368764','boizno1','boizno1','avt1.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Tr?n V?n A',N'Hà N?i','0352368765','boizmmm21','matkhaulagi','avt2.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Nguy?n Th? C',N'H?ng Yên','0352368766','Kizmks11','12345678','avt3.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Nguy?n V?n D',N'H?ng Yên','0352368767','Hyouk1132','1412567','avt4.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Tr?n Ng?c B',N'H?ng Yên','0352368768','Kid1412asd','@!12321','avt5.jpg')
insert into KhachHang(TenKH,DiaChi,SDT,TK,Pass,Anh)
VALUES(N'Nguy?n Th? M',N'H?ng Yên','0352368769','Ponchiky','123@121','avt6.jpg')

create proc SP_KhachHang
@id int,
@TenKH nvarchar(500),
@DiaChi nvarchar(500),
@SDT nvarchar(500),
@TK nvarchar(500),
@Pass nvarchar(500),
@Anh nvarchar(500),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into KhachHang
(
TenKH,
DiaChi,
SDT,
TK,
Pass,
Anh
)
values(
@TenKH ,
@DiaChi ,
@SDT ,
@TK ,
@Pass ,
@Anh 

)
end 
else if(@type='get')
begin
select * from KhachHang order by id desc
end
else if(@type='getid')
begin
select * from KhachHang where id=@id
end
else If(@type='update')
begin
update KhachHang set
TenKH=@TenKH,
DiaChi=@DiaChi,
SDT=@SDT,
TK=@TK,
Pass=@Pass,
Anh=@Anh
where id=@id
end 
else if(@type='delete')
begin
Delete from KhachHang where id=@id
end
end

CREATE TABLE NhanVien (
id INT IDENTITY(1,1) primary key ,
TenNV nvarchar(500)  NULL,
GT nvarchar(500)  NULL,
NgaySinh datetime NULL,
QueQuan nvarchar(100)   NULL,
SDT nvarchar(20)   NULL,
Email nvarchar(500)  NULL,
capbac nvarchar(10)   NULL,
) 
drop
create proc SP_NhanVien
@id int,
@TenNV nvarchar(500),
@GT nvarchar(500),
@NgaySinh datetime  NULL,
@QueQuan nvarchar(100),
@SDT nvarchar(20),
@Email nvarchar(500),
@capbac nvarchar(500),
@type nvarchar(10)
as 
begin
If(@type='insert')
begin
Insert into NhanVien
(
TenNV,
GT,
NgaySinh,
QueQuan,
SDT,
Email,
capbac
)
values(
@TenNV ,
@GT ,
@NgaySinh,
@QueQuan ,
@SDT ,
@Email,
@capbac 

)
end 
else if(@type='get')
begin
select * from NhanVien order by id desc
end
else if(@type='getid')
begin
select * from NhanVien where id=@id
end
else If(@type='update')
begin
update NhanVien set
TenNV=@TenNV,
GT=@GT,
NgaySinh=@NgaySinh,
QueQuan=@QueQuan,
SDT=@SDT,
Email=@Email,
capbac=@capbac

where id=@id
end 
else if(@type='delete')
begin
Delete from NhanVien where id=@id
end
end

create table AccAdmin(
id INT IDENTITY(1,1) not null primary key,
HoTen nvarchar(500) null ,
QuyenHan nvarchar(500),
TK nvarchar(500) NULL,
Pass nvarchar(500) NULL,
)
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'Bùi V?n Tu?n',N'Administrator','Hyouk1132','1412567')
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'Ph?m Minh Hi?u',N'Administrator','boizcuongcung','16022001@')
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'Tr?n Công Di?u',N'Administrator','vipdandang','20042001')
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'Bùi V?n Hi?u',N'Administrator','provip2021','05032001')
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'L??ng Th? Hu?',N'Administrator','Hyouk12311','123456789')
insert into AccAdmin(HoTen,QuyenHan,TK,Pass)
Values(N'Tr?n Th? Lan H??ng',N'Administrator','Hyouk113212','123456789')

create proc SP_AccAdmin
@id int,
@HoTen nvarchar(500),
@QuyenHan nvarchar(500),
@TK nvarchar(500),
@Pass nvarchar(500),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into AccAdmin
(
HoTen,
QuyenHan,
TK,
Pass

)
values(
@HoTen ,
@QuyenHan ,
@TK ,
@Pass 


)
end 
else if(@type='get')
begin
select * from AccAdmin order by id desc
end
else if(@type='getid')
begin
select * from AccAdmin where id=@id
end
else If(@type='update')
begin
update AccAdmin set
HoTen=@HoTen,
QuyenHan=@QuyenHan,
TK=@TK,
Pass=@Pass

where id=@id
end 
else if(@type='delete')
begin
Delete from AccAdmin where id=@id
end
end



CREATE TABLE GioHang(
id INT IDENTITY(1,1) primary key ,
tenSP nvarchar(200) not null,
giaBan int,
soLuong int,
thanhTien int,
anh nvarchar(100),
)

--SP
create proc SP_GioHang
@id int,
@tenSP nvarchar(200),
@giaBan int,
@soLuong int,
@thanhTien int,
@anh nvarchar(100),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into GioHang
(
tenSP,
giaBan,
soLuong,
thanhTien,
anh
)
values(
@tenSP,
@giaBan,
@soLuong,
@thanhTien,
@anh
)
end 
else if(@type='get')
begin
select * from GioHang order by id desc
end
else if(@type='getid')
begin
select * from GioHang where id=@id
end
else If(@type='update')
begin
update GioHang set
tenSP=@tenSP,
giaBan=@giaBan,
soLuong=@soLuong,
thanhTien=@thanhTien,
anh=@anh
where id=@id
end 
else if(@type='delete')
begin
Delete from GioHang where id=@id
end
end

--banner

CREATE TABLE Banner(
id INT IDENTITY(1,1) primary key ,
anh1 nvarchar(100),
anh2 nvarchar(100),
anh3 nvarchar(100),
)

--SP
create proc SP_Banner
@id int,
@anh1 nvarchar(100),
@anh2 nvarchar(100),
@anh3 nvarchar(100),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into Banner
(
anh1,
anh2,
anh3
)
values(
@anh1,
@anh2,
@anh3
)
end 
else if(@type='get')
begin
select * from Banner order by id desc
end
else if(@type='getid')
begin
select * from Banner where id=@id
end
else If(@type='update')
begin
update Banner set
anh1=@anh1,
anh2=@anh2,
anh3=@anh3
where id=@id
end 
else if(@type='delete')
begin
Delete from Banner where id=@id
end
end

--Tin tức

CREATE TABLE TinTuc(
id INT IDENTITY(1,1) primary key ,
tieuDe nvarchar(200) not null,
noiDung1 nvarchar(300),
noiDung2 nvarchar(300),
ngayTao datetime,
anh nvarchar(100),
anh2 nvarchar(100),
)


create proc SP_TinTuc
@id int,
@tieuDe nvarchar(200),
@noiDung1 nvarchar(300),
@noiDung2 nvarchar(300),
@ngayTao datetime,
@anh nvarchar(100),
@anh2 nvarchar(100),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into TinTuc
(
tieuDe,
noiDung1,
noiDung2,
ngayTao,
anh,
anh2
)
values(
@tieuDe,
@noiDung1,
@noiDung2,
@ngayTao,
@anh,
@anh2
)
end 
else if(@type='get')
begin
select * from TinTuc order by id desc
end
else if(@type='getid')
begin
select * from TinTuc where id=@id
end
else If(@type='update')
begin
update TinTuc set
tieuDe=@tieuDe,
noiDung1=@noiDung1,
noiDung2=@noiDung2,
ngayTao=@ngayTao,
anh=@anh,
anh2=@anh2
where id=@id
end 
else if(@type='delete')
begin
Delete from TinTuc where id=@id
end
end