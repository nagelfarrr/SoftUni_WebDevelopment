using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int priceValue = int.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int bulletUsed = 0;
            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {
                int reload = barrelSize;

                while (reload > 0)
                {
                    if (locksQueue.Count == 0 || bulletsStack.Count == 0) break;

                    int currentBullet = bulletsStack.Pop();
                    bulletUsed++;
                    int currentLock = locksQueue.Peek();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locksQueue.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    reload--;

                }
                if (reload == 0 && bulletsStack.Count > 0)
                    Console.WriteLine("Reloading!");

            }

            if (bulletsStack.Count >= 0 && locksQueue.Count == 0)
            {
                int moneyEarned = priceValue - (bulletUsed * bulletPrice);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
            else if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}
