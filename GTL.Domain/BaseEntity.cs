using System.ComponentModel.DataAnnotations;

namespace GTL.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
