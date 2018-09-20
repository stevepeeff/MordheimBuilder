using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.SkavenSpecial
{
    internal class BlackHunger : ISkavenSpecial
    {
        public IReadOnlyCollection<Statistic> Statistics => throw new NotImplementedException();

        public string Description =>
            "The Skaven can draw upon the dreaded Black Hunger, the fighting frenzy which gives him " +
            "unnatural strength and speed but can ravage him from inside.The Skaven Hero may " +
            "declare at the beginning of his turn that he is using this skill.The Hero may add +1 " +
            "attack and +D3\" private to the private total move private to his profile for private the duration private of his private own turn " +
            "but will suffer D3 S3 hits with no armour save possible at the end of the turn.";

        public string SkillName => nameof(BlackHunger);

        public string SkillTypeName => "Skaven Special";
    }
}