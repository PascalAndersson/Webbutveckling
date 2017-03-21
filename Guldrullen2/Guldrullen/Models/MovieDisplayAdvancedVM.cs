using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieDisplayAdvancedVM
    {
        public MovieDisplayVM[] ListViewModels { get; set; }
        public MovieCreateVM FormViewModels { get; set; }

        public string SearchBox { get; set; }


        public bool DisplayActionBool { get; set; }
        public bool DisplayComedyBool { get; set; }
        public bool DisplayRomanceBool { get; set; }
    }
}
