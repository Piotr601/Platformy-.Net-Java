﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorCS;

namespace Zadanie01
{

    class Program
    {
        static void Main(string[] args)
        {
        // Wczytywanie danych
            Console.WriteLine("Podaj ile obiektow chcesz wylosowac:");
            int obiekty = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj limit plecaka");
            int pojemnosc = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj dowolny seed:");
            int seed = int.Parse(Console.ReadLine());

        // Tworzymy nowy obiekt
            RandomNumberGenerator rng = new RandomNumberGenerator(seed);

            Console.WriteLine();
            Console.WriteLine("PROGRAM:");
        
        // Zdefiniowanie tablic i zmiennych
            int pom = 0;
            int[] wartosc = new int[obiekty];
            int[] waga = new int[obiekty];

        // Losujemy obiekty: wartosc i wage
            for (int i=0; i<obiekty; i++)
            {
                wartosc[i] = rng.nextInt(1, 50);
                waga[i] = rng.nextInt(1, 30);

                Console.WriteLine("{0:D}, {1:D}", wartosc[i], waga[i]);
                
             /*
              * TEST
              * Sprawdzenie czy cokolwiek zmieści się do plecaka
             */ 
                if (wartosc[i] > pojemnosc)
                {
                    pom++;
                    if(pom==obiekty)
                    { 
                        Console.WriteLine("Brak rozwiazan");
                        break;
                    }
                }
            }

        // Sortowanie po najwiekszej wartosci
            int pom2;
            for (int j = 0; j < obiekty; j++)
            {
                for (int i = 0; i < obiekty; i++)
                {
                    if (wartosc[i] < wartosc[j])
                    {
                        pom2 = wartosc[i];
                        wartosc[i] = wartosc[j];
                        wartosc[j] = pom2;

                        pom2 = waga[i];
                        waga[i] = waga[j];
                        waga[j] = pom2;
                    }
                    else if(wartosc[i] == wartosc[j])
                    {
                        if(waga[i] > waga[j])
                        {
                            pom2 = wartosc[i];
                            wartosc[i] = wartosc[j];
                            wartosc[j] = pom2;

                            pom2 = waga[i];
                            waga[i] = waga[j];
                            waga[j] = pom2;
                        }
                    }
                }
            }

        /* CO TRZEBA PORPAWIC
            W SORTOWANIU:
                dla wartosci: 
                    10
                    32
                    323
                zrobic tak by jak sa takie same wartosci sortowalo sie jeszcze po wadze
        */

        // Wyswietlenie po sortowaniu
            Console.WriteLine();
            for(int i=0; i< obiekty; i++)
            {
                Console.WriteLine("{0:D}, {1:D}", wartosc[i], waga[i]);
            }

        // Sprawdzenie poprawnosci danych
            Console.WriteLine();
            Console.WriteLine("Sprawdzenie");
            Console.WriteLine("Obiekty = {0:D}", obiekty);
            Console.WriteLine("Pojemnosc = {0:D}", pojemnosc);
            Console.WriteLine("Seed = {0:D}", seed);

            Console.WriteLine("Koniec programu");
            Console.ReadLine();
        }
    }
}
