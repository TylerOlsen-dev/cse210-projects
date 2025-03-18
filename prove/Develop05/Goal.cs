namespace goal_assignment
{
    public abstract class Goal
    {
        protected string _name;
        protected string _desc;
        protected int _points;
        public Goal() { }
        public Goal(string name, string desc, int points)
        {
            _name = name;
            _desc = desc;
            _points = points;
        }
        public abstract void Display();
        public string GetName() => _name;
    }
}