var machines = new List<Machine>
{
    new() {Name = "CNC-01", Tags = new List<string> { "urgent", "electrical" } },
    new() {Name = "Lathe-02", Tags = new List<string> { "mechanical" } },
    new() {Name = "Drill-03", Tags = new List<string> { "urgent", "hydraulic" } },

};

var allTags = machines.SelectMany(m => m.Tags);
foreach (var tag in allTags)
{
    Console.WriteLine(tag);
}