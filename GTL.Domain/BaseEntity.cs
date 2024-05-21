using System.ComponentModel.DataAnnotations;

namespace GTL.Domain
{
    public abstract class BaseEntity
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
