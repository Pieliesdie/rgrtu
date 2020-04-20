using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class ПродукцияЦехов 
    {
        public int Код { get; set; }
        public int? Цех { get; set; }
        public int? Продукт { get; set; }

        public virtual Продукция ПродуктNavigation { get; set; }
        public virtual Цеха ЦехNavigation { get; set; }
    }
}
