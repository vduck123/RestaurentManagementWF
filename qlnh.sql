
CREATE DATABASE RestaurantManagement
GO


USE RestaurantManagement
GO


--
CREATE TABLE Account
(
	acc_id CHAR(10) PRIMARY KEY ,
	username CHAR(30) ,
	password CHAR(30) ,
	role NVARCHAR(30)
)
--
CREATE TABLE Staff
(
	staff_id CHAR(10) PRIMARY KEY ,
	staff_name NVARCHAR(50) ,
	gender NVARCHAR(5) ,
	birth DATE ,
	address NVARCHAR(50) ,
	phone CHAR(11) ,
	acc_id CHAR(10) REFERENCES Account(acc_id)
)
--
CREATE TABLE Salary
(
	salary_id CHAR(10) PRIMARY KEY ,
	salary_month DATE ,
	salary_basic INT ,
	hsl FLOAT ,
	salary_hour INT ,
	num_hour INT ,
	bonus INT ,
	fine INT ,
	total INT,
	staff_id CHAR(10) REFERENCES Staff(staff_id)
)
--
CREATE TABLE _Table
(
	table_id CHAR(10) PRIMARY KEY ,
	table_name NVARCHAR(20) ,
	status NVARCHAR(20) 
)
--
CREATE TABLE Supplier
(
	supplier_id CHAR(10) PRIMARY KEY ,
	supplier_name NVARCHAR(30) ,
	address NVARCHAR(30) ,
	phone NVARCHAR(30) ,
	note NVARCHAR(50)
)

--
CREATE TABLE Category
(	
	category_id CHAR(10) PRIMARY KEY ,
	category_name NVARCHAR(50)  
)
--
CREATE TABLE Material
(
	material_id CHAR(10) PRIMARY KEY ,
	material_name NVARCHAR(30) ,
	quantity INT ,
	unit NVARCHAR(20)
);



--
CREATE TABLE Food
(
	food_id CHAR(10) PRIMARY KEY ,
	food_name NVARCHAR(50) ,
	food_price INT ,
	unit NVARCHAR(20) ,
	image IMAGE ,
	cgFood_id CHAR(10) REFERENCES Category(category_id)
)
--
CREATE TABLE FoodMaterial
(
	material_id CHAR(10) REFERENCES dbo.Material(material_id) ,
	quantity INT ,
	unit NVARCHAR(10) ,
	food_id CHAR(10) REFERENCES dbo.Food(food_id)
)




--
CREATE TABLE BillOfImport
(
	boImport_id CHAR(10) PRIMARY KEY ,
	dayCreate DATE ,
	supplier_id CHAR(10) REFERENCES dbo.Supplier(supplier_id) ,
	staff_id CHAR(10) REFERENCES dbo.Staff(staff_id) ,
	total_money INT 
)
--
CREATE TABLE DetailBillOfImport
(
	dboImport_id CHAR(10) PRIMARY KEY ,
	material_id CHAR(10) REFERENCES dbo.Material(material_id) ,
	price INT ,
	quantity INT ,
	unit NVARCHAR(20) ,
	total_money INT ,
	boImport_id CHAR(10) REFERENCES dbo.BillOfImport(boImport_id)
)


--
CREATE TABLE Voucher
(	
	voucher_id CHAR(10) PRIMARY KEY ,
	voucher_name NVARCHAR(30) ,
	voucher_expiry NVARCHAR(30) ,
	status NVARCHAR(30)
)
--
CREATE TABLE BillOfSale 
(
	boSale_id CHAR(10) PRIMARY KEY ,
	dayIn DATETIME ,
	dayOut DATETIME ,
	voucher_id CHAR(10) REFERENCES dbo.Voucher(voucher_id) ,
	totalMoney INT ,
	customer NVARCHAR(100) ,
	staff_id CHAR(10) REFERENCES dbo.Staff(staff_id) ,
	table_id CHAR(10) REFERENCES dbo._Table(table_id)
)
--

SELECT * FROM dbo.BillOfSale
CREATE TABLE DetailBillOfSale
(
	dboSale_id CHAR(10) PRIMARY KEY,
	food_id CHAR(10) REFERENCES Food(food_id) ,
	food_quantity INT ,
	food_price INT ,
	food_total INT ,	
	boSale_id CHAR(10) REFERENCES BillOfSale(boSale_id)
)
--
CREATE TABLE Menu
(
	food_id CHAR(10) REFERENCES dbo.Food(food_id) ,
	food_price INT ,
	quantity INT ,
	total INT ,
	customer NVARCHAR(100),
	table_id CHAR(10) REFERENCES dbo._TABLE(table_id)
)
--
CREATE TABLE Infomation
(
	name NVARCHAR(255) ,
	address NVARCHAR(255) ,
	phone CHAR(11) ,
	time_open NVARCHAR(100) ,
	time_close NVARCHAR(100) 
)

--
INSERT INTO dbo.Infomation
VALUES (N'Sileo Restaurant', N'Hải Dương', '0388036937', '6:00', '2:00')



INSERT INTO _Table
VALUES ('BA0001', N'Bàn ăn 1', N'Trống'),
('BA0002', N'Bàn ăn 2', N'Trống'),
('BA0003', N'Bàn ăn 3', N'Trống'),
('BA0004', N'Bàn ăn 4', N'Trống'),
('BA0005', N'Bàn ăn 5', N'Trống'),
('BA0006', N'Bàn ăn 6', N'Trống'),
('BA0007', N'Bàn ăn 7', N'Trống'),
('BA0008', N'Bàn ăn 8', N'Trống'),
('BA0009', N'Bàn ăn 9', N'Trống'),
('BA00010', N'Bàn ăn 10', N'Trống')


INSERT INTO dbo.Account
VALUES
(   '000000', -- acc_id - char(10)
    'admin@gmail.com', -- username - char(30)
    '123456', -- password - char(30)
    N'Quản trị viên' -- role - nvarchar(30)
    )

INSERT INTO dbo.Staff
VALUES
	(   '000000',        -- staff_id - char(10)
	    N'Cao Việt',       -- staff_name - nvarchar(50)
	    N'Nam',       -- gender - nvarchar(5)
	    GETDATE(), -- birth - date
	    N'Hải Dương',       -- address - nvarchar(50)
	    '0388036937',        -- phone - char(11)
	    '000000'         -- acc_id - char(10)
	    )
SELECT * FROM dbo.Staff

	DELETE FROM dbo.Voucher
INSERT INTO dbo.Voucher
VALUES
('PGG001',N'Khôngdùng', '0 %', N'Bật'),
('PGG002','VIP-2', '12 %', N'Tắt'),
('PGG003','VIP-3', '13 %', N'Tắt'),
('PGG004','VIP-4', '14 %', N'Tắt'),
('PGG005','VIP-5', '15 %', N'Tắt'),
('PGG006','VIP-6', '16 %', N'Tắt'),
('PGG007','VIP-7', '17 %', N'Tắt'),
('PGG008','VIP-8', '18 %', N'Tắt'),
('PGG009','VIP-9', '20 %', N'Tắt'),
('PGG0010','S-VIP', '100 %', N'Tắt')

SELECT ISNULL(SUM(totalMoney), 0) AS [Tổng thu]
FROM dbo.BillOfSale
WHERE CAST(dayIn AS DATE) = '2024-05-26';
