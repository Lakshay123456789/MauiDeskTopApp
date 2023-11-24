using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.MVVM.Model
{
    public class Service
    {

        
            [JsonProperty("id")]
            public Guid Id { get; set; }

            [Required]
            [JsonProperty("title")]
            public string Title { get; set; }

            [Required]
            [JsonProperty("description")]
            public string Description { get; set; }

            [Required]
            [JsonProperty("price")]
            public Decimal Price { get; set; }

            [JsonProperty("imageName")]
            public string ImageName { get; set; }

            [JsonProperty("servieTypeId")]
            public int? ServieTypeId { get; set; }
        
    }
}
