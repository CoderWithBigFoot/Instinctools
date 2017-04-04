using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class BookViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Pages { set; get; }
    }
}