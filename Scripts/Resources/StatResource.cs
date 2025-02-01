using Godot;

namespace GamedevTvActionAdventure25d_RPG.Scripts.Resources;

[GlobalClass]
public partial class StatResource : Resource
{
    private float _statValue;
    [Export] public Stat StatType { get; private set; }

    [Export] public float StatValue
    {
        get => _statValue;
        set => _statValue = Mathf.Clamp(value, 0, Mathf.Inf);
    }
}
