using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio2
{
    public static class Global
    {
        public const string Version = "1.2.20201126";//Se cambia los valores a mostrar despues de tope de consulta. Se usa valor exedente por practica unitaria. Se habilita consulta complejidad 4 (inventada = alergias), Se arregla BUG en monotributista
        //public const string Version = "1.2.20200119";//Se arreglan BUGs de suma de subpracticas repetidas agrupadas en distintas complejidades. Se arregla consulta erronea en alta complejidad.
        //public const string Version = "1.2.20200117";//Se arreglan 2 BUGs de practicas iguales, con subpracticas distintas no sumaba correctamente y prestaciones de distintas complejidades y subprestaciones repetidas no sumaban correctamente.
        //public const string Version = "1.2.20200115";//Se agrega logica costo de atencion por guardia y Se modifica la tabla ([Hospital].[dbo].[ValoresMonotributoLabo] para costo monotributo) y ([Hospital].[dbo].[ValoresRGLabo] para el costo afiliado comun)
        //Version = "1.2.20191111";//se agrego el modulo presupuesto y la agrupacion de practica de la complejidad 4
        //"1.2.20190923";//se agrego la agrupacion de practicas segun su complejidad para el afiliado en general  
        //Version = "1.2.20190415";//se agrego la agrupacion de practicas segun su complejidad para monotributistas 
        //;"1.2.20190415"
        //"1.2.20180612" No traia los valores de las practicas por nuevo nomneclador se modifico H3_ValorBono_x_Practica en el archivo BonoDAL se agrego "where convenioId = @Convenio" 
        //1.2.20180612 No se genera mas el CUIL de manera automatica
        //1.2.20180608 String Conexion
        //1.2.20180606 Evita DNI Duplicados
        //1.2.20171004 HC Obligatorio.
        //1.2.20170926 Si el estudio es ambulatorio y la fecha es un feriado no deja continuar.
        //1.2.20170906 Arreglo de Redondeo en monotributista
        //1.2.20170904 Arreglo de Redondeo 49.99999 a 50.
        //1.2.20170831 Aumento de precios un 20% en guardia, pasa de $10 a $12.
        //1.2.20170815 Cambio Bug.
        //1.2.20170712 Se cambiar el servidor de codigo QR del 10.10.8.72 al 10.10.8.76.
        //1.2.20161207 A pedido de Paula se expande el tiempo de cierre automático a 50 min.
        //1.2.20161201 Se agrega un cierre del aplicativo de manera automática a los 15 min. También se almacena el usuario en [Estadisticas].[dbo].[Usuarios]
        //1.2.20161103 Salia mal el monto, o sea se copiaba del anterior cuando era derivacion.
        //1.2.20160826 Se modifica una parte del código para que al emitir el bono este sea usado
        //1.2.20160720 Se acomoda el código para que se pueda obtener el monto del último valor de facturación.
        //1.2.20160516 Se le agrega el código QR para la web.
        //1.2.20160418 Se le quita la imagen de fondo en los bonos (Pedido por Menzio)
        //1.2.20160329 Se agrega la opción de cargar monotributistas con el cuit 88888888888 y se agregó la foto del policlínico en los bonos.
        //1.2.20160204 Se agrega por codigo (63) al usuario Cristian Coll para que pueda editar las practicas.
        //1.2.20160114 Se corrige un tema de la fecha de discapacidad nula.
        //1.2.20151028 Se Agrega un nivel para administrar las practicas, es el |9924|....
        //1.2.20151002 Cambios en el sistema, agregado de observaciones, monto en la hoja de impresion.
        //1.2.20151001 Modulo de Bono y cambio de fecha de entrega una vez ingresado.
        //1.1.20150601 Se agregar UTI para San Martin (80).
        //1.1.20150409 Se le quita UTI por que se confunden en la guardia.
    }
}
