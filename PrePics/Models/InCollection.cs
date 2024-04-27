using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrePics.Models;

[Table("InCollection")]
public class InCollection
{
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public string galleryId{ get; set; }
    
    [ForeignKey("galleryId")]
    public virtual Gallery gallery { get; set; }

    public string collectionId { get; set; }
    
    [ForeignKey("collectionId")]
    public Collection collection { get; set; }
}