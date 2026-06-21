
-- 1. CREATE TABLE

CREATE TABLE Products (
    ProductID INT,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

-- 2. INSERT SAMPLE DATA (WITH TIES)

INSERT INTO Products VALUES
(1, 'Laptop A', 'Electronics', 1500),
(2, 'Laptop B', 'Electronics', 1200),
(3, 'Laptop C', 'Electronics', 1200),
(4, 'Phone A', 'Electronics', 800),
(5, 'Phone B', 'Electronics', 800),

(6, 'Mouse A', 'Accessories', 200),
(7, 'Mouse B', 'Accessories', 200),
(8, 'Keyboard', 'Accessories', 150),
(9, 'USB Hub', 'Accessories', 100);

-- 3. ROW_NUMBER() - TOP 3 PER CATEGORY

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS RowNum
    FROM Products
) AS RowNumbered
WHERE RowNum <= 3;



-- 4. RANK() - TOP 3 PER CATEGORY

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS RankNum
    FROM Products
) AS Ranked
WHERE RankNum <= 3;



-- 5. DENSE_RANK() - TOP 3 PER CATEGORY

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER (
            PARTITION BY Category 
            ORDER BY Price DESC
        ) AS DenseRankNum
    FROM Products
) AS DenseRanked
WHERE DenseRankNum <= 3;