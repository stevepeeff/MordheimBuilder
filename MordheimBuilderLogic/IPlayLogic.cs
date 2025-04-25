using DomainModel.ProgressionLogs;
using DomainModel.Warbands;

namespace MordheimBuilderLogic
{
    /// <summary>
    /// Logic used for starting, playing and ending a game
    /// </summary>
    public interface IPlayLogic
    {
        /// <summary>
        /// Gets the battle information.
        /// </summary>
        /// <value>
        /// The battle information.
        /// </value>
        BattleInformation BattleInfo { get; }

        /// <summary>
        /// Ends the game.
        /// </summary>
        /// <param name="enemyWarbandRating">The enemy warband rating.</param>
        void EndGame(int enemyWarbandRating);

        /// <summary>
        /// Enemies the out of action.
        /// </summary>
        /// <param name="who">The who.</param>
        /// <param name="onWho">The on who.</param>
        void EnemyOutOfAction(IWarrior who, string onWho);

        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <param name="opponentName">Name of the opponent.</param>
        /// <param name="enemyWarbandName">Name of the enemy warband.</param>
        /// <param name="enemyType">Type of the enemy.</param>
        /// <param name="enemyWarbandRating">The enemy warband rating.</param>
        void StartGame(string opponentName, string enemyWarbandName, IWarBand enemyType, int enemyWarbandRating);

        /// <summary>
        /// Starts the post battle.
        /// </summary>
        void StartPostBattle();

        /// <summary>
        /// Warriors the out of action.
        /// </summary>
        /// <param name="who">The who.</param>
        /// <param name="byWhom">The by whom.</param>
        void WarriorOutOfAction(IWarrior who, string byWhom);
    }
}