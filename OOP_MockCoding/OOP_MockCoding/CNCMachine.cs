namespace OOP_MockCoding
{
    internal class CNCMachine : Machine, IReportable
    {
        public CNCMachine(string name, string status) : base(name, status)
        {

        }

        public override void PerformMaintenance()
        {
            Console.WriteLine($"CNC: กำลัง calibrate...");
        }

        public void GenerateReport()
        {
            Console.WriteLine($"CNC Report: {Name} checked");
        }
    }
}
