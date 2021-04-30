using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entity
{
    /// <summary>
    /// entitiylerimiz bu interfaceden kalıtım alırlar
    /// </summary>
    public interface IAudit
    {
        //oluşturan kişi ıd si
        public int CreatedUserId { get; set; }

        //oluşturulma tarihi
        public DateTime CreatedDate { get; set; }

        //güncelleyen kişi ıd si
        public int? ModifiedUserId { get; set; }

        //güncelleme tarihi
        public DateTime? ModifiedDate { get; set; }
    }
}
