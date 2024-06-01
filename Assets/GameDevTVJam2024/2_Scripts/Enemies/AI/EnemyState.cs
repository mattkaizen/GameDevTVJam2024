namespace Enemies
{
    public class EnemyState
    {
        public enum Status
        {
            Enter,
            Update,
            Exit
        };
        
        protected Status Stage;
        protected string StateName;
        protected EnemyState NextEnemyState;
        protected EnemyAI AI;
        
        public EnemyState(EnemyAI ai)
        {
            Stage = Status.Enter;
            AI = ai;
        }

        protected virtual void Enter()
        {
            Stage = Status.Update;
        }

        protected virtual void Update()
        {
            Stage = Status.Update;
        }

        protected virtual void Exit()
        {
            Stage = Status.Exit;
        }
        
        public EnemyState Process()
        {
            if (Stage == Status.Enter) Enter();
            if (Stage == Status.Update) Update();
            if (Stage == Status.Exit)
            {
                Exit();
                return NextEnemyState;
            }
            return this;
        }
    }
}