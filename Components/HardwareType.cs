using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDOM.Components
{
    //Таблица "Тип оборудования"
    public class HardwareType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Hardware> Hardware { get; private set; }
    }
}
