using GamedevTvActionAdventure25d_RPG.Scripts.General;
using Godot;

namespace GamedevTvActionAdventure25d_RPG.Scripts.Characters;

public abstract partial class CharacterState : Node
{
    protected Character CharacterNode;

    public override void _Ready()
    {
        base._Ready();
        SetPhysicsProcess(false);
        SetProcessInput(false);
        CharacterNode = GetParent<StateMachine>().GetParent<Character>(); //FindParent("Player").GetNode<Player>(".");
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case (int)GameConstants.States.EnterState:
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;
            case (int)GameConstants.States.ExitState:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                ExitState();
                break;
        }
    }

    protected virtual void EnterState()
    {
    }

    protected virtual void ExitState()
    {
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (!CharacterNode.IsOnFloor())
        {
            /*
             * Fall!
             */

            var velocity = CharacterNode.Velocity;
            velocity += CharacterNode.GetGravity(); // * CharacterNode.GravityFactor;
            CharacterNode.Velocity = velocity;
            CharacterNode.MoveAndSlide();
        }
    }
}
