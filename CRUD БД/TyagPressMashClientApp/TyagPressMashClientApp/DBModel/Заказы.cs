using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Заказы
    {
        public int Код { get; set; }
        public int Ответственный { get; set; }
        public DateTime? Оформлен { get; set; }
        public DateTime? Срок { get; set; }
        public int? Цех { get; set; }
        public int? Продукт { get; set; }

        public virtual Сотрудники ОтветственныйNavigation { get; set; }
        public virtual Продукция ПродуктNavigation { get; set; }
        public virtual Цеха ЦехNavigation { get; set; }
    }
}
