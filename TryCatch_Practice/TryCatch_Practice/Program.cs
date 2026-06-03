namespace TryCatch_Practice
{
    internal class Program
    {

        public static void ParseInput(string input)
        {
            try
            {
                int number = int.Parse(input);
                int result = 100 / number;
            }
            catch (FormatException)
            {
                Console.WriteLine("กรอกตัวเลขเท่านั้น");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("ห้ามหารด้วย 0");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"เกิดข้อผิดพลาด: {ex.Message}");

            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        static void Main(string[] args)
        {
            ParseInput("25");
            ParseInput("abc");
            ParseInput("0");
        }
    }
}
