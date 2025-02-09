CREATE VIEW [ProductView] AS

select
	P.Name,P.Description,P.Qunatity,P.SalePrice,P.Image1,P.UnitPrice,P.Satatus,C.Name categoryName,P.id
from Products P
left outer join Category C on C.id=P.CategoryId;

