
CREATE DATABASE BuyProductOnline;
GO

USE BuyProductOnline;
GO

CREATE TYPE UserType FROM VARCHAR(10);
CREATE TYPE PaymentType FROM VARCHAR(10);

CREATE TABLE Users (
    id VARCHAR(5) PRIMARY KEY,
    name NVARCHAR(25) NOT NULL,
    UserType NVARCHAR(1) NOT NULL,
    CONSTRAINT CHK_UserType CHECK (UserType IN ('B', 'M', 'E'))
);
GO

CREATE TABLE Stores (
    id VARCHAR(5) PRIMARY KEY,
    user_id VARCHAR(5) NOT NULL,
    name NVARCHAR(25) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);
GO

CREATE TABLE JobCatalog(
    user_id VARCHAR(5) NOT NULL,  
    store_id VARCHAR(5) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (store_id) REFERENCES Stores(id)
);
GO

CREATE TABLE Items(
    id VARCHAR(5) PRIMARY KEY,
    store_id VARCHAR(5) NOT NULL,
    name NVARCHAR(25) NOT NULL,
    price NVARCHAR(25) NOT NULL,
    FOREIGN KEY (store_id) REFERENCES Stores(id)
);
GO

CREATE TABLE Bills(
    id VARCHAR(5) PRIMARY KEY,
    store_id VARCHAR(5) NOT NULL,
    paymentType NVARCHAR(1) NOT NULL,
    CONSTRAINT CHK_PaymentType CHECK (paymentType IN ('P', 'A')),
    FOREIGN KEY (store_id) REFERENCES Stores(id)
);
GO

CREATE TABLE ProductCatalog(
    bill_id VARCHAR(5) NOT NULL,
    item_id VARCHAR(5) NOT NULL,
    tax FLOAT NOT NULL,
    count INTEGER NOT NULL,
    amount_total FLOAT,
    FOREIGN KEY (bill_id) REFERENCES Bills(id),
    FOREIGN KEY (item_id) REFERENCES Items(id)
);
GO

-- Tạo trigger để áp dụng ràng buộc kiểu người dùng trên JobCatalog
CREATE OR ALTER TRIGGER trg_JobCatalog_UserTypeCheck
ON JobCatalog
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Users u ON i.user_id = u.id
        WHERE u.UserType <> 'E'
    )
    BEGIN
        RAISERROR ('Chỉ người dùng thuộc loại "E" mới có thể được gán vào công việc.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    INSERT INTO JobCatalog (user_id, store_id)
    SELECT user_id, store_id
    FROM inserted;
END;
GO


-- Tạo trigger để áp dụng ràng buộc kiểu người dùng trên Stores
CREATE OR ALTER TRIGGER trg_stores_UserTypeCheck
ON Stores
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Users u ON i.user_id = u.id
        WHERE u.UserType <> 'M'
    )
    BEGIN
        RAISERROR ('Chỉ người dùng thuộc loại "P" mới có thể được gán vào công việc.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    INSERT INTO Stores (id, user_id, name)
    SELECT id, user_id, name
    FROM inserted;
END;

-- Chèn các dòng vào bảng Items 
INSERT INTO Users (id, name, UserType)
VALUES ('us001', 'Manager', 'M');

INSERT INTO Users (id, name, UserType)
VALUES ('us002', 'Buyeer', 'B');

INSERT INTO Users (id, name, UserType)
VALUES ('us003', 'Employee', 'E');

-- Chèn một dòng vào bảng JobCatalog
INSERT INTO JobCatalog (user_id, store_id)
VALUES ('us003', 'st001');

-- Chèn một dòng vào bảng Stores
INSERT INTO Stores (id, user_id, name)
VALUES ('st001', 'us001', 'Cửa hàng 1');

-- Chèn một dòng vào bảng Items
INSERT INTO Items (id, store_id, name, price)
VALUES ('it001', 'st001', N'Tra  sua', '25000'); 
-- Chèn một dòng vào bảng Items

INSERT INTO Items (id, store_id, name, price)
VALUES ('it002', 'st001', N'ca phe', '20000'); 


-- Chèn một dòng vào bảng Bills
INSERT INTO Bills (id, store_id, paymentType)
VALUES ('bi001', 'st001', 'P');

-- Chèn một dòng vào bảng ProductCatalog
INSERT INTO ProductCatalog(bill_id, item_id, tax, count, tax_amount_total, amount_total)
SELECT 'bi001', 'it001', 0.1, 2, price * 0.1, (price * 2) + (price * 0.1)
FROM Items
WHERE id = 'it001'; 




