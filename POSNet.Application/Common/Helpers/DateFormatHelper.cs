using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace POSNet.Application.Common.Helpers
{
    public static class DateFormatHelper
    {
        public static string[] getMonths(List<ResumenVentasDTO> resumenVentas)
        {

            string[] months = new string[12];

            int contador = 0;

            for (int i = 0; i < resumenVentas.Count; i++)
            {
                TimeOnly timeOnly = TimeOnly.MinValue;
                DateTime tempDate = resumenVentas[i].Fecha.ToDateTime(timeOnly);

                var month = tempDate.ToString("MM");

                if (months.Contains(month))
                {  //si existe entonces no lo agrego

                }
                else
                {//si no existe entonces agregarlo y sumar +1 a la variable contador
                 //Console.WriteLine($"Fecha: {tempDate.ToString("MM")}");
                    months[contador] = tempDate.ToString("MM");
                    contador++;
                }
            }

            string[] arr_result = new string[contador];
            for (int i = 0; i < contador; i++)
            {
                arr_result[i] = months[i];
            }


            return arr_result;
        }

        public static List<ResumenVentasDTO> formatSalesResume(string[] months, List<ResumenVentasDTO> resumenVentas)
        {
            decimal ingresos = 0;
            decimal ventass = 0;
            DateOnly fecha = DateOnly.FromDateTime(DateTime.Now);

            List<ResumenVentasDTO> listVentas = new List<ResumenVentasDTO>();

            foreach (var item in months)
            {
                for (int i = 0; i < resumenVentas.Count; i++)
                {

                    TimeOnly timeOnly = TimeOnly.MinValue;
                    DateTime tempDate = resumenVentas[i].Fecha.ToDateTime(timeOnly);
                    var date = tempDate.ToString("MM");

                    if (item == date)
                    {
                        ingresos += resumenVentas[i].Ingresos;
                        ventass += resumenVentas[i].Ventas;
                        fecha = resumenVentas[i].Fecha;
                    }
                }

                var objventa = new ResumenVentasDTO()
                {
                    Ingresos = ingresos,
                    Ventas = ventass,
                    Fecha = fecha
                };
                listVentas.Add(objventa);
                ingresos = 0;
                ventass = 0;

            }

            return listVentas;

        }
    }
}
