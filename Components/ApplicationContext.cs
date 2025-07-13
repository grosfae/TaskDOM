using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDOM.Components
{
    //Определение таблиц из базы данных
    public class ApplicationContext : DbContext
    {
        public DbSet<Hardware> Hardware {get; set;}
        public DbSet<HardwareType> HardwareType {get; set;}
        public DbSet<HardwareStatus> HardwareStatus { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DomBase.db");
        }
    }
}
