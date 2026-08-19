using System.ComponentModel.DataAnnotations;

public class CreateTransactionDto
{

    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public decimal Value {get;set;}
    public string TransactionType {get;set;} = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public int CategoryId {get;set;}

}