using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.Entity.Entity
{
    public class Product:BaseEntity,IAudit
    {
        public int Id { get; set; }

        public string Name{ get; set; }
        public double Price { get; set; }

        //foregion key ile bağlı olduğu tablo
        public int CategoryId{ get; set; }
        public Category CategoryFK{ get; set; }

        //auditten gelen veriler
        public int CreatedUserId { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public int? ModifiedUserId { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
    }
}
