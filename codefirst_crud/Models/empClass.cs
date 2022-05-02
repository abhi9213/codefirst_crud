using System.ComponentModel.DataAnnotations;

namespace codefirst_crud.Models
{
    public class empClass
    {[Key]
        public int id { get; set; }
        public string name { get; set; }

        public int sal { get; set; }
        public int age { get; set; }
    }
}
