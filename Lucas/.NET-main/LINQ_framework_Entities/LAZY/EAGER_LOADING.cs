static void ExB2()
{
    WriteLine();
    WriteLine("B2 LAZY LOADIGN - Produits par categories");

    using(NorthwindContext context = new NorthwindContext())
    {
        IQueryable<Category> categories = from Category c in context.Categories
                       where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                       select c;

        foreach(Category category in categories)
        {
            WriteLine("Catégori : {0}", category.CategoryName);

            foreach(Product product in category.Products)
            {
                WriteLine("{0}", product.ProductName);
            }
        }
    }
}

static void ExB3()
{

    WriteLine();
    WriteLine("B3 EAGER LOADING - Produits par categories");

    using (NorthwindContext context = new NorthwindContext())
    {

        IQueryable<Category> categories = from Category c in context.Categories.Include("Products")
                                          where (c.CategoryName == "Beverages" || c.CategoryName == "Condiments")
                                          select c;

        foreach (Category c in categories)
        {
            WriteLine("Catégorie :  " + c.CategoryName);
            foreach (Product p in c.Products)
            {
                WriteLine(p.ProductName);
            }
        }
    }


}