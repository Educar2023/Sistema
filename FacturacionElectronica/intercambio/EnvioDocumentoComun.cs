
namespace FacturacionElectronica.intercambio
{
    public abstract class EnvioDocumentoComun
    {
        public string Ruc { get; set; }

        public string UsuarioSol { get; set; }

        public string ClaveSol { get; set; }

        public string IdDocumento { get; set; }

        public string TipoDocumento { get; set; }

        public string EndPointUrl { get; set; }

        public string EmailEmisor { get; set; }

        public string PasswordEmisor { get; set; }

        public string EmailCliente { get; set; }

        public string NombreEmpresa { get; set; }

        public string WebEmpresa { get; set; }

        public string FechaEmision { get; set; }

        public decimal TotalDocumento { get; set; }




    }
}