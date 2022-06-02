using System;
using System.Collections.Generic;


public interface IRent
{
	public int CountRent(int price, int quantity, int days);
}

public interface ITicket
{
	public int CountPrice(int price, int customer_age);
}

public abstract class Building
{
	public string Date { get; set; }
	public int Square { get; set; }
	public int Floors { get; set; }
	public Building(string date, int square, int floors)
	{
		this.Date = date;
		this.Square = square;
		this.Floors = floors;
	}

	public abstract int capacity();
}

public class PublicBuilding: Building, ITicket
{

	public PublicBuilding(string date, int square, int floors): base(date, square, floors) {}

	public int CountPrice(int price, int customer_age) 
	{
		if (customer_age <= 6 || customer_age >= 60) 
		{
			return price/2;
		}
		return price;
	}

	public override int capacity()
	{
		return (this.Square * this.Floors) / 5;
	}
}

public class ResidentialBuilding: Building, IRent
{
	public ResidentialBuilding(string date, int square, int floors) : base(date, square, floors) { }

	public int CountRent(int price_per_meter, int square, int days) 
	{
		return price_per_meter * square * days;
	}

	public override int capacity()
	{
		return (this.Square * this.Floors) / 8;
	}
}

public class Cinema: PublicBuilding, ITicket
{
	public Cinema(string date, int square, int floors) : base(date, square, floors) { }
	public int Price { get; set; }

	public override int capacity()
	{
		return (this.Square * this.Floors) / 4;
	}

}

public class Hotel: ResidentialBuilding, IRent
{
	public Hotel(string date, int square, int floors) : base(date, square, floors) { }

	public override int capacity()
	{
		return (this.Square * this.Floors) / 7;
	}
}

public class City 
{
	public List<Building> Buildings;
	public City(List<Building> building_list) 
	{
		this.Buildings = building_list;
	}

	public void add_building(Building building) 
	{
		Buildings.Add(building);
	}

	public void show_building()
	{
		foreach (Building b in Buildings)
		{
			Console.WriteLine(b);
		}
	}

	public void average_capacity() 
	{
		int cinema_sum = 0;
		int cinema_count = 0;
		int hotel_sum = 0;
		int hotel_count = 0;
		int public_sum = 0;
		int public_count = 0;
		int residental_sum = 0;
		int residental_count = 0;
		foreach (Building b in Buildings)
		{
			if (b is Cinema) 
			{ 
				cinema_sum += b.capacity();
				cinema_count += 1;
			}
			if (b is Hotel)
			{
				hotel_sum += b.capacity();
				hotel_count += 1;
			}

			if (b is PublicBuilding)
			{
				public_sum += b.capacity();
				public_count += 1;
			}

			if (b is ResidentialBuilding)
			{
				residental_sum += b.capacity();
				residental_count += 1;
			}

		}
		if (cinema_count != 0)
		{
			Console.WriteLine("Cередня ємність кінотеатрів: " + cinema_sum / cinema_count);
		}
		if (public_count != 0)
		{
			Console.WriteLine("Cередня ємність громадських будівель: " + public_sum/public_count);
		}
		if (residental_count != 0)
		{
			Console.WriteLine("Cередня ємність всіх житлових будівель: " + residental_sum/residental_count);
		}
		if (hotel_count != 0)
		{
			Console.WriteLine("Cередня ємність всіх готелів: " + hotel_sum/hotel_count);
		}
	}
}