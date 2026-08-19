using System.ComponentModel.DataAnnotations;

public class UpdateUserDto
{
    [Required(ErrorMessage = "FullName is required")]
    public string FullName {get;set;} = string.Empty; //A Combinação de [required] e string.Empty permite a correção do warning por null e a validação do preenchimento

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid format")]
    public string Email {get;set;} = string.Empty;

}