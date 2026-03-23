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
                    Name = "Centrum Women -Multivitamin Tablet",
                    Price = 1499.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Centrum Women -Multivitamin Tablet for Women|With 23 Vital Nutrients including Zinc,Magnesium,Vitamin B,C,D, Calcium for Energy, Immunity,Radiance,Strong Bones and Overall Health|Veg - 50 tablets",
                    ImageName = "Image1.png"
                },
                new Product
                {
                    Id = new Guid("D886CDF6-DE8A-402A-AD03-13A861D1F13B"),
                    Name = "Tata 1mg Salmon Omega 3",
                    Price = 949.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Tata 1mg Salmon Omega 3 Fish Oil Supplements 1000mg - 90 Capsules | Triglyceride form | 180mg EPA & 120mg DHA | High Absorption for Heart,Brain & Joints | Helps Manage Cholesterol\r\n",
                    ImageName = "Image2.png"
                },
                new Product
                {
                    Id = new Guid("DA01AE07-A0E0-4DEF-8EEA-FCB25CC10A1D"),
                    Name = "Wellbeing Nutrition Slow Multivitamin",
                    Price = 1189.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Wellbeing Nutrition Slow Multivitamin + Omega 3 for Men with Probiotics, B-Complex, Ginseng, 23 Vitamins & Minerals, 15 Antioxidants | Stamina, Metabolism, Bones, Immunity, Digestion, 60 Veg Capsules",
                    ImageName = "Image3.png"
                },
                new Product
                {
                    Id = new Guid("80277464-BCBC-4E65-83F8-C37A88ECC0B8"),
                    Name = "Carbamide Forte Multivitamin Tablets for Women",
                    Price = 599.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Carbamide Forte Multivitamin Tablets for Women | Multi Vitamin Supplement for Women With Probiotics | Multivitamin Tablet for Women With 43 Ingredients To Support Energy & Health - 100 Tablets",
                    ImageName = "Image4.png"
                },
                new Product
                {
                    Id = new Guid("D52EE955-6EA8-4FA5-821E-E8CCD45FE57A"),
                    Name = "Wellman 50+ Multivitamin Tablet",
                    Price = 319.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Wellman 50+ Multivitamin Tablets for Men Aged 50+ | Ginseng, Citrus & Amino Acids | Support Health & Vitality | Boost Cognitive & Immune Function | Reduce Tiredness & Fatigue | 30 Veg Tablets\r\n",
                    ImageName = "Image5.png"
                },
                new Product
                {
                    Id = new Guid("18E84C5E-B905-48C5-965B-E35FFA2AB86D"),
                    Name = "Rasayanam Multivitamin for Men",
                    Price = 681.00M,
                    Category = new List<string> { "Electronics", "Computer" },
                    Description = "Rasayanam Multivitamin for Men | 52 Ingredients with 100% RDA of Vitamins & Minerals | Energy, Immunity, Performance, Bone, Joint & Heart Health | Daily Multivitamin Tablet for Men - 60 Tablets\r\n",
                    ImageName = "Image6.png"
                }
            };
    }
}
