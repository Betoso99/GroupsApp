using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroupsApp
{
	class Program
	{
		static void Main(string[] args)
		{
			int GroupsNum, memeberPerGroup, rand, n = 0;
			List<string> Temp;
			List<List<string>> Groups = new List<List<string>>();

			var Students = File.ReadAllLines(@"C:\Users\alber\source\repos\GroupsApp\GroupsApp\students.txt").ToList();

			Console.WriteLine("Cuantos grupos desea?");
			GroupsNum = Convert.ToInt32(Console.ReadLine());

			var Subjects = File.ReadAllLines(@"C:\Users\alber\source\repos\GroupsApp\GroupsApp\subjects.txt").ToList();

			memeberPerGroup = Students.Count / GroupsNum;

			for (int i = 0; i < GroupsNum; i++)
			{
				Temp = new List<string>();
				for (int j = 0; j < memeberPerGroup; j++)
				{
					if(Students.Count != 0)
					{
						Random random = new Random();
						rand = random.Next(0, Students.Count);
						Temp.Add(Students[rand]);
						Students.RemoveAt(rand);
					}
				}
				Groups.Add(Temp);
			}

			while(Students.Count != 0)
			{
				for (int i = 0; i < GroupsNum; i++)
				{
					if(Students.Count != 0)
					{
						Groups[i].Add(Students[0]);
						Students.RemoveAt(0);
					}
				}
			}

			foreach(var i in Groups)
			{
				n++;
				Random random = new Random();
				rand = random.Next(0, Subjects.Count);
				Console.WriteLine($"\nGroup # {n}\n");
				if (Subjects.Count != 0)
				{
					Console.WriteLine($"Subject: {Subjects[rand]}\n");
					Subjects.RemoveAt(rand);
				}
				foreach (var x in i)
				{
					Console.WriteLine(x);
				}
			}
		}
	}
}
