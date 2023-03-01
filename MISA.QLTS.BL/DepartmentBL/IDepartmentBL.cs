using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.BL.BaseBL;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.BL.DepartmentBL
{
    public interface IDepartmentBL : IBaseBL<Department>
    {
        /// <summary>
        /// Lấy danh sách tài sản theo mã phòng ban có phân trang
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        PagingResult GetAssetsByFilter([FromQuery] string? assetFilter, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1);
    }
}
