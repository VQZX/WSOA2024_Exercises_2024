using System;
using UnityEngine;

namespace SecondCodingExercises.Monster
{
    public class MonsterManager : MonoBehaviour
    {
        [SerializeField]
        private Monster firstMonster = new ("Ganymede", 13, false);
        
        [SerializeField]
        private Monster secondMonster;

        private void Start()
        {
            // First Monster
            var eatsPeopleMessageModifier = firstMonster.EatsPeople ? "does" : "does not";
            var output = $"{firstMonster.Name} has a power level of {firstMonster.PowerLevel}, and {eatsPeopleMessageModifier} eat people";
            Debug.Log(output);
            
            // Second Monster
            secondMonster = new Monster("Kaggen", UnityEngine.Random.Range(10, 50), true);
            secondMonster.DisplayIfSleeping();
            var eatenModifier = secondMonster.EatsPeople ? "has" : "has not";
            output = $"{secondMonster.Name} {eatenModifier} eaten someone.";
            Debug.Log(output);
        }
    }
}