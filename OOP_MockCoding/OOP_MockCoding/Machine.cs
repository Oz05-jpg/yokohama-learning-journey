namespace OOP_MockCoding
{
    abstract class Machine
    {
        public string Name { get; }
        public string Status { get; }

        public Machine(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public virtual void GetStatus()
        {
            Console.WriteLine($"Machine:{Name}|Status:{Status}");
        }

        public abstract void PerformMaintenance();
    }


}
