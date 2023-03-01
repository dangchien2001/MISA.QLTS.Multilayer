using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.Common.Entities
{
    public class AssetCategory
    {
        /// <summary>
        /// Id loại tài sản
        /// </summary>
        public Guid AssetCategoryId { get; set; }

        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string AssetCategoryCode { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetCategoryName { get; set; }

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
