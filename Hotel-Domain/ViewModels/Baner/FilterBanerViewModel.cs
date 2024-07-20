using Hotel_Domain.Entities.Baner;
using Hotel_Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels.Baner
{
    public class FilterBanerViewModel : Paging<FisrtBaner>
    {
        public string? TitleBanner { get; set; }
    }
}
