using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lego.Models
{
    public class Users
    {
        public Users()
        {
            UserBoughtLegos = new List<UserBoughtLego>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Нікнейм")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Пошта")]
        public string Email { get; set; }
        public virtual ICollection<UserBoughtLego> UserBoughtLegos { get; set; }

    }
}
