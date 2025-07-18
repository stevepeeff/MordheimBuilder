﻿using DomainModel;
using DomainModel.Psychology;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MordheimBuilderLogic
{
    internal class WarBandRoster : IWarbandRoster
    {
        public WarBandRoster(IWarBand warBand)
        {
            WarBand = warBand;
        }

        public event EventHandler WarBandChanged;

        public int TotalCosts
        {
            get
            {
                int totalCosts = 0;

                foreach (IWarrior warrior in Warriors)
                {
                    IHenchMen henchMan = warrior as IHenchMen;

                    if (henchMan != null)
                    {
                        totalCosts += henchMan.AmountInGroup * (warrior.HireFee + warrior.EquipmentCosts);
                    }
                    else
                    {
                        totalCosts += (warrior.HireFee + warrior.EquipmentCosts);
                    }
                }

                return totalCosts;
            }
        }

        public int TotalNumberOfWarriors
        {
            get
            {
                int totalwarriors = 0;

                foreach (IWarrior warrior in Warriors)
                {
                    IHenchMen henchMan = warrior as IHenchMen;

                    if (henchMan != null)
                    {
                        totalwarriors += henchMan.AmountInGroup;
                    }
                    else
                    {
                        totalwarriors += 1;
                    }
                }
                return totalwarriors;
            }
        }

        public IWarBand WarBand { get; private set; }

        public int WarbandRating
        {
            get
            {
                int rating = (TotalNumberOfWarriors * 5);

                foreach (IWarrior warrior in Warriors)
                {
                    IHenchMen henchMan = warrior as IHenchMen;

                    if (henchMan != null)
                    {
                        rating += (henchMan.AmountInGroup * henchMan.CurrentExperience);
                    }
                    else
                    {
                        rating += warrior.CurrentExperience;
                    }
                    if (warrior.Afflictions.Any(x => x.Affliction.Equals(Afflictions.LargeTarget)))
                    {
                        rating += 20;
                    }
                }
                return rating;
            }
        }

        public IList<IWarrior> Warriors { get; } = new List<IWarrior>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public bool CostsExceedMaximum
        {
            get
            {
                return TotalCosts > WarBand.StartingCash;
            }
        }

        public string SaveFileName { get; set; }

        public IWarrior AddWarrior(IWarrior warrior)
        {
            IWarrior newWarrior = warrior.GetAnInstance();
            Warriors.Add(newWarrior);

            if (newWarrior is IHenchMen)
            {
                IHenchMen henchMan = newWarrior as IHenchMen;
                henchMan.IncreaseGroupByOne();
            }

            InvokeEvent(WarBandChanged);

            return newWarrior;
        }

        public void DecreaseHenchmenInGroup(IHenchMen warrior)
        {
            warrior.DecreaseGroupByOne();
            if (warrior.AmountInGroup <= 0)
            {
                RemoveWarrior(warrior);
            }
            else
            {
                InvokeEvent(WarBandChanged);
            }
        }

        public void IncreaseHenchmenInGroup(IHenchMen warrior)
        {
            if (NumberOffWarriorsOfThisTypeInRoster(warrior) < warrior.MaximumAllowedInWarBand)
            {
                warrior.IncreaseGroupByOne();
                InvokeEvent(WarBandChanged);
            }
        }

        public bool MaximumAllowedAmountOfWarriorReached(IWarrior warrior)
        {
            return (NumberOffWarriorsOfThisTypeInRoster(warrior) == warrior.MaximumAllowedInWarBand);
        }

        public bool MaximumAllowedAmountOfWarriorsReached()
        {
            return (TotalNumberOfWarriors == WarBand.MaximumNumberOfWarriors);
        }

        public void RemoveWarrior(IWarrior warrior)
        {
            Warriors.Remove(warrior);
            InvokeEvent(WarBandChanged);
        }

        private void InvokeEvent(EventHandler handler)
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private int NumberOffWarriorsOfThisTypeInRoster(IWarrior warrior)
        {
            int total = 0;
            foreach (var item in Warriors)
            {
                total += item.AmountOfThisType(warrior);
            }
            return total;
        }
    }
}