namespace CleanArchitecture.Domain.Entities;
public class ShoppingSession : BaseAuditableEntity
{
    public int? UserId { get; set; }
    public decimal Amount { get; set; }
}
