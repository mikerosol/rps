using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        
        public Models.Location Location { get; set; }

        //[Required]
        public RiskContructionEnum RiskConstruction { get; set; }

        //[Required]
        //[Range(0, 2020)]
        public int RiskYearBuilt { get; set; }

        public enum RiskContructionEnum
        {
            [Description("Modular Home")]
            ModularHome,
            [Description("Site Built Home")]
            SiteBuiltHome,            
            [Description("Single Wide Manufactured Home")]
            SingleWideManufacturedHome,
            [Description("Double Wide Manufactured Home")]
            DoubleWideManufacturedHome
        }
    }
}
