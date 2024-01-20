using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LibrarieModele;
using Repository_CodeFirst;

namespace NivelAccessDate
{
    public class UserAccessor
    {
        private string connectionString = "Server=LAPTOP-S2SFAMFC;Database=PDFtoWordConverterDatabaseVersion2;Integrated Security=True;";  // Connection string for your database.
        //private string connectionString = "Server=DESKTOP-752MQUO;Database=PDFtoWordConverterDatabaseVersion2;User ID=sa;Password=admin;";  // Connection string for your database.
        public UserAccessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<USER> GetUsers()
        {
            List<USER> userWithUploadedFiles = new List<USER>();

            using (var context = new PDFtoWordConverterDatabaseVersion2Context())
            {
                userWithUploadedFiles = context.USERS
                    .Include(u => u.UPLOADED_FILE).ToList();
            }
            return userWithUploadedFiles;
        }

        public void InsertUser(string username, string password, string email)
        {
            using (var dbContext = new PDFtoWordConverterDatabaseVersion2Context())
            {
                var newUser = new USER
                {
                    USERNAME = username,
                    PASSWORD = password,
                    EMAIL = email,
                    REGISTRATION_DATE = DateTime.Now,
                    LAST_LOGIN_DATE = DateTime.Now
                };

                dbContext.USERS.Add(newUser);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUser(int userId, string username, string password, string email)
        {
            using (var dbContext = new PDFtoWordConverterDatabaseVersion2Context())
            {
                var userToUpdate = dbContext.USERS.FirstOrDefault(u => u.USER_ID == userId);

                if (userToUpdate != null)
                {
                    userToUpdate.USERNAME = username;
                    userToUpdate.PASSWORD = password;
                    userToUpdate.EMAIL = email;

                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var dbContext = new PDFtoWordConverterDatabaseVersion2Context())
            {
                var userToDelete = dbContext.USERS.FirstOrDefault(u => u.USER_ID == userId);

                if (userToDelete != null)
                {
                    dbContext.USERS.Remove(userToDelete);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}