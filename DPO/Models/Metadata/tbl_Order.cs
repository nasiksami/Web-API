namespace DPO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(tbl_Order))]
    public partial class tbl_Order{}
    public partial class tbl_OrderMetadata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Order()
        {
            this.tbl_Details = new HashSet<tbl_Details>();
        }
        [Display(Name = "ORDER ID")]
        public int order_ID { get; set; }
        [Display(Name = "ORDER NAME")]
        public string order_Name { get; set; }
        [Display(Name = "CREATED BY")]
        public string created_by { get; set; }
       
        public System.DateTime created_on { get; set; }

        [Required(ErrorMessage = "Please Enter the Status name from these three options: Open, Picked, Packed, Shipped, Delivered, Cancelled")]
        [Display(Name = "STATUS")]
        public string status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Details> tbl_Details { get; set; }
    }
}
