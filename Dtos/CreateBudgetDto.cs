using System.ComponentModel.DataAnnotations;

public class CreateBudgetDto
{

    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public int UserId {get;set;}
    public DateTime Month {get;set;}

    [Range(1, int.MaxValue, ErrorMessage = "Value must be positive")]
    public decimal Limit {get;set;}

}