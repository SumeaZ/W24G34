using System.ComponentModel.DataAnnotations;

public class UpdateRoleDTO
{
    [Required]
    [StringLength(256)]
    public string Name { get; set; }
}
