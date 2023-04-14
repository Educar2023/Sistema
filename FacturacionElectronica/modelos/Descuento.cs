namespace FacturacionElectronica.modelos
{
    /// <summary>
    /// Estandar Ubl 2.1
    /// </summary>
    public class Descuento
    {
        public decimal Importe { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal ImporteBase { get; set; }
    }
}
