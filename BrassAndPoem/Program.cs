//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Formats.Asn1;
using System.IO.Compression;

List<Product> products = new List<Product>()
{
new Product()
    {
    Name = "Trumpet",
    Price = 19.99M,
    ProductTypeId = 1,
    },
    new Product()
    {
    Name = "French Horn",
    Price = 29.99M,
    ProductTypeId = 1,
    },
    new Product()
    {
    Name = "Tuba",
    Price = 21.99M,
    ProductTypeId = 1,
    },
    new Product()
    {
    Name = "The Road Not Taken",
    Price = 99.99M,
    ProductTypeId = 2,
    },
    new Product()
    {
    Name = "Fire and Ice",
    Price = 199.99M,
    ProductTypeId = 2,
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
new ProductType()
{
    Title = "Brass",
    Id = 1
},
new ProductType()
{
    Title = "Poem",
    Id = 2
}
};

// Greeting goes here
string greeting = @"
Welcome To The Brass & Poem
Book 1 Self Assessment";

Console.WriteLine(greeting);

// Implement your loop here
string choice = null;
while (choice != "5")
{
    DisplayMenu();

    if (int.TryParse(Console.ReadLine(), out int userChoice))
    {
        switch (userChoice)
        {
            case 1:
                DisplayAllProducts(products, productTypes);
                break;

            case 2:
                DeleteProduct(products, productTypes);
                break;

            case 3:
                AddProduct(products, productTypes);
                break;

            case 4:
                UpdateProduct(products, productTypes);
                break;

            case 5:
                Console.WriteLine("See Ya!");
                Environment.Exit(5);
                break;

        }
    }
}


// Menu method to be called when asking user what action they would like to take
void DisplayMenu()
{
    Console.WriteLine(@"
Select an option:
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit"
);
}

// Iterate through products and display name and price
void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("All products in inventory:");

    for (int i = 0; i < products.Count; i++)
    {
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. {products[i].Name} is a {productType.Title} and is currently for sale for ${products[i].Price}.");
    }
}


// Display all products and allow user to delete product of their choice
void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Product gettingDeleted = null;

    while (gettingDeleted == null)
    {
        Console.WriteLine("Enter the product number you wish to delete:");

        try
        {
            int response = int.Parse(Console.ReadLine());
            gettingDeleted = products[response - 1];

            products.RemoveAt(response - 1);

            Console.WriteLine($"{gettingDeleted.Name} was successfully deleted.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Type integers only.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Choose an existing product.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Product newProduct = new Product();

    //Product name
    Console.WriteLine("Enter products name:");
    var newProductName = Console.ReadLine();

    //Product price 
    Console.WriteLine("Enter product price:");
    decimal newProductPrice = decimal.Parse(Console.ReadLine());

    //Product ProductTypeId
    Console.WriteLine(@"Enter new products ProductTypeId
1 = Brass and 2 = Poem:");
    int newProductProductTypeId = int.Parse(Console.ReadLine());

    newProduct.Name = newProductName;
    newProduct.Price = newProductPrice;
    newProduct.ProductTypeId = newProductProductTypeId;

    ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == newProduct.ProductTypeId);
    Console.WriteLine(@$"
    New Product:
    {newProduct.Name} is a {productType.Title} and is currently for sale for ${newProduct.Price}.");

    products.Add(newProduct);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Enter the number of the product you wish to modify:");

        try
        {
            int response = int.Parse(Console.ReadLine());
            chosenProduct = products[response - 1];

            // Update Name
            Console.WriteLine($"Enter the new name for {chosenProduct.Name}:");
            var newName = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName))
            {
                chosenProduct.Name = newName;
            }

            //Update Price
            Console.WriteLine($"Enter the new price (currently {chosenProduct.Price} ):");
            var newPrice = Console.ReadLine();

            if (!string.IsNullOrEmpty(newPrice))
            {
                chosenProduct.Price = decimal.Parse(newPrice);
            }

            //Update Product Type
            Console.WriteLine($@"Enter new ProductTypeId
        1 = Brass and 2 = Poem:");
            var newProductTypeId = Console.ReadLine();

            if (!string.IsNullOrEmpty(newProductTypeId))
            {
                chosenProduct.ProductTypeId = int.Parse(newProductTypeId);
            }

            ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == chosenProduct.ProductTypeId);

            Console.WriteLine(@$"
        Updated Product:
        {chosenProduct.Name} is a {productType.Title} and is currently for sale for ${chosenProduct.Price}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


    }
}

// don't move or change this!
public partial class Program { }