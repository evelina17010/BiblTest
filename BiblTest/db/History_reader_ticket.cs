//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiblTest.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class History_reader_ticket
    {
        public int ID { get; set; }
        public Nullable<int> ID_Ticket { get; set; }
        public Nullable<int> ID_Book { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader_Ticket Reader_Ticket { get; set; }
    }
}
