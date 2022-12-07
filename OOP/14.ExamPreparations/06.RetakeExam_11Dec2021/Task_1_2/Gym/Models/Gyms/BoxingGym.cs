namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int CAPACITY = 15;
        public BoxingGym(string name) : base(name, CAPACITY)
        {
        }
    }
}
