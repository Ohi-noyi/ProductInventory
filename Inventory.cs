
static void Main(string[] args)
{
 var inventory = new ProductInventory();
      {  
        
        inventory.AddProduct(101, "Laptop", 999.99m, 10);
        inventory.AddProduct(102, "Smartphone", 699.99m, 25);
        inventory.AddProduct(103, "Headphones", 149.99m, 50);
        
        
        inventory.DisplayInventory();
        
       
        inventory.UpdateQuantity(102, 20);
        
        inventory.GetProductInfo(101);
        
       
        inventory.RemoveProduct(103);
        
       
        inventory.DisplayInventory();
      }
}