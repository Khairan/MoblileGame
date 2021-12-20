using Game.TapeBackground;
using Tools;
using UnityEngine;


internal class TapeBackgroundView : MonoBehaviour
{
    [SerializeField]
    private Background[] _backgrounds;

    private IReadOnlySubscriptionProperty<float> _diff;

    internal void Init(IReadOnlySubscriptionProperty<float> diff)
    {
        _diff = diff;
        _diff.SubscribeOnChange(Move);
    }

    protected void OnDestroy()
    {
        _diff?.SubscribeOnChange(Move);
    }

    private void Move(float value)
    {
        foreach (var background in _backgrounds)
            background.Move(-value);
    }
}

