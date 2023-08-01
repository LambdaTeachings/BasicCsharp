class Program
{
    public static void Main()
    {
        // we convert km/h to m/s by dividing by 3.6
        Car c = new Car(new Engine(15 / 3.6f, 100 / 3.6f), "Agile");
        Car c2 = new Car(new Engine(7 / 3.6f, 140 / 3.6f), "Heavy");

        Car[] cars = { c, c2 };
        // try changing the distance to 2000m to see who wins
        var race = new Race(cars, 1000);
        race.DragRace().PrintResults();

        Console.ReadLine();
    }
}