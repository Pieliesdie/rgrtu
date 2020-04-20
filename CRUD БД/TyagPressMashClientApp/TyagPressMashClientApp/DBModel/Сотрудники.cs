using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Сотрудники 
    {
        public Сотрудники()
        {
            Доплаты = new HashSet<Доплаты>();
            Заказы = new HashSet<Заказы>();
        }

        public int Код { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public DateTime? ДатаРождения { get; set; }
        public int? СерияПаспорта { get; set; }
        public int? НомерПаспорта { get; set; }
        public string Образование { get; set; }
        public bool Инвалидность { get; set; }
        public DateTime? ДатаЗаключенияДоговора { get; set; }
        public int? Цех { get; set; }
        public int? Должность { get; set; }

        public override string ToString()
        {
            return $"{Фамилия} {Имя} {Отчество}";
        }

        public virtual Должности ДолжностьNavigation { get; set; }
        public virtual Цеха ЦехNavigation { get; set; }
        public virtual ICollection<Доплаты> Доплаты { get; set; }
        public virtual ICollection<Заказы> Заказы { get; set; }
    }
}
