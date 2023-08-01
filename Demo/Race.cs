class Race
{
    Car[] _cars;
    float _distance;

    public Race(Car[] cars, float distance)
    {
        _cars = cars;
        _distance = distance;
    }

    public RaceResults DragRace()
    {
        Car[] cars = new Car[_cars.Length];
        _cars.CopyTo(cars, 0);

        var results = new RaceResults(_cars.Length);
        int timer = 0;
        int finishedCars = 0;

        while (finishedCars < cars.Length)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                timer++;
                var context = cars[i];

                if (context == null)
                    continue;

                context.Drive();

                if (CarFinished(context))
                {
                    results.AddFinished(context, timer);
                    finishedCars++;
                    cars[i] = null;
                }
            }
        }

        return results;
    }

    public bool CarFinished(Car car)
    {
        return car.DistanceTraveled >= _distance;
    }
}