# Database-Repository-Pattern
Einfache Lösung für den Datenbankzugriff mittels Repository Pattern und ohne Entity Framework (EF)

## Plain Old CLR Object (POCO)
 - Normales .NET Objekt ohne Infrastruktur

 Zunächst wird aus der Datenbanktabelle ein POCO Objekt erstellt.
 Angenommen wir haben eine Tabelle Namens Customer:
 ```sql
 create table Customers (
	CustomerID int NOT NULL auto_increment,
    CompanyName varchar(40),
    Country varchar(40),
    City varchar(40),
    primary key (CustomerID)
);
 ```
 Daraus wird folgendes Objekt:
  ```c#
public class Customer
{
    public int CustomerID { set; get; }
    public string CompanyName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
```

## Single Resonsibility Principle (S of S.O.L.I.D)
 - Eine Klasse sollte nur eine Aufgabe haben.
 - Das erhöht die Wartbarkeit und Änderungen an einer Klasse beeinflussen nicht die anderen Klassen.
 - Das wird hier durch das Repository erreicht.
 
## Repository Pattern
 - Bei dem Repository Pattern legt man im Prinzip ein Facade Pattern vor den Datenbankzugriff.
 - Der Rest des Programms muss nicht wissen wie der Datenbankzugriff funktioniert.
 


Für die Repository Klasse wird ein Interface mit allen typischen CRUD (Create, Read, Update, Delete) Operationen angelegt. Da in der Regel alle Datensätze und ein spezieller Datensatz abgefragt wird, kommen noch die Methoden `GetAll()` und `GetById()` hinzu.
```c#
public interface IRepository <T>
{
    public List<T> GetAll();
    public T GetById(int id);
    public void Insert(T model);
    public void Update(T model);
    public void Delete(int id);
}
```
Das Interface ist generisch, damit es für alle Repositories wiederverwendet werden kann.
 
