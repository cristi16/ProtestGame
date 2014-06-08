using UnityEngine;
using System.Collections;

public class ShowStatsPanel : MonoBehaviour
{
    public UILabel statsButtonLabel;
    public UILabel statsTextLabel;
    private bool isHidden = true;

    private TweenPosition tp;

    void Start()
    {
        tp = GetComponent<TweenPosition>();
    }

    public void PlayTween()
    {
        if (!isHidden)
        {
            tp.PlayReverse();
            statsButtonLabel.text = "Show Stats";
        }
        else
        {
            tp.PlayForward();
            statsButtonLabel.text = "Hide Stats";
        }
        isHidden = !isHidden;
    }

}
