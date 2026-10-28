 using System.ComponentModel.DataAnnotations;
 public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Recipient { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;
    }