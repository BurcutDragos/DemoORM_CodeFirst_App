using UsersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibrarieModele;
using System.Data.Entity;
using Repository_CodeFirst;
using AutoMapper;
using static Repository_CodeFirst.PDFtoWordConverterDatabaseVersion2Context;

namespace UsersApp.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        // Assuming PDFtoWordConverterDatabaseVersion2Context is your DbContext class
        private PDFtoWordConverterDatabaseVersion2Context db = new PDFtoWordConverterDatabaseVersion2Context();
        private MyDataAccessLayer dataAccessLayer = new MyDataAccessLayer();

        // GET: api/Users
        public IEnumerable<Models.User> GetAllUsers()
        {
            return dataAccessLayer.GetAllUsers().Select(user => MapToViewModel(user));
        }

        // GET: api/Users/5
        public IHttpActionResult GetUser(int id)
        {
            var user = dataAccessLayer.GetAllUsers().FirstOrDefault(u => u.USER_ID == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(MapToViewModel(user));
        }

        [HttpPost]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map API model to ENTITY model
            var entityUser = MapToEntityModel(user);

            // Create user in the database
            dataAccessLayer.PostUser(entityUser);

            // Return HTTP 201 Created with the created user
            return CreatedAtRoute("DefaultApi", new { id = entityUser.USER_ID }, user);
        }

        [HttpPut]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.USER_ID)
            {
                return BadRequest("Mismatched user IDs");
            }

            // Check if the user exists
            var existingUser = dataAccessLayer.GetAllUsers().FirstOrDefault(u => u.USER_ID == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Map API model to ENTITY model
            var entityUser = MapToEntityModel(user);

            // Update user in the database
            dataAccessLayer.PutUser(entityUser);

            // Return HTTP 204 No Content
            return StatusCode(HttpStatusCode.NoContent);
        }

        private User MapToViewModel(USER user)
        {
            // Implement your mapping logic (e.g., using AutoMapper)
            // This is where you transform your ENTITY model to your API model
            return new User
            {
                USER_ID = user.USER_ID,
                USERNAME = user.USERNAME,
                PASSWORD = user.PASSWORD,
                EMAIL = user.EMAIL,
                PHONE = user.PHONE,
                REGISTRATION_DATE = user.REGISTRATION_DATE,
                LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
            };
        }

        // Existing code...
        private USER MapToEntityModel(User user)
        {
            // Implement your mapping logic (e.g., using AutoMapper)
            // This is where you transform your API model to your ENTITY model
            return new USER
            {
                USER_ID = user.USER_ID,
                USERNAME = user.USERNAME,
                PASSWORD = user.PASSWORD,
                EMAIL = user.EMAIL,
                PHONE = user.PHONE,
                REGISTRATION_DATE = user.REGISTRATION_DATE,
                LAST_LOGIN_DATE = user.LAST_LOGIN_DATE
            };
        }
    }
}
