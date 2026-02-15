using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Shared summary method
    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.00} miles, " +
               $"Speed {GetSpeed():0.00} mph, " +
               $"Pace: {GetPace():0.00} min per mile";
    }
}
