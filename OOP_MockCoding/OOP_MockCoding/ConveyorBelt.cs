namespace OOP_MockCoding
{
    internal class ConveyorBelt : Machine, IReportable
    {
        public ConveyorBelt(string name, string status) : base(name, status)
        {

        }
        public override void PerformMaintenance()
        {
            Console.WriteLine($"{Name} | Conveyor: กำลัง lubricate...");
        }
        public void GenerateReport()
        {
            Console.WriteLine($"Conveyor Report: {Name} checked");
        }
    }
}
