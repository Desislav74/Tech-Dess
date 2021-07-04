namespace TechDess.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechDess.Common;
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Web.ViewModels.Contacts;

    public class ContactsController : BaseController
    {
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";

        private readonly IRepository<ContactForm> contactsRepository;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender;

        public ContactsController(IRepository<ContactForm> contactsRepository, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.emailSender = emailSender;
        }

        [Authorize]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var contactFormEntry = new ContactForm
            {
                Name = model.Name,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content,
            };
            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();

            var content = "Name: " + model.Name;
            content += "<br>Email: " + model.Email;
            content += "<br>Title: " + model.Title;
            content += "<br>Content: " + model.Content;

            this.ViewBag.msg = MailHelper.Send(model.Email, GlobalConstants.SystemEmail, model.Title, content);
            this.TempData[RedirectedFromContactForm] = true;

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
