using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{
    public TextAsset inkAsset;
    public Story activeStory;
    public string currentStoryText;
    public List<Choice> currentStoryChoices;

    //Delegates for state changes in script
    public delegate void OnStoryTextChangeEvent(string newText);
    public static OnStoryTextChangeEvent storyTextChangeEvent;

    public delegate void OnStoryChoiceChangeEvent(List<Choice> choices);
    public static OnStoryChoiceChangeEvent onChoiceAvailable;

    public static InkManager active;

    private void Awake()
    {
        if(active == null) { active = this;  }
        else { Destroy(this.gameObject);  }
    }

    // Start is called before the first frame update
    void Start()
    {
        activeStory = new Story(inkAsset.text);
        currentStoryChoices = new List<Choice>();

        //set up error handling
        activeStory.onError += (msg, type) => {
            if (type == Ink.ErrorType.Warning)
                Debug.LogWarning(msg);
            else
                Debug.LogError(msg);
        };

        QuestDisplay.UpdateQuests();
    }

    public void ChooseAtIndex(int index)
    {
        currentStoryChoices.Clear();
        activeStory.ChooseChoiceIndex(index);
        RunStory();
    }

    public void JumpToScene(string name)
    {
        activeStory.ChoosePathString(name);
        RunStory();
    }

    public void RunStory()
    {
        while (activeStory.canContinue)
        {
            currentStoryText = activeStory.ContinueMaximally();
            OnStoryTextChange(currentStoryText);
        }

        if (activeStory.currentChoices.Count > 0)
        {
            for (int i = 0; i < activeStory.currentChoices.Count; ++i)
            {
                Choice choice = activeStory.currentChoices[i];
                currentStoryChoices.Add(choice);
                Debug.Log("adding choice");
            }

            StoryChoiceAvailable(this.currentStoryChoices);
        }
    }
    public void RunStory(string inkKnot)
    {
        activeStory.ChoosePathString(inkKnot);
        while (activeStory.canContinue)
        {
            currentStoryText = activeStory.ContinueMaximally();
            OnStoryTextChange(currentStoryText);
        }

        if (activeStory.currentChoices.Count > 0)
        {
            for (int i = 0; i < activeStory.currentChoices.Count; ++i)
            {
                Choice choice = activeStory.currentChoices[i];
                currentStoryChoices.Add(choice);
                Debug.Log("adding choice");
            }

            StoryChoiceAvailable(this.currentStoryChoices);
        }
    }

    private void OnStoryTextChange(string newText)
    {
        storyTextChangeEvent(newText);

        QuestDisplay.UpdateQuests();
    }

    private void StoryChoiceAvailable(List<Choice> choices)
    {
        if(onChoiceAvailable != null)
         onChoiceAvailable(choices);
    }
}
