using Dapper;
using MISA.QLTS.Common.Constrants;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>
        /// 1: Nếu xóa thành công
        /// 0: Nếu xóa thất bại
        /// </returns>
        public int DeleteRecord(Guid recordId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy danh sách record
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllRecord()
        {
            // Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.Get, typeof(T).Name, "All");

            // Khởi tạo kết nối tới Database
            List<T> listRecords;
            using (var mySqlConnection = new MySqlConnection(Datacontext.DataBaseContext.connectionString))
            {
                var result = mySqlConnection.QueryMultiple(storedProcedureName, commandType: CommandType.StoredProcedure);
                listRecords = result.Read<T>().ToList();
            }
            // Xử lý kết quả trả về
            // Thành công
            return listRecords;
        }

        /// <summary>
        /// Tìm bản ghi theo ID
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public List<T> GetRecordById(Guid recordId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record"></param>
        /// <returns>
        /// 1: Nếu insert thành công
        /// 0: Nếu insert thất bại
        /// </returns>
        public int InsertRecord(T record)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="record"></param>
        /// <returns>
        /// 1: Nếu update thành công
        /// 0: Nếu update thất bại
        /// </returns>
        public int UpdateRecord(Guid recordId, T record)
        {
            throw new NotImplementedException();
        }
    }
}
