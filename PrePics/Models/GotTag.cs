using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace PrePics.Models;

[Table("GotTag")]
public class GotTag
{
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string tagId { get; set; }

    [ForeignKey("tagId")]
    public virtual Tag tag { get; set; }
    
    public string galleryId { get; set; }
    
    [ForeignKey("galleryId")]
    public Gallery gallery { get; set; }
}