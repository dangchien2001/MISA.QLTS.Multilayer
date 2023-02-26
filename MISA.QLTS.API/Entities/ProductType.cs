namespace MISA.QLTS.API.Entities
{
    public class ProductType
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid ProductTypeId { get; set; }

        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string ProductName { get; set; }
    }
}
