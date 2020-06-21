drop database if exists business;
create database business;
use business;

create table Customers (
	CustomerID int NOT NULL auto_increment,
    CompanyName varchar(40),
    Country varchar(40),
    City varchar(40),
    primary key (CustomerID)
);
insert into Customers (CustomerID, CompanyName, Country, City) values(1, "Company", "Deutschland", "Berlin");