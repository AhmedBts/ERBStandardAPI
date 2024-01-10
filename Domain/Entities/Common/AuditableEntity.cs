using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Common
{
    public class AuditableEntity
    {
        public int? UserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateAndTime { get; set; } = DateTime.Now;
        public int? CreateUserId { get; set; }
       [ Column(TypeName= "datetime")]
        public DateTime? CreateDateAndTime { get; set; }= DateTime.Now;
    }
}
