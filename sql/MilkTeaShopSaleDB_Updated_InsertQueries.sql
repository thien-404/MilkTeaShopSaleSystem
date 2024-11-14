SET IDENTITY_INSERT Users ON;
INSERT INTO Users (user_id, user_name, email, password, user_role, user_status) VALUES
(1, 'alice', 'alice@example.com', '12345', 'Manager', 2),
(2, 'bob', 'bob@example.com', '12345', 'Cashier', 2),
(3, 'charlie', 'charlie@example.com', '12345', 'Manager', 1),
(4, 'dave', 'dave@example.com', '12345', 'Cashier', 2);
SET IDENTITY_INSERT Users OFF;

-- Enable IDENTITY_INSERT for Drinks table
SET IDENTITY_INSERT Drinks ON;
INSERT INTO Drinks (drink_id, drink_name, description, drink_status) VALUES
(1, 'Milk Tea', 'Classic milk tea with tapioca pearls', 2),
(2, 'Green Tea', 'Freshly brewed green tea', 2),
(3, 'Taro Tea', 'Creamy taro-flavored tea', 1),
(4, 'Matcha Latte', 'Rich matcha latte with milk', 2),
(5, 'Thai Tea', 'Sweet and creamy Thai tea', 2),
(6, 'Oolong Tea', 'Light and fragrant oolong tea', 2),
(7, 'Honeydew Milk Tea', 'Refreshing honeydew-flavored milk tea', 2),
(8, 'Brown Sugar Boba', 'Milk tea with brown sugar syrup and boba', 2),
(9, 'Jasmine Tea', 'Delicate jasmine tea with a floral aroma', 2),
(10, 'Passionfruit Green Tea', 'Green tea with passionfruit flavor', 2);
SET IDENTITY_INSERT Drinks OFF;

-- Insert into Prices table
INSERT INTO Prices (drink_id, size, price, price_status) VALUES
(1, 'Small', 2.50, 2),
(1, 'Large', 3.50, 2),
(2, 'Medium', 3.00, 2),
(3, 'Large', 3.75, 1),
(4, 'Large', 4.00, 2),
(5, 'Medium', 3.25, 2),
(6, 'Small', 2.75, 2),
(7, 'Medium', 3.50, 2),
(8, 'Large', 4.00, 2),
(9, 'Large', 3.75, 2),
(10, 'Large', 4.25, 2),
(6, 'Medium', 3.00, 2),
(7, 'Large', 4.00, 2),
(8, 'Small', 3.25, 2),
(9, 'Medium', 3.50, 2)