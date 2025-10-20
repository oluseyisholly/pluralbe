using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecommerceWepApi.Migrations
{
    /// <inheritdoc />
    public partial class seedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Name", "Price", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Hydrates and soothes dry skin with natural ingredients.", false, "Aloe Vera Moisturizer", 42.99m, 54, null },
                    { 5, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Accurate temperature readings in seconds.", false, "Digital Thermometer", 18.75m, 150, null },
                    { 6, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Durable notebook for daily writing and notes.", false, "Hardcover Journal", 12.50m, 73, null },
                    { 7, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Colorful blocks to teach kids letters and spelling.", false, "Educational Alphabet Blocks", 22.99m, 60, null },
                    { 8, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Non-slip surface ideal for workouts and yoga sessions.", false, "Yoga Mat with Strap", 29.99m, 95, null },
                    { 9, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Smooth spread made from roasted organic almonds.", false, "Organic Almond Butter", 8.99m, 120, null },
                    { 10, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Hands-free phone use while driving.", false, "Car Phone Mount", 15.00m, 200, null },
                    { 11, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Removes loose fur and detangles easily.", false, "Pet Grooming Brush", 10.99m, 88, null },
                    { 12, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant design suitable for daily wear or gifts.", false, "Silver Charm Bracelet", 35.00m, 33, null },
                    { 13, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Compatible with major gaming consoles and PCs.", false, "Wireless Game Controller", 49.99m, 65, null },
                    { 14, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Color-changing bulb controlled by app or voice.", false, "Smart LED Bulb", 17.95m, 110, null },
                    { 15, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Stylish and stretchy denim for all-day comfort.", false, "Women's High-Waist Jeans", 44.50m, 75, null },
                    { 16, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Complete set with ladle, spatula, and whisk.", false, "Stainless Steel Cooking Utensils", 26.30m, 40, null },
                    { 17, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Removes impurities and refreshes skin.", false, "Charcoal Face Wash", 14.20m, 100, null },
                    { 18, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Boosts immune system and skin health.", false, "Vitamin C Tablets", 9.50m, 130, null },
                    { 19, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Organize your week with tear-off sheets.", false, "Planner & To-Do List Pad", 11.75m, 55, null },
                    { 20, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Soft cotton for a cozy, snug fit.", false, "Baby Swaddle Blanket", 19.80m, 78, null },
                    { 21, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Full-body workout bands with varying resistance.", false, "Resistance Bands Set", 23.99m, 49, null },
                    { 22, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Freshly sealed for quality and aroma.", false, "Organic Green Tea Bags", 6.99m, 160, null },
                    { 23, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Portable and powerful suction for quick cleanups.", false, "Car Vacuum Cleaner", 32.90m, 39, null },
                    { 24, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Traps litter and keeps floors clean.", false, "Cat Litter Mat", 13.25m, 51, null },
                    { 25, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Classic analog watch with genuine leather band.", false, "Men’s Leather Wristwatch", 59.00m, 29, null },
                    { 26, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Customizable DPI and color profiles.", false, "Gaming Mouse with RGB Lighting", 27.49m, 90, null },
                    { 27, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Slim design fits under TV with immersive sound.", false, "Bluetooth Soundbar", 89.99m, 20, null },
                    { 28, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Casual wear with a smart collar and short sleeves.", false, "Men’s Polo Shirt", 34.75m, 66, null },
                    { 29, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Durable pan perfect for everyday cooking needs.", false, "Non-Stick Frying Pan", 21.50m, 75, null },
                    { 30, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Keeps lips soft and moisturized all day.", false, "Hydrating Lip Balm", 5.99m, 110, null },
                    { 31, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Accurate home monitoring for your health.", false, "Digital Blood Pressure Monitor", 38.20m, 50, null },
                    { 32, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Perfect for notes, journaling, or sketches.", false, "A5 Leather Notebook", 14.00m, 95, null },
                    { 33, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Safe, colorful, and fun for your little one.", false, "Infant Rattle Toy Set", 18.45m, 62, null },
                    { 34, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Great for muscle recovery and massage therapy.", false, "Foam Roller", 25.00m, 88, null },
                    { 35, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-protein whole grain, perfect for salads.", false, "Organic Quinoa", 9.99m, 145, null },
                    { 36, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Keeps your car cool and protects the interior.", false, "Windshield Sun Shade", 17.00m, 80, null },
                    { 37, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Tough and fun toy for chewing and playing.", false, "Dog Chew Toy", 11.75m, 120, null },
                    { 38, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "A delicate piece for elegant outfits.", false, "Elegant Gold Necklace", 72.99m, 24, null },
                    { 39, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Noise-canceling headset for immersive gameplay.", false, "Gaming Headset with Mic", 54.99m, 35, null },
                    { 40, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Stabilizer for smooth mobile video recording.", false, "Smartphone Gimbal", 99.00m, 15, null },
                    { 41, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight and stylish for warm weather.", false, "Summer Maxi Dress", 45.50m, 60, null },
                    { 42, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Stackable bowls with beautiful patterns.", false, "Ceramic Mixing Bowls Set", 34.99m, 70, null },
                    { 43, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Gently exfoliates and removes impurities.", false, "Facial Cleansing Brush", 29.90m, 90, null },
                    { 44, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Monitors steps, heart rate, and sleep patterns.", false, "Fitness Tracker Watch", 59.00m, 100, null },
                    { 45, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Assorted sizes and colors for quick reminders.", false, "Sticky Notes Combo Pack", 6.99m, 130, null },
                    { 46, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Includes bibs, socks, and soft mittens.", false, "Newborn Gift Set", 22.00m, 43, null },
                    { 47, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Stores phone and keys during workouts.", false, "Running Belt Pouch", 19.00m, 77, null },
                    { 48, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Healthy and crunchy mix for on-the-go munching.", false, "Granola Snack Pack", 4.99m, 200, null },
                    { 49, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Easy-to-read gauge for car safety.", false, "Tire Pressure Gauge", 12.99m, 85, null },
                    { 50, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Non-slip and easy to clean.", false, "Pet Food Bowl Set", 16.99m, 65, null },
                    { 51, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Timeless elegance for formal occasions.", false, "Classic Pearl Earrings", 39.50m, 45, null },
                    { 52, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Responsive keys and customizable lighting.", false, "Gaming Keyboard with Backlight", 44.25m, 52, null },
                    { 53, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Control devices remotely via app or voice assistant.", false, "Bluetooth Smart Plug", 23.75m, 68, null },
                    { 54, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Breathable cotton polo for casual outings.", false, "Slim Fit Polo Shirt", 27.99m, 70, null },
                    { 55, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Boils water quickly and shuts off automatically.", false, "Electric Kettle", 29.50m, 55, null },
                    { 56, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Soothing and hydrating facial treatment.", false, "Aloe Vera Face Mask", 7.50m, 120, null },
                    { 57, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Non-slip and cushioned for floor workouts.", false, "Yoga Mat", 24.00m, 90, null },
                    { 58, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Raw and nutritious snack for healthy living.", false, "Organic Almonds", 11.99m, 150, null },
                    { 59, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Secure and adjustable phone holder for cars.", false, "Car Phone Mount", 13.75m, 85, null },
                    { 60, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Protects furniture while entertaining your cat.", false, "Cat Scratching Post", 33.40m, 50, null },
                    { 61, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Minimalist accessory with a timeless appeal.", false, "Silver Bracelet", 59.99m, 40, null },
                    { 62, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Immersive virtual reality experience for gamers.", false, "VR Gaming Headset", 199.99m, 15, null },
                    { 63, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Fast-charging pad compatible with most smartphones.", false, "Wireless Charging Pad", 18.95m, 73, null },
                    { 64, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight and moisture-wicking for workouts.", false, "Men's Running Shorts", 22.50m, 65, null },
                    { 65, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Set of 4 stylish mugs for your morning brew.", false, "Ceramic Coffee Mug Set", 17.00m, 92, null },
                    { 66, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Brightens skin and improves texture.", false, "Vitamin C Serum", 21.99m, 105, null },
                    { 67, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Deep cleaning and long battery life.", false, "Electric Toothbrush", 49.00m, 40, null },
                    { 68, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Organize your day with to-do lists and schedules.", false, "Daily Planner Notebook", 12.99m, 110, null },
                    { 69, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Gentle care kit for your baby’s bath time.", false, "Baby Bath Essentials Set", 25.50m, 60, null },
                    { 70, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Space-saving weights with adjustable settings.", false, "Adjustable Dumbbells", 129.99m, 20, null },
                    { 71, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Delicious and fiber-rich alternative to white pasta.", false, "Whole Grain Pasta", 3.25m, 130, null },
                    { 72, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Streak-free visibility in all weather.", false, "Windshield Wiper Blades", 15.00m, 80, null },
                    { 73, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Reduces shedding and keeps coat shiny.", false, "Pet Grooming Brush", 9.99m, 98, null },
                    { 74, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant studs for everyday wear.", false, "Women's Stud Earrings", 28.50m, 55, null },
                    { 75, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Ergonomic and responsive buttons.", false, "Console Gaming Controller", 49.95m, 38, null },
                    { 76, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "See and speak to visitors from your phone.", false, "Smart Doorbell Camera", 89.00m, 27, null },
                    { 77, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Warm and stylish for cold days.", false, "Winter Beanie Hat", 14.99m, 66, null },
                    { 78, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Non-stick mats perfect for healthy baking.", false, "Silicone Baking Mat Set", 19.50m, 74, null },
                    { 79, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Deep cleans pores and controls oil.", false, "Charcoal Face Wash", 9.75m, 120, null },
                    { 80, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Easy-to-use monitor with accurate readings.", false, "Digital Blood Pressure Monitor", 45.99m, 30, null },
                    { 81, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Classic journal for writing, sketching, or note-taking.", false, "Leather Journal", 17.25m, 95, null },
                    { 82, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "BPA-free bottles for safe feeding.", false, "Baby Feeding Bottle Set", 28.99m, 60, null },
                    { 83, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "5 levels for stretching, strength, or rehab.", false, "Resistance Bands Set", 21.50m, 85, null },
                    { 84, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "100% raw and unfiltered natural honey.", false, "Organic Honey Jar", 13.99m, 105, null },
                    { 85, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Compact and powerful vacuum for vehicles.", false, "Car Vacuum Cleaner", 39.00m, 45, null },
                    { 86, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Durable toys to keep dogs entertained and healthy.", false, "Dog Chew Toy Pack", 18.00m, 100, null },
                    { 87, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant and simple chain for special occasions.", false, "Rose Gold Necklace", 69.50m, 35, null },
                    { 88, 13, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High precision and customizable lighting.", false, "Gaming Mouse with RGB", 32.75m, 40, null },
                    { 89, 1, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Wireless earbuds with noise isolation and mic.", false, "Bluetooth Earbuds", 44.99m, 60, null },
                    { 90, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Classic blue denim with rugged stitching.", false, "Denim Jacket", 49.00m, 55, null },
                    { 91, 3, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Easy to clean and perfect for daily cooking.", false, "Non-stick Frying Pan", 25.50m, 65, null },
                    { 92, 4, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Gently exfoliates and removes makeup.", false, "Facial Cleansing Brush", 14.99m, 95, null },
                    { 93, 5, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Boosts immunity and daily nutrition.", false, "Multivitamin Capsules", 19.95m, 140, null },
                    { 94, 6, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Perfect for desk organization.", false, "Planner Pad with Sticky Notes", 9.50m, 85, null },
                    { 95, 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Protects toddlers from dangerous drawers and cabinets.", false, "Baby Safety Locks", 12.99m, 77, null },
                    { 96, 8, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Ideal for cardio and agility training.", false, "Jump Rope", 8.25m, 120, null },
                    { 97, 9, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Nutritious and versatile superfood.", false, "Quinoa Grain Pack", 6.75m, 90, null },
                    { 98, 10, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Keeps car interior clean and items accessible.", false, "Car Organizer", 22.00m, 68, null },
                    { 99, 11, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Encourages pets to drink more water.", false, "Pet Water Fountain", 35.00m, 50, null },
                    { 100, 12, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Timeless design with water resistance.", false, "Luxury Watch", 199.00m, 25, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
