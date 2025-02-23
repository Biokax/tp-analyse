using System.Linq;
using Xunit;

namespace Behourd.Test
{
    public class SessionTests
    {
        [Fact(DisplayName = "session deux joueurs, " +
                            "quand une partie d�marre, " +
                            "alors elle compte deux �quipes d'un joueur, chacun diff�rent")]
        public void Two_Players_Make_A_Duel()
        {
            var session = new Session();
            session.AddPlayers(new Player(), new Player());

            var game = session.StartGame();
            var teams = game.Teams;

            Assert.True(teams.Length == 2);
            Assert.True(teams.All(team => team.PlayerTeamCount == 1));
            Assert.NotEqual(teams.First().Players.Single(), teams.Last().Players.Single());
        }

        [Fact(DisplayName = "session trois joueurs, " +
                            "quand une partie d�marre, " +
                            "alors elle compte deux �quipes �quilibr�es en poids")]
        public void Three_Players_Make_Two_Wight_Equivalent_Teams()
        {
            var session = new Session();
            session.AddPlayers(new Player(), new Player(), new Player());

            var game = session.StartGame();
            var teams = game.Teams;

            Assert.True(teams.Length == 2);
            Assert.True(teams.All(team => team.PlayerTeamCount >= 1));
            Assert.NotEqual(teams.First().Players.First(), teams.Last().Players.First());
            Assert.True(session.PlayerSessionCount == 3);
            Assert.Equal(teams.First().PlayerTeamCount + teams.Last().PlayerTeamCount, session.PlayerSessionCount) ;
        }
    }
}
