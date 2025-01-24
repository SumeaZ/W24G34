public class CreateRoleDTO
{
    [Required]
    [StringLength(256)]
    public string Name { get; set; }
}
