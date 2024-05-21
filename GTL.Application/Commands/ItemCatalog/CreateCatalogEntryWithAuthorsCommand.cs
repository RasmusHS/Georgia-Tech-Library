using GTL.Application.Commands.Author;

namespace GTL.Application.Commands.ItemCatalog
{
    public class CreateCatalogEntryWithAuthorsCommand : ICommand
    {
        public CreateCatalogEntryWithAuthorsCommand(string? isbn, string title, string description, string subjectArea, string type, string? edition, List<CreateAuthorCommand>? authors)
        {
            ISBN = isbn;
            Title = title;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            Authors = authors;
        }

        public string? ISBN { get; }
        public string Title { get; }
        public string Description { get; }
        public string SubjectArea { get; }
        public string Type { get; }
        public string? Edition { get; }
        public List<CreateAuthorCommand>? Authors { get; }
    }
}
