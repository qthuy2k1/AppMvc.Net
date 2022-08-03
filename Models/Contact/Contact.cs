using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Net.Models.Contact
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }
        public DateTime? DateSent { get; set; }
        [Display(Name = "Nội dung")]
        public string? Message { get; set; }
        [StringLength(50)]
        [Phone(ErrorMessage = "Phải là số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string? Phone { get; set; }
    }
}
