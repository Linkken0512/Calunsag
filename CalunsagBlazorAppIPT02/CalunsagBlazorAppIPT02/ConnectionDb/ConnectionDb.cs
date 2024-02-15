#nullable disable
using CalunsagBlazorAppIPT02.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
namespace CalunsagBlazorAppIPT02.ConnectionDb
{
    public class ConnectionDb
    {
        private readonly SqlConnection sqlcon;
        private readonly IConfiguration con;
        public ConnectionDb(IConfiguration _con) 
        {
            con = _con;
            sqlcon = new SqlConnection(con.GetConnectionString("MARC"));
        }
        public IEnumerable<Player> playerlist()
        {
                var sqlstring = "[dbo].[PlayerOptions]";
                return sqlcon.Query<Player>(sqlstring);
        }
        public void Create(Player player)
        {
            var sqlstring = "[dbo].[NewPlayerDetails]";
            var parameter = new DynamicParameters();
            parameter.Add("@PlayerName", player.PlayerName, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerRank", player.PlayerRank, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerClass", player.PlayerClass, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
        public void PlayerDetailsUpdate(Player player)
        {
            var sqlstring = "[dbo].[UpdatePlayerDetails]";
            var parameter = new DynamicParameters();
            parameter.Add("@PlayerId", player.PlayerId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PlayerName", player.PlayerName, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerRank", player.PlayerRank, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerClass", player.PlayerClass, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);

        }
        public IEnumerable<Player> PickedPlayer(int PlayerId)
        {
            var sqlstring = "[dbo].[DisplayPlayerDetails]";
            var parameter = new { PlayerId = PlayerId };
            return sqlcon.Query<Player>(sqlstring, parameter);
        }
        public void PlayerDetailsDelete(int PlayerId)
        {
            var sqlstring = "[dbo].[DeletePlayerDetails]";
            var parameter = new { PlayerId = PlayerId };
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
