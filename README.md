# MVC_Pattern

<h2>MVC 01</h2>


Document: https://www.geeksforgeeks.org/mvc-design-pattern/


<h4>MVC pattern diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/0a9003de-1b2a-42fb-a4c8-fa8769fbaec4)


<h4>Class diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/c9dadf13-b27e-48fc-a89e-6a333f319d8d)


<h2>MVC 02</h2>


Document: https://guides.visual-paradigm.com/from-use-case-to-mvc-framework-a-guide-object-oriented-system-development/

<h4>Example: Car Rental System</h4>


<h4>Problem Description: A car rental company wants to develop a software system that will enable customers to rent cars online. Customers should be able to browse available cars, select a car to rent, and make a reservation. The system should keep track of the availability of cars, as well as the reservations made by customers.</h4>


<h4>usecase diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/b26a4688-6b1f-43c6-b781-65b06db892b2)


<h4>ERD diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/55364a5f-c810-481c-8ff8-a5f2476a8284)


<h4>Class diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/60193546-a18b-4e26-9923-3d1d300446ef)


<h4>Sequeue diagrame</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/6904056f-0a0a-49fc-bb91-86b55a388de8)


<h4>Class diagrame with MVC pattern</h4>


![image](https://github.com/Vokhanh12/MVC_Pattern/assets/36543564/dc09b2f1-0752-4a01-99be-a4aebdc20250)


<h2>MVC 03</h2>


<h4>SQL Server</h4>


```sql

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

```







