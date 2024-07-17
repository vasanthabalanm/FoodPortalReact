/* MICRO SERVICE DB FOR OWNER*/
/*DBNAME:FoodOwner*/
CREATE TABLE ApprovedUsers (Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
							UserName NVARCHAR(MAX),
							Email NVARCHAR(MAX),
							UserPassword NVARCHAR(MAX),
							UserRole NVARCHAR(MAX),
							UserPhone NVARCHAR(MAX),
							UserLocation NVARCHAR(MAX),
							TempPassword NVARCHAR(MAX));
CREATE TABLE PendingUser (Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
							UserName NVARCHAR(MAX),
							Email NVARCHAR(MAX),
							UserPassword NVARCHAR(MAX),
							UserRole NVARCHAR(MAX),
							UserPhone NVARCHAR(MAX),
							UserLocation NVARCHAR(MAX),
							TempPassword NVARCHAR(MAX));

/*Approved User SP*/
{
  "userName": "Admin",
  "email": "balanm8014@gmail.com",
  "userPassword": "Admin@123",
  "userRole": "Admin",
  "userPhone": "9830983780",
  "userLocation": "Chennai"
}
/*Get new arrivels*/
	create PROC GetNewArrivals
	AS
	BEGIN
	SELECT Id,UserName, UserRole, Email from ApprovedUsers where UserRole IN ('User', 'Vendor') group by Id,UserName, UserRole, Email order by max(Id) desc;
	END

exec GetNewArrivals

SELECT * FROM dbo.ApprovedUsers
/**/
select count(*) as ApprovedUser from ApprovedUsers where UserRole = 'User'
/**/
/**/
/**/
/**/
/**/
/**/
/**/
/**/
/**/
/**/


/*sample data*/
	insert into ApprovedUsers values('Admin','Admin1@gmail.com','Admin1@123','Admin',8392893892,'Chennai','deedaDf21k');
	delete from ApprovedUsers where id =1;

	select * from ApprovedUsers


	


/*Pending User SP*/

/*Add User*/
/*Get User*/
/*Delete User*/

/*Add Vendor*/
/*Get Vendor*/
/*Delete Vendor*/




/*MICROSERVICE DB FOR HOTEL AND THE ORDER DETAILS*/
/*DBNAME:FoodHotelManager*/
CREATE TABLE Hotel (Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
					HotelName NVARCHAR(MAX),
					ApprovedUsersId INT);

create table HotelBranch (Id INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
						  BranchName NVARCHAR(MAX),
						  BranchLocation NVARCHAR(MAX),
						  BranchPhoneNumber NVARCHAR(MAX),
						  HotelId INT FOREIGN KEY (HotelId) REFERENCES Hotel(Id));

create table MenuDetails (Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
						  MenuItems NVARCHAR(MAX),
						  MenuQuantity INT,
						  Price MONEY,
						  HotelBranchId INT FOREIGN KEY (HotelBranchId) REFERENCES HotelBranch(Id));

create table Orders(Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
					ApprovedUsersId INT,
					HotelBranchId INT FOREIGN KEY (HotelBranchId) REFERENCES HotelBranch(Id),
					MenuDetailsId INT FOREIGN KEY (MenuDetailsId) REFERENCES MenuDetails(Id),
					QuantityOfOrder INT,
					TotalPrice MONEY,
					OrderStatus NVARCHAR(MAX));

/*filter*/
create proc filterMenu @menuItems varchar(50),@branchLocation varchar(30)
as
	begin 
	select MenuDetails.Id, MenuDetails.MenuItems,MenuDetails.Price, HotelBranch.BranchName,HotelBranch.BranchLocation,MenuDetails.HotelBranchId
	from MenuDetails
	join HotelBranch on MenuDetails.HotelBranchId = HotelBranch.Id where MenuDetails.MenuItems = @menuItems and  HotelBranch.BranchLocation= @branchLocation;
end

exec filterMenu @menuItems='Pizza', @branchLocation='Karpakam'

/*show menu list*/
create proc ShowMenuDetail
as
	begin
	SELECT MenuDetails.Id, MenuDetails.MenuItems,MenuDetails.Price, HotelBranch.BranchName,HotelBranch.BranchLocation,MenuDetails.HotelBranchId
	FROM MenuDetails
	JOIN HotelBranch ON MenuDetails.HotelBranchId = HotelBranch.Id;
end
exec ShowMenuDetail

