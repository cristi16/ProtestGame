using UnityEngine;
using System.Collections;

public class RequestCharacter : MonoBehaviour
{
    public IndividualRequest request;

    public bool finishedRound = false;

    public Sprite[] sprites;

    GameObject dialogueObject;

    IEnumerator Start()
    {
        System.Random random = new System.Random();
        GetComponent<SpriteRenderer>().sprite = sprites[random.Next(0, sprites.Length)];

        GetComponent<Animation>().Play();

        while(animation.isPlaying)
        {
            yield return null;
        }

        dialogueObject = GameController.Instance.dialogueHandler.gameObject;
        GameController.Instance.dialogueHandler.currentCharacter = this;

        foreach(Transform tr in dialogueObject.transform)
            tr.gameObject.SetActive(true);

        UILabel label = dialogueObject.transform.FindChild("RequestLabel").GetComponent<UILabel>();
        label.text = request.isPro ? GetProText() : GetAgainstText();
    }

    private string GetProText()
    {
        return "Hi there! I am here representing " + request.numberOfActivists + " people who are supporting " 
            + request.causeType.ToString() + "! We would like you to grant the following request... It'll cost you " + request.moneyRequired + "$!";
    }

    private string GetAgainstText()
    {
        return "Hi there! I am here to complain about the your actions regarding "
            + request.causeType.ToString() + "! I would like you to grant the following request... It'll cost you " + request.moneyRequired + "$!";
    }

    public void StartLeaving()
    {
        StartCoroutine(Leaving());
    }

    private IEnumerator Leaving()
    {
        foreach (Transform tr in dialogueObject.transform)
            tr.gameObject.SetActive(false);

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        animation["entrance"].speed = -1;
        animation["entrance"].time = animation["entrance"].length;
        animation.Play();

        while (animation.isPlaying)
            yield return null;

        finishedRound = true;

        Destroy(gameObject, 1f);
    }
}
