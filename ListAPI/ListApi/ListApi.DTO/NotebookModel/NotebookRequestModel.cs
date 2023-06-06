using System.ComponentModel.DataAnnotations;

namespace ListApi.DTO.NotebookModel
{
    public class NotebookRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
