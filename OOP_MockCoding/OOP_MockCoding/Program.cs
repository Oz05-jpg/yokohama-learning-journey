namespace OOP_MockCoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Machine> machines = new List<Machine>
        {
            new CNCMachine("CNC1", "Active"),
            new ConveyorBelt("Belt-01", "Needs Active")

        };

            foreach (var m in machines)
            {
                m.GetStatus();
                m.PerformMaintenance();

                if (m is IReportable r)
                {
                    r.GenerateReport();
                }
            }
        }
    }
}
