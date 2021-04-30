using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entity
{
    public class BaseEntity : ISoftDeleted
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }
        //bunun amacına bak unutma
        public StatusType Status { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
