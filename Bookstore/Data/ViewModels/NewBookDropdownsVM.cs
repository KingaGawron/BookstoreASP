using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Authors = new List<Author>();
            PublishingHouses = new List<PublishingHouse>();
        }

        public List<Author> Authors { get; set; }
        public List<PublishingHouse> PublishingHouses { get; set; }
    }
}
