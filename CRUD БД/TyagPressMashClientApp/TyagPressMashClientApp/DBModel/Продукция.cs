using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Продукция : IHavingPrimaryKey
    {
        public Продукция()
        {
            Заказы = new HashSet<Заказы>();
            ПродукцияЦехов = new HashSet<ПродукцияЦехов>();
        }

        public int Код { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
        public decimal? Стоимость { get; set; }

        public override string ToString()
        {
            return Наименование;
        }

        public virtual ICollection<Заказы> Заказы { get; set; }
        public virtual ICollection<ПродукцияЦехов> ПродукцияЦехов { get; set; }
    }
}
