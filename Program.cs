using System;
using System.Collections.Generic;

public class ProductInventory
{
    
    private Dictionary<int, int> inventory = new Dictionary<int, int>();
    
    
    private Dictionary<int, string> productNames = new Dictionary<int, string>();
    
    
    private Dictionary<int, decimal> productPrices = new Dictionary<int, decimal>();

    
    public void AddProduct(int productId, string productName, decimal price, int initialQuantity)
    {
        if (inventory.ContainsKey(productId))
        {
            Console.WriteLine($"Product with ID {productId} already exists.");
        }
        else
        {
            inventory[productId] = initialQuantity;
            productNames[productId] = productName;
            productPrices[productId] = price;
            Console.WriteLine($"Product '{productName}' added to inventory with {initialQuantity} units.");
        }
    }

    
    public void RemoveProduct(int productId)
    {
        if (inventory.ContainsKey(productId))
        {
            string productName = productNames[productId];
            inventory.Remove(productId);
            productNames.Remove(productId);
            productPrices.Remove(productId);
            Console.WriteLine($"Product '{productName}' (ID: {productId}) removed from inventory.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found in inventory.");
        }
    }

    public void UpdateQuantity(int productId, int newQuantity)
    {
        if (inventory.ContainsKey(productId))
        {
            inventory[productId] = newQuantity;
            Console.WriteLine($"Quantity for product ID {productId} updated to {newQuantity}.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found in inventory.");
        }
    }

    public void DisplayInventory()
    {
        Console.WriteLine("\nCurrent Inventory:");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("ID\tName\t\tPrice\t\tQuantity");
        Console.WriteLine("--------------------------------------------------");
        
        foreach (var kvp in inventory)
        {
            int productId = kvp.Key;
            Console.WriteLine($"{productId}\t{productNames[productId]}\t\t{productPrices[productId]:C}\t\t{kvp.Value}");
        }
        
        Console.WriteLine("--------------------------------------------------\n");
    }

    
    public int GetQuantity(int productId)
    {
        if (inventory.ContainsKey(productId))
        {
            return inventory[productId];
        }
        return -1; 
    }

    
    public void GetProductInfo(int productId)
    {
        if (inventory.ContainsKey(productId))
        {
            Console.WriteLine($"Product ID: {productId}");
            Console.WriteLine($"Name: {productNames[productId]}");
            Console.WriteLine($"Price: {productPrices[productId]:C}");
            Console.WriteLine($"Quantity in stock: {inventory[productId]}");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found in inventory.");
        }
    }
}


