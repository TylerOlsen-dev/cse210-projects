namespace goal_assignment
{
    public class EternalGoal : Goal
    {
        private int _recordCount;
        public EternalGoal() : base() { _recordCount = 0; }
        public EternalGoal(string name, string desc, int points) : base(name, desc, points) { _recordCount = 0; }
        public EternalGoal(string name, string desc, int points, int recordCount) : base(name, desc, points)
        {
            _recordCount = recordCount;
        }
        public override void Display()
        {
            string status = _recordCount > 0 ? $"[{_recordCount}]" : "[ ]";
            Console.WriteLine($"{status} {_name}, {_desc}, {_points} points");
        }
        public int RecordEvent()
        {
            _recordCount++;
            return _points;
        }
        public string GetStringRepresentation()
        {
            return $"EternalGoal:{_name}|{_desc}|{_points}|{_recordCount}";
        }
    }
}