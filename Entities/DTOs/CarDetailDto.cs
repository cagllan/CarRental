using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public int MinFindexScore { get; set; }
        public List<CarImage> CarImages { get; set; }

        public int BrandId { get; set; }
        public int ColorId { get; set; }

    }
}
