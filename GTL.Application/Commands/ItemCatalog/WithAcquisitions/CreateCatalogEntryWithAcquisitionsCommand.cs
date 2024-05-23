using GTL.Application.Commands.Acquisitions;
using GTL.Application.Commands.Author;

namespace GTL.Application.Commands.ItemCatalog.WithAcquisitions
{
    public class CreateCatalogEntryWithAcquisitionsCommand : ICommand
    {
        public CreateCatalogEntryWithAcquisitionsCommand(string? isbn, string title, string description, string subjectArea, string type, string? edition, List<CreateAuthorCommand>? authors, List<CreateAcquisitionCommand>? acquisitions)
        {
            ISBN = isbn;
            Title = title;
            Description = description;
            SubjectArea = subjectArea;
            Type = type;
            Edition = edition;
            Authors = authors;
            Acquisitions = acquisitions;
        }

        public string? ISBN { get; }
        public string Title { get; }
        public string Description { get; }
        public string SubjectArea { get; }
        public string Type { get; }
        public string? Edition { get; }
        public List<CreateAuthorCommand>? Authors { get; }
        public List<CreateAcquisitionCommand>? Acquisitions { get; }
    }
}
