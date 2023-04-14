ALTER PROCEDURE [dbo].[MOSTRAR_IFACT_VTA_FE_PENDIENTE]          
AS          
SELECT          
[Cod. Suc.]= A.COD_SUCURSAL,          
[Sucursal]= B.DESC_SUCURSAL,          
[Cod. Clase]= A.COD_CLASE,          
[Clase]= C.DESC_CLASE,          
[Cod. Doc.]= A.COD_DOC,          
[Nro. Doc.]= A.NRO_DOC,          
[Fecha Doc.]= A.FECHA_DOC,          
[Cod. Cliente]= A.COD_PER,          
[Desc. Cliente]= D.DESC_PER,          
[Doc. Cliente]= A.NRO_DOC_PER,          
[Cod. Moneda]= F.COD_INTERNACIONAL,          
[Moneda]=F.Desc_moneda,          
[Observacion]= A.OBSERVACION,          
[Año]= A.FE_AÑO,          
[Mes]= A.FE_MES,          
[Tipo]= '01' + ISNULL(A.TIPO_OPERACION_FE,''),          
[Cod. Ref.]= ISNULL(A.COD_REF,''),          
[Nro. Ref.]= ISNULL(A.NRO_REF,''),          
[Fec. Ref.]= ISNULL(A.FECHA_REF,''),          
[Condicion]= CASE WHEN ISNULL(G.DESC_TIPO,'') = '' THEN (SELECT TOP 1 DESC_TIPO FROM BD_GENERAL_COI.dbo.CONDICION_VENTA WHERE COD_TIPO =  A.CONDICION_VENTA) ELSE ISNULL(G.DESC_TIPO,'')  END,          
[Forma Pago]= CASE WHEN ISNULL(H.DESC_TIPO,'') = '' THEN (SELECT TOP 1 DESC_TIPO FROM BD_GENERAL_COI.dbo.FORMAS_PAGO WHERE COD_TIPO = A.FORMA_PAGO ) ELSE  ISNULL(H.DESC_TIPO,'') END ,          
[Nro. Ped.]= ISNULL(E.NRO_DOC,''),          
[Origen]=ISNULL(A.TIPO_FACT,''),          
[Nro. Guia]=ISNULL(A.NRO_GUIA,''),          
ROW_NUMBER()  OVER(ORDER BY A.COD_SUCURSAL ASC) Id    ,      
A.COD_MOT_DEV,
a.POR_DETRACCION,
a.VALOR_DETRACCION  ,
a.MEDIO_PAGO_DETRACCION       
FROM I_FACT_VTA A          
LEFT JOIN SUCURSAL B          
ON A.COD_SUCURSAL=B.COD_SUCURSAL          
LEFT JOIN CLASE_ARTICULO C          
ON A.COD_CLASE=C.COD_CLASE          
LEFT JOIN MAESTRO_PERSONAS D          
ON A.COD_PER=D.COD_PER          
LEFT JOIN I_PEDIDO E          
ON A.COD_SUCURSAL=E.COD_SUCURSAL AND          
A.COD_CLASE=E.COD_CLASE AND A.NRO_PEDIDO=E.NRO_DOC          
AND E.STATUS_NC = 0        
AND A.COD_PER = E.COD_PER          
LEFT JOIN BD_General_Coi.dbo.MONEDA F          
ON A.COD_MONEDA=F.Cod_moneda LEFT JOIN BD_GENERAL_COI.dbo.CONDICION_VENTA G          
ON E.CONDICION_VENTA=G.COD_TIPO LEFT JOIN BD_GENERAL_COI.dbo.FORMAS_PAGO H          
ON E.FORMA_PAGO=H.COD_TIPO          
WHERE          
ISNULL(A.STATUS_FE,'0')='1' AND ISNULL(A.STATUS_ENVIO_FE,'0')='0'          
AND ISNULL(A.STATUS_ANUL,'0')=0          
AND A.COD_DOC IN ('01','07','08')      
AND (A.COD_REF IS NULL OR A.COD_REF IN ('01',''))      
ORDER BY A.COD_DOC, A. NRO_DOC      
  


  