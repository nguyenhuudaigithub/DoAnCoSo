using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoAnWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập Email!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Xin vui lòng kiểm tra lại!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản!")]
        public string UserName { get; set; }

        [Display(Name = "Họ Và Tên")]
        [Required(ErrorMessage = "Bạn chưa nhập họ và tên!")]
        public string FullName { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ!")]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public bool Gender { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        public string PhoneNumber { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Bạn có nhớ trình duyệt này không?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        //[Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Tài Khoản")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Xin vui lòng kiểm tra lại!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản!")]
        public string UserName { get; set; }

        [Display(Name = "Họ Và Tên")]
        [Required(ErrorMessage = "Bạn chưa nhập họ và tên!")]
        public string FullName { get; set; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ!")]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public bool Gender { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải tối đa {0} ký tự và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác thực mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu phải tối đa {0} ký tự và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác thực mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
