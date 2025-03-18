namespace goal_assignment
{
    public class SimpleGoal : Goal
    {
        private bool _completed;
        public SimpleGoal() : base() { _completed = false; }
        public SimpleGoal(string name, string desc, int points) : base(name, desc, points) { _completed = false; }
        public override void Display()
        {
            string status = _completed ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {_name}, {_desc}, {_points} points");
        }
        public int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return _points;
            }
            else
            {
                Console.WriteLine("This goal is already completed.");
                return 0;
            }
        }
        public string GetStringRepresentation()
        {
            return $"SimpleGoal:{_name}|{_desc}|{_points}|{_completed}";
        }
        public void MarkComplete()
        {
            _completed = true;
        }
    }
}