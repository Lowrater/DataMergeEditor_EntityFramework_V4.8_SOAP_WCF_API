using DataMergeEditor_WCF_SOAP_API.Database;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DataMergeEditor_WCF_SOAP_API.Services.Svc.GamesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGamesService" in both code and config file together.
    [ServiceContract]
    public interface IGamesService
    {

        [OperationContract]
        Task<IEnumerable<Database.Game>> GetGames();

        [OperationContract]
        Task<Database.Game> GetGame(int id);

        [OperationContract]
        Task<bool> AddGame(Database.Game game);

        [OperationContract]
        Task<bool> DeleteGame(int id, string name);
    }
}
