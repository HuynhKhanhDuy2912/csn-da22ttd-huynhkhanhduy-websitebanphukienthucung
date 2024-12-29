using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public abstract class CommonAbstract
    {
        public string Createdby {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public string ModifierBy {  get; set; }
        public DateTime ModifierDate {  get; set; }
    }
}