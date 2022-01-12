namespace Task_2_2.Interfaces
{
    public interface IAttacker
    {
        /// <summary>
        /// Attack target
        /// </summary>
        /// <param name="target">victim</param>
        /// <returns>Real damage dealt</returns>
        int Attack(IDamagable target);
    }
}
