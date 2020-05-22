using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Документы
    {
        public int Код { get; set; }
        public int? Снилс { get; set; }
        public int? Инн { get; set; }
        public int? СерияИНомерПаспорта { get; set; }
        public int? НомерСотрудника { get; set; }

        public virtual Сотрудники НомерСотрудникаNavigation { get; set; }


        public override string ToString()
        {
            return Код.ToString();
        }
    }
}
