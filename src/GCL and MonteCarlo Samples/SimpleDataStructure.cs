using GEV.Layouts.Meta;
using GEV.Layouts.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    [GCLName("Teszt adatstruktúra", GCLLanguages.Hungarian)]
    [GCLName("Datenstruktur", GCLLanguages.German)]
    [GCLName("Simple data structure", GCLLanguages.English)]
    public class SimpleDataStructure
    {
        public string Name { get; } = "Valami";

        public int Height { get; set; } = 13;

        [GCLName("Szélesség", GCLLanguages.Hungarian)]
        [GCLName("Breite", GCLLanguages.German)]
        [GCLName("Width", GCLLanguages.English)]
        [GCLUnit("px")]
        public int Width { get; set; } = 200;

        [GCLCommand(true)]
        [GCLName("Hiba", GCLLanguages.Hungarian)]
        [GCLDescription("Ez direkt hibát fog okozni.", GCLLanguages.Hungarian)]
        [GCLCommandDescription("FUCK ME UP", GCLLanguages.Hungarian)]
        public CommandResult Fuckup()
        {
            return new CommandResult()
            {
                Buttons = System.Windows.Forms.MessageBoxButtons.OK,
                HeaderText = "HIBAAAA",
                Icon = System.Windows.Forms.MessageBoxIcon.Error,
                Text = "SHIEEEEEET"
            };
        }

        [GCLCommand(true)]
        [GCLName("Mentés", GCLLanguages.Hungarian)]
        [GCLDescription("Menti az összes beállítást.", GCLLanguages.Hungarian)]
        [GCLCommandDescription("Futtatás", GCLLanguages.Hungarian)]
        public string SaveAllChanges()
        {
            return "Mentve!";
        }
    };
}
