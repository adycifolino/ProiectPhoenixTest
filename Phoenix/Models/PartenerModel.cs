namespace Phoenix.Models
{
    using System.ComponentModel.DataAnnotations;
    public class PartenerModel
    {
        [Required(ErrorMessage = "Denumirea este obligatorie")]
        [StringLength(100, ErrorMessage = "Maxim 100 caractere")]
        public string Denumire { get; set; } = string.Empty;
    }
}
