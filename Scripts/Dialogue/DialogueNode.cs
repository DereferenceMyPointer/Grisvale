using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueNode : ScriptableObject
{

    [TextArea]
    public string playerText;
    [TextArea]
    public string[] npcText;

    public List<DialogueNode> next;

}
