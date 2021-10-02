using GrocerySupplyManagementApp.Entities;
using GrocerySupplyManagementApp.Repositories.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrocerySupplyManagementApp.Repositories
{
    public class MSSqlEmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;

        public MSSqlEmployeeRepository()
        {
            connectionString = UtilityService.GetConnectionString();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var query = @"SELECT " +
                "[Id], [Counter], [EmployeeId], [Name], [TempAddress], [PermAddress], " +
                "[ContactNo], [Email], [CitizenshipNo], [Education], [DateOfBirth], " + 
                "[Age], [BloodGroup], [FatherName], [MotherName], [Gender], [MaritalStatus], " +
                "[SpouseName], [Post], [PostStatus], [AppointedDate], [ResignedDate], " +
                "[ImagePath], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_EMPLOYEE;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Counter = Convert.ToInt64(reader["Counter"].ToString()),
                                    EmployeeId = reader["EmployeeId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    TempAddress = reader["TempAddress"].ToString(),
                                    PermAddress = reader["PermAddress"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    CitizenshipNo = reader["CitizenshipNo"].ToString(),
                                    Education = reader["Education"].ToString(),
                                    DateOfBirth = reader["DateOfBirth"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"].ToString()),
                                    BloodGroup = reader["BloodGroup"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    MotherName = reader["MotherName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    MaritalStatus = reader["MaritalStatus"].ToString(),
                                    SpouseName = reader["SpouseName"].ToString(),
                                    Post = reader["Post"].ToString(),
                                    PostStatus = reader["PostStatus"].ToString(),
                                    AppointedDate = reader["AppointedDate"].ToString(),
                                    ResignedDate = reader["ResignedDate"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employees;
        }

        public Employee GetEmployee(long id)
        {
            var employee = new Employee();
            var query = @"SELECT " +
                "[Id], [Counter], [EmployeeId], [Name], [TempAddress], [PermAddress], " +
                "[ContactNo], [Email], [CitizenshipNo], [Education], [DateOfBirth], " +
                "[Age], [BloodGroup], [FatherName], [MotherName], [Gender], [MaritalStatus], " +
                "[SpouseName], [Post], [PostStatus], [AppointedDate], [ResignedDate], " +
                "[ImagePath], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_EMPLOYEE + " " +
                "WHERE 1 = 1 " +
                "AND [Id] = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    employee.Id = Convert.ToInt64(reader["Id"].ToString());
                                    employee.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                    employee.EmployeeId = reader["EmployeeId"].ToString();
                                    employee.Name = reader["Name"].ToString();
                                    employee.TempAddress = reader["TempAddress"].ToString();
                                    employee.PermAddress = reader["PermAddress"].ToString();
                                    employee.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                    employee.Email = reader["Email"].ToString();
                                    employee.CitizenshipNo = reader["CitizenshipNo"].ToString();
                                    employee.Education = reader["Education"].ToString();
                                    employee.DateOfBirth = reader["DateOfBirth"].ToString();
                                    employee.Age = Convert.ToInt32(reader["Age"].ToString());
                                    employee.BloodGroup = reader["BloodGroup"].ToString();
                                    employee.FatherName = reader["FatherName"].ToString();
                                    employee.MotherName = reader["MotherName"].ToString();
                                    employee.Gender = reader["Gender"].ToString();
                                    employee.MaritalStatus = reader["MaritalStatus"].ToString();
                                    employee.SpouseName = reader["SpouseName"].ToString();
                                    employee.Post = reader["Post"].ToString();
                                    employee.PostStatus = reader["PostStatus"].ToString();
                                    employee.AppointedDate = reader["AppointedDate"].ToString();
                                    employee.ResignedDate = reader["ResignedDate"].ToString();
                                    employee.ImagePath = reader["ImagePath"].ToString();
                                    employee.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    employee.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public Employee GetEmployee(string employeeId)
        {
            var employee = new Employee();
            var query = @"SELECT " +
                "[Id], [Counter], [EmployeeId], [Name], [TempAddress], [PermAddress], " +
                "[ContactNo], [Email], [CitizenshipNo], [Education], [DateOfBirth], " +
                "[Age], [BloodGroup], [FatherName], [MotherName], [Gender], [MaritalStatus], " +
                "[SpouseName], [Post], [PostStatus], [AppointedDate], [ResignedDate], " +
                "[ImagePath], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_EMPLOYEE + " " +
                "WHERE 1 = 1 " +
                "AND [EmployeeId] = @EmployeeId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", ((object)employeeId) ?? DBNull.Value);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    employee.Id = Convert.ToInt64(reader["Id"].ToString());
                                    employee.Counter = Convert.ToInt64(reader["Counter"].ToString());
                                    employee.EmployeeId = reader["EmployeeId"].ToString();
                                    employee.Name = reader["Name"].ToString();
                                    employee.TempAddress = reader["TempAddress"].ToString();
                                    employee.PermAddress = reader["PermAddress"].ToString();
                                    employee.ContactNo = Convert.ToInt64(reader["ContactNo"].ToString());
                                    employee.Email = reader["Email"].ToString();
                                    employee.CitizenshipNo = reader["CitizenshipNo"].ToString();
                                    employee.Education = reader["Education"].ToString();
                                    employee.DateOfBirth = reader["DateOfBirth"].ToString();
                                    employee.Age = Convert.ToInt32(reader["Age"].ToString());
                                    employee.BloodGroup = reader["BloodGroup"].ToString();
                                    employee.FatherName = reader["FatherName"].ToString();
                                    employee.MotherName = reader["MotherName"].ToString();
                                    employee.Gender = reader["Gender"].ToString();
                                    employee.MaritalStatus = reader["MaritalStatus"].ToString();
                                    employee.SpouseName = reader["SpouseName"].ToString();
                                    employee.Post = reader["Post"].ToString();
                                    employee.PostStatus = reader["PostStatus"].ToString();
                                    employee.AppointedDate = reader["AppointedDate"].ToString();
                                    employee.ResignedDate = reader["ResignedDate"].ToString();
                                    employee.ImagePath = reader["ImagePath"].ToString();
                                    employee.AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString());
                                    employee.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public long GetLastEmployeeId()
        {
            long id = 0;
            string query = @"SELECT " +
                "TOP 1 [Counter] " +
                "FROM " + Constants.TABLE_EMPLOYEE + " " +
                "ORDER BY [Counter] DESC ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null && DBNull.Value != result)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }

        public IEnumerable<Employee> GetDeliveryPersons()
        {
            var employees = new List<Employee>();
            var query = @"SELECT " +
                "[Id], [Counter], [EmployeeId], [Name], [TempAddress], [PermAddress], " +
                "[ContactNo], [Email], [CitizenshipNo], [Education], [DateOfBirth], " +
                "[Age], [BloodGroup], [FatherName], [MotherName], [Gender], [MaritalStatus], " +
                "[SpouseName], [Post], [PostStatus], [AppointedDate], [ResignedDate], " +
                "[ImagePath], [AddedDate], [UpdatedDate] " +
                "FROM " + Constants.TABLE_EMPLOYEE + " " +
                "WHERE 1=1 " +
                "AND [Post] = '" + Constants.DELIVERY_PERSON + "'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee
                                {
                                    Id = Convert.ToInt64(reader["Id"].ToString()),
                                    Counter = Convert.ToInt64(reader["Counter"].ToString()),
                                    EmployeeId = reader["EmployeeId"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    TempAddress = reader["TempAddress"].ToString(),
                                    PermAddress = reader["PermAddress"].ToString(),
                                    ContactNo = Convert.ToInt64(reader["ContactNo"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    CitizenshipNo = reader["CitizenshipNo"].ToString(),
                                    Education = reader["Education"].ToString(),
                                    DateOfBirth = reader["DateOfBirth"].ToString(),
                                    Age = Convert.ToInt32(reader["Age"].ToString()),
                                    BloodGroup = reader["BloodGroup"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    MotherName = reader["MotherName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    MaritalStatus = reader["MaritalStatus"].ToString(),
                                    SpouseName = reader["SpouseName"].ToString(),
                                    Post = reader["Post"].ToString(),
                                    PostStatus = reader["PostStatus"].ToString(),
                                    AppointedDate = reader["AppointedDate"].ToString(),
                                    ResignedDate = reader["ResignedDate"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString(),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"].ToString()),
                                    UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString())
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employees;
        }

        public Employee AddEmployee(Employee employee)
        {
            string query = @"INSERT INTO " +
                    " " + Constants.TABLE_EMPLOYEE + " " +
                    "( " +
                        "[Counter], [EmployeeId], [Name], [TempAddress], [PermAddress], " +
                        "[ContactNo], [Email], [CitizenshipNo], [Education], [DateOfBirth], " +
                        "[Age], [BloodGroup], [FatherName], [MotherName], [Gender], [MaritalStatus], " +
                        "[SpouseName], [Post], [PostStatus], [AppointedDate], [ResignedDate], " +
                        "[ImagePath], [AddedDate], [UpdatedDate] " +
                    ") " +
                    "VALUES " +
                    "( " +
                        "@Counter, @EmployeeId, @Name, @TempAddress, @PermAddress, " +
                        "@ContactNo, @Email, @CitizenshipNo, @Education, @DateOfBirth, " +
                        "@Age, @BloodGroup, @FatherName, @MotherName, @Gender, @MaritalStatus, " +
                        "@SpouseName, @Post, @PostStatus, @AppointedDate, @ResignedDate, " +
                        "@ImagePath, @AddedDate, @UpdatedDate " +
                    ") ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Counter", ((object)employee.Counter) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EmployeeId", ((object)employee.EmployeeId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)employee.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TempAddress", ((object)employee.TempAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PermAddress", ((object)employee.PermAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ContactNo", ((object)employee.ContactNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", ((object)employee.Email) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CitizenshipNo", ((object)employee.CitizenshipNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Education", ((object)employee.Education) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateOfBirth", ((object)employee.DateOfBirth) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Age", ((object)employee.Age) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodGroup", ((object)employee.BloodGroup) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FatherName", ((object)employee.FatherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MotherName", ((object)employee.MotherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", ((object)employee.Gender) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaritalStatus", ((object)employee.MaritalStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpouseName", ((object)employee.SpouseName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Post", ((object)employee.Post) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PostStatus", ((object)employee.PostStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointedDate", ((object)employee.AppointedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ResignedDate", ((object)employee.ResignedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", ((object)employee.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AddedDate", ((object)employee.AddedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)employee.UpdatedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public Employee UpdateEmployee(long id, Employee employee)
        {
            string query = @"UPDATE " + Constants.TABLE_EMPLOYEE + " " +
                    "SET " +
                    "[EmployeeId] = @EmployeeId, " +
                    "[Name] = @Name, " +
                    "[TempAddress] =  @TempAddress, " +
                    "[PermAddress] =  @PermAddress, " +
                    "[ContactNo] =  @ContactNo, " +
                    "[Email] =  @Email, " +
                    "[CitizenshipNo] =  @CitizenshipNo, " +
                    "[Education] =  @Education, " +
                    "[DateOfBirth] =  @DateOfBirth, " +
                    "[Age] =  @Age, " +
                    "[BloodGroup] =  @BloodGroup, " +
                    "[FatherName] =  @FatherName, " +
                    "[MotherName] =  @MotherName, " +
                    "[Gender] =  @Gender, " +
                    "[MaritalStatus] =  @MaritalStatus, " +
                    "[SpouseName] =  @SpouseName, " +
                    "[Post] =  @Post, " +
                    "[PostStatus] =  @PostStatus, " +
                    "[AppointedDate] =  @AppointedDate, " +
                    "[ResignedDate] =  @ResignedDate, " +
                    "[ImagePath] =  @ImagePath, " +
                    "[UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EmployeeId", ((object)employee.EmployeeId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)employee.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TempAddress", ((object)employee.TempAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PermAddress", ((object)employee.PermAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ContactNo", ((object)employee.ContactNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", ((object)employee.Email) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CitizenshipNo", ((object)employee.CitizenshipNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Education", ((object)employee.Education) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateOfBirth", ((object)employee.DateOfBirth) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Age", ((object)employee.Age) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodGroup", ((object)employee.BloodGroup) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FatherName", ((object)employee.FatherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MotherName", ((object)employee.MotherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", ((object)employee.Gender) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaritalStatus", ((object)employee.MaritalStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpouseName", ((object)employee.SpouseName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Post", ((object)employee.Post) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PostStatus", ((object)employee.PostStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointedDate", ((object)employee.AppointedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ResignedDate", ((object)employee.ResignedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", ((object)employee.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)employee.UpdatedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public Employee UpdateEmployee(string employeeId, Employee employee)
        {
            string query = @"UPDATE " + Constants.TABLE_EMPLOYEE + " " +
                    "SET " +
                    "[EmployeeId] = @EmployeeId, " +
                    "[Name] = @Name, " +
                    "[TempAddress] =  @TempAddress, " +
                    "[PermAddress] =  @PermAddress, " +
                    "[ContactNo] =  @ContactNo, " +
                    "[Email] =  @Email, " +
                    "[CitizenshipNo] =  @CitizenshipNo, " +
                    "[Education] =  @Education, " +
                    "[DateOfBirth] =  @DateOfBirth, " +
                    "[Age] =  @Age, " +
                    "[BloodGroup] =  @BloodGroup, " +
                    "[FatherName] =  @FatherName, " +
                    "[MotherName] =  @MotherName, " +
                    "[Gender] =  @Gender, " +
                    "[MaritalStatus] =  @MaritalStatus, " +
                    "[SpouseName] =  @SpouseName, " +
                    "[Post] =  @Post, " +
                    "[PostStatus] =  @PostStatus, " +
                    "[AppointedDate] =  @AppointedDate, " +
                    "[ResignedDate] =  @ResignedDate, " +
                    "[ImagePath] =  @ImagePath, " +
                    "[UpdatedDate] = @UpdatedDate " +
                    "WHERE 1 = 1 " +
                    "AND [EmployeeId] = @EmployeeId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", ((object)employeeId) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Name", ((object)employee.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TempAddress", ((object)employee.TempAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PermAddress", ((object)employee.PermAddress) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ContactNo", ((object)employee.ContactNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", ((object)employee.Email) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CitizenshipNo", ((object)employee.CitizenshipNo) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Education", ((object)employee.Education) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateOfBirth", ((object)employee.DateOfBirth) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Age", ((object)employee.Age) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodGroup", ((object)employee.BloodGroup) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FatherName", ((object)employee.FatherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MotherName", ((object)employee.MotherName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", ((object)employee.Gender) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaritalStatus", ((object)employee.MaritalStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpouseName", ((object)employee.SpouseName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Post", ((object)employee.Post) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PostStatus", ((object)employee.PostStatus) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointedDate", ((object)employee.AppointedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ResignedDate", ((object)employee.ResignedDate) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", ((object)employee.ImagePath) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedDate", ((object)employee.UpdatedDate) ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public bool DeleteEmployee(long id)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_EMPLOYEE + " " +
                    "WHERE 1 = 1 " +
                    "[Id] = @Id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ((object)id) ?? DBNull.Value);
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

        public bool DeleteEmployee(string employeeId)
        {
            bool result = false;
            string query = @"DELETE " +
                    "FROM " + Constants.TABLE_EMPLOYEE + " " +
                    "WHERE 1 = 1 " +
                    "[EmployeeId] = @EmployeeId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", ((object)employeeId) ?? DBNull.Value);
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
