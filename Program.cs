

using System;
using TextFile;


namespace F02KM2_OOP_Ass2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the filename: ");
            string filename = Console.ReadLine();

            var lines = File.ReadAllLines(filename);

            int numLayers = int.Parse(lines[0]);
            var atmosphere = new Atmosphere();

            for (int i = 1; i <= numLayers; i++)
            {
                var parts = lines[i].Split(' ');
                string type = parts[0];
                double thickness = double.Parse(parts[1]);

                GasLayer layer = type switch
                {
                    "Z" => new Ozone(thickness),
                    "X" => new Oxygen(thickness),
                    "C" => new CarbonDioxide(thickness),
                    _ => throw new InvalidOperationException("Unknown gas type")
                };

                atmosphere.AddLayer(layer);
            }

            atmosphere.setSize();
            char[] variables = lines[numLayers + 1].ToCharArray();

            atmosphere.Simulate(variables);
        }

    }
}

