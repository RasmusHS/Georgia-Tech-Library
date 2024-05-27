namespace GTL.Application.Commands.Author
{
    public class UpdateAuthorCommand : ICommand
    {
        public UpdateAuthorCommand(Guid? itemCatalogId, string currentName, string updatedName, byte[] rowVersion)
        {
            ItemCatalogId = itemCatalogId;
            CurrentName = currentName;
            UpdatedName = updatedName;
            RowVersion = rowVersion;
        }

        public UpdateAuthorCommand() { }

        public Guid? ItemCatalogId { get; set; }
        public string CurrentName { get; set; }
        public string UpdatedName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
