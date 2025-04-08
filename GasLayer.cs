using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace F02KM2_OOP_Ass2
{
    public abstract class GasLayer
    {
        public string Type { get; set; }
        public double Thickness { get; set; }

        protected GasLayer(string type, double thickness)
        {
            Type = type;
            Thickness = thickness;
        }

        public abstract void Transform(char variable, Atmosphere atmosphere);
    }
    class Ozone : GasLayer
    {
        public Ozone(double thickness) : base("Z", thickness) { }

        public override void Transform(char variable, Atmosphere atmosphere)
        {
            switch (variable)
            {
                case 'O': 
                    double transformedThickness = Thickness * 0.05;
                    Thickness *= 0.95;
                    
                    if (transformedThickness >= 0.5)
                    {
                        atmosphere.AddOrAbsorbLayer(new Oxygen(transformedThickness));
                    }
                   
                    break;
            }
        }
    }
    class Oxygen : GasLayer
    {
        public Oxygen(double thickness) : base("X", thickness) { }

        public override void Transform(char variable, Atmosphere atmosphere)
        {
            switch (variable)
            {
                case 'T':  
                    double ozoneThickness = Thickness * 0.5; 
                    Thickness *= 0.5;
                    
                    if (ozoneThickness >= 0.5)
                    {
                        atmosphere.AddOrAbsorbLayer(new Ozone(ozoneThickness));
                    }
                    
                    break;
                    
                case 'S':
                    double smallOzoneThickness = Thickness * 0.05; 
                    Thickness *= 0.95;
                   
                    if (smallOzoneThickness >= 0.5)
                    {
                        atmosphere.AddOrAbsorbLayer(new Ozone(smallOzoneThickness));
                    }
                   
                    break;
                case 'O':
                    double carbonDioxideThickness = Thickness * 0.1;
                    Thickness *= 0.9;
                    
                    if (carbonDioxideThickness >= 0.5)
                    {
                        atmosphere.AddOrAbsorbLayer(new CarbonDioxide(carbonDioxideThickness));
                    }
                    break;
            }
        }
    }
    class CarbonDioxide : GasLayer
    {
        public CarbonDioxide(double thickness) : base("C", thickness) { }
        
        public override void Transform(char variable, Atmosphere atmosphere)
        {
            switch (variable)
            {
                case 'S':
                    double oxygenThickness = Thickness * 0.05; 
                    Thickness *= 0.95;
                    if (oxygenThickness >= 0.5)
                    {
                        atmosphere.AddOrAbsorbLayer(new Oxygen(oxygenThickness));
                    }
                    
                    break;
            }
        }
    }
}
