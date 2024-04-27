using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrePics.Models;

[Table("User")]
public class User
{
    [Key] [Column("Id")]
    public string id { get; set; }
    
    [Required]
    [Column("UserName")]
    public string userName { get; set; }
    
    [Column("FirstName")]
    public string firstName { get; set; }

    [Column("LastName")]
    public string lastName { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Wrong type! Please check email!")]
    [Column("Email")]
    public string email { get; set; }
    
    [Required]
    [Column("Password")]
    public string password { get; set; }
    
    [Column("Discription")]
    public string discription { get; set; }

    [Column("Address")]
    public string address { get; set; }

    [Column("WebsiteUrl")]
    [Url(ErrorMessage = "Wrong type! Please check url!")]
    public string websiteUrl { get; set; }
    
    [Column("TwitterUrl")]
    [Url(ErrorMessage = "Wrong type! Please check url!")]
    public string twitterUrl { get; set; }
    
    [Column("Instagram")]
    [Url(ErrorMessage = "Wrong type! Please check url!")]
    public string instagramUrl { get; set; }
    
    [Column("IsActive")]
    public bool isActive { get; set; }

    public virtual ICollection<Collection> collections { get; set; }
}