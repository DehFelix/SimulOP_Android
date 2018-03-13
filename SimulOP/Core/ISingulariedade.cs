namespace SimulOP.Core
{
    public interface ISingulariedade
    {
        /// <summary>
        /// Comprimento equivalente da singulariedade
        /// </summary>
        double ComprimentoEqv { get; set; }
        /// <summary>
        /// Tipo da singulariedade
        /// </summary>
        string Tipo { get; }
    }
}