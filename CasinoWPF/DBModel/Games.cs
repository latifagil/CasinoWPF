//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasinoWPF.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            this.GameSessions = new HashSet<GameSessions>();
        }
    
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public decimal MinBet { get; set; }
        public decimal MaxBet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameSessions> GameSessions { get; set; }
    }
}
