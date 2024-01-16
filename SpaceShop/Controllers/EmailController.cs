using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.Email;
using Shop.Core.ServiceInterface;
using SpaceShop.Models.Email;

namespace SpaceShop.Controllers
{
    //[Authorize]
    public class EmailController : Controller
    {
            private readonly IEmailService _emailService;
            public EmailController(IEmailService emailService)
            {
                _emailService = emailService;


            }

            [HttpGet]
            public IActionResult Index()
            {
                return View();

            }

            [HttpPost]
            public IActionResult SendEmail(EmailViewModel vm)
            {
                EmailDto dto = new EmailDto();
                dto.To = vm.To;
                dto.Subject = vm.Subject;
                dto.Body = vm.Body;

                _emailService.sendEmail(dto);



                return RedirectToAction(nameof(Index)); ;
            }
        }
    }

