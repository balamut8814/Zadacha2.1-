﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha2._1
{
    class circle //Объявляем класс "круг"
    {
        private int r; //Приватная переменная - радиус
        private int[] center = new int[2]; //Приватная переменная - массив с координатами центра
        private double l, s; //Приватные переменные - длина окружности и площадь круга

        public circle(int rad, int x, int y) //Конструктор класса, принимает радиус и координаты центра
        {
            r = rad; //Копируем радиус
            l = 2 * Math.PI * r; //Вычисляем длину окружности
            s = Math.PI * Math.Pow(r, 2); //Вычисляем площадь круга
            center[0] = x; //Присваиваем координату X
            center[1] = y; //Присваиваем координату Y
            Console.Write("Длина окружности: {0}\n", l); //Выводим длину окружности
            Console.Write("Площадь круга: {0}\n", s); //Выводим площадь круга
        }

        public void intersections() //Функция класса - определяем пересечения с осями координат
        {
            if (center[0] == 0) //Если координата X центра равна нулю
            {
                Console.Write("Центр лежит на оси X\n"); //То центр лежит на оси X
            }
            else if (center[0] > 0 && (center[0] - r) <= 0) //Если центр правее оси X и координата X-радиус меньше 0
            {
                Console.Write("Есть пересечение с осью X\n"); //То пересечение
            }
            else if (center[0] < 0 && (center[0] + r) >= 0) //Если центр левее оси X и координата X+радиус больше 0
            {
                Console.Write("Есть пересечение с осью X\n"); //То пересечение
            }

            if (center[1] == 0) //Если координата Y центра равна нулю
            {
                Console.Write("Центр лежит на оси Y\n"); //То центр лежит на оси Y
            }
            else if (center[1] > 0 && (center[1] - r) <= 0) //Если центр выше оси Y и координата Y-радиус меньше 0
            {
                Console.Write("Есть пересечение с осью Y\n"); //То пересечение
            }
            else if (center[1] < 0 && (center[1] + r) >= 0) //Если центр ниже оси Y и координата Y+радиус больше 0
            {
                Console.Write("Есть пересечение с осью Y\n"); //То пересечение
            }
        }

        public double lenght(int k, int b) //Функция класса - определяем длину отрезка прямой, проходящей сквозь окружность
        { //Принимаем k и b функции прямой y = k*x + b
            int d = 4 * ((int)Math.Pow(r, 2) * (1 + (int)Math.Pow(k, 2)) - (int)Math.Pow(b, 2)); //Магия геометрии, определяем, есть ли пересечения и сколько
            if (d < 0) //Если пересечений нет
                return 0; //Возвращаем из функции ноль

            if (d == 0) //Если прямая проходит по касательной
                return 0; //Возвращаем из функции ноль

            double x1 = (-2 * k * b + Math.Sqrt(d)) / (2 * (1 + Math.Pow(k, 2))); //Магия геометрии - рассчитываем координату X первой точки отрезка
            double x2 = (-2 * k * b - Math.Sqrt(d)) / (2 * (1 + Math.Pow(k, 2))); //Магия геометрии - рассчитываем координату X второй точки отрезка
            double y1 = k * x1 + b; //Магия геометрии - рассчитываем координату Y первой точки отрезка
            double y2 = k * x2 + b; //Магия геометрии - рассчитываем координату Y второй точки отрезка

            double len = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); //Магия геометрии - находим длину отрезка

            return len; //Возвращаем длину отрезка

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите координаты центра и радиус окружности:\n"); //Просим координаты центра окружности и ее радиус
            int x, y, r; //Объявляем под них переменные
            x = Convert.ToInt32(Console.ReadLine()); 
            y = Convert.ToInt32(Console.ReadLine()); 
            r = Convert.ToInt32(Console.ReadLine()); 
            circle t = new circle(r, x, y); //Создаем объект "круг", используя созданный нами конструктор
            t.intersections(); //Проверяем на пересечения с осями
            Console.Write("Введите k и b прямой:\n"); //Просим k и b прямой
            x = Convert.ToInt32(Console.ReadLine()); //Получаем их
            y = Convert.ToInt32(Console.ReadLine());
            double d; //Создаем вещественную переменную под длину отрезка
            if ((d = t.lenght(x, y)) != 0) //Вызываем функцию по рассчету длины и сразу проверяем на ноль
                Console.Write("Длина отрезка внутри окружности: {0}\n", Math.Round(d, 2)); //Если не ноль - выводим, округлив до двух знаков после запятой
            else
                Console.Write("Прямая не пересекает окружность или лишь касается ее\n"); //А если ноль - выводим, что не пересекает или лишь касается
            Console.ReadKey();
        }
    }
}