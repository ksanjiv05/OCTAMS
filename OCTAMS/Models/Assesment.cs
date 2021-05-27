using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Models
{
    public class Assesment
    {
        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }
        public bool Q4 { get; set; }
        public bool Fever { get; set; }
        public bool Cough { get; set; }
        public bool Sorethroat  { get; set; }
        public bool Shortnessofbreath { get; set; }
        public bool Difficultybreathing  { get; set; }
        public bool Chills { get; set; }
        public bool Musclepain { get; set; }
        public bool Headache { get; set; }
        public bool GIsymptoms { get; set; }
        public bool Losstasteorsmell  { get; set; }
    }
}
