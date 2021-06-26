namespace ChieuThu6.Models
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
        [Required(ErrorMessage = "ID Không Để Trống !")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tiêu Đề Không Để Trống !")]
        [StringLength(250,ErrorMessage ="Không quá 250 ký tự")]
        public string Tieu_De { get; set; }

        [Required(ErrorMessage = "Nội Dung Không Để Trống !")]
        [StringLength(250, ErrorMessage = "Không quá 250 ký tự")]

        public string Noi_Dung { get; set; }

        [Required(ErrorMessage = "Đường Dẫn Hình Ảnh Không Để Trống !")]
        [StringLength(250, ErrorMessage = "Không quá 250 ký tự")]
        public string Hinh_Anh { get; set; }
        [Required(ErrorMessage = "Giá Không Để Trống !")]
        [Range(1000,1000000,ErrorMessage = "Giá Nằm từ 1000 - 1000000")]
        public double? Gia { get; set; }
    }
}
