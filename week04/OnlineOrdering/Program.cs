using System;
using System.Collections.Generic;
using System.Linq;


public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
    
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Equals("United States", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddressString()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }


    public string Street { get => _street; set => _street = value; }
    public string City { get => _city; set => _city = value; }
    public string StateProvince { get => _stateProvince; set => _stateProvince = value; }
    public string Country { get => _country; set => _country = value; }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string Name => _name;
    public Address Address => _address;
}

public class Product
{
    private string _name;
    private string _productId;
    private decimal _unitPrice;
    private int _quantity;

    public Product(string name, string productId, decimal unitPrice, int quantity)
    {
        _name = name;
        _productId = productId;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _unitPrice * _quantity;
    }


    public string Name => _name;
    public string ProductId => _productId;
}

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal ShippingCostUSA = 5.0m;
    private const decimal ShippingCostInternational = 35.0m;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productsTotal = _products.Sum(p => p.GetTotalCost());
        decimal shippingCost = _customer.LivesInUSA() ? ShippingCostUSA : ShippingCostInternational;
        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (var product in _products)
        {
            label += $"Name: {product.Name} | ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        // The requirement is to list the name and address of the customer
        string label = "--- Shipping Label ---\n";
        label += $"Customer: {_customer.Name}\n";
        label += "Address:\n";
        label += _customer.Address.GetFullAddressString();
        return label;
    }
}


class Program
{
    static void Main(string[] args)
    {

        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("Eusebio Ngoy", address1);

        Product p1 = new Product("Laptop", "P1001", 999.99m, 1);
        Product p2 = new Product("Mouse", "A500", 15.50m, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Console.WriteLine("***** Order 1 (Domestic) Details *****");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\n" + order1.GetPackingLabel());
    
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n=======================================\n");

       

        Address address2 = new Address("45 Rue de la Paix", "Paris", "Ile-de-France", "France");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product p3 = new Product("Headphones", "H800", 150.00m, 1);
        Product p4 = new Product("Adapter", "E900", 5.00m, 3);
        Product p5 = new Product("Book", "B404", 25.00m, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        Console.WriteLine("***** Order 2 (International) Details *****");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\n" + order2.GetPackingLabel());
    
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("\n=======================================\n");
    }
}
