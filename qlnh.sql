
CREATE DATABASE RestaurantManagement
GO



USE RestaurantManagement
GO

INSERT INTO dbo.Account
(
    acc_id,
    username,
    password,
    role
)
VALUES
(   '0', -- acc_id - char(10)
    'admin', -- username - char(30)
    '1', -- password - char(30)
    N'Quản trị viên' -- role - nvarchar(30)
    )

INSERT INTO dbo.Staff
(
    staff_id,
    staff_name,
    gender,
    birth,
    address,
    phone,
    acc_id
)
VALUES
(   '0',        -- staff_id - char(10)
    N'Cao Việt',       -- staff_name - nvarchar(30)
    N'Nam',       -- gender - nvarchar(5)
    GETDATE(), -- birth - date
    N'Hải Dương',       -- address - nvarchar(30)
    '0388036937',        -- phone - char(11)
    '0'         -- acc_id - char(10)
    )

	SELECT * FROM Account
	SELECT * FROM Staff
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
	image IMAGE ,
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
	boSale_id CHAR(10) REFERENCES BillOfSale(boSale_id)
)

--
CREATE TABLE Menu
(
	food_id CHAR(10) REFERENCES dbo.Food(food_id) ,
	food_price INT ,
	quantity INT ,
	total INT ,
	table_id CHAR(10) REFERENCES dbo._TABLE(table_id)
)


SELECT * FROM WareHouse

SELECT * FROM BillSale
SELECT * FROM Supplier
INSERT INTO Supplier
VALUES ('NCC006','Simson-6',N'Hải Dương','093423423', 'Test') ,
('NCC007','Simson-7',N'Hải Dương','093423423', 'Test') ,
('NCC008','Simson-8',N'Hải Dương','093423423', 'Test') ,
('NCC009','Simson-9',N'Hải Dương','093423423', 'Test') ,
('NCC0010','Simson-10',N'Hải Dương','093423423', 'Test')

SELECT * FROM BillOfImport
DELETE FROM BillOfImport
DELETE FROM DetailBillOfImport
SELECT * FROM Staff
SELECT * FROM WareHouse