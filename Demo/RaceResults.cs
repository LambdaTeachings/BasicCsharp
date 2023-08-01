class RaceResults
{
    CarFinishRaceData[] _cars;
    int _index = 0;

    public RaceResults(int numberOfCars)
    {
        _cars = new CarFinishRaceData[numberOfCars];
    }

    public void AddFinished(Car car, int finishTime)
    {
        _cars[_index] = new CarFinishRaceData(car, finishTime);
        _index++;
    }

    public void PrintResults()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            var car = _cars[i];
            if (car == null)
                continue;

            Console.WriteLine($"Car {car.Car.Name} finished in {car.FinishTime} seconds");
        }
    }
}
