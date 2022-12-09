namespace Easter.Models.Workshops
{
    using System.Collections.Generic;
    using System.Linq;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Dyes.Any(x => !x.IsFinished()) && bunny.Energy > 0)
            {
                IDye dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                dye.Use();
                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
