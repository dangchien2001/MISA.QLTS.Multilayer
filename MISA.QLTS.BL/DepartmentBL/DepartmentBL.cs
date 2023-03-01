using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.BL.BaseBL;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.DL.BaseDL;
using MISA.QLTS.DL.DepartmentDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.BL.DepartmentBL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        #region Field

        private IDepartmentDL _departmentDL;

        #endregion

        #region Constructor

        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }

        public PagingResult GetAssetsByFilter([FromQuery] string? assetFilter, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var result = _departmentDL.GetAssetsByFilter(assetFilter, pageSize, pageNumber);
            return result;
        }

        #endregion
    }
}
