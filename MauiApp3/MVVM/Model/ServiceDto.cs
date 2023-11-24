using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.MVVM.Model
{
   public  class ServiceDto
    {

        [Required(ErrorMessage = "Service Title is required.")]
      
        public string Title { get; set; }

        [Required(ErrorMessage ="Service Description is required")]
     
        public string Description { get; set; }

        [Required(ErrorMessage ="Service Price is required")]
 
        public Decimal Price { get; set; }

     
        public string ImageName { get; set; }

     
        public int? ServieTypeId { get; set; }
    }
}
