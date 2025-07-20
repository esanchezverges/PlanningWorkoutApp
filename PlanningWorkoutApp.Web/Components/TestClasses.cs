namespace PlanningWorkoutApp.Web;

public class Workout
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<IWorkoutSet> Sets { get; set; }
    public string IdForUserAsigned { get; set; }
    public Workout() { }
    public Workout(string title, string description)
    {
        Title = title;
        Description = description;
    }
}

public class ExerciseData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string BodyPart { get; set; }
    public string Equipment { get; set; }
    public string TargetMuscle { get; set; }
    public string ImageUrl { get; set; }
    public string VideoUrl { get; set; }
}

public enum WorkoutSetType
{
    Weighted,
    Timed
}

public interface IWorkoutSet
{
    int SetNumber { get; }
    TimeSpan Rest { get; }
    WorkoutSetType SetType { get; }
}

public abstract class WorkoutSet : IWorkoutSet
{
    public int SetNumber { get; init; }
    public TimeSpan Rest { get; set; }
    public string Notes { get; set; }

    public abstract WorkoutSetType SetType { get; }

    protected WorkoutSet(int setNumber, TimeSpan rest)
    {
        SetNumber = setNumber;
        Rest = rest;
    }
}

public class WeightedSet : WorkoutSet
{
    public float Weight { get; set; }
    public int Repetitions { get; set; }

    public override WorkoutSetType SetType => WorkoutSetType.Weighted;

    public WeightedSet(int setNumber, TimeSpan rest, float weight, int repetitions)
        : base(setNumber, rest)
    {
        Weight = weight;
        Repetitions = repetitions;
    }
}

public class TimedSet : WorkoutSet
{
    public TimeSpan Duration { get; set; }

    public override WorkoutSetType SetType => WorkoutSetType.Timed;

    public TimedSet(int setNumber, TimeSpan rest, TimeSpan duration)
        : base(setNumber, rest)
    {
        Duration = duration;
    }
}

public class ExerciseInWorkout<TSet> where TSet : IWorkoutSet
{
    public string Name { get; init; } = string.Empty;
    public List<TSet> Sets { get; init; } = new();
    public WorkoutSetType WorkoutSetType { get; init; }
}
