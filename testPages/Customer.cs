using System.ComponentModel.DataAnnotations;

namespace testPages
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}