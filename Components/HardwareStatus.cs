using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDOM.Components
{
    //Таблица "Статус оборудования"
    public class HardwareStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Hardware> Hardware { get; private set; }
        
        //Поле, отвечающее за цветовую индикацию статуса
        public string StatusIndicator
        {
            get
            {
                switch (Id)
                {
                    case 1:
                        return "#FF0BBF27";
                    case 2:
                        return "#FF13A4E2";
                    case 3:
                        return "#FFC30000";
                    default:
                        return "Black";
                }
            }
        }
    }
}
