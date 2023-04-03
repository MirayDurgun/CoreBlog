using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationsRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
			RuleFor(x => x.WriterPassword2).NotEmpty().WithMessage("Şifre boş geçilemez");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapın");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapın");
			//Şifre
			RuleFor(x => x.WriterPassword).Equal(x => x.WriterPassword2).WithMessage("Şifreler eşleşmiyor");
			RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermeli.");
			RuleFor(p => p.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifre en az bir kicik harf içermeli.");
			RuleFor(p => p.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermeli.");
			//şifre tekrar 
			RuleFor(x => x.WriterPassword2).Equal(x => x.WriterPassword).WithMessage("Şifreler eşleşmiyor");
			RuleFor(p => p.WriterPassword2).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermeli.");
			RuleFor(p => p.WriterPassword2).Matches(@"[a-z]+").WithMessage("Şifre en az bir kicik harf içermeli.");
			RuleFor(p => p.WriterPassword2).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermeli.");
		}
	}
}
