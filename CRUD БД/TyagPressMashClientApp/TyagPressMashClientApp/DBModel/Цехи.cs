using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Цехи
    {
        public Цехи()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        public int Код { get; set; }
        public string Название { get; set; }

        public virtual ICollection<Сотрудники> Сотрудники { get; set; }

        public override string ToString()
        {
            return $"{Код} - {Название}" ;
        }
    }
}
