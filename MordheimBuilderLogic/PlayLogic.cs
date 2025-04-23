using DomainModel;
using DomainModel.ProgressionLogs;
using DomainModel.Warbands;
using DomainModel.WarriorStatus;
using System;

namespace MordheimBuilderLogic
{
    internal class PlayLogic : IPlayLogic
    {
        public BattleInformation BattleInfo => throw new NotImplementedException();

        private IWarbandRoster _WarbandRoster;

        public PlayLogic(IWarbandRoster warbandRoster)
        {
            if (warbandRoster == null) { throw new ArgumentNullException("The warband roster is null"); }
            _WarbandRoster = warbandRoster;
        }

        public void EndGame(int enemyWarbandRating)
        {
            throw new NotImplementedException();
        }

        public void EnemyOutOfAction(IWarrior who, string onWho)
        {
            throw new NotImplementedException();
        }

        public void StartGame(string opponentName, string enemyWarbandName, IWarBand enemyType, int enemyWarbandRating)
        {
            throw new NotImplementedException();
        }

        public void StartPostBattle()
        {
            throw new NotImplementedException();
        }

        public void WarriorOutOfAction(IWarrior who, string byWhom)
        {
            who.ChangeStatus(new OutOfAction());
        }
    }
}