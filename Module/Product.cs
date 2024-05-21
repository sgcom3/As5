namespace Project.Module
{
    public class Product
    {
        // Primary key
        public int Id { get; set; }

        // Product name, cannot be null
        public string? Name { get; set; }

        // Product description, optional
        public string? Description { get; set; }

        // Product price, cannot be null
        public int? Price { get; set; }

        // Category of the product, cannot be null
        public string? Category { get; set; }

        // Subcategory of the product, optional
        public string? Subcategory { get; set; }
    }
    public class User
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
