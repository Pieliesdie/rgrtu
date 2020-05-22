using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Отпуска
    {
        public int Код { get; set; }
        public int? КодСотрудника { get; set; }
        public DateTime? НачалоОтпуска { get; set; }
        public DateTime? ОкончаниеОтпуска { get; set; }

        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
    }
}
