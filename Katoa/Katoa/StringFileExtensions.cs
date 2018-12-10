namespace Katoa
{
    public static class StringFileExtensions
    {
        public static string File(this string filename)
        {
            return System.IO.File.ReadAllText(filename);
        }

        public static string ToFile(this string s, string filename)
        {
            System.IO.File.WriteAllText(filename, s);
            return s;
        }


        public static string[] FileLines(this string filename)
        {
            return System.IO.File.ReadAllLines(filename);
        }


    }
}