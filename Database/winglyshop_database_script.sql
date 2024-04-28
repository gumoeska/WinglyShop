CREATE DATABASE WinglyShop

CREATE TABLE Roles(
    id INT PRIMARY KEY IDENTITY,
    description VARCHAR(255),
    access INT,
    isActive BIT
)

CREATE TABLE Account(
    id INT PRIMARY KEY IDENTITY,
    login VARCHAR(255),
    email VARCHAR(255),
    password VARCHAR(255),
    phone VARCHAR(255),
    isActive BIT,

    -- Foreign Keys
    idRole INT,

    CONSTRAINT FK_Users_Roles FOREIGN KEY (idRole) 
        REFERENCES Roles(id)
)

CREATE TABLE Address(
    id INT PRIMARY KEY IDENTITY,
    city VARCHAR(255),
    state VARCHAR(255),
    country VARCHAR (255),
    postalCode VARCHAR(255),
    isActive BIT,

    -- Foreign Keys
    idUser INT,

    CONSTRAINT FK_Addresses_Users FOREIGN KEY (idUser)
        REFERENCES User (id)
        ON DELETE CASCADE
)

CREATE TABLE User(
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(255),
    surname VARCHAR(255),
    image VARCHAR(1000),
    isActive BIT,

    -- Foreign Keys
    idAccount INT,

    CONSTRAINT FK_Users_Accounts FOREIGN KEY (idAccount) 
        REFERENCES Account (id)
)

CREATE TABLE Category(
    id INT PRIMARY KEY IDENTITY,
    code VARCHAR(255),
    description VARCHAR(255),
    isActive BIT
)

CREATE TABLE Product(
    id INT PRIMARY KEY IDENTITY,
    code VARCHAR(255),
    description VARCHAR(255),
    price DECIMAL(10, 2),
    hasStock BIT,
    isActive BIT,

    -- Foreign Keys
    idCategory INT,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (idCategory)
        REFERENCES Category(id)
)

CREATE TABLE Order(
    id INT PRIMARY KEY IDENTITY,
    status INT,
    orderDate DATETIME,
    paymentMethod INT,
    totalValue DECIMAL(10, 2),

    -- Foreign Keys
    idUser INT,
    idDelivery INT,

    CONSTRAINT FK_Orders_Users FOREIGN KEY (idUser)
        REFERENCES User (id)
)

CREATE TABLE OrderDetail(
    id INT PRIMARY KEY IDENTITY,
    quantity DECIMAL,
    price DECIMAL(10, 2),

    -- Foreign Keys
    idOrder INT,
    idProduct INT,
    idAddress INT

    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (idOrder) 
        REFERENCES Order(id)
        ON DELETE CASCADE,

    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (idProduct) 
        REFERENCES Product(id),

    CONSTRAINT FK_OrderDetails_Addresses FOREIGN KEY (idAddress) 
        REFERENCES Address(id)
)

CREATE TABLE Cart(
    id INT PRIMARY KEY IDENTITY,
    totalValue DECIMAL(10, 2),
    isActive BIT,

    -- Foreign Keys
    idUser INT,

    CONSTRAINT FK_Carts_Users FOREIGN KEY (idUser) 
        REFERENCES User (id)
        ON DELETE CASCADE
)

CREATE TABLE CartDetail(
    id INT PRIMARY KEY IDENTITY,
    quantity INT,
    price DECIMAL(10, 2),

    -- Foreign Keys
    idCart INT,
    idProduct INT,

    CONSTRAINT FK_CartDetails_Carts FOREIGN KEY (idCart) 
        REFERENCES Cart (id)
        ON DELETE CASCADE,

    CONSTRAINT FK_CartDetails_Products FOREIGN KEY (idProduct) 
        REFERENCES Product (id)
)