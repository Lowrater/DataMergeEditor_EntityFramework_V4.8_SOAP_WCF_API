using DataMergeEditor_WCF_SOAP_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace DataMergeEditor_WCF_SOAP_API.Services.Asmx
{
    /// <summary>
    /// Summary description for UsersTestAsmx
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UsersTestAsmx : System.Web.Services.WebService
    {

     
        /// <summary>
        /// Database as entity reference
        /// </summary>
        private MasterEntities db = new MasterEntities();

        /// <summary>
        /// Get's all users listed
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public  async Task<List<Database.User>> GetUsers()
        {
            // Get's users
            var dataResult = db.Users;

            // checks if any users exists
            if (dataResult.Any())
            {
                return await Task.FromResult(dataResult.ToList<Database.User>());
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
        [WebMethod]
        public Database.User GetUser(int id)
        {
            // get's users
            var dataResult = db.Users;

            // checks if any users exists
            if (dataResult.Any())
            {
                return  dataResult.FirstOrDefault(user => user.UserID == id);
            }
            else
            {
                return null;
            }
        }
    }
}
