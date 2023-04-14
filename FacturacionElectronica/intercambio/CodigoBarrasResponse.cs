namespace FacturacionElectronica.intercambio
{
    public class CodigoBarrasResponse : RespuestaComun
    {
        public byte[] CodigoBarrasBytes { get; set; }
        public System.Drawing.Bitmap CodigoBarrasBitmap { get; set; }

    }
}
