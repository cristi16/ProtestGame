using UnityEngine;
using System.Collections;

public class RequestFactory : MonoBehaviour
{
    public RequestCharacter characterPrefab;
    private RequestCharacter currentCharacter;

    private System.Random random;

    IEnumerator Start()
    {
        random = new System.Random();
        yield return new WaitForSeconds(1f);
        SpawnNewCharacter();
    }

    void Update()
    {
        if(currentCharacter && currentCharacter.finishedRound)
        {
            SpawnNewCharacter();
        }
    }


    private void SpawnNewCharacter()
    {
        currentCharacter = Instantiate(characterPrefab, transform.position, Quaternion.identity) as RequestCharacter;
        int causeIndex = Random.Range(0, GameController.Instance.causeStats.Count - 1);
        bool isSupporter =  random.Next(0, 2) == 0 ? false : true;

        currentCharacter.request = new IndividualRequest(EnumUtil.GetValues<CauseStatType>()[causeIndex], isSupporter, Random.Range(10, 100));
    }
}
