using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Сотрудники
    {
        public Сотрудники()
        {
            Документы = new HashSet<Документы>();
            Отпуска = new HashSet<Отпуска>();
            Увольнения = new HashSet<Увольнения>();
        }

        public int Код { get; set; }
        public string Фио { get; set; }
        public string АдресРегистрации { get; set; }
        public string АдресПроживания { get; set; }
        public DateTime? ДатаРождения { get; set; }
        public int? Номер { get; set; }
        public int? КодЦеха { get; set; }
        public int? КодДолжности { get; set; }

        public virtual Должности КодДолжностиNavigation { get; set; }
        public virtual Цехи КодЦехаNavigation { get; set; }
        public virtual ICollection<Документы> Документы { get; set; }
        public virtual ICollection<Отпуска> Отпуска { get; set; }
        public virtual ICollection<Увольнения> Увольнения { get; set; }

        public override string ToString()
        {
            return $"{Код} - {Фио}";
        }
    }
}
