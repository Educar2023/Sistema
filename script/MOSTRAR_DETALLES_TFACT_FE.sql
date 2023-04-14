ALTER PROCEDURE [dbo].[MOSTRAR_DETALLES_TFACT_FE]      
@FE_AÑO CHAR(4),      
@FE_MES CHAR(2),      
@COD_SUCURSAL CHAR(4),      
@COD_CLASE CHAR(2),      
@COD_PER CHAR(5),      
@NRO_DOC VARCHAR(20),      
@COD_DOC CHAR(2) ,
@ORIGEN CHAR(1)     
AS  
IF @ORIGEN = 'I' 
	SELECT      
	[Codigo]=A.COD_ARTICULO,      
	[Descripcion]=isnull(B.DESC_ARTICULO,''),      
	[UnidadMedida]=isnull(b.UNIDAD_MEDIDA, ''),      
	[NumeroParte]=ISNULL(B.NRO_PARTE,''),      
	[Cantidad]=A.CANTIDAD,      
	[ValorUnitario]=a.precio_unitario,      
	[CodigoPrecio]=ISNULL(A.COD_PRECIO_VTA_FE,''),      
	[PorcentajeIGV]=A.POR_IGV,      
	[ValorIGV]=A.VALOR_IGV,      
	[ValorDCTO]=A.VALOR_DSCTO,      
	[ValorVenta]=((A.VALOR_COMPRA+A.AJUSTE_BI)-VALOR_DSCTO),      
	[PrecioVenta]=(A.VALOR_COMPRA+A.AJUSTE_BI-VALOR_DSCTO)+(VALOR_IGV+AJUSTE_IGV),      
	[TipoAfectacion]=ISNULL(A.COD_TIPO_AFEC_IGV_FE,''),      
	[ValorReferecial]=ISNULL(A.VALOR_REFERENCIAL,'0'),      
	[ValorIGVReferecial]=ISNULL(A.VALOR_IGV_REF,'0'),      
	[Observacion]=ISNULL(A.OBSERVACION,'')   ,
	[UnidadMedidaSunat]=c.COD_SUNAT   
	FROM T_FACT_VTA A      
	LEFT JOIN ARTICULO B      
	ON A.COD_ARTICULO=B.COD_ARTICULO   
	LEFT JOIN [BD_GENERAL_COI]..UNIDAD_MEDIDA C
	ON C.CODIGO = B.UNIDAD_MEDIDA   
	WHERE      
	COD_SUCURSAL=@COD_SUCURSAL AND      
	COD_CLASE=@COD_CLASE AND      
	COD_DOC=@COD_DOC AND      
	NRO_DOC=@NRO_DOC AND      
	COD_PER=@COD_PER AND      
	FE_AÑO=@FE_AÑO AND      
	FE_MES=@FE_MES      
	ORDER BY A.COD_ARTICULO
ELSE
	SELECT      
	[Codigo]=A.COD_ARTICULO,      
	[Descripcion]=isnull(B.DESC_ARTICULO,''),      
	[UnidadMedida]=c.UNIDAD_MEDIDA,      
	[NumeroParte]='',      
	[Cantidad]=A.CANTIDAD,      
	[ValorUnitario]=a.precio_unitario,      
	[CodigoPrecio]=ISNULL(A.COD_PRECIO_VTA_FE,''),      
	[PorcentajeIGV]=A.POR_IGV,      
	[ValorIGV]=A.VALOR_IGV,      
	[ValorDCTO]=A.VALOR_DSCTO,      
	[ValorVenta]=((A.VALOR_COMPRA+A.AJUSTE_BI)-VALOR_DSCTO),      
	[PrecioVenta]=(A.VALOR_COMPRA+A.AJUSTE_BI-VALOR_DSCTO)+(VALOR_IGV+AJUSTE_IGV),      
	[TipoAfectacion]=ISNULL(A.COD_TIPO_AFEC_IGV_FE,''),      
	[ValorReferecial]=ISNULL(A.VALOR_REFERENCIAL,'0'),      
	[ValorIGVReferecial]=ISNULL(A.VALOR_IGV_REF,'0'),      
	[Observacion]=ISNULL(A.OBSERVACION,''),
	[UnidadMedidaSunat]='ZZ'
	FROM T_FACT_VTA A      
	LEFT JOIN ARTICULO_SERVICIO B      
	ON A.COD_SUCURSAL = B.COD_SUCURSAL
	AND A. COD_PER = B.COD_PER
	AND A.COD_CLASE = B.COD_CLASE
	AND A.FE_AÑO = B.FE_AÑO
	AND A.FE_MES = B.FE_MES
	AND A.NRO_PEDIDO = B.NRO_DOC
	AND CAST(A.ITEM AS INT) = CAST(B.ITEM AS INT) 
	AND B.TIPO_DOC = 'S' 
	AND B.COD_DOC =  '04'  
	LEFT JOIN ARTICULO C
	ON    C.COD_ARTICULO = B.COD_ARTICULO
	LEFT JOIN [BD_GENERAL_COI]..UNIDAD_MEDIDA D
	ON D.CODIGO = C.UNIDAD_MEDIDA
	WHERE      
	A.COD_SUCURSAL=@COD_SUCURSAL AND      
	A.COD_CLASE=@COD_CLASE AND      
	A.COD_DOC=@COD_DOC AND      
	A.NRO_DOC=@NRO_DOC AND      
	A.COD_PER=@COD_PER AND      
	A.FE_AÑO=@FE_AÑO AND      
	A.FE_MES=@FE_MES      
	ORDER BY A.COD_ARTICULO

	--SELECT * FROM ARTICULO_SERVICIO

	--SP_HELPTEXT MOSTRAR_TFACT_VTA_SER


