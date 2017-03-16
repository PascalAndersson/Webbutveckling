using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieDisplayAdvancedVM
    {
        public MovieDisplayVM[] ListViewModels { get; set; }
        public MovieCreateVM FormViewModels { get; set; }

        public string SearchBox { get; set; }
        
        [Display(Name = "Action")]
        public bool DisplayActionBool { get; set; }

        [Display(Name = "Comedy")]
        public bool DisplayComedyBool { get; set; }

        [Display(Name = "Romance")]
        public bool DisplayRomanceBool { get; set; }
    }
}
