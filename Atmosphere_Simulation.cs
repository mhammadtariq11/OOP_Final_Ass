using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F02KM2_OOP_Ass2
{
    public class Atmosphere
    {
        public List<GasLayer> Layers { get; set; }
        public int size;

        public Atmosphere()
        {
            Layers = new List<GasLayer>();
            
        }

        public void setSize()
        {
            size = Layers.Count;
        }

        public void AddLayer(GasLayer layer)
        {
            Layers.Add(layer);
        }

        public void AddOrAbsorbLayer(GasLayer newLayer)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                if (Layers[i].Type == newLayer.Type)
                {
                    Layers[i].Thickness += newLayer.Thickness;
                    return;
                }
            }
            Layers.Add(newLayer);
        }

        public void Simulate(char[] variables)
        {
            int round = 0;
            int initialGasTypesCount = Layers.Select(layer => layer.Type).Distinct().Count();

            while (true)
            {
                round++;
                Console.WriteLine($"Round {round}:");
                foreach (var layer in Layers)
                {
                    Console.WriteLine($"{layer.Type} {layer.Thickness:F2}");
                }
                Console.WriteLine();

                bool anyLayerRemoved = false;
                for (int i = 0; i < Layers.Count; i++)
                {
                    if (Layers[i].Thickness < 0.5)
                    {
                        Layers.RemoveAt(i);
                        anyLayerRemoved = true;
                        i--; 
                    }
                }

                if (anyLayerRemoved)
                {
                    continue; 
                }

                foreach (var variable in variables)
                {
                    for (int i = 0; i < Layers.Count; i++)
                    {
                        Layers[i].Transform(variable, this);
                    }
                }

                int currentGasTypesCount = Layers.Select(layer => layer.Type).Distinct().Count();
                if (currentGasTypesCount < initialGasTypesCount)
                {
                    Console.WriteLine("Simulation over. One gas component totally perished from the atmosphere.");
                    return;
                }
            }
        }
        /*
        private void RemoveLayersBelowThreshold()
        {
            Layers.RemoveAll(layer => layer.Thickness < 0.5);
            for (int i = 0; i < Layers.Count - 1; i++)
            {
                if (Layers[i].Type == Layers[i + 1].Type && Layers[i].Thickness < 0.5)
                {
                    Layers[i + 1].Thickness += Layers[i].Thickness;
                    Layers.RemoveAt(i);
                }
            }
        }
        
        private void AbsorbOrRemoveLayer(int index)
        {
            var layer = Layers[index];
            for (int i = index + 1; i < Layers.Count; i++)
            {
                if (Layers[i].Type == layer.Type)
                {
                    Layers[i].Thickness += layer.Thickness;
                    Layers.RemoveAt(index);
                    return;
                }
            }

            if (layer.Thickness >= 0.5)
            {
                Layers.Add(layer);
            }
            else
            {
                Layers.RemoveAt(index);
            }
        }

        private bool IsAnyGasPerished()   
        {
           return Layers.Count != size;
        }
        */
    }
}