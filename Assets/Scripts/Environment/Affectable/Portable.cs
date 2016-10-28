using UnityEngine;


public class Portable : Affectable
{
    [SerializeField]
    private LeanTweenType portInEase;

    [SerializeField]
    private LeanTweenType portOutEase;

    [SerializeField]
    private float portDuration;

    private Vector3 originScale;


    protected override void Awake()
    {
        base.Awake();

        originScale = transform.localScale;
    }

    public override void Activate()
    {
        base.Activate();

        LeanTween.scale(this.gameObject, new Vector3(0.1f, 0.1f, 0.1f), portDuration)
            .setEase(portOutEase);
    }

    public override void Deactivate()
    {
        base.Deactivate();

        LeanTween.scale(this.gameObject, originScale, portDuration)
            .setEase(portInEase);
    }
}
