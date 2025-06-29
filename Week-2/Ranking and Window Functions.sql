DROP TABLE IF EXISTS Product;
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    Product VARCHAR(20),
    CategoryID INT,
    Price DECIMAL(10,2)
);

INSERT INTO Product (ProductID, Product, CategoryID, Price) VALUES 
(1, 'iPhone 15', 1, 1200.00),
(2, 'Galaxy S23', 1, 1100.00),
(3, 'Pixel 8', 1, 1100.00),
(4, 'Redmi Note 12', 1, 300.00),
(5, 'Dell XPS', 2, 1500.00),
(6, 'MacBook Pro', 2, 1500.00),
(7, 'HP Pavilion', 2, 950.00),
(8, 'Lenovo Ideapad', 2, 700.00);

SELECT 
    ProductID,
    Product,
    CategoryID,
    Price,

    -- Assigns a unique row number regardless of ties
    ROW_NUMBER() OVER (PARTITION BY CategoryID ORDER BY Price DESC) AS RowNum,

    -- Assigns the same rank to tied prices but skips the next number(s)
    RANK() OVER (PARTITION BY CategoryID ORDER BY Price DESC) AS PriceRank,

    -- Assigns the same rank to tied prices without skipping any numbers
    DENSE_RANK() OVER (PARTITION BY CategoryID ORDER BY Price DESC) AS DensePriceRank

FROM 
    Product;
