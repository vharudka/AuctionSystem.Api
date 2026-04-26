using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "John", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Doe", "jdoe" },
                    { 2, "Alice", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Smith", "asmith" },
                    { 3, "Brian", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Jackson", "bjackson" },
                    { 4, "Chloe", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Wilson", "cwilson" },
                    { 5, "David", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Thomas", "dthomas" },
                    { 6, "Emma", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Clark", "eclark" },
                    { 7, "Frank", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Martin", "fmartin" },
                    { 8, "Grace", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "White", "gwhite" },
                    { 9, "Henry", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Walker", "hwalker" },
                    { 10, "Isabella", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Johnson", "ijohnson" },
                    { 11, "James", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Lewis", "jlewis" },
                    { 12, "Karen", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Roberts", "kroberts" },
                    { 13, "Liam", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "King", "lking" },
                    { 14, "Mia", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Green", "mgreen" },
                    { 15, "Noah", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Wright", "nwright" },
                    { 16, "Olivia", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Allen", "oallen" },
                    { 17, "Paul", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Phillips", "pphillips" },
                    { 18, "Quinn", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Campbell", "qcampbell" },
                    { 19, "Ryan", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Turner", "rturner" },
                    { 20, "Sophia", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Moore", "smoore" },
                    { 21, "Thomas", "$2a$11$1oqokiyY1uOg3IY.YYD6Yu6v65h.MwNfAr4jRhGvfUpxuB9HaPROO", "Ward", "tward" }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "Category", "CurrentPrice", "Description", "EndDate", "OwnerId", "StartDate", "StartingPrice", "Title" },
                values: new object[,]
                {
                    { 1, "Electronics", 82m, "Classic 35mm film camera in good condition.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, "Vintage Camera" },
                    { 2, "Sports", 120m, "Used mountain bike, aluminum frame.", new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, "Mountain Bike" },
                    { 3, "Computers", 800m, "High‑performance laptop with RTX GPU.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, "Gaming Laptop" },
                    { 4, "Electronics", 90m, "Waterproof smartwatch with GPS.", new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, "Smartwatch" },
                    { 5, "Music", 60m, "Beginner‑friendly acoustic guitar.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, "Acoustic Guitar" },
                    { 6, "Furniture", 40m, "Ergonomic chair with lumbar support.", new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, "Office Chair" },
                    { 7, "Electronics", 30m, "Portable speaker with deep bass.", new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, "Bluetooth Speaker" },
                    { 8, "Home", 70m, "10‑piece stainless steel cookware.", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, "Cookware Set" },
                    { 9, "Electronics", 150m, "Quadcopter with HD camera.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, "Drone" },
                    { 10, "Fashion", 25m, "Handmade genuine leather wallet.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, "Leather Wallet" },
                    { 11, "Home", 20m, "LED lamp with adjustable brightness.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, "Desk Lamp" },
                    { 12, "Music", 210m, "Great for rock and blues.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, "Electric Guitar" },
                    { 13, "Home", 200m, "Automatic espresso machine.", new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, "Coffee Machine" },
                    { 14, "Electronics", 180m, "10‑inch tablet for work and play.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m, "Tablet" },
                    { 15, "Sports", 50m, "Lightweight running shoes.", new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, "Running Shoes" },
                    { 16, "Computers", 220m, "144Hz gaming monitor.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 220m, "Monitor 27\"" },
                    { 17, "Computers", 70m, "Mechanical keyboard with RGB.", new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, "Keyboard" },
                    { 18, "Electronics", 300m, "Unlocked Android phone.", new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m, "Smartphone" },
                    { 19, "Outdoors", 90m, "4‑person waterproof tent.", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, "Camping Tent" },
                    { 20, "Fashion", 35m, "Polarized UV protection.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, "Sunglasses" },
                    { 21, "Travel", 45m, "Durable travel backpack.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "Backpack" },
                    { 22, "Home", 25m, "Fast‑boil stainless steel kettle.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, "Electric Kettle" },
                    { 23, "Sports", 600m, "Lightweight carbon frame.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "Road Bike" },
                    { 24, "Electronics", 400m, "55‑inch UHD Smart TV.", new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 400m, "4K TV" },
                    { 25, "Transport", 350m, "Foldable scooter with long battery life.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 350m, "Electric Scooter" },
                    { 26, "Home", 80m, "HEPA filter air purifier.", new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, "Air Purifier" },
                    { 27, "Tools", 60m, "Cordless drill with accessories.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, "Electric Drill" },
                    { 28, "Fashion", 90m, "Insulated waterproof jacket.", new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, "Winter Jacket" },
                    { 29, "Electronics", 120m, "Noise‑cancelling over‑ear headphones.", new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, "Wireless Headphones" },
                    { 30, "Furniture", 150m, "Ergonomic gaming chair.", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 150m, "Gaming Chair" },
                    { 31, "Books", 35m, "Set of 5 bestselling cookbooks.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, "Cookbook Collection" },
                    { 32, "Electronics", 45m, "Tracks steps, sleep, and heart rate.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "Fitness Tracker" },
                    { 33, "Home", 20m, "Wooden organizer for office supplies.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, "Desk Organizer" },
                    { 34, "Music", 155m, "Retro turntable with speakers.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, "Vinyl Record Player" },
                    { 35, "Furniture", 250m, "Comfortable 3‑seat sofa.", new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 250m, "Sofa" },
                    { 36, "Electronics", 180m, "1080p home cinema projector.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 180m, "Projector" },
                    { 37, "Sports", 300m, "Skis, poles, and boots.", new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m, "Ski Set" },
                    { 38, "Home", 70m, "Indoor smokeless grill.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, "Electric Grill" },
                    { 39, "Travel", 120m, "3‑piece travel luggage.", new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, "Luggage Set" },
                    { 40, "Health", 40m, "Rechargeable toothbrush with timer.", new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, "Electric Toothbrush" },
                    { 41, "Games", 30m, "Collection of 10 classic board games.", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, "Board Game Set" },
                    { 42, "Home", 35m, "Portable ceramic heater.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, "Electric Heater" },
                    { 43, "Automotive", 25m, "Compact vacuum for car interiors.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, "Car Vacuum" },
                    { 44, "Sports", 20m, "Non‑slip yoga mat.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, "Yoga Mat" },
                    { 45, "Computers", 55m, "Adjustable aluminum stand.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, "Laptop Stand" },
                    { 46, "Home", 60m, "700W compact microwave.", new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, "Microwave Oven" },
                    { 47, "Music", 80m, "20W practice amplifier.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, "Electric Guitar Amp" },
                    { 48, "Electronics", 55m, "Controls smart devices.", new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, "Smart Home Hub" },
                    { 49, "Home", 65m, "Oil‑less cooking appliance.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 65m, "Air Fryer" },
                    { 50, "Photography", 85m, "Softbox lighting set for studio work.", new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, "Photography Lighting Kit" },
                    { 51, "Health", 40m, "Rechargeable shaver with precision blades.", new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, "Electric Shaver" },
                    { 52, "Computers", 55m, "1TB USB 3.0 external drive.", new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, "Portable Hard Drive" },
                    { 53, "Automotive", 15m, "Dashboard mount for smartphones.", new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, "Car Phone Holder" },
                    { 54, "Home", 45m, "Heated blanket with adjustable settings.", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "Electric Blanket" },
                    { 55, "Computers", 25m, "Ergonomic mouse with long battery life.", new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, "Wireless Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "AuctionId", "PlacedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 55m, 1, new DateTime(2026, 5, 8, 22, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 2, 60m, 1, new DateTime(2026, 5, 8, 22, 30, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 3, 68m, 1, new DateTime(2026, 5, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 4, 75m, 1, new DateTime(2026, 5, 8, 23, 30, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 5, 82m, 1, new DateTime(2026, 5, 8, 23, 50, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 6, 160m, 12, new DateTime(2026, 5, 8, 21, 40, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 170m, 12, new DateTime(2026, 5, 8, 22, 20, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 185m, 12, new DateTime(2026, 5, 8, 22, 50, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, 195m, 12, new DateTime(2026, 5, 8, 23, 20, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, 210m, 12, new DateTime(2026, 5, 8, 23, 45, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, 520m, 23, new DateTime(2026, 5, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 12, 540m, 23, new DateTime(2026, 5, 8, 22, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 13, 560m, 23, new DateTime(2026, 5, 8, 22, 30, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 14, 580m, 23, new DateTime(2026, 5, 8, 23, 15, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 15, 600m, 23, new DateTime(2026, 5, 8, 23, 40, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 16, 110m, 34, new DateTime(2026, 5, 8, 21, 20, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 17, 120m, 34, new DateTime(2026, 5, 8, 22, 10, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 18, 135m, 34, new DateTime(2026, 5, 8, 22, 40, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 19, 145m, 34, new DateTime(2026, 5, 8, 23, 10, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 20, 155m, 34, new DateTime(2026, 5, 8, 23, 35, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 21, 35m, 45, new DateTime(2026, 5, 8, 21, 50, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 22, 40m, 45, new DateTime(2026, 5, 8, 22, 25, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 23, 45m, 45, new DateTime(2026, 5, 8, 22, 50, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 24, 50m, 45, new DateTime(2026, 5, 8, 23, 25, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 25, 55m, 45, new DateTime(2026, 5, 8, 23, 50, 0, 0, DateTimeKind.Unspecified), 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