/*in user role they can view their pending orders*/
alter proc UsersOrders @userId int
as
	begin
	select MenuDetails.Id,Orders.QuantityOfOrder,Orders.ApprovedUsersId,Orders.OrderStatus,Orders.TotalPrice,MenuDetails.MenuItems,HotelBranch.BranchName from Orders
	join MenuDetails on Orders.MenuDetailsId = MenuDetails.Id
	join HotelBranch on Orders.HotelBranchId = HotelBranch.Id
	where Orders.ApprovedUsersId = @userId and Orders.OrderStatus = 'Pending'
end

exec UsersOrders @userId =2
/*approved order list by specific user*/
alter proc ApprovedUsersOrders @userId int
as
	begin
	select MenuDetails.Id,Orders.QuantityOfOrder,Orders.OrderStatus,Orders.TotalPrice,MenuDetails.MenuItems,HotelBranch.BranchName,Orders.ApprovedUsersId from Orders
	join MenuDetails on Orders.MenuDetailsId = MenuDetails.Id
	join HotelBranch on Orders.HotelBranchId = HotelBranch.Id
	where Orders.ApprovedUsersId = @userId and Orders.OrderStatus = 'Approved' 
end

exec ApprovedUsersOrders @userId =11

/*admin approve order*/
/*alter PROCEDURE ApporoveOrder 
    @orderId INT,
	@userId INT,
    @userRole NVARCHAR(30)
AS
BEGIN
    IF @userRole = 'Admin'
    BEGIN
        UPDATE Orders
        SET OrderStatus = 'Approved'
        FROM Orders
        JOIN MenuDetails ON Orders.MenuDetailsId = MenuDetails.Id
        JOIN HotelBranch ON Orders.HotelBranchId = HotelBranch.Id
        JOIN Hotel ON HotelBranch.HotelId = Hotel.Id
        WHERE Hotel.ApprovedUsersId = @userId AND  Orders.Id = @orderId;
    END
    ELSE
    BEGIN
		select MenuDetails.Id,Orders.QuantityOfOrder,Orders.OrderStatus,Orders.TotalPrice,MenuDetails.MenuItems,HotelBranch.BranchName,Orders.ApprovedUsersId from Orders
    END
END*/

alter PROCEDURE ApporoveOrder 
    @orderId INT,
	@userRole NVARCHAR(30)
   
AS
BEGIN
    SET NOCOUNT ON;

    IF @userRole = 'Admin'
    BEGIN
        UPDATE O
        SET O.OrderStatus = 'Approved'
        FROM Orders O
        INNER JOIN MenuDetails MD ON O.MenuDetailsId = MD.Id
        INNER JOIN HotelBranch HB ON O.HotelBranchId = HB.Id
        INNER JOIN Hotel H ON HB.HotelId = H.Id
        WHERE O.Id = @orderId;

		SELECT MD.Id,
               O.QuantityOfOrder,
               O.OrderStatus,
               O.TotalPrice,
               MD.MenuItems,
               HB.BranchName,
               O.ApprovedUsersId
        FROM Orders O
        INNER JOIN MenuDetails MD ON O.MenuDetailsId = MD.Id
        INNER JOIN HotelBranch HB ON O.HotelBranchId = HB.Id
        WHERE O.Id = @orderId;
        
    END
    ELSE
    BEGIN
        SELECT MD.Id,
               O.QuantityOfOrder,
               O.OrderStatus,
               O.TotalPrice,
               MD.MenuItems,
               HB.BranchName,
               O.ApprovedUsersId
        FROM Orders O
        INNER JOIN MenuDetails MD ON O.MenuDetailsId = MD.Id
        INNER JOIN HotelBranch HB ON O.HotelBranchId = HB.Id
        WHERE O.Id = @orderId;
    END
END

exec ApporoveOrder @orderId=3,@userRole='Admin';

select * from ApprovedUsers
/*get mail by orderid*/

create proc getEmail @orderID int
as
	begin
	select ApprovedUsers.Email from ApprovedUsers 
	join Orders on Orders.ApprovedUsersId = ApprovedUsers.Id
	WHERE Orders.Id = @orderID;
end

exec getEmail @orderID = 5



/*get all menu order by login admin or vendor id*/
alter proc sendemail
as
	begin
	select Orders.Id,Orders.ApprovedUsersId, MenuDetails.MenuItems,HotelBranch.BranchName,Orders.QuantityOfOrder,Orders.totalPrice,Orders.OrderStatus
	from Orders join MenuDetails on Orders.MenuDetailsId = MenuDetails.Id
	join HotelBranch on Orders.HotelBranchId = HotelBranch.Id
end

exec sendemail 