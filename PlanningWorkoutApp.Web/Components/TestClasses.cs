namespace PlanningWorkoutApp.Web;


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
public class ExerciseInWorkout
{
    public string Name { get; set; }
    public int Repetitions { get; set; }
    public double Weight { get; set; }
}

