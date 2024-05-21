using GTL.Application.Commands.Author;

namespace GTL.Application.Commands.ItemCatalog
{
    public class UpdateCatalogEntryCommand : ICommand
    {
        public UpdateCatalogEntryCommand(Guid itemCatalogId, string? isbn, string title, string description, string subjectArea, string type, string? edition, List<UpdateAuthorCommand> authors, byte[] rowVersion)
        {
            ItemCatalogId = itemCatalogId;
            ISBN = isbn;
            Title = title;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            Authors = authors;
            RowVersion = rowVersion;
        }

        public Guid ItemCatalogId { get; set; }
        public string? ISBN { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string SubjectArea { get; private set; }
        public string Type { get; private set; }
        public string? Edition { get; private set; }
        public List<UpdateAuthorCommand> Authors { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
