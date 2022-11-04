CREATE TABLE [dbo].[OrderedIngredients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[IngredientId] INT NOT NULL FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id),
	[OrderedPizzaId] INT NOT NULL FOREIGN KEY (OrderedPizzaId) REFERENCES OrderedPizzas(Id),
	[Price] MONEY NOT NULL,
	[Quantity] INT NOT NULL
)
