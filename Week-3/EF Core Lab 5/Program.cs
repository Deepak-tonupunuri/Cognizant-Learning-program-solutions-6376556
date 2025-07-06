using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Check if categories already exist
    if (!context.Categories.Any())
    {
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);

        await context.SaveChangesAsync();
    }
}

// 🧪 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // 1. Retrieve all products
    var products = await context.Products
                                .Include(p => p.Category)  
                                .ToListAsync();

    Console.WriteLine("\n📦 All Products:");
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category?.Name})");

    // 2. Find a product by ID
    var product = await context.Products.FindAsync(1);
    Console.WriteLine($"\n🔍 Found by ID: {product?.Name} - ₹{product?.Price}");

    // 3. Find first product with price > 50,000
    var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"\n💰 Expensive Product: {expensive?.Name} - ₹{expensive?.Price}");
}

app.Run();

