using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    class MSSqlCompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly string connectionString;

        public MSSqlCompanyInfoRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public CompanyInfo GetCompanyInfo()
        {
            var companyInfo = new CompanyInfo();
            var query = @"SELECT " +
                "[Name], [Type], [Address], [ContactNo], " +
                "[EmailId], [Website], [FacebookPage], [RegistrationNo], " +
                "[RegistrationDate], [PanVatNo], [LogoPath], [AddedDate] " +
                "FROM " + Constants.TABLE_COMPANY_INFO + " " +
                "WHERE 1 = 1 ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    companyInfo.Name = reader["Name"].ToString();
                                    companyInfo.Type = reader["Type"].ToString();
                                    companyInfo.Address =reader["Address"].ToString();
                                    companyInfo.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                    companyInfo.EmailId = reader["EmailId"].ToString();
                                    companyInfo.Website = reader["Website"].ToString();
                                    companyInfo.FacebookPage = reader["FacebookPage"].ToString();
                                    companyInfo.RegistrationNo = reader["RegistrationNo"].ToString();
                                    companyInfo.RegistrationDate = reader["RegistrationDate"].ToString();
                                    companyInfo.PanVatNo = reader["PanVatNo"].ToString();
                                    companyInfo.LogoPath = reader["LogoPath"].ToString();
                                    companyInfo.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyInfo;
        }

        public CompanyInfo AddCompanyInfo(CompanyInfo companyInfo)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_COMPANY_INFO + " " +
                    "( " +
                        "[Name], [Type], [Address], [ContactNo], " +
                        "[EmailId], [Website], [FacebookPage], [RegistrationNo], " +
                        "[RegistrationDate], [PanVatNo], [LogoPath], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Name, @Type, @Address, @ContactNo, " +
                        "@EmailId, @Website, @FacebookPage, @RegistrationNo, " +
                        "@RegistrationDate, @PanVatNo, @LogoPath, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", ((object)companyInfo.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Type", ((object)companyInfo.Type) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", ((object)companyInfo.Address) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ContactNo", ((object)companyInfo.ContactNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EmailId", ((object)companyInfo.EmailId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Website", ((object)companyInfo.Website) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FacebookPage", ((object)companyInfo.FacebookPage) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RegistrationNo", ((object)companyInfo.RegistrationNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RegistrationDate", ((object)companyInfo.RegistrationDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PanVatNo", ((object)companyInfo.PanVatNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LogoPath", ((object)companyInfo.LogoPath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)companyInfo.AddedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyInfo;
        }

        public bool DeleteCompanyInfo()
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_COMPANY_INFO + " " +
                    "WHERE 1 = 1 ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
