
namespace DPO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(tbl_Users))]
    public partial class tbl_Users
    {
    }
    public partial class tbl_UsersMetadata
    {
        [Display(Name = "USER ID")]
        public int user_ID { get; set; }
        [Display(Name = "USER NAME")]
        [Required]
        public string user_Name { get; set; }
        [Display(Name = "EMAIL ADDRESS")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
