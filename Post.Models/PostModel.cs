using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Post.Models
{
    public class PostModel
    {
        public int PostId { get; set; }

        public int SiteId { get; set; }

        /// <summary>
        /// 1   - недвижими имоти
        /// </summary>
        public int CategoryId { get; set; }

        [Display(Name = "Link")]
        public string PLink { get; set; }

        [Display(Name = "Image")]
        public string PImage { get; set; }

        [Display(Name = "Заглавие")]
        public string PTitle { get; set; }

        [Display(Name = "Текст")]
        public string PText { get; set; }

        [Display(Name = "Цена")]
        public decimal PPrice { get; set; }

        public int TemplateLocationId { get; set; }

        [Display(Name = "Дата")]
        public DateTime PDate { get; set; }

        public int SitePostedId { get; set; }

        [Display(Name = "Тип цена")]
        public int PPriceTypeId { get; set; }
    }
}
