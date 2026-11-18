using System.ComponentModel.DataAnnotations;

public class ChatRequestDto
{   
    [Required]
    [MaxLength(2000)]
    public string Prompt {get;set;} = string.Empty;
}