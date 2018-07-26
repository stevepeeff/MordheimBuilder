using DomainModel.ProgressionLogs;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    public interface IPlayLogic
    {
        BattleInformation BattleInfo { get; }

        void EndGame(int enemyWarbandRating);

        void EnemyOutOfAction(IWarrior who, string onWho);

        void StartGame(string opponentName, string enemyWarbandName, IWarBand enemyType, int enemyWarbandRating);

        void StartPostBattle();

        void WarriorOutOfAction(IWarrior who, string byWhom);
    }
}