INSERT INTO Customer(Name, Surname) VALUES ('Jakub', 'Michalski');
INSERT INTO Customer(Name, Surname) VALUES ('Ania', 'Anielska');
INSERT INTO Employee(Name, Surname) VALUES ('Kamil', 'Niewiem');
INSERT INTO Orders( DateAccepted, DateFinished, Notes, IdClient, IdEmployee) VALUES ('2020-06-09', '2020-06-10', 'somenotes', 1, 1);
INSERT INTO Confectionery(Name, PricePerlte, Type) VALUES ('BirthadayCake', 2.50, 'Cake');
INSERT INTO Confectionery_Order(IdConfection, IdOrder, Quantity, Notes) VALUES (1, 1, 3, 'Somenotes');

SELECT * FROM Customer;
SELECT * FROM Employee;
SELECT * FROM Orders;
SELECT * FROM Confectionery_Order;
SELECT * FROM Confectionery;
