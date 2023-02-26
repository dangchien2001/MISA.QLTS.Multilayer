using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.Common.Constrants;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.DL.BaseDL;
using MISA.QLTS.DL.Datacontext;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DL.AssetDL
{
    public class AssetDL : BaseDL<asset>, IAssetDL
    {
        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="assetIds"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteAssetMore(List<Guid> assetIds)
        {
            // Khởi tạo câu lệnh sql
            var sql = "DELETE FROM asset WHERE asset_id IN ('{0}')";
            var result = 0;
            using (var mySqlConnection = new MySqlConnection(DataBaseContext.connectionString))
            {
                mySqlConnection.Open();

                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        result = mySqlConnection.Execute(string.Format(sql, string.Join("','", assetIds)), transaction: transaction);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                mySqlConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Kiểm tra trùng mã tài sản
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<asset> DuplicateCode(asset asset)
        {
            var storedProcedureName = "Proc_Asset_Duplicate_Code";
            var parameters = new DynamicParameters();
            parameters.Add("p_AssetCode", asset.asset_code);
            parameters.Add("p_AssetId", asset.asset_id);
            dynamic result;
            using (var mySqlConnection = new MySqlConnection(Datacontext.DataBaseContext.connectionString))
            {
                var multy = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                result = multy.Read<asset>().ToList();
            }
            return result;
        }

        /// <summary>
        /// API lấy danh sách nhân viên lọc theo trang
        /// </summary>
        /// <param name="assetFilter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public PagingResult GetAssetsByFilter(
            [FromQuery] string? assetFilter, 
            [FromQuery] int pageSize = 10, 
            [FromQuery] int pageNumber = 1)
        {
            // Khởi tạo kết quả trả về
            var result = new PagingResult();

            // Chuẩn bị tên stored proc
            string storedProcedureName = string.Format(ProcedureName.Filter, typeof(asset).Name);

            // Chuẩn bị tham số đầu vào cho proc
            var parameters = new DynamicParameters();
            parameters.Add("p_PageNumber", pageNumber);
            parameters.Add("p_PageSize", pageSize);
            parameters.Add("p_AssetFilter", assetFilter);

            // Khởi tạo kết nối db
            using (var mySqlConnection = new MySqlConnection(Datacontext.DataBaseContext.connectionString))
            {
                // Gọi proc
                var multy = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // lấy kết quả gán cho result
                result.TotalRecord = multy.Read<int>().Single();
                result.Data = multy.Read<asset>().ToList();
                result.CurrentPageRecords = result.Data.Count;
                result.CurrentPage = pageNumber;
            }
            return result;
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        public int GetMaxAssetCode()
        {
            var procedureName = "Proc_Asset_MaxCode";
            var mySqlConnection = new MySqlConnection(Datacontext.DataBaseContext.connectionString);
            var multy = mySqlConnection.QueryMultiple(procedureName, commandType: System.Data.CommandType.StoredProcedure);
            int numCode = multy.Read<int>().Single();
            return numCode;
        }
    }
}
