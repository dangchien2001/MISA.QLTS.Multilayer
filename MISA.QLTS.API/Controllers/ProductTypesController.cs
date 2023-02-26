using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        /// <summary>
        /// API lấy tất cả loại tài sản
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllProductType()
        {
            // Chuẩn bị tên stored procedure          

            // Câu lệnh truy vấn
            var sqlCommand = "SELECT * FROM producttype";

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Gọi vào DB
            var products = mySqlConnection.Query<object>(sqlCommand);

            // Kết quả trả về
            return StatusCode(StatusCodes.Status201Created, products);
        }

        /// <summary>
        /// API lấy 1 phòng ban dựa trên mã loại tài sản (ProductTypeCode)
        /// </summary>
        /// <param name="ProductTypeCode"></param>
        /// <returns></returns>
        [HttpGet("{ProductTypeCode}")]
        public IActionResult GetByDepartmentCode(String ProductTypeCode)
        {
            // Chuẩn bị tên stored procedure          

            // Câu lệnh truy vấn
            var sqlCommand = "SELECT * FROM producttype WHERE ProductTypeCode = @ProductTypeCode";

            // Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("@ProductTypeCode", ProductTypeCode);

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
