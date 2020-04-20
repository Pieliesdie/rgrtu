using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Цеха
    {
        public Цеха()
        {
            Заказы = new HashSet<Заказы>();
            ПродукцияЦехов = new HashSet<ПродукцияЦехов>();
            Сотрудники = new HashSet<Сотрудники>();
        }

        public int Код { get; set; }
        public string Название { get; set; }
        public bool Вредность { get; set; }
        public string Телефон { get; set; }

        public override string ToString()
        {
            return Название;
        }

        public virtual ICollection<Заказы> Заказы { get; set; }
        public virtual ICollection<ПродукцияЦехов> ПродукцияЦехов { get; set; }
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
