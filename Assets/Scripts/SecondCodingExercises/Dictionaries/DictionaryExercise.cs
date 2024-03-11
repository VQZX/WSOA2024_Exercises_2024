using System;
using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace SecondCodingExercises.Dictionaries
{
    public class DictionaryExercise : MonoBehaviour
    {
        private Dictionary<string, float> studentMarks = new Dictionary<string, float>();
        
        /*
            1. Ndlovu, Thandi
            2. Van der Merwe, Johan
            3. Patel, Fatima
            4. Botha, Pieter
            5. Ngubane, Nomthandazo
            6. De Villiers, Jacques
            7. Nkosi, Lindiwe
            8. Van Niekerk, Jan
            9. Dlamini, Sipho
            10. Van Wyk, Sarah
         */

        private void Start()
        {
            studentMarks.Add("Ndlovu, Thandi", UnityRandom.Range(0, 100));
            studentMarks.Add("Van der Merwe, Johan", UnityRandom.Range(0, 100));
            studentMarks.Add("Patel, Fatima", UnityRandom.Range(0, 100));
            studentMarks.Add("Botha, Pieter", UnityRandom.Range(0, 100));
            studentMarks.Add("Ngubane, Nomthandazo", UnityRandom.Range(0, 100));
            studentMarks.Add("De Villiers, Jacques", UnityRandom.Range(0, 100));
            studentMarks.Add("Van Niekerk, Jan", UnityRandom.Range(0, 100));
            studentMarks.Add("Dlamini, Sipho", UnityRandom.Range(0, 100));
            studentMarks.Add("Van Wyk, Sarah", UnityRandom.Range(0, 100));

            Debug.Log($"Patel, Fatima: {studentMarks["Patel, Fatima"]}");
            
            foreach (var studentMark in studentMarks)
            {
                Debug.Log($"{studentMark.Key}: {studentMark.Value}");
            }
        }
    }
}