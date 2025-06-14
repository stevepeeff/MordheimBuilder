﻿namespace DomainModel
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
        Shooting,
        MagicSpellsAndPrayers,
        Permenant
    }

    public class Statistic
    {
        public Applications Application { get; }

        public Characteristics Characteristic { get; }

        public string Description { get; }

        public int AppliedValue { get; }

        public Statistic(Characteristics characteristic, int appliedValue, string reason)
        {
            Characteristic = characteristic;
            AppliedValue = appliedValue;
            Description = reason;
        }

        public Statistic(Characteristics characteristic, int appliedValue, Applications application, string reason) : this(characteristic, appliedValue, reason)
        {
            Application = application;
        }
    }
}