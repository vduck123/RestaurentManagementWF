
CREATE DATABASE RestaurantManagement
GO
USE RestaurantManagement
GO

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
	staff_name NVARCHAR(30) ,
	gender NVARCHAR(5) ,
	birth DATE ,
	phone CHAR(11) ,
	acc_id CHAR(10) REFERENCES Account(acc_id)
)
--
CREATE TABLE Salary
(
	salary_id CHAR(10) PRIMARY KEY ,
	salary_month INT ,
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
CREATE TABLE FoodCategory
(	
	cgFood_id CHAR(10) PRIMARY KEY ,
	cgFood_name NVARCHAR(50)  
)
--
CREATE TABLE Warehouse
(
	item_id CHAR(10) PRIMARY KEY ,
	item_name NVARCHAR(30) ,
	quantity INT ,
	item_category CHAR(10) REFERENCES dbo.FoodCategory(cgFood_id)
);
GO
--
CREATE TABLE Food
(
	food_id CHAR(10) PRIMARY KEY ,
	food_name NVARCHAR(50) ,
	food_price INT ,
	item_id CHAR(10) REFERENCES dbo.Warehouse(item_id) ,
	item_quantity INT ,
	cgFood_id CHAR(10) REFERENCES FoodCategory(cgFood_id)
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
SELECT * FROM dbo.BillOfImport
--
CREATE TABLE DetailBillOfImport
(
	dboImport_id CHAR(10) PRIMARY KEY ,
	item_id CHAR(10) REFERENCES dbo.Warehouse(item_id) ,
	price INT ,
	quantity INT ,
	total_money INT ,
	boImport_id CHAR(10) REFERENCES dbo.BillOfImport(boImport_id)
)
--
CREATE TABLE Voucher
(	
	voucher_id CHAR(10) PRIMARY KEY ,
	voucher_name NVARCHAR(30) ,
	voucher_expiry CHAR(30) ,
	status NVARCHAR(30)
)

DROP TABLE VOUCHER
SELECT * FROM Voucher
--
CREATE TABLE BillOfSale 
(
	boSale_id CHAR(10) PRIMARY KEY ,
	dayIn DATETIME ,
	dayOut DATETIME ,
	totalMoney INT ,
	staff_id CHAR(10) REFERENCES dbo.Staff(staff_id) ,
	table_id CHAR(10) REFERENCES dbo._Table(table_id)
)
--
CREATE TABLE DetailBillOfSale
(
	dboSale_id CHAR(10) ,
	food_id CHAR(10) REFERENCES Food(food_id) ,
	food_quantity INT ,
	food_price INT ,
	food_total INT ,
	voucher_id CHAR(10) REFERENCES dbo.Voucher(voucher_id) ,
	boSale_id CHAR(10) REFERENCES BillOfSale(boSale_id)
)

DROP TABLE DetailBillOfSale

--
CREATE TABLE Menu
(
	food_id CHAR(10) REFERENCES dbo.Food(food_id) ,
	food_price INT ,
	quantity INT ,
	total INT ,
	table_id CHAR(10) REFERENCES dbo._TABLE(table_id)
)

DROP TABLE Menu

SELECT 
FROM dbo.Account acc
INNER JOIN dbo.Staff sf ON sf.acc_id = acc.acc_id
INNER JOIN dbo.Salary sl ON sl.staff_id = sf.staff_id


--


--Insert Data
SELECT * FROM dbo.Voucher
INSERT INTO _Table
VALUES 
('0',N'Bàn 0',N'Trống'),
('1',N'Bàn 1',N'Trống');
GO

INSERT INTO Account
VALUES ('AC0001','Admin','1',N'Quản trị viên')

INSERT INTO dbo.Voucher
VALUES('VC0',N'Happy Day',10000,N'Còn') ,
	  ('VC1',N'Happy Day1',15000,N'Hết hạn')
INSERT INTO dbo.FoodCategory
(
    cgFood_id,
    cgfFood_name
)
VALUES ('FC0',N'Hoa quả') ,
	   ('FC1',N'Hải sản') ,
	   ('FC2',N'Đồ uống') ;
GO


SELECT a.username
FROM Account a
LEFT JOIN Staff s ON s.acc_id = a.acc_id
WHERE s.acc_id IS NULL;

SELECT * FROM dbo.Account WHERE username = '4'



INSERT INTO dbo.Staff
VALUES('0',N'Cao Bá Việt',N'Nam','03-10-2004','0335287161','AC0001')

SELECT s.staff_name
FROM dbo.Account a
INNER JOIN dbo.Staff s ON s.acc_id = a.acc_id
WHERE a.acc_id = @id
--test query 
SELECT f.food_name, f.food_price , dbos.food_quantity, bos.totalMoney
FROM Food f 
INNER JOIN dbo.DetailBillOfSale dbos ON dbos.food_id = f.food_id
INNER JOIN dbo.BillOfSale bos ON bos.boSale_id = dbos.boSale_id
INNER JOIN dbo._TABLE t ON t.table_id = bos.table_id
WHERE t.table_id = @id

UPDATE dbo.BillOfSale
SET totalMoney = @total,
	dayIn = @dayin ,
	dayOut = @dayout
WHERE boSale_id = @id

INSERT INTO dbo.Food
(
    food_id,
    food_name,
    food_price,
    cgFood_id
)
VALUES ('F0',N'Táo Việt Nam',5000,'FC0'),
		('F1',N'Dưa leo Himalaya',5000,'FC0'),
		('F2',N'Cua 4 chân',100000,'FC1'),
		('F3',N'Tôm 2 càng',90000,'FC1'),
		('F4',N'Coco Pepsi',2000,'FC2'),
		('F5',N'Nước đường không ngọt',1000,'FC2');

		UPDATE dbo.Food
		SET food_name = @name ,
			food_price = @price 
		WHERE food_id = @id
GO
