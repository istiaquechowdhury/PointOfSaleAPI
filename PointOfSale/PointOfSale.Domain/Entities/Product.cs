using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }    

        public string Name { get; set; }    
    }
}
