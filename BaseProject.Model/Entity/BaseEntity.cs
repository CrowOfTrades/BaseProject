using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public static string TABLE_NAME { get; internal set; }
    }
}
