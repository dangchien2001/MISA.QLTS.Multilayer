using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.Common.Constrants;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.DL.BaseDL;
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
        public int DeleteAssetMore(List<Guid> assetIds)
        {
            throw new NotImplementedException();
        }

        public List<asset> DuplicateCode(asset asset)
        {
            throw new NotImplementedException();
        }

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
