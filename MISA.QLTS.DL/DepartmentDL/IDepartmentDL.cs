using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DL.DepartmentDL
{
    public interface IDepartmentDL : IBaseDL<Department>
    {
        #region Method

        /// <summary>
        /// Lấy danh sách tài sản theo mã phòng ban có phân trang
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        PagingResult GetAssetsByFilter([FromQuery] string? assetFilter, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1);

        #endregion
    }
}
