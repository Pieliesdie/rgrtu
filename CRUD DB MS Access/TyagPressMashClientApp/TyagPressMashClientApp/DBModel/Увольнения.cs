using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Увольнения
    {
        public int Код { get; set; }
        public int? КодУволенногоСотрудника { get; set; }
        public DateTime? ДатаУвольнения { get; set; }
        public string ПричинаУвольнения { get; set; }

        public virtual Сотрудники КодУволенногоСотрудникаNavigation { get; set; }
    }
}
