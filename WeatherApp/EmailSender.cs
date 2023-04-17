using System.Net;
using System.Net.Mail;

namespace WeatherApp
{
	public static class EmailSender
	{
		public static bool SendEmail(string senderEmail, string password, string recipientEmail, string subject, string body, string filepath)
		{
			var smtpCLient = new SmtpClient("smtp.freesmtpservers.com")
			{
				Port = 25,
				Credentials = new NetworkCredential(senderEmail, password),
				EnableSsl = false,
			};

			MailMessage mailMessage = new MailMessage();

			mailMessage.From = new MailAddress(senderEmail);
			mailMessage.Sender = new MailAddress(senderEmail);
			mailMessage.To.Add(new MailAddress(recipientEmail));
			mailMessage.Subject = subject;
			mailMessage.Body = body;
			mailMessage.Attachments.Add(new Attachment(filepath));

			smtpCLient.Send(mailMessage);

			return true;
		}
	}
}

