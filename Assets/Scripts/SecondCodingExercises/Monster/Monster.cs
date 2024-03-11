using System;
using UnityEngine;

namespace SecondCodingExercises.Monster
{
    [Serializable]
    public class Monster
    {
        [SerializeField]
        private string name;
        public string Name => name;
        
        [SerializeField]
        private int powerLevel;
        public int PowerLevel => powerLevel;
        
        [SerializeField]
        private bool eatsPeople;
        public bool EatsPeople => eatsPeople;

        public Monster()
        {
            name = string.Empty;
            powerLevel = -1;
            eatsPeople = false;
        }

        public Monster(string name, int powerLevel, bool eatsPeople)
        {
            this.name = name;
            this.powerLevel = powerLevel;
            this.eatsPeople = eatsPeople;
        }
        
        public void DisplayIfSleeping()
        {
            var output = $"{name} is sleeping";
            Debug.Log(output);
        }

        public void DisplayDiet()
        {
            var output = string.Empty;
            output = eatsPeople ? "${name} eats people" : $"{name} does not eat people";
            Debug.Log(output);
        }
        
    }
}