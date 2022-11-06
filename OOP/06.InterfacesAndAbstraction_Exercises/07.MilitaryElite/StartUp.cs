namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;


    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Private> privates = new HashSet<Private>();
            while (true)
            {
                Soldier soldier = null;
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] cmd = input.Split();

                switch (cmd[0])
                {
                    case "Private":
                        soldier = new Private(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]));
                        privates.Add(new Private(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4])));
                        break;

                    case "LieutenantGeneral":
                        string[] privateIDs = cmd.Skip(5).ToArray();
                        HashSet<Private> newPrivates = new HashSet<Private>();

                        for (int i = 0; i < privateIDs.Length; i++)
                        {
                            if (privates.Any(p => p.Id == privateIDs[i]))
                            {
                                newPrivates.Add(privates.FirstOrDefault(p => p.Id == privateIDs[i]));
                            }
                        }

                        soldier = new LieutenantGeneral(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), newPrivates);
                        break;
                    case "Engineer":
                        string[] repairs = cmd.Skip(6).ToArray();
                        HashSet<Repair> newRepairs = new HashSet<Repair>();

                        for (int i = 0; i < repairs.Length; i += 2)
                        {
                            string repairPart = repairs[i];
                            int repairHours = int.Parse(repairs[i + 1]);

                            newRepairs.Add(new Repair() { PartName = repairPart, HoursWorked = repairHours });
                        }

                        soldier = new Engineer(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], newRepairs);
                        break;
                    case "Commando":
                        string[] missionInfo = cmd.Skip(6).ToArray();
                        HashSet<Mission> newMissions = new HashSet<Mission>();

                        for (int i = 0; i < missionInfo.Length; i += 2)
                        {
                            string codeName = missionInfo[i];
                            string state = missionInfo[i + 1];

                            Mission mission = new Mission() { CodeName = codeName, State = state };

                            if (mission.State != null)
                            {
                                newMissions.Add(mission);
                            }
                        }

                        soldier = new Commando(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], newMissions);
                        break;
                    case "Spy":
                        soldier = new Spy(cmd[1], cmd[2], cmd[3], int.Parse(cmd[4]));
                        break;
                }

                Console.WriteLine(soldier);
            }
        }
    }
}
