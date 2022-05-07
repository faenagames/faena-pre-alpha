using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestName", menuName = "Quest", order = 1)]
[System.Serializable]
public class Quest : ScriptableObject
{
    public string questName;
    public string description;
    public string[] inkKnots;

    public int GetProgress()
    {
        
        int progress = 0;
        foreach(string knot in inkKnots)
        {
            if (InkManager.active.activeStory.state.VisitCountAtPathString(knot) > 0)
            {
                progress++;
            }
        }
        return progress;
    }
    public int GetMaxProgress()
    {
        return inkKnots.Length;
    }
}
