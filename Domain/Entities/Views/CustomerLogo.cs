using Domain.Entities.MainModule.Master;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Views
{
    public  class CustomerLogo
    {
        public Customer Customer { get; set; }
        public byte[] Logo { get; set; }
    }
}
