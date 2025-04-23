namespace MordheimBuilderLogic
{
    public class BuilderLogicFactory
    {
        public static IMordheimBuilderLogic Instance { get; } = new BuilderLogic();

        private BuilderLogicFactory()
        {
        }
    }
}