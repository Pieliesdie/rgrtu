using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        public int Код { get; set; }
        public string Название { get; set; }
        public DateTime? ВремяСоздания { get; set; }
        public bool Опасность { get; set; }
        public decimal? Оклад { get; set; }

        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
