using System.Linq.Expressions;
using EcommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }




        // Add more DbSets here as needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    // Prevent cascade delete
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }

                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var isDeletedProp = Expression.Property(
                        parameter,
                        nameof(ISoftDeletable.IsDeleted)
                    );
                    var compare = Expression.Equal(isDeletedProp, Expression.Constant(false));
                    var lambda = Expression.Lambda(compare, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            var fixedCreatedAt = new DateTime(2025, 7, 4, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Electronics",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Fashion",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Home & Kitchen",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Beauty & Personal Care",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Health & Wellness",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Books & Stationery",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 7,
                        Name = "Toys & Baby Products",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 8,
                        Name = "Sports & Outdoors",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 9,
                        Name = "Groceries & Food",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 10,
                        Name = "Automotive",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 11,
                        Name = "Pet Supplies",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 12,
                        Name = "Jewelry & Watches",
                        CreatedAt = fixedCreatedAt,
                    },
                    new Category
                    {
                        Id = 13,
                        Name = "Gaming",
                        CreatedAt = fixedCreatedAt,
                    }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 4, Name = "Aloe Vera Moisturizer", Description = "Hydrates and soothes dry skin with natural ingredients.", Price = 42.99m, StockQuantity = 54, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 5, Name = "Digital Thermometer", Description = "Accurate temperature readings in seconds.", Price = 18.75m, StockQuantity = 150, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 6, Name = "Hardcover Journal", Description = "Durable notebook for daily writing and notes.", Price = 12.50m, StockQuantity = 73, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 7, Name = "Educational Alphabet Blocks", Description = "Colorful blocks to teach kids letters and spelling.", Price = 22.99m, StockQuantity = 60, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 8, Name = "Yoga Mat with Strap", Description = "Non-slip surface ideal for workouts and yoga sessions.", Price = 29.99m, StockQuantity = 95, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 9, Name = "Organic Almond Butter", Description = "Smooth spread made from roasted organic almonds.", Price = 8.99m, StockQuantity = 120, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 10, Name = "Car Phone Mount", Description = "Hands-free phone use while driving.", Price = 15.00m, StockQuantity = 200, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 11, Name = "Pet Grooming Brush", Description = "Removes loose fur and detangles easily.", Price = 10.99m, StockQuantity = 88, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 12, Name = "Silver Charm Bracelet", Description = "Elegant design suitable for daily wear or gifts.", Price = 35.00m, StockQuantity = 33, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 13, Name = "Wireless Game Controller", Description = "Compatible with major gaming consoles and PCs.", Price = 49.99m, StockQuantity = 65, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 14, Name = "Smart LED Bulb", Description = "Color-changing bulb controlled by app or voice.", Price = 17.95m, StockQuantity = 110, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 15, Name = "Women's High-Waist Jeans", Description = "Stylish and stretchy denim for all-day comfort.", Price = 44.50m, StockQuantity = 75, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 16, Name = "Stainless Steel Cooking Utensils", Description = "Complete set with ladle, spatula, and whisk.", Price = 26.30m, StockQuantity = 40, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 17, Name = "Charcoal Face Wash", Description = "Removes impurities and refreshes skin.", Price = 14.20m, StockQuantity = 100, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 18, Name = "Vitamin C Tablets", Description = "Boosts immune system and skin health.", Price = 9.50m, StockQuantity = 130, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 19, Name = "Planner & To-Do List Pad", Description = "Organize your week with tear-off sheets.", Price = 11.75m, StockQuantity = 55, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 20, Name = "Baby Swaddle Blanket", Description = "Soft cotton for a cozy, snug fit.", Price = 19.80m, StockQuantity = 78, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 21, Name = "Resistance Bands Set", Description = "Full-body workout bands with varying resistance.", Price = 23.99m, StockQuantity = 49, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 22, Name = "Organic Green Tea Bags", Description = "Freshly sealed for quality and aroma.", Price = 6.99m, StockQuantity = 160, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 23, Name = "Car Vacuum Cleaner", Description = "Portable and powerful suction for quick cleanups.", Price = 32.90m, StockQuantity = 39, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 24, Name = "Cat Litter Mat", Description = "Traps litter and keeps floors clean.", Price = 13.25m, StockQuantity = 51, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 25, Name = "Men’s Leather Wristwatch", Description = "Classic analog watch with genuine leather band.", Price = 59.00m, StockQuantity = 29, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 26, Name = "Gaming Mouse with RGB Lighting", Description = "Customizable DPI and color profiles.", Price = 27.49m, StockQuantity = 90, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 27, Name = "Bluetooth Soundbar", Description = "Slim design fits under TV with immersive sound.", Price = 89.99m, StockQuantity = 20, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 28, Name = "Men’s Polo Shirt", Description = "Casual wear with a smart collar and short sleeves.", Price = 34.75m, StockQuantity = 66, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 29, Name = "Non-Stick Frying Pan", Description = "Durable pan perfect for everyday cooking needs.", Price = 21.50m, StockQuantity = 75, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 30, Name = "Hydrating Lip Balm", Description = "Keeps lips soft and moisturized all day.", Price = 5.99m, StockQuantity = 110, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 31, Name = "Digital Blood Pressure Monitor", Description = "Accurate home monitoring for your health.", Price = 38.20m, StockQuantity = 50, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 32, Name = "A5 Leather Notebook", Description = "Perfect for notes, journaling, or sketches.", Price = 14.00m, StockQuantity = 95, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 33, Name = "Infant Rattle Toy Set", Description = "Safe, colorful, and fun for your little one.", Price = 18.45m, StockQuantity = 62, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 34, Name = "Foam Roller", Description = "Great for muscle recovery and massage therapy.", Price = 25.00m, StockQuantity = 88, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 35, Name = "Organic Quinoa", Description = "High-protein whole grain, perfect for salads.", Price = 9.99m, StockQuantity = 145, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 36, Name = "Windshield Sun Shade", Description = "Keeps your car cool and protects the interior.", Price = 17.00m, StockQuantity = 80, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 37, Name = "Dog Chew Toy", Description = "Tough and fun toy for chewing and playing.", Price = 11.75m, StockQuantity = 120, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 38, Name = "Elegant Gold Necklace", Description = "A delicate piece for elegant outfits.", Price = 72.99m, StockQuantity = 24, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 39, Name = "Gaming Headset with Mic", Description = "Noise-canceling headset for immersive gameplay.", Price = 54.99m, StockQuantity = 35, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 40, Name = "Smartphone Gimbal", Description = "Stabilizer for smooth mobile video recording.", Price = 99.00m, StockQuantity = 15, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 41, Name = "Summer Maxi Dress", Description = "Lightweight and stylish for warm weather.", Price = 45.50m, StockQuantity = 60, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 42, Name = "Ceramic Mixing Bowls Set", Description = "Stackable bowls with beautiful patterns.", Price = 34.99m, StockQuantity = 70, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 43, Name = "Facial Cleansing Brush", Description = "Gently exfoliates and removes impurities.", Price = 29.90m, StockQuantity = 90, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 44, Name = "Fitness Tracker Watch", Description = "Monitors steps, heart rate, and sleep patterns.", Price = 59.00m, StockQuantity = 100, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 45, Name = "Sticky Notes Combo Pack", Description = "Assorted sizes and colors for quick reminders.", Price = 6.99m, StockQuantity = 130, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 46, Name = "Newborn Gift Set", Description = "Includes bibs, socks, and soft mittens.", Price = 22.00m, StockQuantity = 43, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 47, Name = "Running Belt Pouch", Description = "Stores phone and keys during workouts.", Price = 19.00m, StockQuantity = 77, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 48, Name = "Granola Snack Pack", Description = "Healthy and crunchy mix for on-the-go munching.", Price = 4.99m, StockQuantity = 200, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 49, Name = "Tire Pressure Gauge", Description = "Easy-to-read gauge for car safety.", Price = 12.99m, StockQuantity = 85, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 50, Name = "Pet Food Bowl Set", Description = "Non-slip and easy to clean.", Price = 16.99m, StockQuantity = 65, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 51, Name = "Classic Pearl Earrings", Description = "Timeless elegance for formal occasions.", Price = 39.50m, StockQuantity = 45, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 52, Name = "Gaming Keyboard with Backlight", Description = "Responsive keys and customizable lighting.", Price = 44.25m, StockQuantity = 52, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 53, Name = "Bluetooth Smart Plug", Description = "Control devices remotely via app or voice assistant.", Price = 23.75m, StockQuantity = 68, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 54, Name = "Slim Fit Polo Shirt", Description = "Breathable cotton polo for casual outings.", Price = 27.99m, StockQuantity = 70, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 55, Name = "Electric Kettle", Description = "Boils water quickly and shuts off automatically.", Price = 29.50m, StockQuantity = 55, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 56, Name = "Aloe Vera Face Mask", Description = "Soothing and hydrating facial treatment.", Price = 7.50m, StockQuantity = 120, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 57, Name = "Yoga Mat", Description = "Non-slip and cushioned for floor workouts.", Price = 24.00m, StockQuantity = 90, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 58, Name = "Organic Almonds", Description = "Raw and nutritious snack for healthy living.", Price = 11.99m, StockQuantity = 150, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 59, Name = "Car Phone Mount", Description = "Secure and adjustable phone holder for cars.", Price = 13.75m, StockQuantity = 85, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 60, Name = "Cat Scratching Post", Description = "Protects furniture while entertaining your cat.", Price = 33.40m, StockQuantity = 50, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 61, Name = "Silver Bracelet", Description = "Minimalist accessory with a timeless appeal.", Price = 59.99m, StockQuantity = 40, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 62, Name = "VR Gaming Headset", Description = "Immersive virtual reality experience for gamers.", Price = 199.99m, StockQuantity = 15, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 63, Name = "Wireless Charging Pad", Description = "Fast-charging pad compatible with most smartphones.", Price = 18.95m, StockQuantity = 73, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 64, Name = "Men's Running Shorts", Description = "Lightweight and moisture-wicking for workouts.", Price = 22.50m, StockQuantity = 65, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 65, Name = "Ceramic Coffee Mug Set", Description = "Set of 4 stylish mugs for your morning brew.", Price = 17.00m, StockQuantity = 92, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 66, Name = "Vitamin C Serum", Description = "Brightens skin and improves texture.", Price = 21.99m, StockQuantity = 105, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 67, Name = "Electric Toothbrush", Description = "Deep cleaning and long battery life.", Price = 49.00m, StockQuantity = 40, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 68, Name = "Daily Planner Notebook", Description = "Organize your day with to-do lists and schedules.", Price = 12.99m, StockQuantity = 110, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 69, Name = "Baby Bath Essentials Set", Description = "Gentle care kit for your baby’s bath time.", Price = 25.50m, StockQuantity = 60, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 70, Name = "Adjustable Dumbbells", Description = "Space-saving weights with adjustable settings.", Price = 129.99m, StockQuantity = 20, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 71, Name = "Whole Grain Pasta", Description = "Delicious and fiber-rich alternative to white pasta.", Price = 3.25m, StockQuantity = 130, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 72, Name = "Windshield Wiper Blades", Description = "Streak-free visibility in all weather.", Price = 15.00m, StockQuantity = 80, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 73, Name = "Pet Grooming Brush", Description = "Reduces shedding and keeps coat shiny.", Price = 9.99m, StockQuantity = 98, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 74, Name = "Women's Stud Earrings", Description = "Elegant studs for everyday wear.", Price = 28.50m, StockQuantity = 55, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 75, Name = "Console Gaming Controller", Description = "Ergonomic and responsive buttons.", Price = 49.95m, StockQuantity = 38, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 76, Name = "Smart Doorbell Camera", Description = "See and speak to visitors from your phone.", Price = 89.00m, StockQuantity = 27, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 77, Name = "Winter Beanie Hat", Description = "Warm and stylish for cold days.", Price = 14.99m, StockQuantity = 66, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 78, Name = "Silicone Baking Mat Set", Description = "Non-stick mats perfect for healthy baking.", Price = 19.50m, StockQuantity = 74, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 79, Name = "Charcoal Face Wash", Description = "Deep cleans pores and controls oil.", Price = 9.75m, StockQuantity = 120, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 80, Name = "Digital Blood Pressure Monitor", Description = "Easy-to-use monitor with accurate readings.", Price = 45.99m, StockQuantity = 30, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 81, Name = "Leather Journal", Description = "Classic journal for writing, sketching, or note-taking.", Price = 17.25m, StockQuantity = 95, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 82, Name = "Baby Feeding Bottle Set", Description = "BPA-free bottles for safe feeding.", Price = 28.99m, StockQuantity = 60, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 83, Name = "Resistance Bands Set", Description = "5 levels for stretching, strength, or rehab.", Price = 21.50m, StockQuantity = 85, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 84, Name = "Organic Honey Jar", Description = "100% raw and unfiltered natural honey.", Price = 13.99m, StockQuantity = 105, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 85, Name = "Car Vacuum Cleaner", Description = "Compact and powerful vacuum for vehicles.", Price = 39.00m, StockQuantity = 45, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 86, Name = "Dog Chew Toy Pack", Description = "Durable toys to keep dogs entertained and healthy.", Price = 18.00m, StockQuantity = 100, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 87, Name = "Rose Gold Necklace", Description = "Elegant and simple chain for special occasions.", Price = 69.50m, StockQuantity = 35, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 88, Name = "Gaming Mouse with RGB", Description = "High precision and customizable lighting.", Price = 32.75m, StockQuantity = 40, CategoryId = 13, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 89, Name = "Bluetooth Earbuds", Description = "Wireless earbuds with noise isolation and mic.", Price = 44.99m, StockQuantity = 60, CategoryId = 1, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 90, Name = "Denim Jacket", Description = "Classic blue denim with rugged stitching.", Price = 49.00m, StockQuantity = 55, CategoryId = 2, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 91, Name = "Non-stick Frying Pan", Description = "Easy to clean and perfect for daily cooking.", Price = 25.50m, StockQuantity = 65, CategoryId = 3, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 92, Name = "Facial Cleansing Brush", Description = "Gently exfoliates and removes makeup.", Price = 14.99m, StockQuantity = 95, CategoryId = 4, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 93, Name = "Multivitamin Capsules", Description = "Boosts immunity and daily nutrition.", Price = 19.95m, StockQuantity = 140, CategoryId = 5, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 94, Name = "Planner Pad with Sticky Notes", Description = "Perfect for desk organization.", Price = 9.50m, StockQuantity = 85, CategoryId = 6, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 95, Name = "Baby Safety Locks", Description = "Protects toddlers from dangerous drawers and cabinets.", Price = 12.99m, StockQuantity = 77, CategoryId = 7, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 96, Name = "Jump Rope", Description = "Ideal for cardio and agility training.", Price = 8.25m, StockQuantity = 120, CategoryId = 8, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 97, Name = "Quinoa Grain Pack", Description = "Nutritious and versatile superfood.", Price = 6.75m, StockQuantity = 90, CategoryId = 9, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 98, Name = "Car Organizer", Description = "Keeps car interior clean and items accessible.", Price = 22.00m, StockQuantity = 68, CategoryId = 10, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 99, Name = "Pet Water Fountain", Description = "Encourages pets to drink more water.", Price = 35.00m, StockQuantity = 50, CategoryId = 11, CreatedAt = fixedCreatedAt, IsDeleted = false },
                new Product { Id = 100, Name = "Luxury Watch", Description = "Timeless design with water resistance.", Price = 199.00m, StockQuantity = 25, CategoryId = 12, CreatedAt = fixedCreatedAt, IsDeleted = false }
            );
        }
    }
}
