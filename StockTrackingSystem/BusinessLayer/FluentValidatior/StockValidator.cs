using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidatior
{
    public class StockValidatior : AbstractValidator<Stock>
    {
        public StockValidatior()
        {
            RuleFor(b => b.Kategori)
                .NotEmpty().WithMessage("Kategori alanı boş bırakılamaz");
            RuleFor(b => b.Miktar)
                .GreaterThan(0).WithMessage("Miktar alanı 0'dan büyük olmalıdır");
            RuleFor(b => b.BirimFiyat)
                .GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalıdır");
            RuleFor(b => b.Tedarikci)
                .NotEmpty().WithMessage("Lütfen stok tedarikçisini giriniz");
            RuleFor(b => b.EklenmeTarihi)
                .NotEmpty()
                .WithMessage("Eklenme tarihi gerekli");
            RuleFor(b => b.SonGuncellenmeTarihi)
                .GreaterThan(record => record.EklenmeTarihi)
                .WithMessage("Son Güncelleme Tarihi Ekleme Tarihinden sonra olmalıdır");



        }
    }
}
