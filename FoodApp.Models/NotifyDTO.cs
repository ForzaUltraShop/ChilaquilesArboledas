namespace FoodApp.DataModels
{
    using FoodApp.Models;
    using FoodApp.Models.Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NotifyDTO
    {
        public string Message { get; set; }

        public NotifyType Type { get; set; }

        public LocationDTO Location { get; set; }
    }
}
