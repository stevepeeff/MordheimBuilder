using DomainModel;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    internal class WarBandRoster : IWarbandRoster
    {
        public WarBandRoster(IWarBand warBand)
        {
            WarBand = warBand;
        }

        public event EventHandler WarBandChanged;

        public event EventHandler WarBandWariorListChanged;

        public int TotalCosts
        {
            get
            {
                int totalCosts = 0;

                foreach (IWarrior warrior in Warriors)
                {
                    IHenchMan henchMan = warrior as IHenchMan;

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
                    IHenchMan henchMan = warrior as IHenchMan;

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
                    IHenchMan henchMan = warrior as IHenchMan;

                    if (henchMan != null)
                    {
                        rating += (henchMan.AmountInGroup * henchMan.CurrentExperience);
                    }
                    else
                    {
                        rating += warrior.CurrentExperience;
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

        public IWarrior AddWarrior(IWarrior warrior)
        {
            IWarrior newWarrior = warrior.GetAnInstance();
            Warriors.Add(newWarrior);

            newWarrior.PropertiesChanged += NewWarrior_PropertiesChanged;

            if (newWarrior is IHenchMan)
            {
                IHenchMan henchMan = newWarrior as IHenchMan;
                henchMan.IncreaseGroupByOne();
            }

            InvokeEvent(WarBandChanged);
            InvokeEvent(WarBandWariorListChanged);

            return newWarrior;
        }

        public void DecreaseHenchmenInGroup(IHenchMan warrior)
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

        public void IncreaseHenchmenInGroup(IHenchMan warrior)
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
            InvokeEvent(WarBandWariorListChanged);
        }

        private void InvokeEvent(EventHandler handler)
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void NewWarrior_PropertiesChanged(object sender, EventArgs e)
        {
            InvokeEvent(WarBandChanged);
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