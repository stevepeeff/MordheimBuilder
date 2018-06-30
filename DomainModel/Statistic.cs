using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public enum Characteristics
    {
        None,
        Movement,
        Attack,
        Toughness,
        Initiative,
        Strength,
        WeaponSkill,
        BallisticSkill,
        Wounds,
        LeaderShip,
        Wealth,
        Save
    }

    public enum Applications
    {
        CloseCombat,
        CloseCombatExcludingPistols,
        InsideBuildings,
        WarbandStartIncome,
        Shooting
    }

    public class Statistic
    {
        public Applications Application { get; private set; }

        public Characteristics Characteristic { get; private set; }

        public int AppliedValue { get; private set; }

        public Statistic(Characteristics characteristic, int appliedValue)
        {
            Characteristic = characteristic;
            AppliedValue = appliedValue;
        }

        public Statistic(Characteristics characteristic, int appliedValue, Applications application) : this(characteristic, appliedValue)
        {
            Application = application;
        }
    }
}