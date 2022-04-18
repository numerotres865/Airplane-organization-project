using System;

namespace Test1_proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            float tiempoperf = 0;
            float tiempoback = 0;
            int[,] aeroplano = new int[44, 5];
            int[] pasajeros = new int[88];
            bool[] maleta = new bool[88];
            int baggage;
            float maxperf=-1, minperf=20000, maxback=-1, minback=20000,promedioperf,promedioback;
            Random bag = new Random();

            //for para entrar datos
            for (int i = 1; i < 89; i++)
            {

                pasajeros[i-1] = i;
                baggage = bag.Next(2);
                if (baggage == 1)
                {
                    maleta[i-1] = true;
                }
                else
                {
                    maleta[i - 1] = false;
                }
            }
            //test perf
            {

                for (int i = 0; i < 61; i++)
                {
                    tiempoperf = 0;
                    for (int j = 1; j < 9; j++)
                    {
                        tiempoperf = tiempoperf + perfectmethod(j, aeroplano, pasajeros, maleta);
                    }
                    if (tiempoperf < minperf)
                        minperf = tiempoperf;
                    if (tiempoperf > maxperf)
                        maxperf = tiempoperf;
                }
                
                Console.WriteLine("---------------PERFECT METHOD-------------------");
                print(aeroplano);
            }
            //test back
            {
                for (int l = 0; l < 60; l++)
                {
                    tiempoback = tiempoback + backtofront(aeroplano, pasajeros, maleta);
                    if (tiempoback < minback)
                        minback = tiempoback;
                    if (tiempoback > maxback)
                        maxback = tiempoback;
                    tiempoback = 0;
                }
            }
            Console.WriteLine("---------------BACK TO FRONT METHOD-------------------");
            print(aeroplano);
            Console.WriteLine("-----------------------------");
            
            //Calculo en minutos del perfecto
            
            maxperf = maxperf / 60;     //Pasar de segundos a minutos
            maxperf = (float)Math.Round(maxperf * 100f) / 100f;     //Redondear a 2 cifras
            minperf = minperf / 60;     //Pasar de segundos a minutos
            minperf = (float)Math.Round(minperf * 100f) / 100f;     //Redondear a 2 cifras
            promedioperf = (maxperf + minperf) / 2;
            promedioperf = (float)Math.Round(promedioperf * 100f) / 100f;
            Console.WriteLine("-Metodo perfecto (minutos) -\n"+ "Tiempo Minimo (Omega): "+minperf+" - Tiempo Maximo (Big O): "+maxperf+ " - Tiempo promedio (Theta): "+promedioperf);
            
            Console.WriteLine("-------------------------------------------------------------------------------------");

            //Calculo en minutos del back to front

            maxback = maxback / 60;     //Pasar de segundos a minutos
            maxback = (float)Math.Round(maxback * 100f) / 100f;     //Redondear a 2 cifras
            minback = minback / 60;     //Pasar de segundos a minutos
            minback = (float)Math.Round(minback * 100f) / 100f;     //Redondear a 2 cifras
            promedioback = (maxback + minback) / 2;
            promedioback = (float)Math.Round(promedioback * 100f) / 100f;
            Console.WriteLine("-Metodo Back to Front (minutos) -\n" + "Tiempo Minimo (Omega): " + minback + " - Tiempo Maximo (Big O): " + maxback + " - Tiempo promedio (Theta): " + promedioback);
        }

        public static void print(int[,] xd)
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 2)
                    {
                        Console.Write("|  | ");
                    }
                    else
                    {
                        if (xd[i, j] < 10)
                        {
                            Console.Write(xd[i, j] + "  ");
                        }
                        else
                            Console.Write(xd[i, j] + " ");
                    }

                }
                Console.WriteLine();
            }
        }


        public static float perfectmethod(int x, int[,] avioneta, int[] nombres, bool[] luggage)
        {
            Random loquera = new Random();
            int temp = 0;
            int pasos = 0;
            int count = 0, Count = 0;
            switch (x)
            {
                case 1:
                    pasos = 1;
                    for (int i = 0; i < 11; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 0] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 2:
                    pasos = 1;
                    for (int i = 11; i < 22; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 4] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 3:
                    pasos = 0;
                    for (int i = 22; i < 33; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 0] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 4:
                    pasos = 0;
                    for (int i = 33; i < 44; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 4] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 5:
                    pasos = 1;
                    for (int i = 44; i < 55; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 1] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 6:
                    pasos = 1;
                    for (int i = 55; i < 66; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 3] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 7:
                    pasos = 0;
                    for (int i = 66; i < 77; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 1] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;

                case 8:
                    pasos = 0;
                    for (int i = 77; i < 88; i++)
                    {
                        if (luggage[i] == true)
                        {
                            count = count + 1 + loquera.Next(15, 60);
                        }

                        avioneta[pasos, 3] = nombres[i];
                        pasos = pasos + 2;
                    }
                    Count = Count + count;
                    break;


            }
            temp = Count + pasos;
            return temp;
        }
        public static float backtofront(int[,] avioneta, int[] nombres, bool[] luggage)
        {
            Random loquera = new Random();
            int temp;
            int pasos = 0;
            int count = 0;
            int casito = 0;
            int k = 0;
            for (int i = 21; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (casito)
                    {

                        case 0:
                            if (luggage[k] == true)
                            {
                                count = count + loquera.Next(15, 60);
                            }
                            pasos = pasos + i + 1;
                            avioneta[i, casito] = nombres[k];
                            k++;
                            casito = 4;
                            break;
                        case 4:
                            if (luggage[k] == true)
                            {
                                count = count + loquera.Next(15, 60);
                            }
                            pasos = pasos + i + 1;
                            avioneta[i, casito] = nombres[k];
                            k++;
                            casito = 1;
                            break;

                        case 1:
                            if (luggage[k] == true)
                            {
                                count = count + loquera.Next(15, 60);
                            }

                            pasos = pasos + i + 1;
                            avioneta[i, casito] = nombres[k];
                            k++;
                            casito = 3;
                            break;

                        case 3:
                            if (luggage[k] == true)
                            {
                                count = count + loquera.Next(15, 60);
                            }

                            pasos = pasos + i + 1;
                            avioneta[i, casito] = nombres[k];
                            k++;
                            casito = 0;
                            break;
                    }
                }

            }
            temp = count + pasos;
            return temp;

        }
    }
}