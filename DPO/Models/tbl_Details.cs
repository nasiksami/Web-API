//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DPO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class tbl_Details
    {
        public int ID { get; set; }
        [Display(Name = "ORDER ID")]
        [Required]
        public int order_ID { get; set; }
        [Display(Name = "USER NAME")]
        public string user_Name { get; set; }
       
        public System.DateTime created_On { get; set; }


        [Required]
        [MaxLength(200)]
        [Display(Name = "COMMENT/MESSAGE")]
        public string comment { get; set; }

        [Required(ErrorMessage = "Please Enter the App name from these three options: OMS/WMS/DMS")]
        [Display(Name = "APPLICATION NAME")]
        public string application { get; set; }


        //[Required(ErrorMessage = "Please Enter the Status from these options: Open, Picked, Packed, Shipped, Delivered, Cancelled")]


        [Display(Name = "STATUS")]
        public string status { get; set; }

        public virtual tbl_Order tbl_Order { get; set; }
    }
}
