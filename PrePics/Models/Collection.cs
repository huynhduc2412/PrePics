using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrePics.Models;

[Table("Collection")]
public class Collection
{
    [Key]
    [Column("Id")]
    public string id { get; set; }
    
    [Column("Title")]
    public string title { get; set; }
    
    [Column("DateCreate")]
    public DateTime dateCreate { get; set; }
    
    [Column("IsPublict")]
    public bool isPublic { get; set; }

    public string userId { get; set; }
    
    [ForeignKey("userId")]
    public virtual User user { get; set; }
}