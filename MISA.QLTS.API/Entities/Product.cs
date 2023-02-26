namespace MISA.QLTS.API.Entities
{

    /// <summary>
    /// Thông tin tài sản
    /// </summary>
    public class Product
    {

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Mã tài sản
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Khóa kiểu tài sản
        /// </summary>
        public string ProductTypeId { get; set; }

        /// <summary>
        /// Khóa phòng ban
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Hao mòn lũy kế
        /// </summary>
        public decimal AccumulatedDepreciation { get; set; }

        /// <summary>
        /// Giá trị còn lại
        /// </summary>
        public decimal ResidualValue { get; set; }
    }
}
