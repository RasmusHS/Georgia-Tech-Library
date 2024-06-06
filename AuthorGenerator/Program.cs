using Microsoft.Data.SqlClient;

namespace AuthorGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost,1433;Database=GTLDB;Application Name=GTL;Integrated Security=false;User ID=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;";
            int unknownAuthorPercentage = 1; // 1%

            // Fetch item_catalog_ids from the item_catalog_entities table
            List<Guid> catalogIds = GetCatalogIds(connectionString);

            // Generate authors for each catalog entry
            List<Author> authors = GenerateAuthors(catalogIds, unknownAuthorPercentage);

            // Insert authors into the author_entities table
            InsertAuthors(connectionString, authors);

            Console.WriteLine($"Authors have been generated and inserted into the author_entities table for {catalogIds.Count} catalog entries.");
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

        static List<Author> GenerateAuthors(List<Guid> catalogIds, int unknownAuthorPercentage)
        {
            Random random = new Random();
            List<Author> authors = new List<Author>();
            string[] firstNames = { "John", "Jane", "Alex", "Emily", "Chris" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones" };

            foreach (var catalogId in catalogIds)
            {
                if (random.Next(100) < unknownAuthorPercentage)
                {
                    authors.Add(new Author
                    {
                        ItemCatalogId = catalogId,
                        Name = "Unknown Author"
                    });
                }
                else
                {
                    int authorCount = random.Next(1, 6);
                    for (int i = 0; i < authorCount; i++)
                    {
                        string name;
                        do
                        {
                            name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}";
                        } while (authors.Any(a => a.ItemCatalogId == catalogId && a.Name == name));

                        authors.Add(new Author
                        {
                            ItemCatalogId = catalogId,
                            Name = name
                        });
                    }
                }
            }

            return authors;
        }

        static void InsertAuthors(string connectionString, List<Author> authors)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var author in authors)
                {
                    try
                    {
                        string query = "INSERT INTO author_entities (item_catalog_id, name) VALUES (@ItemCatalogId, @Name)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ItemCatalogId", author.ItemCatalogId);
                            command.Parameters.AddWithValue("@Name", author.Name);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Primary key violation
                        {
                            Console.WriteLine($"Primary key violation for item_catalog_id: {author.ItemCatalogId}, name: {author.Name}. Skipping this author.");
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
        }
    }

    class Author
    {
        public Guid ItemCatalogId { get; set; }
        public string Name { get; set; }
    }
}
