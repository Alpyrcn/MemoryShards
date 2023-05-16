using UnityEngine;
using UnityEngine.UI;

// Diyalog için gerekli verileri tutacak olan Scriptable Object
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    // Konuþan karakterin adý
    public string speakerName;

    // Diyalog metni
    [TextArea(3, 10)]
    public string[] dialogueLines;

    // Diyalog kutusunun pozisyonu
    public Vector2 boxPosition;
}

// Diyalog kutusu için gerekli olan UI elementlerinin kontrolünü saðlayacak olan kod
public class DialogueBox : MonoBehaviour
{
    // UI elementleri
    public Text speakerNameText;
    public Text dialogueText;
    public RectTransform boxTransform;

    // Diyalog Scriptable Object'i
    public DialogueSO dialogue;

    // Diyalog kutusu oluþturulduðunda çalýþacak olan kod
    private void OnEnable()
    {
        // Diyalog verilerini UI elementlerine yükle
        speakerNameText.text = dialogue.speakerName;
        dialogueText.text = dialogue.dialogueLines[0];
        boxTransform.anchoredPosition = dialogue.boxPosition;
    }
}
