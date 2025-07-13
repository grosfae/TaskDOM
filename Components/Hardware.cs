using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDOM.Components
{
    //Таблица "Оборудование"
    public class Hardware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HardwareTypeId { get; set; }
        public virtual HardwareType HardwareType { get; set; }
        public int HardwareStatusId { get; set; }
        public virtual HardwareStatus HardwareStatus { get; set; }

    }
}
