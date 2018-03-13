namespace SimulOP.Core
{
    class Singularidade : EquipamentoOPI, ISingulariedade
    {
        private double comprimentoEqv;
        private string tipo;

        /// <summary>
        /// Comprimento equivalente da singulariedade [m]
        /// </summary>
        public double ComprimentoEqv { get => comprimentoEqv; set => comprimentoEqv = value; }

        /// <summary>
        /// Tipo da singulariedade
        /// </summary>
        public string Tipo { get => tipo; }

        /// <summary>
        /// Constructor para o objeto Singularidade
        /// </summary>
        /// <param name="comprimentoEqv">Comprimento equivalente da singulariedade [m]</param>
        /// <param name="tipo">Tipo da singulariedade</param>
        public Singularidade(double comprimentoEqv, string tipo = "NA")
        {
            this.comprimentoEqv = comprimentoEqv;
            this.tipo = tipo;
        }

    }
}