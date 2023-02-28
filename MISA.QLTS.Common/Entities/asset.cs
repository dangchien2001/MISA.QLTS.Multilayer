using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.QLTS.Common.Attributes.QLTSAttributes;

namespace MISA.QLTS.Common.Entities
{
    public class Asset
    {
        /// <summary>
        /// Id tài sản
        /// </summary>
        [PrimaryKey]
        public Guid AssetId { get; set; }

        /// <summary>
        /// Mã tài sản
        /// </summary>
        [Required(ErrorMessage = "Mã tài sản không được bỏ trống")]
        [StringLength(4, ErrorMessage = "Mã tài sản không vượt quá 20 ký tự")]
        public string AssetCode { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        [Required(ErrorMessage = "Tên tài sản không được bỏ trống")]
        [StringLength(3, ErrorMessage = "Tên tài sản không vượt quá 20 ký tự")]
        public string AssetName { get; set; }

        /// <summary>
        /// Id loại tài sản
        /// </summary>
        /// 
        [ForeignKey("Mã loại không được để trống")]
        public Guid AssetCategoryId { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetCategoryName { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// 
        [ForeignKey("Mã phòng ban không được để trống")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int quantity { get; set; }


        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal Price { get; set; }

        

        /// <summary>
        /// Hao mòn lũy kế (%)
        /// </summary>
        public decimal AccumulatedDepreciation { get; set; }

        /// <summary>
        /// Giá trị còn lại
        /// </summary>
        public decimal ResidualValue { get; set; }

       

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public string ModifiedDate { get; set; }
    }
}
