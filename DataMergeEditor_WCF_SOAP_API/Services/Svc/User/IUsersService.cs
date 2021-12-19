
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataMergeEditor_WCF_SOAP_API.Services.Svc.User
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsersService" in both code and config file together.
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        Task<IEnumerable<Database.User>> GetUsers();

        [OperationContract]
        Task<Database.User> GetUser(int id);

        [OperationContract]
        Task<bool> AddUser(Database.User user);

        [OperationContract]
        Task<bool> DeleteUser(int id, string name);


    }
}

