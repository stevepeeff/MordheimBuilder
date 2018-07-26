using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ProgressionLogs
{
    public class BattleInformation
    {
        public int Battle { get; }

        public string Scenario { get; }

        public string Opponent { get; }

        public int EnemyWarbandRating { get; }

        public string EnemyWarband { get; }

        public DateTime Date { get; } = DateTime.Now;

        public BattleInformation()
        {
        }
    }
}