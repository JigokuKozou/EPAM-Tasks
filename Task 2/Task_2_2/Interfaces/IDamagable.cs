namespace Task_2_2.Interfaces
{
    internal interface IDamagable
    {
        bool IsAlive { get; }

        /// <summary>
        /// Take damage
        /// </summary>
        /// <param name="damage">Damage taken</param>
        /// <returns>Real damage dealt</returns>
        int TakeDamage(int damage);
    }
}
