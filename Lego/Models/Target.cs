using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lego.Models
{
    [Table("Target")]
    public class Target
    {
        public Target()
        {
            Constructors = new List<Constructor>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Аудиторія")]
        public string Name { get; set; }

        public virtual ICollection<Constructor> Constructors { get; set; }

    }
}
