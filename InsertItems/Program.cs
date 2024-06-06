using Microsoft.Data.SqlClient;

namespace ItemGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost,1433;Database=GTLDB;Application Name=GTL;Integrated Security=false;User ID=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;";
            int itemCount = 250000;

            // Fetch item_catalog_ids from the item_catalog_entities table
            List<Guid> catalogIds = GetCatalogIds(connectionString);

            // Generate items
            List<Item> items = GenerateItems(itemCount, catalogIds);

            // Insert items into the item_entities table
            InsertItems(connectionString, items);

            Console.WriteLine($"{itemCount} items have been generated and inserted into the item_entities table.");
        }

        static List<Guid> GetCatalogIds(string connectionString)
        {
            List<Guid> catalogIds = new List<Guid>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT item_catalog_id FROM item_catalog_entities";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            catalogIds.Add(reader.GetGuid(0));
                        }
                    }
                }
            }

            return catalogIds;
        }

        static List<Item> GenerateItems(int itemCount, List<Guid> catalogIds)
        {
            Random random = new Random();
            List<Item> items = new List<Item>();

            for (int i = 0; i < itemCount; i++)
            {
                Item item = new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemCatalogId = catalogIds[random.Next(catalogIds.Count)],
                    IsLendable = random.Next(2) == 0, // Randomly assign true or false
                    DateCreated = DateTime.UtcNow,
                    Condition = random.Next(2) == 0 ? "New" : "Used" // Randomly assign "New" or "Used"
                };
                items.Add(item);
            }

            return items;
        }

        static void InsertItems(string connectionString, List<Item> items)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var item in items)
                {
                    string query = "INSERT INTO item_entities (item_id, item_catalog_id, is_lendable, date_created, condition) " +
                                   "VALUES (@ItemId, @ItemCatalogId, @IsLendable, @DateCreated, @Condition)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", item.ItemId);
                        command.Parameters.AddWithValue("@ItemCatalogId", item.ItemCatalogId);
                        command.Parameters.AddWithValue("@IsLendable", item.IsLendable);
                        command.Parameters.AddWithValue("@DateCreated", item.DateCreated);
                        command.Parameters.AddWithValue("@Condition", item.Condition);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    class Item
    {
        public Guid ItemId { get; set; }
        public Guid ItemCatalogId { get; set; }
        public bool IsLendable { get; set; }
        public DateTime DateCreated { get; set; }
        public string Condition { get; set; }
    }
}
