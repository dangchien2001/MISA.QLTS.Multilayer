using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.Common.Constrants;
using MISA.QLTS.Common.Entities;
using MISA.QLTS.Common.Entities.DTO;
using MISA.QLTS.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DL.DepartmentDL
{
    public class DepartmentDL : BaseDL<Department>, IDepartmentDL
    {
        /// <summary>
        /// Lấy danh sách tài sản theo mã phòng ban có phân trang
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public PagingResult GetAssetsByFilter(string? assetFilter, int pageSize, int pageNumber)
        {
            string storedProcedureName = string.Format(ProcedureName.Filter, typeof(Asset).Name);

            var parameters = new DynamicParameters();
            parameters.Add("p_PageSize", pageSize);
            parameters.Add("p_PageNumber", pageNumber);
            parameters.Add("p_AssetFilter", assetFilter);

            var mySqlConnection = new MySqlConnection(Datacontext.DataBaseContext.connectionString);
            mySqlConnection.Open();

            var getAssetFilter = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            //int totalRecords = getAssetFilter.Read<int>().Single();
            var AssetFilters = getAssetFilter.Read<Asset>().ToList();
            //double totalPage = Convert.ToDouble(totalRecords) / pageSize;
            return new PagingResult
            {
                CurrentPage = pageNumber,
                CurrentPageRecords = pageSize,
                //TotalPage = Convert.ToInt32(Math.Ceiling(totalPage)),
                //TotalRecord = totalRecords,
                Data = AssetFilters
            };
        }
    }
}
