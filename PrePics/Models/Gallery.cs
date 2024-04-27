using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrePics.Models;

[Table("Gallery")]
public class Gallery
{
    [Key]
    [Column("Id")]
    public string id { get; set; }
    
    [Column("Location")]
    public string location { get; set; }
    
    [Column("DateUpload")]
    public DateTime dateUpload { get; set; }
    
    [Column("Liked")]
    public int liked { get; set; }
    
    [Column("Downloads")]
    public int download { get; set; }
    
    [Column("Views")]
    public int views { get; set; }
    
    [Required]
    [Column("Height")]
    public int height { get; set; }
    
    [Required]
    [Column("Width")]
    public int width { get; set; }
    
    [Url(ErrorMessage = "Wrong type! Please check url!")]
    [Column("ImageUrl")]
    public string imageUrl { get; set; }
    
    [Column("IsPublic")]
    public bool isPublic { get; set; }
    
    public virtual ICollection<GotTag> gotTags { get; set; }
    
    public virtual ICollection<InCollection> inCollections { get; set; }
}