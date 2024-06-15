namespace Assets.MyAssets.InGame.Slimes.Interfaces
{
    public interface IDamageable
    {
        void ApplyDamage();
    }
    
    public interface IEnemyDamageable
    {
        void ApplyDamage(int damageNum);
    }
}
