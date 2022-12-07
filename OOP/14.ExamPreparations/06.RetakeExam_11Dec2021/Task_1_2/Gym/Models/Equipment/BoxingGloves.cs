namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double GlovesWeight = 227;
        private const decimal GlovesPrice = 120;
        public BoxingGloves()
            : base(GlovesWeight, GlovesPrice)
        {
        }
    }
}
