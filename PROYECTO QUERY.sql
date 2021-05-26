create table Users (
UserId char (8) primary key,
Nombre varchar (40)not null,
Apellido varchar (40)not null, 
pass varchar (20)not null, 
)

use proyectopoo

create table Clients(
Log_In char (20) primary key,
Nombre varchar (40) not null,
Apellido varchar (40) not null,
pass varchar (20) not null,
ShipAddress char (20) not null,
Email varchar (20) not null,
)

create table Products(
ProductId char(8) primary key not null,
Descripcion varchar (200) not null ,
Price char (10) not null, 
CategoryId char(8) not null,
ProductKey char(15)not null,

CONSTRAINT fk_Category FOREIGN KEY (CategoryId) References Category (CategoryId)
)

create table Category(
CategoryId char (8) primary key not null,
Descripcion varchar(200)not null,

)

create table Forums(
ForumId char(8) primary key not null,
CategoryId char (8) not null,
Descripcion varchar (200) not null,
Comments varchar (250) not null,

CONSTRAINT fk_Category2 FOREIGN KEY (CategoryId) References Category (CategoryId)

)



create table Orders(
OrderId char(8) primary key not null,
ProductId char(8) not null,
Quantity char (10) not null,
Log_In char (20) not null,
fecha char (8) not null,
OrderStatusId char (8) not null,
CartId char(8) not null,

CONSTRAINT fk_login FOREIGN KEY (Log_In) References Clients (Log_In),
CONSTRAINT fk_Product FOREIGN KEY (ProductId) References Products (ProductId),
CONSTRAINT fk_Cart FOREIGN KEY (CartId) References Cart (CartId),
CONSTRAINT fk_Status FOREIGN KEY (OrderStatusId) References OrderStatus (OrderStatusId)

)

create table Cart (
CartId char (8) primary key not null,
ProductId char(8) not null,
Quantity char (8) not null,
Log_In char(20) not null,

CONSTRAINT fk_login2 FOREIGN KEY (Log_In) References Clients (Log_In),
CONSTRAINT fk_product2 FOREIGN KEY (ProductId) References Products (ProductId)


)

create table OrderStatus(
OrderStatusId char(8) primary key not null,
StatusDescription varchar (150) not null


)

create table InVoice (
InvoiceId char(8) not null,
OrderId char(8) not null, 
fecha char(8) not null,
InVoiceTotalAmount char (8) not null

CONSTRAINT fk_order3 FOREIGN KEY (OrderId) References Orders (OrderId)

)

create table OtherSites (
RelatedSiteId char(8) not null,
ProductId char(8) not null,
WebsiteLink varchar (200) not null

CONSTRAINT fk_product3 FOREIGN KEY (ProductId) References Products (ProductId)

)