using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Data", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string characterName;
    [TextArea(3, 10)] public string[] sentences;
    public Sprite characterSprite;
}
