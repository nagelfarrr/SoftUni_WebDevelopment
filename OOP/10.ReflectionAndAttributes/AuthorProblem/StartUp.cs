namespace AuthorProblem
{
    using System;

    [Author("Victor")]
    internal class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Ivan")]
        public void Test(){}
    }
}
