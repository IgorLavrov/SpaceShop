using Shop.Core.Dto.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{   
    public interface IEmailService
    {
       public  void sendEmail(EmailDto request);
    }
}
