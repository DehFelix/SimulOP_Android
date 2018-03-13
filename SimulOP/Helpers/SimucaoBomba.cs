using SimulOP.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SimulOP.Helpers
{
    class SimucaoBomba
    {
        private Fluido fluido;
        private Tubulacao tubulacao;
        private Singularidade singularidade;
        private Bomba bomba;

        private double fluidoDensidade;
        private double fluidoViscosidade;
        private double tubulacaoDiametro;
        private double tubulacaoComprimento;
        private double tubulacaoRugosidade;
        private double tubulacaoElevazao;
        private double singularidadeComprEqv;
        private double[] bombaEqCruva;

        //public Fluido Fluido { get => fluido; }
        //public Tubulacao Tubulacao { get => tubulacao; }
        //public Singularidade Singularidade { get => singularidade; }
        //public Bomba Bomba { get => bomba; }

        public double FluidoDensidade
        {
            get => fluidoDensidade;
            set
            {
                if (value > 0) fluidoDensidade = value;
            }
        }
        public double FluidoViscosidade
        {
            get => fluidoViscosidade;
            set
            {
                if (value > 0) fluidoViscosidade = value;
            }
        }
        public double TubulacaoDiametro
        {
            get => tubulacaoDiametro;
            set
            {
                if (value > 0) tubulacaoDiametro = value;
            }
        }
        public double TubulacaoComprimento
        {
            get => tubulacaoComprimento;
            set
            {
                if (value > 0) tubulacaoComprimento = value;
            }
        }
        public double TubulacaoRugosidade
        {
            get => tubulacaoRugosidade;
            set
            {
                if (value > 0) tubulacaoRugosidade = value;
            }
        }
        public double TubulacaoElevazao
        {
            get => tubulacaoElevazao;
            set => tubulacaoElevazao = value;
        }
        public double SingularidadeComprEqv
        {
            get => singularidadeComprEqv;
            set
            {
                if (value > 0) singularidadeComprEqv = value;
            }
        }
        public double[] BombaEqCruva
        {
            get => bombaEqCruva;
            set
            {
                if (value[0] != 0 || value[1] != 0 || value[2] != 0 || value[3] != 0) bombaEqCruva = value;
            }
        }

        public void FluidoInput(double densidade, double viscosidade)
        {
            if (densidade > 0) FluidoDensidade = densidade;
            if (viscosidade > 0) FluidoViscosidade = viscosidade;
        }

        public void TubulacaoInput(double diametro, double comprimento, double rugosidade, double elevacao)
        {
            if (diametro > 0) TubulacaoDiametro = diametro;
            if (comprimento > 0) TubulacaoComprimento = comprimento;
            if (rugosidade > 0) TubulacaoRugosidade = rugosidade;
            if (elevacao > 0) TubulacaoElevazao = elevacao;
        }

        public void SingularidadeInput(double comprEqv)
        {
            if (comprEqv > 0) SingularidadeComprEqv = comprEqv;
        }

        public void BombaInput(double[] eqCurva)
        {
            if (eqCurva[0] != 0 || eqCurva[1] != 0 || eqCurva[2] != 0 || eqCurva[3] != 0)
            {
                BombaEqCruva = eqCurva;
            }
        }

        public bool ConstruirSimulacao()
        {
            if (fluido != null && singularidade != null && tubulacao != null && bomba != null)
            {
                fluido = new Fluido(fluidoDensidade, fluidoViscosidade);
                singularidade = new Singularidade(singularidadeComprEqv);
                tubulacao = new Tubulacao(tubulacaoDiametro, tubulacaoComprimento, tubulacaoRugosidade, tubulacaoElevazao)
                {
                    ListaSingulariedades = new List<Singularidade> { singularidade }
                };
                bomba = new Bomba(bombaEqCruva, fluido, tubulacao);
                return true;
            }
            else return false;
        }

        public void SimularBomba()
        {
            bomba.CalculaVazao();
        }

    }
}