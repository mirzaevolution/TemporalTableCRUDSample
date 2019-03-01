using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MSC.Models;

namespace MSC.BussinessLogics
{
    public class ProjectRequestsBLL
    {
        public List<ProjectRequests> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    List<ProjectRequests> list = sqlConn
                        .Query<ProjectRequests>("SELECT ID, ProjectName, Description, ClientName, StartDate, ExpectedEndDate, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate, StartTime, EndTime FROM vx.ProjectRequests")
                        .ToList();
                    return list;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool Insert(ProjectRequests data)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    string query = "vx.ProjectRequests_Insert";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("ID", data.ID);
                    parameters.Add("ProjectName", data.ProjectName);
                    parameters.Add("Description", data.Description);
                    parameters.Add("ClientName", data.ClientName);
                    parameters.Add("StartDate", data.StartDate);
                    parameters.Add("ExpectedEndDate", data.ExpectedEndDate);
                    parameters.Add("CreatedBy", data.CreatedBy);
                    parameters.Add("CreatedDate", data.CreatedDate);
                    parameters.Add("ModifiedBy", data.ModifiedBy);
                    parameters.Add("ModifiedDate",data.ModifiedDate);
                    parameters.Add("Status", string.Empty,direction:System.Data.ParameterDirection.Output);
                    var result = sqlConn.Execute(query, parameters,commandType:System.Data.CommandType.StoredProcedure);
                    string status = parameters.Get<string>("Status");
                    if (status.Equals("Success",StringComparison.InvariantCultureIgnoreCase))
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Update(ProjectRequests data)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    string query = "UPDATE vx.ProjectRequests " +
                        "SET ProjectName=@ProjectName, " +
                        "Description=@Description," +
                        "ClientName=@ClientName," +
                        "StartDate=@StartDate," +
                        "ExpectedEndDate=@ExpectedEndDate," +
                        "CreatedBy=@CreatedBy," +
                        "CreatedDate=@CreatedDate," +
                        "ModifiedBy=@ModifiedBy," +
                        "ModifiedDate=@ModifiedDate " +
                        "WHERE ID=@ID;";
                    var result = sqlConn.Execute(query, new
                    {
                        ID = data.ID,
                        ProjectName = data.ProjectName,
                        Description = data.Description,
                        ClientName = data.ClientName,
                        StartDate = data.StartDate,
                        ExpectedEndDate = data.ExpectedEndDate,
                        CreatedBy = data.CreatedBy,
                        CreatedDate = data.CreatedDate,
                        ModifiedBy = data.ModifiedBy,
                        ModifiedDate = data.ModifiedDate
                    });
                    if (result > 0)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    string query = "vx.ProjectRequest_Delete";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("ID", id);
                    parameters.Add("status", string.Empty, direction: System.Data.ParameterDirection.Output);
                    var result = sqlConn.Execute(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    string status = parameters.Get<string>("status");
                    if (status.Equals("success", StringComparison.InvariantCultureIgnoreCase))
                        return true;
                    else
                    {
                        //Display error messages
                        Console.WriteLine(status);
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public List<ProjectRequests> GetHistories(Guid id,bool showAll=true)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GlobalBLL.GetConnectionString()))
                {
                    List<ProjectRequests> list = sqlConn
                        .Query<ProjectRequests>("vx.QueryHistoryByID",
                        new
                        {
                            TableName = "ProjectRequests",
                            ID = id,
                            ShowAll = showAll
                        }, commandType:System.Data.CommandType.StoredProcedure)
                        .ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
