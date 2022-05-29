using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lego.Models
{
    public class Collection
    {
        public Collection()
        {
            Constructors = new List<Constructor>();
        }
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Поле не може бути порожнім")]
        [Display(Name = "Колекція")]
        public string Name { get; set; }

        public virtual ICollection<Constructor> Constructors { get; set; }
    }
}
