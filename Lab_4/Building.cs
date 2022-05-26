using System;


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

public class Cinema: Building, ITicket
{
	public Cinema(string date, int square, int floors) : base(date, square, floors) { }
	public int Price { get; set; }

	public int CountPrice(int price, int customer_age)
	{
		if (customer_age <= 6 || customer_age >= 60)
		{
			return (price*8)/10;
		}
		return price;
	}

	public override int capacity()
	{
		return (this.Square * this.Floors) / 4;
	}

}

public class Hotel: Building, IRent
{
	public Hotel(string date, int square, int floors) : base(date, square, floors) { }

	public int CountRent(int price_per_room, int number_of_rooms, int days) 
	{
		return price_per_room * number_of_rooms * days;
	}

	public override int capacity()
	{
		return (this.Square * this.Floors) / 7;
	}
}
