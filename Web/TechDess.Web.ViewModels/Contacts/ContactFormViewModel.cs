namespace TechDess.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using TechDess.Web.Infrastructure;

    public class ContactFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your names")]
        [Display(Name = "Your names")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title for the message")]
        [Display(Name = "Message title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the content of the message")]
        [Display(Name = "Content of the message")]
        public string Content { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
