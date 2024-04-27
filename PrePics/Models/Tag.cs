using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrePics.Models;

[Table("Tag")]
public class Tag
{
    [Key]
    [Column("Id")]
    public string id { get; set; }
    
    [Column("Title")]
    public string title { get; set; }
    
    public virtual ICollection<GotTag> gotTags { get; set; }
}