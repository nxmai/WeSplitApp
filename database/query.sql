create database wesplit
go

use wesplit
go


--bảng địa danh
create table places
(
	id int not null,
	name nvarchar(50),
	address nvarchar(500),
	discription nvarchar(1000)

	constraint pk_places primary key (id)
)
go

--bảng chuyến đi, 1 khóa ngoại tới địa danh
create table trip
(
	id int not null,
	name nvarchar(50),
	idplace int,
	thumbnail char(50),
	datetogo date,
	returndate date,
	isfinish bit,
	totalrevenue int,
	totalexpend int

	constraint pk_trip primary key (id)
)
go

alter table trip add constraint fk_trip foreign key (idplace) references places(id)
go

--bảng hình ảnh, 1 chuyến đi có nhiều hình ảnh, 1 khóa ngoại tới chuyến đi, quan hệ một - nhiều
create table image
(
	id int not null,
	path char(50),
	idtrip int

	constraint pk_image primary key (id)
)
go

alter table image add constraint fk_image foreign key (idtrip) references trip(id)
go

--bảng lộ trình, 1 chuyến đi có nhiều lộ trình, 1 khóa ngoại tới chuyến đi, quan hệ một-nhiều
create table route
(
	id int not null,
	place nvarchar(50),
	cost int,
	idtrip int

	constraint pk_route primary key (id)
)

alter table route add constraint fk_route foreign key (idtrip) references trip(id)
go

--bảng thành viên
create table member 
(
	id int not null,
	name nvarchar(50),
	phonenumber char(11),
	collectedmoney int,
	idtrip int

	constraint pk_member primary key (id)
)
go

alter table member add constraint fk_member foreign key (idtrip) references trip(id)
go


insert into places values ('1', N'Biển Vũng Tàu', N'Bãi sau Vũng Tàu, thành phố Vũng Tàu, tỉnh Bà Rịa - Vũng Tàu', N'Vũng Tàu là một thành phố thuộc tỉnh Bà Rịa - Vũng Tàu, ở vùng Đông Nam Bộ, Việt Nam. Đây là trung tâm kinh tế, tài chính, văn hóa, du lịch, giao thông - vận tải và giáo dục và là một trong những trung tâm kinh tế của vùng Đông Nam Bộ');
insert into places values ('2', N'Đà Lạt', N'Tỉnh Lâm Đồng', N'Đà Lạt là thành phố tỉnh lỵ của tỉnh Lâm Đồng, nằm trên cao nguyên Lâm Viên, thuộc vùng Tây Nguyên, Việt Nam. Từ xa xưa, vùng đất này vốn là địa bàn cư trú của những cư dân người Lạch, người Chil và người Srê thuộc dân tộc Cơ Ho.');
insert into places values ('3', N'Đà Nẵng', N'Tỉnh Đà Nẵng', N'Đà Nẵng là một thành phố trực thuộc trung ương, nằm trong vùng Duyên hải Nam Trung Bộ Việt Nam, là thành phố trung tâm và lớn nhất khu vực miền Trung - Tây Nguyên.');


insert into trip values ('1', N'Tắm biển mùa đông', '1', 'Data/fakedata/vungtau_thumbnail.jpg', '1/6/2019', '5/6/2019', 1, null, null);
insert into trip values ('2', N'Tắm biển mùa hè', '1', 'Data/fakedata/vungtau_thumbnail.jpg', '1/6/2020', '3/6/2020', 1, null, null);
insert into trip values ('3', N'Du lịch Đà Lạt', '2', 'Data/fakedata/dalat_thumbnail.jpg', '5/7/2020', '12/7/2020', 1, null, null);
insert into trip values ('4', N'Đi Đà Nẵng', '3', 'Data/fakedata/danang_thumbnail.jpg', '1/6/2019', '5/6/2019', 1, null, null);
insert into trip values ('5', N'Đà Lạt chưa về', '2', 'Data/fakedata/dalat_thumbnail.jpg', '1/6/2021', '5/6/2021', 0, null, null);

insert into trip values ('6', N'Đà Nẵng chưa về', '3', 'Data/fakedata/danang_thumbnail.jpg', '12/1/2020', '12/26/2020', 0, null, null);
insert into trip values ('7', N'Vũng Tàu chưa về', '1', 'Data/fakedata/vungtau_thumbnail.jpg', '12/1/2020', '12/20/2020', 0, null, null);



insert into image values ('1', 'Data/fakedata/vungtau1.jpg', '1');
insert into image values ('2', 'Data/fakedata/vungtau2.jpg', '1');
insert into image values ('3', 'Data/fakedata/vungtau3.jpg', '1');

insert into image values ('4', 'Data/fakedata/vungtau1.jpg', '2');
insert into image values ('5', 'Data/fakedata/vungtau2.jpg', '2');
insert into image values ('6', 'Data/fakedata/vungtau3.jpg', '2');

