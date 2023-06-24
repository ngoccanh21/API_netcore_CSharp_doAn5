create database demo_btl	
use demo_btl
CREATE TABLE LoaiSP(
id INT IDENTITY(1,1) primary key , 
TenLoai nvarchar(200) NOT NULL,
Anh nvarchar(500) ,
)
insert into LoaiSP(TenLoai,Anh)
values(N'Giày Converse','kemcanhhoa.jpg')
insert into LoaiSP(TenLoai,Anh)
values(N'Giày Vans','BEEFBBQPIZZA.jpg')
insert into LoaiSP(TenLoai,Anh)
values(N'Giày Nike','mousechanh2.jpg')
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

--Sản phẩm
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
values('1',N'giày converse all star',500000,450000,10,N'Gi?m giá','kembo.jpg')
insert into SanPham(MaLoai,TenSP,GiaBan,Sale,SoLuong,TinhTrang,Anh)
values('2',N'giày vans old skool',500000,450000,6,N'Gi?m giá','banhkemdautay.jpg')

alter proc SP_SanPham
@id int,
@MaLoai int,
@TenSP nvarchar(500),
@GiaBan int,
@Sale int,
@SoLuong int,
@TinhTrang nvarchar(50),
@Anh text,
@MoTa nvarchar(300),
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
Anh,
MoTa
)
values(
@MaLoai ,
@TenSP ,
@GiaBan ,
@Sale ,
@SoLuong ,
@TinhTrang,
@Anh,
@MoTa
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
Anh=@Anh,
MoTa=@MoTa
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
TenNV nvarchar(200) not NULL,
GT nvarchar(50)  NULL,
NgaySinh nvarchar(200) NULL,
QueQuan nvarchar(100)   NULL,
SDT nvarchar(10)   NULL,
Email nvarchar(300)  NULL,
capbac nvarchar(200)   NULL,
) 
--drop
create proc SP_NhanVien
@id int,
@TenNV nvarchar(200),
@GT nvarchar(50),
@NgaySinh nvarchar(200),
@QueQuan nvarchar(100),
@SDT nvarchar(10),
@Email nvarchar(300),
@capbac nvarchar(200),
@type nvarchar(200)
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

--accadmin
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


--giohang
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
ngayTao nvarchar(200),
anh nvarchar(100),
anh2 nvarchar(100),
)


create proc SP_TinTuc
@id int,
@tieuDe nvarchar(200),
@noiDung1 nvarchar(300),
@noiDung2 nvarchar(300),
@ngayTao nvarchar(200),
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

--nhà cung cấp


create proc SP_NhaCungCap
@id int,
@TenNCC nvarchar(200),
@DiaChi nvarchar(200),
@SDT nvarchar(10),
@Email nvarchar(200),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into NhaCungCap
(
TenNCC,
DiaChi,
SDT,
Email
)
values(
@TenNCC,
@DiaChi,
@SDT,
@Email
)
end 
else if(@type='get')
begin
select * from NhaCungCap order by id desc
end
else if(@type='getid')
begin
select * from NhaCungCap where id=@id
end
else If(@type='update')
begin
update NhaCungCap set
TenNCC=@TenNCC,
DiaChi=@DiaChi,
SDT=@SDT,
Email=@Email
where id=@id
end 
else if(@type='delete')
begin
Delete from NhaCungCap where id=@id
end
end


--user
create proc SP_NguoiDung
@id int,
@tk nvarchar(500),
@mk nvarchar(500),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into NguoiDung
(
tk,
mk
)
values(
@tk,
@mk
)
end 
else if(@type='get')
begin
select * from NguoiDung order by id desc
end
else if(@type='getid')
begin
select * from NguoiDung where id=@id
end
else If(@type='update')
begin
update NguoiDung set
tk=@tk,
mk=@mk
where id=@id
end 
else if(@type='delete')
begin
Delete from NguoiDung where id=@id
end
end


--hoadonban
create proc SP_HoaDonBan
@MaHDB int,
@NgayBan datetime,
@id_kh int,
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into HoaDonBan
(
NgayBan,
id_kh
)
values(
@NgayBan,
@id_kh
)
end 
else if(@type='get')
begin
select * from HoaDonBan order by MaHDB desc
end
else if(@type='getid')
begin
select * from HoaDonBan where MaHDB=@MaHDB
end
else If(@type='update')
begin
update HoaDonBan set
NgayBan=@NgayBan,
id_kh=@id_kh
where MaHDB=@MaHDB
end 
else if(@type='delete')
begin
Delete from HoaDonBan where MaHDB=@MaHDB
end
end

--chitiet hdb

create proc SP_CTHDB
@id_cthdb int,
@id_hdb int,
@id_sp int,
@tenSP nvarchar(500),
@giaBan int,
@soLuong int,
@thanhTien int,
@anh nvarchar(300),
@size nvarchar(300),
@type nvarchar(200)
as 
begin
If(@type='insert')
begin
Insert into CTHDB
(
id_hdb,
id_sp,
tenSP,
giaBan,
soLuong,
thanhTien,
anh,
size
)
values(
@id_hdb,
@id_sp,
@tenSP,
@giaBan,
@soLuong,
@thanhTien,
@anh,
@size
)
end 
else if(@type='get')
begin
select * from CTHDB order by id_cthdb desc
end
else if(@type='getid')
begin
select * from CTHDB where id_cthdb=@id_cthdb
end
else If(@type='update')
begin
update CTHDB set
id_hdb=@id_hdb,
id_sp=@id_sp,
tenSP=@tenSP,
giaBan=@giaBan,
soLuong=@soLuong,
thanhTien=@thanhTien,
anh=@anh,
size=@size
where id_cthdb=@id_cthdb
end 
else if(@type='delete')
begin
Delete from CTHDB where id_cthdb=@id_cthdb
end
end


--cart
CREATE TABLE Cart(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    customer_id INT CONSTRAINT fk_customer_cart FOREIGN KEY(customer_id) REFERENCES KhachHang(id) ON DELETE CASCADE,
    product_id  INT CONSTRAINT fk_cart_product FOREIGN KEY(product_id) REFERENCES SanPham(id),
   
    quantity INT NOT NULL
)

Create TABLE Shipping_address (
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    phone CHAR(10) NOT NULL,
    address NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE Orders(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    customer_id INT CONSTRAINT fk_customer_oder FOREIGN KEY(customer_id) REFERENCES KhachHang(id),
    address_id INT CONSTRAINT fk_address_oder FOREIGN KEY(address_id) REFERENCES Shipping_address(id) ON DELETE CASCADE,
    created_at datetime NOT NULL,
  
    status TINYINT NOT NULL,
)

CREATE TABLE Detail_orders(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    order_id INT CONSTRAINT fk_order_detail FOREIGN KEY(order_id) REFERENCES orders(id) ON DELETE CASCADE,
    name NVARCHAR(250),
    option_name VARCHAR(100),
    image VARCHAR(200),
    quantity INT NOT NULL,
    price INT NOT NULL
)