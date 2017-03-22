using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieEditVM
    {
        [Display(Name = "Title")]
        [MaxLength(50, ErrorMessage = "Only 50 character allowed")]
        [Required(ErrorMessage = "*Required")]
        public string Title { get; set; }

        [Display(Name = "About")]
        [MaxLength(300, ErrorMessage = "Only 300 character allowed")]
        [Required(ErrorMessage = "*Required")]
        public string About { get; set; }

        [Display(Name = "Length")]
        [Required(ErrorMessage = "*Required")]
        public int Length { get; set; }

        [Display(Name = "Genre")]
        [MaxLength(25, ErrorMessage = "Only 25 character allowed")]
        [Required(ErrorMessage = "*Required")]
        public string Genre { get; set; }

        [Display(Name = "Trailer")]
        public string Trailer { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

    }
}
