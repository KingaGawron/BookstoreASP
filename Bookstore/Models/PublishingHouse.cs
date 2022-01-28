using Bookstore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class PublishingHouse:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "PublishingHouse LogoURL")]
        [Required(ErrorMessage = "PublishingHouse logo is required")]
        public string LogoURL { get; set; }

        [Display(Name = "PublishingHouse Name")]
        [Required(ErrorMessage = "PublishingHouse name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "PublishingHouse description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
