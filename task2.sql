select p.Name as ProductName, c.Name as CategoryName
 from Product p
 left join ProductCategory pc on p.ID = pc.ProductID
 left join Category c on pc.CategoryID = c.ID
