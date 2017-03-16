using Guldrullen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guldrullen.Models
{
    public class MovieReviewAdvancedVM
    {
        public MovieReviewVM[] ListViewModels { get; set; }
        public MovieDisplayVM FormViewModel { get; set; }
    }
}
