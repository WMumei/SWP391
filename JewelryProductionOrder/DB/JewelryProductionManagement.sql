create table Customer (
	CustomerID int NOT NULL PRIMARY KEY,
	LastName nvarchar(40),
	Firstname nvarchar(40),
	DateOfBirth date,
	Gender nvarchar(10),
	Email nvarchar(40),
	Address nvarchar(40),
	PhoneNumber int
)

create table Staff (
	StaffID int NOT NULL PRIMARY KEY,
	LastName nvarchar(40),
	Firstname nvarchar(40),
	DateOfBirth date,
	Gender nvarchar(10),
	Email nvarchar(40),
	WorkAddress nvarchar(40),
	PhoneNumber int,
	StaffRole nvarchar(16),
)

create table Material (
	MaterialID int not null primary key,
	MaterialName nvarchar(100),
	BuyPrice int,
	SellPrice int
)

create table category (
	CategoryID int not null primary key,
	CategoryName nvarchar(40),
	MaterialID int,
	constraint fk_MaterialID foreign key (MaterialID) references Material(MaterialID)
)

create table Jewelry (
	JewelryID int not null primary key,
	JewelryName nvarchar(100),
	JewelryPrice int,
	CategoryID int,
	constraint fk_CategoryID foreign key (CategoryID) references Category(CategoryID)
)

create table ProductRequest (
	ProductRequestID int not null PRIMARY KEY,
	Title nvarchar (100),
	Description nvarchar (255),
	MaterialID int,
	FinalPrice int,
	constraint fk_MaterialID foreign key (MaterialID) references Material(MaterialID)	
)

create table WarrantyCard(
	CardID int not null primary key,
	CustomerID int,
	JewelryID int,
	IssueDate date,
	ExpirationDate date,
	constraint fk_CustomerID foreign key (CustomerID) references Customer(CustomerID),
	constraint fk_JewelryID foreign key (JewelryID) references Jewelry(JewelryID)
)

create table Post (
	Title nvarchar(100),
	PostDate date,
	Content nvarchar(max)
)
