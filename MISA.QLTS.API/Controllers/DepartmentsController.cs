using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.BL.AssetBL;
using MISA.QLTS.BL.BaseBL;
using MISA.QLTS.BL.DepartmentBL;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.Common.Resources;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        #region Field

        private IDepartmentBL _departmentBL;

        #endregion

        #region Constructor

        public DepartmentsController(IDepartmentBL departmentBL) : base(departmentBL)
        {
            _departmentBL = departmentBL;
        }

        #endregion

        #region Method

        [HttpGet("filter")]
        public IActionResult GetAssetsByFilter(
            [FromQuery] string? assetFilter,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var result = new PagingResult();
                result = _departmentBL.GetAssetsByFilter(assetFilter, pageSize, pageNumber);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ErrorException(ex);
            }
        }

        private IActionResult ErrorException(Exception ex)
        {
            var errorExp = new
            {
                errorCode = Common.Enums.ErrorCode.Exception,
                devMsg = ex.Message,
                userMsg = Resource.SystemError,
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorExp);
        }

        #endregion
    }
}
