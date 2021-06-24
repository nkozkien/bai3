namespace lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        
        [StringLength(100, ErrorMessage = "Tiêu đề không được quá 100 ký tự")]
        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mô Tả không được bỏ trống")]
        [StringLength(255)]
        public string Description { get; set; }

        
        [StringLength(30, ErrorMessage = "Tên tác giả không được quá 30 ký tự")]
        [Required(ErrorMessage = "Tên tác giả không được bỏ trống")]
        public string Author { get; set; }

        
        [StringLength(255)]
        [Required(ErrorMessage = "hình ảng không được bỏ trống")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Giá sách không được bỏ trống")]
        [Range(1000,1000000,ErrorMessage = "Giá sách từ 1.000 đến 1.000.000")]
        public int Price { get; set; }
    }
}
