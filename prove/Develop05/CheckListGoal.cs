namespace goal_assignment
{
    public class CheckListGoal : Goal
    {
        private int _bonusPoints;
        private int _times;
        private int _done;
        public CheckListGoal() : base() { }
        public CheckListGoal(string name, string desc, int points) : base(name, desc, points) { }
        public override void Display()
        {
            string status = "[ ]";
            if (_done >= _times && _times > 0)
                status = "[X]";
            else if (_done > 0)
                status = $"[{_done}]";
            Console.WriteLine($"{status} {_name}, {_desc}, {_points} points, Completed {_done}/{_times} times, Bonus: {_bonusPoints}");
        }
        public void SetTimes(int times)
        {
            _times = times;
        }
        public void SetBonus(int bonus)
        {
            _bonusPoints = bonus;
        }
        public int RecordEvent()
        {
            _done++;
            int earned = _points;
            if (_done >= _times && _times > 0)
            {
                earned += _bonusPoints;
                Console.WriteLine("Checklist goal completed!");
            }
            return earned;
        }
        public string GetStringRepresentation()
        {
            return $"CheckListGoal:{_name}|{_desc}|{_points}|{_times}|{_done}|{_bonusPoints}";
        }
        public void SetDone(int done)
        {
            _done = done;
        }
    }
}