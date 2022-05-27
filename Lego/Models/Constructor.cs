using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lego.Models
{
    public class Constructor
    {
        public Constructor()
        {
            UserBoughtLegos = new List<UserBoughtLego>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Конструктор")]
        public string Name { get; set; }

        public double price { get; set; }

        public int TargetId { get; set; }
        public int CollectionId { get; set; }
        [ForeignKey("CollectionId")]
        public virtual Collection Collection { get; set; }
        [ForeignKey("TargetId")]
        public virtual Target Target { get; set; }

        public virtual ICollection<UserBoughtLego> UserBoughtLegos { get; set; }


    }
}