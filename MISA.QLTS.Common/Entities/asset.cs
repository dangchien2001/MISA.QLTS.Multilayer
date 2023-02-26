using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.Common.Entities
{
    public class asset
    {
        /// <summary>
        /// Id tài sản
        /// </summary>
        public Guid asset_id { get; set; }

        /// <summary>
        /// Mã tài sản
        /// </summary>
        public string asset_code { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        public string asset_name { get; set; }

        /// <summary>
        /// Id của đơn vị
        /// </summary>
        public Guid organization_id { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        public string organization_code { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string organization_name { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid department_id { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// Id loại tài sản
        /// </summary>
        public Guid asset_category_id { get; set; }

        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string asset_category_code { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string asset_category_name { get; set; }

        /// <summary>
        /// Ngày mua
        /// </summary>
        public DateTime purchase_date { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal cost { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        public float depreciation_rate { get; set; }

        /// <summary>
        /// Năm bắt đầu theo dõi sản phẩm trên phần mềm
        /// </summary>
        public int tracked_year { get; set; }

        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        public int life_time { get; set; }

        /// <summary>
        /// Năm sử dụng
        /// </summary>
        public int production_year { get; set; }

        /// <summary>
        /// Sử dụng
        /// </summary>
        public int active { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string created_by { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime created_date { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string modified_by { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime modified_date { get; set; }
    }
}
