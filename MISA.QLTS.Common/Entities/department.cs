using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.Common.Entities
{
    public class department
    {
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
        public string department_name { get;set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Có phải là cha không (1 - có, 0 - không)
        /// </summary>
        public int is_parent { get; set; }

        /// <summary>
        /// Id phòng ban cha
        /// </summary>
        public Guid parent_id { get; set; }

        /// <summary>
        /// Id của đơn vị
        /// </summary>
        public Guid organization_id { get; set; }

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
