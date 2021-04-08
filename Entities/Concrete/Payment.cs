using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Ccv { get; set; }
        

    }
}
