using DataMergeEditor_WCF_SOAP_API.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMergeEditor_WCF_SOAP_API.Services.Svc.GamesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GamesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GamesService.svc or GamesService.svc.cs at the Solution Explorer and start debugging.
    public class GamesService : IGamesService
    {

        /// <summary>
        /// 
        /// </summary>
        private MasterEntities db = new MasterEntities();

        /// <summary>
        /// Get's all users listed
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Database.Game>> GetGames()
        {
            // Get's users
            var dataResult = db.Games;

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
        public async Task<Database.Game> GetGame(int id)
        {
            // get's users
            var dataResult = db.Games;

            // checks if any users exists
            if (dataResult.Any())
            {
                return await Task.FromResult(dataResult.FirstOrDefault(game => game.GameID == id));
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
        public async Task<bool> AddGame(Database.Game game)
        {
            // null check
            if (game == null)
                return false;

            // adds user and saves the changes
            await Task.FromResult(db.Games.Add(game));
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
        public async Task<bool> DeleteGame(int id, string name)
        {
            // null check
            if (string.IsNullOrEmpty(name))
                return false;

            // Get's users
            var dataResult = db.Games;

            // checks if any data exists
            if (dataResult.Any())
            {
                // finds the user
                var foundGame = await Task.FromResult(dataResult.FirstOrDefault(game => game.GameID == id && game.GameName == name));

                // null check
                if (foundGame != null)
                {
                    db.Games.Remove(foundGame);
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
