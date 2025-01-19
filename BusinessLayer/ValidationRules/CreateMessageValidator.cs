using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.MessageValidationRules
{
	public class CreateMessageValidator:AbstractValidator<Message>
	{
		public CreateMessageValidator()
		{
			RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı E-Posta Adresi Boş Bırakılamaz!");
			RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici E-Posta Adresi Boş Bırakılamaz!");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Bırakılamaz!");
			RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz!");
		}
	}
}

