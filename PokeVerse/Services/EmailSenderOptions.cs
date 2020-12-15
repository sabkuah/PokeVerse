using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PokeVerse.Services
{
    public class EmailSenderOptions
    {
        public string SENDGRID_KEY { get; set; }
        public string SENDGRID_EMAIL { get; set; }
        public string SENDGRID_NAME { get; set; }
    }
}
