using GamedevTvActionAdventure25d_RPG.Scripts.General;

namespace GamedevTvActionAdventure25d_RPG.Scripts.Characters.Enemy;

public partial class EnemyIdleState : EnemyState {
    protected override void EnterState() {
        base.EnterState();
        CharacterNode.CharacterSprite.Play(GameConstants.Anim.Idle);
        CharacterNode.NaviAgent.TargetPosition = GetPointGlobalPosition(0); //
    }

    public override void _PhysicsProcess(double delta) {
        base._PhysicsProcess(delta);
        var nav = CharacterNode.NaviAgent;
        if (!nav.IsNavigationFinished()) {
            CharacterNode.StateMachine.SwitchState<EnemyReturnState>();
            return;
        }

        Move();
    }
}