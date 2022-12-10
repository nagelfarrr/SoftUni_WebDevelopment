namespace FootballTeam.Tests
{
    using System;
    using System.Linq;
    using System.Numerics;
    using NUnit.Framework;


    public class Tests
    {
        private FootballPlayer testPlayer;
        private FootballPlayer testPlayer1;
        private FootballPlayer testPlayer2;
        private FootballPlayer testPlayer3;
        private FootballPlayer testPlayer4;
        private FootballPlayer testPlayer5;
        private FootballPlayer testPlayer6;
        private FootballPlayer testPlayer7;
        private FootballPlayer testPlayer8;
        private FootballPlayer testPlayer9;
        private FootballPlayer testPlayer10;
        private FootballPlayer testPlayer11;
        private FootballPlayer testPlayer12;
        private FootballPlayer testPlayer13;
        private FootballPlayer testPlayer14;
        private FootballPlayer testPlayer15;

        private FootballTeam testTeam;
            

        [SetUp]
        public void Setup()
        {
            testPlayer = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer1 = new FootballPlayer("Ivan", 9, "Forward");
            testPlayer2 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer3 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer4 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer5 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer6 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer7 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer8 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer9 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer10 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer11 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer12 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer13 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer14 = new FootballPlayer("Gonzo", 9, "Forward");
            testPlayer15 = new FootballPlayer("Gonzo", 9, "Forward");

            testTeam = new FootballTeam("Kaliakra", 15);
        }

        [Test]
        public void FootballPlayerNameShouldBeInitializedFromConstructor()
        {
            string playerName = "Ivan";

            FootballPlayer player = new FootballPlayer(playerName, 9, "Goalkeeper");

            Assert.AreEqual(playerName, player.Name);
        }

        [Test]
        public void FootballPlayerNumberShouldBeInitializedFromConstructor()
        {
            int playerNumber = 9;

            FootballPlayer player = new FootballPlayer("Gonzo", playerNumber, "Forward");

            Assert.AreEqual(playerNumber, player.PlayerNumber);
        }

        [TestCase("Goalkeeper")]
        [TestCase("Midfielder")]
        [TestCase("Forward")]
        public void FootballPlayerPositionShouldBeInitializedFromConstructor(string playerPosition)
        {
            FootballPlayer player = new FootballPlayer("Ivan", 9, playerPosition);

            Assert.AreEqual(playerPosition, player.Position);
        }

        [Test]
        public void FootballPlayerScoredGoalsShouldBeZeroWhenInitialized()
        {
            int expectedGoals = 0;

            Assert.AreEqual(expectedGoals, testPlayer.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FootballPlayerNameCannotBeNullOrEmpty(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                testPlayer = new FootballPlayer(name, 9, "Forward");

            });
        }

        [TestCase(0)]
        [TestCase(22)]
        [TestCase(100)]
        public void FootballPlayerNumberCannotBeLessThan1AndMoreThan21(int number)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testPlayer = new FootballPlayer("Ivan", number, "Goalkeeper");
            });
        }

        [TestCase("Zashtitnik")]
        [TestCase("Attacker")]
        [TestCase("goalkeeper")]
        [TestCase("midfielder")]
        [TestCase("forward")]
        public void FootballPlayerPositionCannotBeAnything(string position)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testPlayer = new FootballPlayer("Ivan", 9, position);
            });
        }

        [Test]
        public void FootballPlayerScoreMethodShouldIncreaseScoreGoalsByOne()
        {
            int expectedGoals = 1;

            testPlayer.Score();

            Assert.AreEqual(expectedGoals, testPlayer.ScoredGoals);
        }

        [Test]
        public void TeamNameShouldBeInitializedFromConstructor()
        {
            string teamName = "Litex";

            FootballTeam team = new FootballTeam(teamName, 19);

            Assert.AreEqual(teamName, team.Name);
        }

        [Test]
        public void TeamCapacityShouldBeInitializedFromConstructor()
        {
            int teamCapacity = 21;
            FootballTeam team = new FootballTeam("Kaliakra", teamCapacity);

            Assert.AreEqual(teamCapacity, team.Capacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TeamNameCannotBeNullOrEmpty(string teamName)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(teamName, 19);
            });
        }

        [TestCase(14)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-20)]
        public void TeamCapacityCannotBeLessThan15(int teamCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("otbor", teamCapacity);
            });
        }

        [Test]
        public void TeamCannotAddMorePlayersThanCapacity()
        {
            string expectedOutput = "No more positions available!";

            testTeam.AddNewPlayer(testPlayer);
            testTeam.AddNewPlayer(testPlayer1);
            testTeam.AddNewPlayer(testPlayer2);
            testTeam.AddNewPlayer(testPlayer3);
            testTeam.AddNewPlayer(testPlayer4);
            testTeam.AddNewPlayer(testPlayer5);
            testTeam.AddNewPlayer(testPlayer6);
            testTeam.AddNewPlayer(testPlayer7);
            testTeam.AddNewPlayer(testPlayer8);
            testTeam.AddNewPlayer(testPlayer9);
            testTeam.AddNewPlayer(testPlayer10);
            testTeam.AddNewPlayer(testPlayer11);
            testTeam.AddNewPlayer(testPlayer12);
            testTeam.AddNewPlayer(testPlayer13);
            testTeam.AddNewPlayer(testPlayer14);

            Assert.AreEqual(expectedOutput,testTeam.AddNewPlayer(testPlayer15));
        }

        [Test]
        public void TeamAddingAPlayerShouldReturnProperString()
        {
            string expectedOutput =
                $"Added player {testPlayer.Name} in position {testPlayer.Position} with number {testPlayer.PlayerNumber}";

            Assert.AreEqual(expectedOutput,testTeam.AddNewPlayer(testPlayer));
        }

        [Test]
        public void TeamAddingAPlayerShouldAddPlayerToTheTeam()
        {
            testTeam.AddNewPlayer(testPlayer);

            Assert.AreSame(testPlayer,testTeam.Players.First());
        }

        [Test]
        public void TeamPickPlayerShouldReturnPlayerByItsName()
        {
            testTeam.AddNewPlayer(testPlayer);
            testTeam.AddNewPlayer(testPlayer1);

            var actualPlayer = testTeam.PickPlayer("Ivan");

            Assert.AreEqual(testPlayer1,actualPlayer);
        }

        [Test]
        public void TeamPlayerScoreShouldReturnProperString()
        {
            testTeam.AddNewPlayer(testPlayer);
            
            string expectedOutput = $"{testPlayer.Name} scored and now has 1 for this season!";

            Assert.AreEqual(expectedOutput,testTeam.PlayerScore(9));
        }

        
    }


}