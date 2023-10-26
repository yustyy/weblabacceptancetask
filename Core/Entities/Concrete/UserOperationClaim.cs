using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim: IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("operation_claim_id")]
        public int OperetaionClaimId { get; set; }

    }
}

