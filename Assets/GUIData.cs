using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GUIData : MonoBehaviour
{
    public static GUIData Current = new GUIData();
    public Dictionary<string, int> selectedExercise = new Dictionary<string, int>();
    public List<string> ExerciseList = new List<string>();
    public List<string> selectedJoints = new List<string>();
    public int breakTime, sets;
    public bool CanWork = false;
}
