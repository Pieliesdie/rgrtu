﻿using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Должности:IHavingPrimaryKey
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

        public override string ToString()
        {
            return Название;
        }

        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
