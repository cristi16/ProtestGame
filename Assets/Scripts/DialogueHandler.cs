using UnityEngine;
using System.Collections;

public class DialogueHandler : MonoBehaviour
{

    public RequestCharacter currentCharacter;

    public void SendAnswerYes()
    {
        currentCharacter.request.FullfillRequest();
        currentCharacter.StartLeaving();
    }
    
    public void SendAnswerNo()
    {
        currentCharacter.request.DenyRequest();
        currentCharacter.StartLeaving();
    }

    
}
