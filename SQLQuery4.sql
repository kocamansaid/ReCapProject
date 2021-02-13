create database CarProjectdb;
create table Cars(

CarId int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice decimal,
Descriptions nvarchar(25),
FOREIGN KEY (BrandID) REFERENCES Brands(BrandId),
FOREIGN KEY (ColorId) REFERENCES Colors(ColorId)
)
create table Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(15),
)

create table Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(15)
)

insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
values 
	('1','2','2012','100','10 yıllık kullanılmış'),
	('2','1','2000','150','5 yıllık kullanılmış'),
	('2','1','2006','190','3 yıllık kullanılmış'),
	('3','3','2019','200','9 yıllık kullanılmış'),
	('1','1','2021','150','1 yıllık kullanılmış');
	
insert into Colors(ColorName)
values
('Siyah'),
('Beyaz'),
('Mavi');
insert into Brands(BrandName)
values
('BMW'),
('Mercedes'),
('Audi');

select * from Cars
select * from Brands
select * from Colors
