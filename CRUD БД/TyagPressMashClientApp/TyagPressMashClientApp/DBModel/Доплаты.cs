using System;
using System.Collections.Generic;

namespace TyagPressMashClientApp
{
    public partial class Доплаты: IHavingPrimaryKey
    {
        public int Код { get; set; }
        public int? Сотрудник { get; set; }
        public decimal? Размер { get; set; }
        public string Причина { get; set; }

        public virtual Сотрудники СотрудникNavigation { get; set; }
    }
}
