using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JwtAuthentication.Data;

namespace JwtAuthentication.Areas.Identity.Data
{
    public class RefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Token { get; set; }
        public string JwtId { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationContext User { get; set; }
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null;
    }
}
