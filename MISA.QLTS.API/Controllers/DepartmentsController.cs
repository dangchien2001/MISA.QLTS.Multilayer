using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.API.Entities;
using MySqlConnector;
using System.Data;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        /// <summary>
        /// API lấy tất cả phòng ban
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            // Chuẩn bị tên stored procedure          
            var storedProcedureName = "Proc_Department_GetAll";

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Gọi vào DB
            var products = mySqlConnection.Query<object>(storedProcedureName, commandType: CommandType.StoredProcedure);

            // Kết quả trả về
            return StatusCode(StatusCodes.Status201Created, products);
        }

        /// <summary>
        /// API lấy 1 phòng ban dựa trên mã phòng ban (DepartmentCode)
        /// </summary>
        /// <param name="DepartmentCode"></param>
        /// <returns></returns>
        [HttpGet("{DepartmentCode}")]
        public IActionResult GetByDepartmentCode(String DepartmentCode)
        {
            // Chuẩn bị tên stored procedure          

            // Câu lệnh truy vấn
            var sqlCommand = "SELECT * FROM department WHERE DepartmentCode = @DepartmentCode";

            // Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentCode", DepartmentCode);

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Gọi vào DB
            var department = mySqlConnection.QueryFirstOrDefault<object>(sqlCommand, parameters);

            // Kết quả trả về
            return StatusCode(StatusCodes.Status201Created, department);
        }
    }
}
