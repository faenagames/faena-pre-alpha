using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField]
    List<Quest> quests = new List<Quest>();
    [SerializeField]
    private TextMeshProUGUI _textBox;
    public static QuestDisplay self;
    // Start is called before the first frame update
    void Start()
    {
        if (self == null)
        {
            self = this;
            Debug.Log("QuestDisplay Self Set");
        }
        else
        {
            Destroy(this);
            Debug.Log("Destroying Duplicate QuestDisplay");
        }
    }

    public static void UpdateQuests()
    {
        string text = "";
        foreach (Quest q in self.quests)
        {
            text = text + q.questName + ": " + q.GetProgress().ToString() + "/" + q.GetMaxProgress().ToString();
        }
        self._textBox.text = text;
    }
}
