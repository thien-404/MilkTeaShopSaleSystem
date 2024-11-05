create database MilkTeaShopSaleDB
go

use MilkTeaShopSaleDB
go

create table Users(
	user_id int identity(1,1) primary key,
	user_name Nvarchar(50) unique,
	email Nvarchar(50) unique,
	password Nvarchar(50),
	user_role Nvarchar(20),
	user_status int --1-Inactive, 2-Active
)

create table Drinks(
	drink_id int identity(1,1) primary key,
	drink_name Nvarchar(50) unique,
	description Nvarchar(200),
	drink_status int --1-Inactive, 2-Active
)

create table Prices (
    drink_id int,
    size nvarchar(20),
    price DECIMAL(10, 2),
    price_status int, -- 1-Inactive, 2-Active
    PRIMARY KEY (drink_id, size), -- Composite primary key
    FOREIGN KEY (drink_id) REFERENCES Drinks(drink_id)
);



create table Orders(
	order_id int identity(1,1) primary key,
	staff_id int,
	total_price DECIMAL(10, 2),
	order_status int --1-Inactive, 2-Active, 3-Cancelled
	FOREIGN KEY (staff_id) REFERENCES Users(user_id),
)

create table Order_Detail(
	order_id int,
	drink_id int,
	quantity int,
	FOREIGN KEY (order_id) REFERENCES Orders(order_id),
	FOREIGN KEY (drink_id) REFERENCES Drinks(drink_id),
)

