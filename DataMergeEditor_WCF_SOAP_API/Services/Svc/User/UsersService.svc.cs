using DataMergeEditor_WCF_SOAP_API.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMergeEditor_WCF_SOAP_API.Services.Svc.User
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsersService.svc or UsersService.svc.cs at the Solution Explorer and start debugging.
    public class UsersService : IUsersService
    {
        /// <summary>
        /// Database as entity reference
        /// </summary>
        private MasterEntities db = new MasterEntities();

        /// <summary>
        /// Get's all users listed
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Database.User>> GetUsers()
        {
            // Get's users
            var dataResult = db.Users;

            // checks if any users exists
            if (dataResult.Any())
            {
                return await Task.FromResult(dataResult.AsEnumerable());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get's an user based on id
        /// </summary>
        /// <param name="id"></param>
        public async Task<Database.User> GetUser(int id)
        {
            // get's users
            var dataResult = db.Users;

            // checks if any users exists
            if (dataResult.Any())
            {
                return await Task.FromResult(dataResult.FirstOrDefault(user => user.UserID == id));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddUser(Database.User user)
        {
            // null check
            if (user == null)
                return false;

            // adds user and saves the changes
            await Task.FromResult(db.Users.Add(user));
            await Task.FromResult(db.SaveChanges());

            // returns OK.
            return true;
        }

        /// <summary>
        /// Deletes an user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(int id, string name)
        {
            // null check
            if (string.IsNullOrEmpty(name))
                return false;

            // Get's users
            var dataResult = db.Users;

            // checks if any data exists
            if (dataResult.Any())
            {
                // finds the user
                var foundUser = await Task.FromResult(dataResult.FirstOrDefault(user => user.UserID == id && user.UserName == name));

                // null check
                if(foundUser != null)
                {
                    db.Users.Remove(foundUser);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
