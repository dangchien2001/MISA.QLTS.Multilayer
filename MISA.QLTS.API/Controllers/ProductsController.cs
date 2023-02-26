using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.API.Entities;
using MySqlConnector;
using System.Data;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        /// <summary>
        /// API lấy tài sản theo Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{ProductId}")]
        public IActionResult GetProductById(Guid ProductId)
        {
            // Try catch exception
            try
            {
                // Chuẩn bị tên stored procedure
                var storedProcedureName = "Proc_Product_GetById";

                // Chuẩn bị tham số đầu vào 
                var parameters = new DynamicParameters();
                parameters.Add("p_ProductId", ProductId);

                // Khởi tạo kết nối tới DB
                string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Gọi vào DB
                var products = mySqlConnection.QueryFirstOrDefault<object>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Kết quả trả về
                return StatusCode(StatusCodes.Status201Created, products);
            }
            catch (Exception ex)
            {
                var error = new ErrorService();
                error.devMsg = ex.Message;
                error.userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp";

                return StatusCode(500, error);
            }            
        }

        /// <summary>
        /// API lấy tài sản phân trang 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProductPaging([FromQuery] int PageIndex, [FromQuery] int PageSize)
        {
            // Try catch exception

            // Chuẩn bị tên stored procedure
            var storedProcedureName = "Proc_Product_Paging";

            // Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("p_PageIndex", PageIndex);
            parameters.Add("p_PageSize", PageSize);

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Gọi vào DB
            var products = mySqlConnection.Query<object>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            // Kết quả trả về
            return StatusCode(StatusCodes.Status201Created, products);
        }

        /// <summary>
        /// API thêm mới một tài sản
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {

            // try catch
            try
            {
                // Khai báo thông tin cần thiết
                var error = new ErrorService();
                var errorData = new Dictionary<string, string>();
                var errorMsgs = new List<string>();

                // Validate đầu vào

                // 1. Mã tài sản bắt buộc nhập
                if (string.IsNullOrEmpty(product.ProductCode))
                {
                    errorData.Add("ProductCode", Resources.ResourceVN.ValidateError_ProductCodeNotEmpty);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_ProductCodeNotEmpty);
                }
                // 1.2. Mã tài sản không được phép trùng
                if (CheckProductCode(product.ProductCode))
                {
                    errorData.Add("ProductCode", Resources.ResourceVN.ValidateError_DuplicateProductCode);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_DuplicateProductCode);
                }
                // 2. Tên tài sản bắt buộc nhập
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    errorData.Add("ProductName", Resources.ResourceVN.ValidateError_ProductNameNotEmpty);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_ProductNameNotEmpty);
                }
                // 3. Mã loại tài sản không được phép để trống
                if (string.IsNullOrEmpty(product.ProductTypeId))
                {
                    errorData.Add("ProductTypeId", Resources.ResourceVN.ValidateError_ProductTypeIdNotEmpty);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_ProductTypeIdNotEmpty);
                }
                // 4. Mã phòng ban không được phép để trống
                if (string.IsNullOrEmpty(product.DepartmentId))
                {
                    errorData.Add("DepartmentId", Resources.ResourceVN.ValidateError_ProductDepartmentIdNotEmpty);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_ProductDepartmentIdNotEmpty);
                }
                // 5. Số lượng không được phép bằng 0
                if (product.Quantity == 0)
                {
                    errorData.Add("Quantity", Resources.ResourceVN.ValidateError_QuantityNotEqualZero);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_QuantityNotEqualZero);
                }
                // 6. Nguyên giá không được phép bằng 0
                if (product.Price.Equals(0))
                {
                    errorData.Add("Price", Resources.ResourceVN.ValidateError_PriceNotEqualZero);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_PriceNotEqualZero);
                }
                // 7. Hao mòn lũy kế không được phép bằng 0
                if (product.AccumulatedDepreciation.Equals(0))
                {
                    errorData.Add("AccumulatedDepreciation", Resources.ResourceVN.ValidateError_AccumulatedDepreciationNotEqualZero);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_AccumulatedDepreciationNotEqualZero);
                }
                // 8. Giá trị còn lại không được phép bằng 0
                if (product.ResidualValue.Equals(0))
                {
                    errorData.Add("ResidualValue", Resources.ResourceVN.ValidateError_ResidualValueNotEqualZero);
                    errorMsgs.Add(Resources.ResourceVN.ValidateError_ResidualValueNotEqualZero);
                }

                // Check lỗi Validate 
                if (errorData.Count > 0)
                {
                    error.userMsg = "Dữ liệu đầu vào không hợp lệ";
                    error.Data = errorData;
                    return BadRequest(error);
                }


                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Product_Insert";

                // Chuẩn bị tham số đầu vào cho stored
                var parameters = new DynamicParameters();
                parameters.Add("p_ProductId", Guid.NewGuid());
                parameters.Add("p_ProductCode", product.ProductCode);
                parameters.Add("p_ProductName", product.ProductName);
                parameters.Add("p_ProductTypeId", product.ProductTypeId);
                parameters.Add("p_DepartmentId", product.DepartmentId);
                parameters.Add("p_Quantity", product.Quantity);
                parameters.Add("p_Price", product.Price);
                parameters.Add("p_AccumulatedDepreciation", product.AccumulatedDepreciation);
                parameters.Add("p_ResidualValue", product.ResidualValue);

                // Khởi tạo kết nối tới DB
                string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
                var mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();

                // Gọi vào DB
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                // Đóng kết nối
                mySqlConnection.Close();

                // Xử lý kết quả trả về
                if (numberOfAffectedRows > 0)
                {
                    // TH thành công
                    return StatusCode(StatusCodes.Status201Created, numberOfAffectedRows);
                }
                else
                {
                    // TH thất bại
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Hàm bắn ra Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private IActionResult HandleException(Exception ex)
        {
            var error = new ErrorService();
            error.devMsg = ex.Message;
            error.userMsg = Resources.ResourceVN.Error_Exception;
            error.Data = ex.Data;
            return StatusCode(500, error);
        }
        /// <summary>
        /// Kiểm tra mã tài sản có trùng hay không
        /// </summary>
        /// <param name="ProductCode">Mã tài sản</param>
        /// <returns>true = đã bị trùng; false = không bị trùng</returns>
        /// CreatedBy: NDCHIEN (21/02/2023)
        private bool CheckProductCode(string ProductCode)
        {
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);
            var sqlCheck = "SELECT * FROM product WHERE ProductCode = @ProductCode";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductCode", ProductCode);
            var res = mySqlConnection.QueryFirstOrDefault<object>(sqlCheck, parameters);
            if(res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sửa 1 tài sản
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{ProductId}")]
        public IActionResult UpdateProduct([FromRoute] Guid ProductId, [FromBody] Product product)
        {
            // Validate đầu vào

            // Chuẩn bị tên stored procedure
            string storedProcedureName = "Proc_Product_Insert";

            // Chuẩn bị câu lệnh query
            var sqlCommand = "UPDATE product " +                
                "SET " + 
                    "ProductId = @ProductId," + 
                    "ProductCode = @ProductCode," + 
                    "ProductName = @ProductName," + 
                    "ProductTypeId = @ProductTypeId," + 
                    "DepartmentId = @DepartmentId," + 
                    "Quantity = @Quantity," + 
                    "Price = @Price," + 
                    "AccumulatedDepreciation = @AccumulatedDepreciation," + 
                    "ResidualValue = @ResidualValue " + 
                 "WHERE " + 
                    "ProductId = @ProductId";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", ProductId);
            parameters.Add("@ProductCode", product.ProductCode);
            parameters.Add("@ProductName", product.ProductName);
            parameters.Add("@ProductTypeName", product.ProductTypeId);
            parameters.Add("@DepartmentName", product.DepartmentId);
            parameters.Add("@Quantity", product.Quantity);
            parameters.Add("@Price", product.Price);
            parameters.Add("@AccumulatedDepreciation", product.AccumulatedDepreciation);
            parameters.Add("@ResidualValue", product.ResidualValue);

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            // Gọi vào DB
            int numberOfAffectedRows = mySqlConnection.Execute(sqlCommand, parameters);

            // Đóng kết nối
            mySqlConnection.Close();

            // Xử lý kết quả trả về
            if (numberOfAffectedRows > 0)
            {
                // TH thành công
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                // TH thất bại
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Xóa 1 tài sản theo Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(Guid ProductId)
        {
            // Chuẩn bị tên stored procedure


            // Câu lệnh truy vấn
            var sqlCommand = "DELETE FROM product p WHERE p.ProductId = @ProductId;";

            // Chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", ProductId);

            // Khởi tạo kết nối tới DB
            string connectionString = "Server=localhost;Port=3306;Database=misa.product.ndchien;Uid=root;Pwd=123456;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Gọi vào DB
            var products = mySqlConnection.Query<Product>(sqlCommand, parameters);

            // Kết quả trả về
            return StatusCode(StatusCodes.Status201Created, products);
        }
    }
}