insert into image values ('7', 'Data/fakedata/dalat1.jpg', '3');
insert into image values ('8', 'Data/fakedata/dalat2.jpg', '3');
insert into image values ('9', 'Data/fakedata/dalat3.jpg', '3');

insert into image values ('10', 'Data/fakedata/danang1.jpg', '4');
insert into image values ('11', 'Data/fakedata/danang2.jpg', '4');
insert into image values ('12', 'Data/fakedata/danang3.jpg', '4');

insert into image values ('13', 'Data/fakedata/dalat1.jpg', '5');
insert into image values ('14', 'Data/fakedata/dalat2.jpg', '5');
insert into image values ('15', 'Data/fakedata/dalat3.jpg', '5');


insert into image values ('16', 'Data/fakedata/danang1.jpg', '6');
insert into image values ('17', 'Data/fakedata/danang2.jpg', '6');
insert into image values ('18', 'Data/fakedata/danang3.jpg', '6');


insert into image values ('19', 'Data/fakedata/vungtau1.jpg', '7');
insert into image values ('20', 'Data/fakedata/vungtau2.jpg', '7');
insert into image values ('21', 'Data/fakedata/vungtau3.jpg', '7');



insert into route values ('1', N'Đại học Khoa học tự nhiên', 50000, '1');
insert into route values ('2', N'Làng đại học', 70000, '1');
insert into route values ('3', N'Bò sữa Long Thành', 100000, '1');
insert into route values ('4', N'Bãi sau Vũng Tàu', 20000, '1');

insert into route values ('5', N'Đại học Khoa học tự nhiên 2', 60000, '2');
insert into route values ('6', N'Làng đại học 2', 80000, '2');
insert into route values ('7', N'Bò sữa Long Thành 2', 110000, '2');
insert into route values ('8', N'Bãi sau Vũng Tàu 2', 21000, '2');

insert into route values ('9', N'Đại học Khoa học tự nhiên 3 ', 50000, '3');
insert into route values ('10', N'Làng đại học 3', 70000, '3');
insert into route values ('11', N'Cao nguyên Lâm Viên ', 100000, '3');
insert into route values ('12', N'Thành phố Đà Lạt', 20000, '3');

insert into route values ('13', N'Đại học Khoa học tự nhiên 4', 150000, '4');
insert into route values ('14', N'Làng đại học 4', 710000, '4');
insert into route values ('15', N'Đèo Hải Vân', 1100000, '4');
insert into route values ('16', N'Đà Nẵng', 120000, '4');

insert into route values ('13', N'Đại học Khoa học tự nhiên 4', 150000, '5');
insert into route values ('14', N'Làng đại học 5', 710000, '5');
insert into route values ('15', N'Đèo Hải Vân 5', 1100000, '5');
insert into route values ('16', N'Đà Lat 5', 120000, '5');


insert into route values ('17', N'Đèo Hải Vân 6', 1100000, '6');
insert into route values ('18', N'DN 6', 120000, '6');


insert into route values ('19', N'Đèo Hải Vân 6', 1100000, '7');
insert into route values ('20', N'VT 6', 120000, '7');


insert into member values ('1', N'Nguyễn Xuân Mai', '012345678', 120000, '1');
insert into member values ('2', N'Khưu Thùy Kỳ', '152637934', 240000, '1');
insert into member values ('3', N'Dương Bội Long', '019826421', 300000, '1');

insert into member values ('4', N'Nguyễn Xuân Mai 2', '012345678', 220000, '2');
insert into member values ('5', N'Khưu Thùy Kỳ 2', '152637934', 340000, '2');
insert into member values ('6', N'Dương Bội Long 2', '019826421', 400000, '2');

insert into member values ('7', N'Nguyễn Xuân Mai 3', '012345678', 1200000, '3');
insert into member values ('8', N'Khưu Thùy Kỳ 3', '152637934', 2400000, '3');
insert into member values ('9', N'Dương Bội Long 3', '019826421', 3000000, '3');

insert into member values ('10', N'Nguyễn Xuân Mai 4', '012345678', 200000, '4');
insert into member values ('11', N'Khưu Thùy Kỳ 4', '152637934', 240000, '4');
insert into member values ('12', N'Dương Bội Long 4', '019826421', 300000, '4');
insert into member values ('13', N'Nhựt Nam', '2403294', 30000, '4');

insert into member values ('14', N'Nguyễn Thị Lan 5', '019826421', 300000, '5');
insert into member values ('15', N'Lê Văn An 5', '2403294', 30000, '5');


insert into member values ('16', N'Lê Văn Đạt 6', '019826421', 300000, '6');
insert into member values ('17', N'Trần Dần 6', '2403294', 30000, '6');


insert into member values ('18', N'Lê Thị Tám 7', '019826421', 300000, '7');
insert into member values ('19', N'Trần Dần Bảy 7', '2403294', 30000, '7');


 select * from trip join member on trip.id = member.idtrip;

 select * from trip join places on trip.idplace = places.id;
 