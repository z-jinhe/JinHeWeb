//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class JH_Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainPic { get; set; }
        public string GId { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string DelTime { get; set; }
        public string Del { get; set; }
    
        public virtual JH_Goods Goods { get; set; }
    }
}
