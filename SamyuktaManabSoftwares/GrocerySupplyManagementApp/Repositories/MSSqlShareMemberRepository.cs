using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlShareMemberRepository : IShareMemberRepository
    {
        private static readonly log4net.ILog logger = LogHelper.GetLogger();
        private readonly string connectionString;

        public MSSqlShareMemberRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public ShareMember GetShareMember(long id)
        {
            var query = @"SELECT " +
                "[Id], [Name], " +
                "[Address], [ContactNo], [ImagePath], " +
                "[AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_SHARE_MEMBER + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            var shareMember = new ShareMember();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id",id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                shareMember.Id = Convert.ToInt64(reader["Id"].ToString());
                                shareMember.Name = reader["Name"].ToString();
                                shareMember.Address = reader["Address"].ToString();
                                shareMember.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                shareMember.ImagePath = reader["ImagePath"].ToString();
                                shareMember.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                shareMember.UpdatedDate = reader.IsDBNull(6) ? (DateTime?)null : Convert.ToDateTime(reader["UpdatedDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return shareMember;
        }

        public ShareMember AddShareMember(ShareMember shareMember)
        {
            string query = @"INSERT INTO " + Constants.TABLE_SHARE_MEMBER + " " +
                    "( " +
                        "[EndOfDay], [Name], [Address], [ContactNo], [ImagePath], [AddedBy], [AddedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@EndOfDay, @Name, @Address, @ContactNo, @ImagePath, @AddedBy, @AddedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndOfDay", shareMember.EndOfDay);
                        command.Parameters.AddWithValue("@Name", shareMember.Name);
                        command.Parameters.AddWithValue("@Address", shareMember.Address);
                        command.Parameters.AddWithValue("@ContactNo", shareMember.ContactNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)shareMember.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedBy", shareMember.AddedBy);
                        command.Parameters.AddWithValue("@AddedDate", shareMember.AddedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return shareMember;
        }

        public ShareMember UpdateShareMember(long id, ShareMember shareMember)
        {
            string query = @"UPDATE " + Constants.TABLE_SHARE_MEMBER + " " +
                "SET " +
                "[Name] = @Name, " +
                "[Address] = @Address, " +
                "[ContactNo] = @ContactNo, " +
                "[ImagePath] = @ImagePath, " +
                "[UpdatedBy] = @UpdatedBy, " +
                "[UpdatedDate] = @UpdatedDate " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", shareMember.Name);
                        command.Parameters.AddWithValue("@Address", shareMember.Address);
                        command.Parameters.AddWithValue("@ContactNo", shareMember.ContactNo);
                        command.Parameters.AddWithValue("@ImagePath", ((object)shareMember.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedBy", shareMember.UpdatedBy);
                        command.Parameters.AddWithValue("@UpdatedDate", shareMember.UpdatedDate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return shareMember;
        }

        public bool DeleteShareMember(long id)
        {
            string query = @"DELETE FROM " + Constants.TABLE_SHARE_MEMBER + " " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id ";
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                UtilityService.ShowExceptionMessageBox();
            }

            return result;
        }
    }
}
