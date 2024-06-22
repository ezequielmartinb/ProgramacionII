using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public sealed class Auto : Vehiculo
    {
        private float valorHora;
        private ETipoAuto tipo;
        static int espacioOcupado;

        static Auto()
        {
            espacioOcupado = 1;
        }
        public Auto() : base()
        {

        }
        public Auto(ETipoAuto tipo)
        {
            this.tipo = tipo;
        }
        public Auto(float valorHora, ETipoAuto tipo) : this(tipo)
        {
            this.valorHora = valorHora;
        }
        public Auto(string patente, string marca, DateTime horaIngreso, float valorHora, ETipoAuto tipo) : base(patente, marca, horaIngreso)
        {
            this.tipo = tipo;
            this.valorHora = valorHora;
        }
        public int EspacioOcupado { get => espacioOcupado; }
        public ETipoAuto Tipo { get => tipo; set => tipo = value; }
        public float ValorHora { get => valorHora; set => valorHora = value; }
      
        public override float CargoEstacionamiento()
        {
            float costo;
            if (this.HoraIngreso.Hour == this.HoraEgreso.Hour)
            {
                costo = this.valorHora;
            }
            else
            {
                costo = this.valorHora * (this.HoraEgreso.Hour - this.HoraIngreso.Hour);
            }
            return costo;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***DATOS AUTOMOVIL***");
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo de auto: {this.tipo.ToString()}");
            if (this.HoraEgreso != DateTime.MinValue)
            {
                sb.AppendLine($"Valor a pagar: {this.CargoEstacionamiento().ToString("$ 00.00")}");
            }

            return sb.ToString();
        }
        public static bool operator ==(Auto a1, Auto a2)
        {
            return a1.Patente == a2.Patente && a1.tipo == a2.tipo;
        }
        public static bool operator !=(Auto a1, Auto a2)
        {
            return !(a1 == a2);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Auto)
            {
                return this == ((Auto)obj);
            }
            return false;
        }

    }
}
