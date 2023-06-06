using System.ComponentModel.DataAnnotations;

namespace ListApi.DTO.LineModel
{
    public class LineRequestModel
    {
        [Required]
        public Guid NotebookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
