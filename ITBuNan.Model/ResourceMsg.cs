//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITBuNan.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResourceMsg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResourceMsg()
        {
            this.Recommend = new HashSet<Recommend>();
            this.UserCollection = new HashSet<UserCollection>();
        }
    
        public string resId { get; set; }
        public string resMsg { get; set; }
        public string resUrl { get; set; }
        public string resPwd { get; set; }
        public string resUserId { get; set; }
        public int resClickNum { get; set; }
        public string resCategoryId { get; set; }
        public int resCollectNum { get; set; }
        public int resUploadNum { get; set; }
        public System.DateTime resCreateTime { get; set; }
        public int resStatus { get; set; }
        public int resType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommend> Recommend { get; set; }
        public virtual Res_Category Res_Category { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCollection> UserCollection { get; set; }
    }
}
