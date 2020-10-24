using System;
using System.Security.Cryptography.X509Certificates;
using ClassLibrary;


// "C# 6 introduced new construct - the using static directive lets you import all the static members of a type,
// so that you can use those members unqualified..."
// https://stackoverflow.com/questions/6319226/can-i-import-a-static-class-as-a-namespace-to-call-its-methods-without-specifyin
// (or we could try to implement GenerateRandomScore() as a local function, but it defeats the purpose of c#)
using static ClassLibrary.RandomScore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
//  _      _      _
//>(.)__ <(.)__ =(.)__
// (___/  (___/  (___/  hjw

			int i;
			Episode ep1, ep2;
			ep1 = new Episode();
			ep2 = new Episode(10, 64.39, 8.7);
			int viewers = 10;
			for (i = 0; i < viewers; i++)
			{
				ep1.AddView(GenerateRandomScore()); //adds a viewer and his random score 
				
				Console.WriteLine($"{i+1}.{ep1.GetMaxScore()}");
			}
			if (ep1.GetAverageScore() > ep2.GetAverageScore())
			{
				Console.WriteLine($"{i + 1}.Viewers: {ep1.GetViewerCount()}");
			}
			else
			{
				Console.WriteLine($"{i + 1}.Viewers: {ep2.GetViewerCount()}");
			}
			
		}
    }
}