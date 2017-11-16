using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Home : Location
    {
        //[Required]
        [Display(Name = "Construction Type")]
        public RiskContructionEnum RiskConstruction { get; set; }

        //[Required]
        //[Range(0, 2020)]
        [Display(Name = "Year Built")]
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
