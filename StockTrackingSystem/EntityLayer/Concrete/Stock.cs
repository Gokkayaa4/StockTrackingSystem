using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entityes;

namespace EntityLayer.Concrete
{
    public class Stock:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Kategori { get; set; }
        public string Tedarikci { get; set; }
        public int Miktar { get; set; }
        public int BirimFiyat { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime SonGuncellenmeTarihi { get; set; }
    }
}
