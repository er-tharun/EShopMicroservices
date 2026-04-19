using Marten.Schema;

namespace Catalog.API.Data
{
    public class InitialCatalogData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = await store.LightweightSerializableSessionAsync(cancellation);
            var existingData = session.Query<Product>();
            if (existingData.Any())
                return;

            session.Store(GetInitialCatalog());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetInitialCatalog() => new List<Product>
            {
                new Product
                {
                    Id = new Guid("ED52F02D-344F-4DE4-AC2F-E6E0CB073E5F"),
                    Name = "Samsung Galaxy S25 Ultra 5G AI Smartphone",
                    Price = 1499.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Samsung Galaxy S25 Ultra 5G AI Smartphone (Titanium Gray, 12GB RAM, 256GB Storage), 200MP Camera, S Pen Included, Long Battery Life",
                    ImageName = "product-1.png"
                },
                new Product
                {
                    Id = new Guid("D886CDF6-DE8A-402A-AD03-13A861D1F13B"),
                    Name = "Apple iPhone 17 Pro",
                    Price = 949.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Apple iPhone 17 Pro 256 GB: 15.93 cm (6.3″) Display with Promotion up to 120Hz, A19 Pro Chip, Breakthrough Battery Life, Pro Fusion Camera System with Center Stage Front Camera; Silver",
                    ImageName = "product-2.png"
                },
                new Product
                {
                    Id = new Guid("DA01AE07-A0E0-4DEF-8EEA-FCB25CC10A1D"),
                    Name = "acer ALG",
                    Price = 1189.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "acer ALG (2025) Intel Core i5 13th Gen 13420H - (16 GB/512 GB SSD/6 GB NVIDIA GeForce RTX 3050/Windows 11 Home) AL15G-53 Gaming Laptop/15.6\" FHD 144Hz/Steel Grey/1.9 Kg/MSO 2021/3 Years Warranty\r\n",
                    ImageName = "product-3.png"
                },
                new Product
                {
                    Id = new Guid("80277464-BCBC-4E65-83F8-C37A88ECC0B8"),
                    Name = "Lenovo Yoga",
                    Price = 599.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Lenovo Yoga Slim 7 Ultra 9 185H WUXGA OLED with 1Yr ADP Intel Core Ultra 9 185H - (32 GB/1 TB SSD/Windows 11 Home) Yoga Slim 7 14IMH9 Thin and Light Laptop (14 inch, Luna Grey, 1.39 Kg, With MS Office)",
                    ImageName = "product-4.png"
                },
                new Product
                {
                    Id = new Guid("D52EE955-6EA8-4FA5-821E-E8CCD45FE57A"),
                    Name = "Dell Inspiron",
                    Price = 319.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Dell Inspiron 7440 2in1 Laptop,14 inch Touch FHD+ 250nits(35.56cm)Display, Intel Core i5-1334U Windows 11 Home, 16 GB DDR5 RAM, 512 GB SSD, Active Pen, Intel Graphics, Ice Blue, Backlit KB+FPR, 1.71Kg",
                    ImageName = "product-5.png"
                },
                new Product
                {
                    Id = new Guid("18E84C5E-B905-48C5-965B-E35FFA2AB86D"),
                    Name = "HP OmniBook",
                    Price = 681.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "HP OmniBook 5 OLED (Previously Pavilion), Snapdragon X Processor (16GB LPDDR5x, 512GB SSD) 2K, 14''/35.6cm, Win11, M365 Basic(1yr)* Office24, Silver, 1.35kg, he0014QU, Light-Weight, Next-Gen AI Laptop",
                    ImageName = "product-6.png"
                }
            };
    }
}
