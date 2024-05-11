using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaCore.Models
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
