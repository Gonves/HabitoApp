using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitoApp
{
    public class Habito
    {
        public string Name { get; set; }
        public int Frequency { get; set; }  // Quantas vezes por dia
        public int Progress { get; set; }   // Quantas vezes o usuário completou o hábito hoje
    }

}
