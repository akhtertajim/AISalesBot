create table AspNetRoles
(
 Id  nvarchar(128) not null,
 Name nvarchar(256),
 NormalizedName nvarchar(256),
 ConcurrencyStamp nvarchar(256),
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id]),
)

create table AspNetUsers(
Id  nvarchar(128) not null,
UserName nvarchar(256) not null,
NormalizedUserName nvarchar(256) not null,
Email nvarchar(256) ,
NormalizedEmail nvarchar(256) ,
EmailConfirmed bit,
PasswordHash nvarchar(max),
SecurityStamp nvarchar(512),
ConcurrencyStamp nvarchar(512),
PhoneNumber  nvarchar(15) ,
PhoneNumberConfirmed bit,
TwoFactorEnabled bit,
LockoutEnd datetime,
LockoutEnabled bit,
AccessFailedCount int,
CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
)


CREATE TABLE [AspNetRoleClaims] (
    [Id] INT NOT NULL,
    [RoleId] nvarchar(128) NOT NULL,
    [ClaimType] nvarchar(512) NULL,
    [ClaimValue] nvarchar(512) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id])
);

CREATE TABLE [AspNetUserClaims] (
    [Id] INT NOT NULL,
    [UserId] nvarchar(128) NOT NULL,
    [ClaimType] nvarchar(512) NULL,
    [ClaimValue] nvarchar(512) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
);


CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] varchar(255) NOT NULL,
    [ProviderKey] Nvarchar(255) NOT NULL,
    [ProviderDisplayName] varchar(255) NULL,
    [UserId] Nvarchar(128) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
	CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
)

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(128) NOT NULL,
    [RoleId] nvarchar(128) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

create table UserCart
(
    Id  int identity(1,1) not null,
    UserId   nvarchar(128),
	ProductId nvarchar(128),
	Unit int ,
	CreatedDate DateTime null,
	ModifiedDate DateTime null,
	IsCheckedOut bit,
    CheckOutId int null,
	ExpectedDeliveryDate DateTime null,
	ReceivedByUserDate DateTime null,
	ShipmentWendor nvarchar(512),
    CONSTRAINT [PK_UserCart] PRIMARY KEY ([Id])
)

create table CheckOut
(
    Id int identity(1,1) not null,
	UserId  nvarchar(128),
	CheckoutDate DateTime  ,
	PaymentMethod  nvarchar(512),
	TotalAmount decimal,
	TransactionNumber  nvarchar(128),
	CONSTRAINT [PK_CheckOut] PRIMARY KEY ([Id]),
)
create table ShipmentDetails
(
	Id int identity(1,1) not null,
	UserId  nvarchar(128),
	CheckOutId int  ,
	DeliveryAddress  nvarchar(max),
	DeliveryEmail  nvarchar(128),
	DeliveryMobile  nvarchar(15),
   CONSTRAINT [PK_ShipmentDetails] PRIMARY KEY ([Id])
)


