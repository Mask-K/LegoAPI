using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lego.Models
{
    public class UserBoughtLego
    {
        
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        

        public int ConstructorId { get; set; }
        [ForeignKey("ConstructorId")]
        public virtual Constructor Constructor { get; set; }
        [ForeignKey("UserId")]


        public virtual Users User { get; set; }
    }
}
