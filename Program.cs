
class ProductInventory
{
    private Dictionary<string, Product> inventory = new Dictionary<string, Product>();

    static void Main(string[] args)
    {
        var system = new ProductInventory();
        system.Run();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Avocado Inventory Management System");
        Console.WriteLine("---------------------------------");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Product");
            Console.WriteLine("3. Update Product Quantity");
            Console.WriteLine("4. List All Products");
            Console.WriteLine("5. Remove Product");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ViewProduct();
                    break;
                case "3":
                    UpdateProductQuantity();
                    break;
                case "4":
                    ListAllProducts();
                    break;
                case "5":
                    RemoveProduct();
                    break;
                case "6":
                    Console.WriteLine("Exiting system...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.Write("Enter product ID: ");
        string id = Console.ReadLine();

        if (inventory.ContainsKey(id))
        {
            Console.WriteLine("Product ID already exists!");
            return;
        }

        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
        {
            Console.Write("Invalid price. Please enter a positive number: ");
        }

        Console.Write("Enter initial quantity: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.Write("Invalid quantity. Please enter a non-negative number: ");
        }

        inventory[id] = new Product(name, price, quantity);
        Console.WriteLine("Product added successfully!");
    }

    private void ViewProduct()
    {
        Console.Write("Enter product ID: ");
        string id = Console.ReadLine();

        if (inventory.TryGetValue(id, out Product product))
        {
            Console.WriteLine($"\nProduct ID: {id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price:C}");
            Console.WriteLine($"Quantity: {product.Quantity}");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    private void UpdateProductQuantity()
    {
        Console.Write("Enter product ID: ");
        string id = Console.ReadLine();

        if (!inventory.ContainsKey(id))
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.Write("Enter quantity change (use + or - to adjust): ");
        int change;
        while (!int.TryParse(Console.ReadLine(), out change))
        {
            Console.Write("Invalid input. Please enter a whole number: ");
        }

        Product product = inventory[id];
        int newQuantity = product.Quantity + change;

        if (newQuantity < 0)
        {
            Console.WriteLine("Cannot set quantity below 0. Setting to 0.");
            newQuantity = 0;
        }

        product.Quantity = newQuantity;
        Console.WriteLine($"Quantity updated. New quantity: {newQuantity}");
    }

    private void ListAllProducts()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        Console.WriteLine("ID\tName\t\tPrice\tQuantity");
        Console.WriteLine("----------------------------");
        
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Key}\t{item.Value.Name}\t{item.Value.Price:C}\t{item.Value.Quantity}");
        }
    }

    private void RemoveProduct()
    {
        Console.Write("Enter product ID to remove: ");
        string id = Console.ReadLine();

        if (inventory.Remove(id))
        {
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}