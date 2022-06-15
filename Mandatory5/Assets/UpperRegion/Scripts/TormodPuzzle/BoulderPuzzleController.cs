using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BoulderPuzzleController : MonoBehaviour {
    
    [SerializeField] private int numberOfCorrectHoles = 2;
    [SerializeField] private UnityEvent onCompletion;
    [SerializeField] private List<BoulderHole> possibleBoulderHoles;

    private List<BoulderHole> _correctBoulderHoles = new List<BoulderHole>();
    private bool _completed;

    private void Awake() {
        //Limit the number of correct holes to what is actually possible
        if (numberOfCorrectHoles > possibleBoulderHoles.Count)
            numberOfCorrectHoles = possibleBoulderHoles.Count;
        
        //Pick random holes
        for (int i = 0; i < numberOfCorrectHoles; i++) {
            var randomHole = possibleBoulderHoles[Random.Range(0, possibleBoulderHoles.Count)];
            possibleBoulderHoles.Remove(randomHole);
            _correctBoulderHoles.Add(randomHole);

            //Set up correct hole
            randomHole.CorrectHoleIndicator.SetActive(true);
        }

        BoulderHole.OnStateChanged += CheckSolveCondition;
    }

    private void OnDestroy() => BoulderHole.OnStateChanged -= CheckSolveCondition;

    private void CheckSolveCondition() {
        if (_completed) return;
        //Check if correct holes are not slotted
        foreach (var boulderHole in _correctBoulderHoles) {
            if (!boulderHole.IsBoulderSlotted)
                return;
        }
        //Check if wrong holes are slotted 
        foreach (var boulderHole in possibleBoulderHoles) {
            if (boulderHole.IsBoulderSlotted)
                return;
        }

        //If this point is reach, all and just the correct holes are slotted
        _completed = true;
        onCompletion.Invoke();
    }
    
}