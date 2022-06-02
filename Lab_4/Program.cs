using System;
using System.Collections.Generic;

namespace Lab_4
{

    class Program
    {
        static void Main(string[] args)
        {
            Cinema florencia = new Cinema("12.03.2002", 150, 3);
            Console.WriteLine(florencia);
            Console.WriteLine("Дата побудови: " + florencia.Date);
            Console.WriteLine("Вартiсть квитка (пiльговий): " + florencia.CountPrice(100, 3));
            Console.WriteLine("Вартiсть квитка (звичайний): " + florencia.CountPrice(100, 30));
            Console.WriteLine("Мiсткiсть: " + florencia.capacity());

            Hotel California = new Hotel("15.04.1976", 400, 7);
            Console.WriteLine(California);
            Console.WriteLine("Дата побудови: " + California.Date);
            Console.WriteLine("Вартiсть оренди: " + California.CountRent(100, 3, 10));
            Console.WriteLine("Мiсткiсть: " + California.capacity());

            PublicBuilding museum = new PublicBuilding("23.08.1923", 200, 4);
            Console.WriteLine(museum);
            Console.WriteLine("Дата побудови: " + museum.Date);
            Console.WriteLine("Вартiсть квитка (звичайний): " + museum.CountPrice(50, 34));
            Console.WriteLine("Вартiсть квитка (пiльговий): " + museum.CountPrice(50, 84));
            Console.WriteLine("Мiсткiсть: " + museum.capacity());

            ResidentialBuilding house = new ResidentialBuilding("01.01.2012", 150, 20);
            Console.WriteLine(house);
            Console.WriteLine("Дата побудови: " + house.Date);
            Console.WriteLine("Вартiсть оренди: " + house.CountRent(150, 50, 30));
            Console.WriteLine("Мiсткiсть: " + house.capacity());

            List<Building> building_list = new List<Building> { florencia, California, museum};
            City misto = new City(building_list);
            misto.show_building();
            misto.add_building(house);
            misto.show_building();
            Console.WriteLine(misto.average_capacity());
        }
    }
}
