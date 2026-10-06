using System.ComponentModel.DataAnnotations;

namespace MvcBasicSample.Models {
    public class Product {
        public int id { get; set; } //主キー

        [Required]
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } //円単位の価格
    }
}
