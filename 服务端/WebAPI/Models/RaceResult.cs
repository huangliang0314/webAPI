//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceResult
    {
        public int Id { get; set; }
        public string RaceId { get; set; }
        public string Position { get; set; }
        public string Grid { get; set; }
        public string Point { get; set; }
        public string RacerId { get; set; }
        public string TeamId { get; set; }
    
        public virtual Race Race { get; set; }
        public virtual Racer Racer { get; set; }
    }
}
