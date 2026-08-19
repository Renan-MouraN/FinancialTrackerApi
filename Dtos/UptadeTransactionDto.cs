using System.ComponentModel.DataAnnotations;

public class UpdateTransactionDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public decimal Value {get;set;}

    [Required(ErrorMessage = "Transaction is required")]
    public string TransactionType {get;set;} = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public int CategoryId {get;set;}

}