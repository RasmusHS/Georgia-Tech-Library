using GTL.Application.Commands.Author;
using GTL.Application.Commands.Item;

namespace GTL.Application.Commands.ItemCatalog.WithItems
{
    public class CreateCatalogEntryWithItemsCommand : ICommand
    {
        public CreateCatalogEntryWithItemsCommand(string? isbn, string title, string description, string subjectArea, string type, string? edition, List<CreateAuthorCommand>? authors, List<CreateItemCommand>? items)
        {
            ISBN = isbn;
            Title = title;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            Authors = authors;
            Items = items;
        }

        public string? ISBN { get; }
        public string Title { get; }
        public string Description { get; }
        public string SubjectArea { get; }
        public string Type { get; }
        public string? Edition { get; }
        public List<CreateAuthorCommand>? Authors { get; }
        public List<CreateItemCommand>? Items { get; }
    }
}
